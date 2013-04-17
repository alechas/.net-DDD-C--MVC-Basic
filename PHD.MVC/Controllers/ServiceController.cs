using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using PHD.MVC.Helper;
using System.Web.Services.Protocols;
using PHD.Session.Classes;
using PHD.Service.ModelService;
using NHibernate.Criterion;
using NHibernate;
using System.Text;
using System.Collections;
using System.Text.RegularExpressions;

namespace PHD.MVC.Controllers
{
    public class ServiceController : Controller
    {
        static ArrayList asalKata = new ArrayList();
        static ArrayList singkatan = new ArrayList();
        //
        // GET: /Service/

        public ActionResult Index()
        {
            return View();
        }

     
        public ActionResult Orderan(string outletKode) {
           List<ICriterion> Crit = new List<ICriterion>();
           //status_data=0 and segment=1
            Crit.Add(Restrictions.Eq("shopcode",outletKode));
            Crit.Add(Restrictions.Eq("status_data", "1"));
            Crit.Add(Restrictions.Eq("segment", "1"));
            //List<ICriterion> Crit2 = new List<ICriterion>();
            //status_data=0 and segment=1
           //string sql = 
            string detailTrx = "";
            
           Orderhd Ord = new OrderhdService().FindByCriteria(Crit);
           if (Ord == null) {
               string hql = "from Orderhd where shopcode='" + outletKode + "' and status_data=9 and segment=1 and " +
              "DATEDIFF(MINUTE, getdate(), convert(datetime, date_deliver + ' ' + time_deliver)) <= promise_time";
               Ord = new OrderhdService().FindByHql(hql);
               if (Ord == null) {
                   string hql2 = "from Orderhd where shopcode='" + outletKode + "' and status_data=9 and segment=2 and " +
            "DATEDIFF(MINUTE, getdate(), convert(datetime, date_deliver + ' ' + time_deliver)) <= 30" +
            " order by status_data, id_order";
                   Ord = new OrderhdService().FindByHql(hql2);
               }
           }
           
           if (Ord != null)
           {
               detailTrx = "<xml>";
               string ctitemp = CreateCTITEMPText(Ord);
               detailTrx += CreateFDSText(Ord);
               detailTrx += ctitemp;
               detailTrx += CreateMEMBERText(Ord);
               detailTrx += "</xml>";
           }
           return Content(detailTrx, "application/xhtml+xml");
        }
        
        private string CreateFDSText(Orderhd Ord)
        {
            DateTime tglJamKirim = DateTime.ParseExact(Ord.date_deliver + " " + Ord.time_deliver, "dd-MM-yyyy HH:mm", System.Globalization.CultureInfo.CurrentCulture);
             StringBuilder sb = new StringBuilder();
          //  int i = 0;
           // foreach (Submenu menu in Ord.order.submenus) {
               
                sb.Append("<FDS>");
                sb.Append("100").Append(";");    // ID
                sb.Append(Convert.ToInt32(Ord.order.Id).ToString("00000")).Append(";");  // Number

                sb.Append(Ord.shopcode).Append(";");    // ShopCode
                sb.Append(Ord.zone).Append(";");  // Zone
                //sb.Append(Ord.order.submenus[i].name).Append(";"); //menuname
                sb.Append(Ord.amount.ToString().Replace(",", "")).Append(";"); // Amount
                sb.Append("").Append(";"); // Rider

                sb.Append(tglJamKirim.ToString("yyyy/MM/dd")).Append(";");      // Date

                //sb.Append(DateTime.Now.ToString("HH:mm")).Append(";");  // Time_Call
                sb.Append(tglJamKirim.ToString("HH:mm")).Append(";");  // Time_Call

                sb.Append("").Append(";"); // Time_Out
                if (Ord.segment == "2")
                    sb.Append("").Append(";");                        // Time_Del
                else sb.Append(Ord.time_deliver).Append(";"); // Time_Del
                sb.Append("").Append(";"); // Time_Back
                sb.Append(Ord.segment).Append(";"); // OrderType

                if (Ord.customer.Length > 0 && Ord.customer != "N/A") sb.Append(Ord.customer).Append(";"); // Customer

                sb.Append(Ord.cashier).Append(";"); // Cashier
                sb.Append(Ord.cashier).Append(";"); // LStaff
                sb.Append("E").Append(";"); // Polled
                sb.Append("").Append(";"); // Rev
                sb.Append("F").Append(";"); // Sync
                sb.Append("").Append(";"); // Time_Make
                sb.Append("999").Append(";"); // Handle_ID
                sb.Append("1").Append(";"); // PCount
                sb.Append("T").Append(";"); // PBill
                sb.Append("-1.0").Append(";"); // SC_Rate
                sb.Append("").Append(";"); // Ref0
                sb.Append("").Append(";"); // Ref1
                sb.Append("0").Append(";"); // Deposit
                sb.Append("").Append(";");    // Time_Del2

                sb.Append(Ord.subdata1).Append(";"); // SubData1
                sb.Append(Ord.zone_address).Append(";"); // SubData2
                sb.Append("").Append(";"); // Ref2
                // Timestamp
                sb.Append(DateTime.Now.ToString("yyMMddHHmmss")).Append(";");
                sb.Append("").Append(";"); // Time_RB
                sb.Append(Ord.shopcode).Append(";");    // Org_Shop
                sb.Append(Ord.zone).Append(";");  // Org_Zone

                sb.Append("0").Append(";"); // Location
                sb.Append("F").Append(";"); // LBR
                sb.Append("").Append(";"); // LastTime
                sb.Append("").Append(";"); // SyncDate
                sb.Append("0").Append(";"); // SPFlag
                sb.Append("").Append(";"); // VIP
                sb.Append("").Append(";"); // Ref3
                sb.Append("").Append(";"); // Time_NT
                sb.Append("0").Append(";"); // Addr_ID
                sb.Append("").Append(";"); // SyncID
                sb.Append("").Append(";"); // SubData3
                sb.Append("0").Append(";"); // OSource
                sb.Append("").Append(";"); // SPPhone
                sb.Append("").Append(";"); // DAU1
                sb.Append("").Append(";"); // DAU2

                sb.Append(Ord.zone).Append(";"); // Block
                sb.Append("").Append(";"); // Flat
                sb.Append("").Append(";"); // Floor
                sb.Append("").Append(";"); // Room
                sb.Append("").Append(";"); // Num

                sb.Append("").Append(";"); // Time_OCall
                sb.Append("0").Append(";"); // Time_Min
                sb.Append("").Append(";"); // Time_Mrb
                sb.Append("").Append(";"); // XXRef2
                sb.Append("").Append(";"); // XXRef3
                sb.Append("0").Append(";"); // SOT2
                sb.Append("WEB").Append(Guid.NewGuid().ToString().ToUpper().Substring(0, 7)).Append(";"); // RX
                sb.Append("1").Append(";"); // RY
                sb.Append(""); // CC2Polled
                 sb.Append("</FDS>");
               //  i++;
           // }
           

            return sb.ToString();
        }
        private string CreateMEMBERText(Orderhd ord)
        {
            DateTime tglJamKirim = DateTime.ParseExact(ord.date_deliver + " " + ord.time_deliver, "dd-MM-yyyy HH:mm", System.Globalization.CultureInfo.CurrentCulture);

            StringBuilder sb = new StringBuilder();
            sb.Append("<MEMBER>");

            sb.Append(ord.customer).Append(";");    // Tel
            sb.Append("").Append(";");                    // Code
            sb.Append(ord.shopcode).Append(";");    // Shop
            sb.Append(ord.zone).Append(";");        // Zone
            sb.Append(ord.subdata1).Append(";");    // Name

            sb.Append("0").Append(";"); // CoCount
            sb.Append("").Append(";"); // Sex
            sb.Append("12/30/1899").Append(";"); // DOB
            sb.Append("0").Append(";"); // Age
            sb.Append("").Append(";"); // ID
            sb.Append(ord.email).Append(";"); // Email
            sb.Append("12/30/1899").Append(";"); // SPDate

            sb.Append(ord.zone_district).Append(";");   // District
            sb.Append(ord.zone_address).Append(";");   // Street
            sb.Append(";");   // St_No
            sb.Append("").Append(";");                    // Estate
            sb.Append(ord.zone_city).Append(";");   // Bldg

            sb.Append("").Append(";"); // Block
            sb.Append("").Append(";"); // Flat
            sb.Append("").Append(";"); // Floor
            sb.Append("").Append(";"); // Room
            sb.Append("").Append(";"); // Num
            sb.Append("0.00").Append(";"); // Points
            sb.Append(ord.zone_remark).Append(";"); // Note

            sb.Append("").Append(";"); // Note2
            sb.Append(tglJamKirim.ToString("yyyy/MM/dd")).Append(";"); // First
            sb.Append(tglJamKirim.ToString("yyyy/MM/dd")).Append(";"); // Last
            // Time
            sb.Append(tglJamKirim.ToString("HH:mm")).Append(";");
            sb.Append("").Append(";"); // Status
            sb.Append("").Append(";"); // MemType2
            sb.Append("0.00").Append(";"); // Disc
            sb.Append("F").Append(";"); // Sync
            // Timestamp
            sb.Append(DateTime.Now.ToString("yyMMddHHmmss")).Append(";");
            sb.Append("0").Append(";"); // Status2
            sb.Append("12/30/1899").Append(";"); // ExpDate
            sb.Append("").Append(";"); // Tel2
            sb.Append("0").Append(";"); // AddrID
            sb.Append("").Append(";"); // Lang
            sb.Append("").Append(";"); // Zip
            sb.Append("").Append(";"); // DAU1
            sb.Append(""); // DAU2
            sb.Append("</MEMBER>");

            return sb.ToString();
        }
        private string CreateCTITEMPText(Orderhd ord)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<CTITEMP>");

            string stringRX = string.Concat("WEB", Guid.NewGuid().ToString().ToUpper().Substring(0, 5));
            string delivery = ord.biaya_kirim.ToString();
            int countOrderRow = 0;
            int countOrderSubRow = 0;
            int tambahDetik = 0;
            /*
            SqlConnection conn;
            if (Convert.ToBoolean(ConfigurationManager.AppSettings["isDevelopment"].ToString()))
                conn = new SqlConnection(ConfigurationManager.ConnectionStrings["dev-conn"].ConnectionString);
            else
                conn = new SqlConnection(ConfigurationManager.ConnectionStrings["live-conn"].ConnectionString);

            SqlCommand cmd = new SqlCommand("select * from ph_order_online_dt where number_cc=" + colTrx["number_cc"] + " order by seq, subseq", conn);
            cmd.CommandType = CommandType.Text;

            SqlDataAdapter objDataAdapter = new SqlDataAdapter(cmd);
            DataTable objDataTable = new DataTable();
            
            try
            {
                if (conn.State != ConnectionState.Open) conn.Open();
                objDataAdapter.Fill(objDataTable);
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                return "";
            }
            finally
            { }
            */
            string tax, diskon;
            int jumrec = ord.orderdts.Count;
            //DateTime.ParseExact("20101020", "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture)
           
            DateTime tglJamKirim = DateTime.ParseExact(ord.date_deliver + " " + ord.time_deliver,"dd-MM-yyyy HH:mm", System.Globalization.CultureInfo.CurrentCulture);

            foreach (Orderdt dr in ord.orderdts)
            {
                dr.Bersih();
                countOrderRow = Convert.ToInt32(dr.seq.ToString());
                //countOrderSubRow = 0;
                countOrderSubRow = Convert.ToInt16(dr.subseq);

                sb.Append("100").Append(";");    // ID
                sb.Append(Convert.ToInt32(ord.order.Id).ToString("00000")).Append(";");  // Number
                sb.Append("@").Append(";");    // Group
                sb.Append(countOrderRow).Append(";");  // Seq
                sb.Append(countOrderSubRow).Append(";");  // SubSeq
                sb.Append("0").Append(";");  // XRef
                sb.Append("").Append(";");  // TN

                if (countOrderSubRow > 0)
                {
                    sb.Append("Z").Append(dr.fcode.ToString()).Append(";");  // FCode
                    sb.Append("0").Append(";");   // SubCode
                }
                else
                {
                    sb.Append(dr.fcode.ToString()).Append(";");              // FCode
                    sb.Append("").Append(";");                                  // SubCode
                }

                sb.Append(Dipersingkat(dr.desc1.ToString())).Append(";");  // Desc1
                sb.Append(Dipersingkat(dr.desc1.ToString())).Append(";");  // Desc2

                //if (countOrderSubRow > 0)
                //  sb.Append("1").Append(";");                                 // Qty
                //else sb.Append(dr["qty"].ToString()).Append(";");             // Qty
                sb.Append(dr.qty.ToString()).Append(";");             // Qty

                sb.Append(dr.unitprice.ToString()).Append(";");            // UnitPrice

                //sb.Append(DateTime.Today.ToString("yyyy/MM/dd")).Append(";"); // Date
                sb.Append(tglJamKirim.ToString("yyyy/MM/dd")).Append(";");      // Date

                if (countOrderSubRow > 0)
                    sb.Append(tglJamKirim.AddSeconds(++tambahDetik).ToString("HH:mm:ss")).Append(";");   // Time
                else sb.Append(tglJamKirim.AddSeconds(tambahDetik).ToString("HH:mm:ss")).Append(";");  // Time

                sb.Append(ord.segment).Append(";"); // OrderType
                sb.Append("K1").Append(";"); // K1
                sb.Append(ord.cashier).Append(";"); // Cashier
                sb.Append("F").Append(";"); // Sync
                sb.Append("0").Append(";"); // Level
                sb.Append("0").Append(";"); // Tax1
                sb.Append("0").Append(";"); // Tax2
                sb.Append("0").Append(";"); // Tax3

                if (dr.t_able.ToString() == "1") tax = "T"; else tax = "F";
                sb.Append(tax).Append(";"); // T_Able

                if (dr.t_able.ToString() == "1") diskon = "T"; else diskon = "F";
                sb.Append(diskon).Append(";"); // D_Able

                sb.Append("T").Append(";"); // SC_Able
                sb.Append("").Append(";"); // Remark
                sb.Append("F").Append(";"); // Tomain
                sb.Append("").Append(";"); // SplitGroup
                sb.Append("0.00").Append(";"); // Points

                sb.Append(dr.fgroup.ToString()).Append(";");      // FGroup

                sb.Append("0").Append(";"); // Tax_Group
                sb.Append("0").Append(";"); // DCode
                sb.Append("999").Append(";"); // Handle_ID
                sb.Append("").Append(";"); // XXRef1
                sb.Append("0").Append(";"); // ISeat
                sb.Append("0").Append(";"); // IXRewards
                sb.Append("0").Append(";"); // IXRewardRD
                sb.Append("0").Append(";"); // IRDRequire
                sb.Append("").Append(";"); // SyncID
                sb.Append(stringRX).Append(Guid.NewGuid().ToString().ToUpper().Substring(0, 2)).Append(";"); // RX
                sb.Append("\\n");
            }

            /*** Add Payment ***/
            string paymentItemName = string.Empty;
            string paymentItemValue = string.Empty;
            long subTotal = Convert.ToInt64(ord.amount);

            sb.Append("100").Append(";");    // ID
            sb.Append(Convert.ToInt32(ord.order.Id).ToString("00000")).Append(";");  // Number
            sb.Append("@").Append(";");    // Group
            sb.Append(countOrderRow).Append(";");		//Seq

            //if (countOrderSubRow == 0) sb.Append(countOrderSubRow + 1).Append(";");  // SubSeq
            //else sb.Append(countOrderSubRow).Append(";");  // SubSeq
            sb.Append(countOrderSubRow + 1).Append(";");  // SubSeq

            sb.Append("0").Append(";");  // XRef
            sb.Append("").Append(";");  // TN

            sb.Append("ZGA02").Append(";");

            sb.Append("0").Append(";");  // SubCode
            string jnsbayar = ord.payment_type.name;
            sb.Append(jnsbayar).Append(";");  // Desc1
            sb.Append(jnsbayar).Append(";");  // Desc2

            sb.Append("1").Append(";");  // Qty
            sb.Append("0").Append(";");  // UnitPrice

            //sb.Append(DateTime.Today.ToString("yyyy/MM/dd")).Append(";"); // Date
            sb.Append(tglJamKirim.ToString("yyyy/MM/dd")).Append(";");      // Date

            // Time
            sb.Append(tglJamKirim.AddSeconds(++tambahDetik).ToString("HH:mm:ss")).Append(";");

            sb.Append(ord.segment).Append(";"); // OrderType
            sb.Append("K1").Append(";"); // K1
            sb.Append(ord.cashier).Append(";"); // Cashier
            sb.Append("F").Append(";"); // Sync
            sb.Append("0").Append(";"); // Level
            sb.Append("").Append(";"); // Tax1
            sb.Append("").Append(";"); // Tax2
            sb.Append("").Append(";"); // Tax3
            sb.Append("").Append(";"); // T_Able
            sb.Append("").Append(";"); // D_Able
            sb.Append("").Append(";"); // SC_Able
            sb.Append("").Append(";"); // Remark
            sb.Append("F").Append(";"); // Tomain
            sb.Append("").Append(";"); // SplitGroup
            sb.Append("0.00").Append(";"); // Points
            sb.Append("14").Append(";"); // FGroup
            sb.Append("").Append(";"); // Tax_Group
            sb.Append("0").Append(";"); // DCode
            sb.Append("999").Append(";"); // Handle_ID
            sb.Append("").Append(";"); // XXRef1
            sb.Append("0").Append(";"); // ISeat
            sb.Append("0").Append(";"); // IXRewards
            sb.Append("0").Append(";"); // IXRewardRD
            sb.Append("0").Append(";"); // IRDRequire
            sb.Append("0").Append(";"); // SyncID
            sb.Append(stringRX).Append(Guid.NewGuid().ToString().ToUpper().Substring(0, 2)).Append(";"); // RX
            sb.Append("\\n");
            //-------------------- Payment ------------------------


            /*** Add Delivery Fee ***/
            if (ord.segment == "1")
            {
                sb.Append("100").Append(";");    // ID
                sb.Append(Convert.ToInt32(ord.order.Id).ToString("00000")).Append(";");  // Number
                sb.Append("@").Append(";");    // Group
                sb.Append(++countOrderRow).Append(";");  // Seq
                sb.Append("0").Append(";");  // SubSeq
                sb.Append("0").Append(";");  // XRef
                sb.Append("").Append(";");  // TN
                sb.Append("YA010").Append(";");  // FCode
                sb.Append("").Append(";");  // SubCode
                sb.Append("Delivery Cost").Append(";");  // Desc1
                sb.Append("Delivery Cost").Append(";");  // Desc2
                sb.Append("1").Append(";");  // Qty
                sb.Append(delivery).Append(";");  // UnitPrice/ Delivery Cost
                sb.Append(tglJamKirim.ToString("yyyy/MM/dd")).Append(";");  // Date

                // Time
                sb.Append(tglJamKirim.AddSeconds(++tambahDetik).ToString("HH:mm:ss")).Append(";");

                sb.Append(ord.segment).Append(";"); // OrderType
                sb.Append("").Append(";"); // K1
                sb.Append(ord.cashier).Append(";"); // Cashier
                sb.Append("F").Append(";"); // Sync
                sb.Append("0").Append(";"); // Level
                sb.Append("0").Append(";"); // Tax1
                sb.Append("0").Append(";"); // Tax2
                sb.Append("0").Append(";"); // Tax3
                sb.Append("T").Append(";"); // T_Able
                sb.Append("T").Append(";"); // D_Able
                sb.Append("T").Append(";"); // SC_Able
                sb.Append("").Append(";"); // Remark
                sb.Append("F").Append(";"); // Tomain
                sb.Append("").Append(";"); // SplitGroup
                sb.Append("0.00").Append(";"); // Points
                sb.Append("").Append(";"); // FGroup
                sb.Append("0").Append(";"); // Tax_Group
                sb.Append("0").Append(";"); // DCode
                sb.Append("999").Append(";"); // Handle_ID
                sb.Append("").Append(";"); // XXRef1
                sb.Append("0").Append(";"); // ISeat
                sb.Append("0").Append(";"); // IXRewards
                sb.Append("0").Append(";"); // IXRewardRD
                sb.Append("0").Append(";"); // IRDRequire
                sb.Append("").Append(";"); // SyncID
                sb.Append(stringRX).Append(Guid.NewGuid().ToString().ToUpper().Substring(0, 2)).Append(";"); // RX
                sb.Append("\\n");
            }
            //************************************************************************************************


            /*** Tambah Diskon Tipe Bayar ***/
            if (dapatDiskon(ord))
            {
                sb.Append("100").Append(";");    // ID
                sb.Append(Convert.ToInt32(ord.order.Id).ToString("00000")).Append(";");  // Number
                sb.Append("@").Append(";");    // Group
                sb.Append("0").Append(";"); // Seq
                sb.Append("1").Append(";");  // SubSeq
                sb.Append("0").Append(";");  // XRef
                sb.Append("").Append(";");  // TN

//                if (ord.payment_type.Id.ToString() == "4") sb.Append("423").Append(";");      // FCode bca 
//                else if (ord.payment_type.Id.ToString() == "7") sb.Append("416").Append(";"); // FCode mandiri

                if (ord.payment_type.Id.ToString() == "13" || ord.payment_type.Id.ToString() == "7") sb.Append("423").Append(";");      // FCode bca 
                else if (ord.payment_type.Id.ToString() == "14" || ord.payment_type.Id.ToString() == "6") sb.Append("416").Append(";"); // FCode mandiri



                sb.Append("").Append(";");  // SubCode
                sb.Append("").Append(";");  // Desc1
                sb.Append("").Append(";");  // Desc2
                sb.Append("1").Append(";");  // Qty
                sb.Append("15").Append(";");  // UnitPrice
                sb.Append(tglJamKirim.ToString("yyyy/MM/dd")).Append(";");  // Date

                // Time
                sb.Append(tglJamKirim.AddSeconds(++tambahDetik).ToString("HH:mm:ss")).Append(";");

                sb.Append("").Append(";"); // OrderType
                sb.Append("").Append(";"); // K1
                sb.Append(ord.cashier).Append(";"); // Cashier
                sb.Append("F").Append(";"); // Sync
                sb.Append("").Append(";"); // Level
                sb.Append("").Append(";"); // Tax1
                sb.Append("").Append(";"); // Tax2
                sb.Append("").Append(";"); // Tax3
                sb.Append("").Append(";"); // T_Able
                sb.Append("").Append(";"); // D_Able
                sb.Append("").Append(";"); // SC_Able
                sb.Append("").Append(";"); // Remark
                sb.Append("").Append(";"); // Tomain
                sb.Append("").Append(";"); // SplitGroup
                sb.Append("0.00").Append(";"); // Points
                sb.Append("").Append(";"); // FGroup
                sb.Append("").Append(";"); // Tax_Group
                sb.Append("").Append(";"); // DCode
                sb.Append("999").Append(";"); // Handle_ID
                sb.Append("").Append(";"); // XXRef1
                sb.Append("").Append(";"); // ISeat
                sb.Append("").Append(";"); // IXRewards
                sb.Append("").Append(";"); // IXRewardRD
                sb.Append("").Append(";"); // IRDRequire
                sb.Append("").Append(";"); // SyncID
                sb.Append(stringRX).Append(Guid.NewGuid().ToString().ToUpper().Substring(0, 2)).Append(";"); // RX
            }
           // conn.Close();

            sb.Append("</CTITEMP>");

            return sb.ToString();
        }
        private bool dapatDiskon(Orderhd ord)
        {
            bool dapat = false;
            Int32 amount = Convert.ToInt32(ord.amount);
            // yng awal if (ord.payment_type.Id.ToString()== "4")
            if (ord.payment_type.Id.ToString() == "13" || ord.payment_type.Id.ToString() == "7") //bca
            {
                 List<ICriterion> Crit = new List<ICriterion>();
               //status_data=0 and segment=1
                Crit.Add(Restrictions.Eq("name","diskonbca"));

                string[] settingBCA = new ConfigsService().FindByCriteria(Crit).value.Split(';');
                //string[] settingBCA = bacaRecord("select value from Configs where name='diskonbca'", "").Split(';');
                byte persen = Convert.ToByte(settingBCA[0]);
                Int32 minimal = Convert.ToInt32(settingBCA[1]);
                if (amount >= minimal) return dapat;

                string[] hari = settingBCA[2].Split(',');
                for (int i = 0; i < hari.Length; i++)
                {
                    if (hari[i] == Convert.ToInt16(DateTime.Now.DayOfWeek).ToString())
                    {
                        dapat = true;
                        return dapat;
                    }
                }
            }
            //yg awal else if (ord.payment_type.Id.ToString() == "7")
            else if(ord.payment_type.Id.ToString() == "6" || ord.payment_type.Id.ToString() == "14")//mandiri
            {
                List<ICriterion> Crit = new List<ICriterion>();
                //status_data=0 and segment=1
                Crit.Add(Restrictions.Eq("name", "diskonmandiri"));

                string[] settingMandiri = new ConfigsService().FindByCriteria(Crit).value.Split(';');
                
                
                byte persen = Convert.ToByte(settingMandiri[0]);
                Int32 minimal = Convert.ToInt32(settingMandiri[1]);
                if (amount >= minimal) return dapat;

                string[] hari = settingMandiri[2].Split(',');
                for (int i = 0; i < hari.Length; i++)
                {
                    if (hari[i] == Convert.ToInt16(DateTime.Now.DayOfWeek).ToString())
                    {
                        dapat = true;
                        return dapat;
                    }
                }
            }

            return dapat;
        }
        private string Dipersingkat(string detailTransaksi)
        {
            byte panjangMaks = 23;

            detailTransaksi = detailTransaksi.Replace("  ", " ").Replace(" + ", "+").Trim();

            if (detailTransaksi.Length <= panjangMaks) return detailTransaksi;

            for (int i = 0; i < asalKata.Count; i++)
            {
                var regex = new Regex(asalKata[i].ToString(), RegexOptions.IgnoreCase);
                var hasil = regex.Replace(detailTransaksi, singkatan[i].ToString());

                if (hasil == detailTransaksi)
                    detailTransaksi = detailTransaksi.Replace(asalKata[i].ToString(), singkatan[i].ToString());
                else
                    detailTransaksi = hasil;

                if (detailTransaksi.Length <= panjangMaks) break;
            }
            return detailTransaksi;
        }

        public ActionResult UpdateStatus(int id, string status)
        {
            string temp = "";
           
            /*if (Convert.ToBoolean(ConfigurationManager.AppSettings["isDevelopment"].ToString()))
                conn = new SqlConnection(ConfigurationManager.ConnectionStrings["dev-conn"].ConnectionString);
            else
                conn = new SqlConnection(ConfigurationManager.ConnectionStrings["live-conn"].ConnectionString);

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Update ph_order_online_hd set status_data='" + status + "', lup = getdate() " +
              " where number = " + id + " and shopcode='" + kodeoutlet + "' and status_data <> '" + status +
              "' and convert(date,date_deliver) = convert(date,getdate())";
            */
            try
            {
                List<ICriterion> Crit = new List<ICriterion>();
                //status_data=0 and segment=1

                Crit.Add(Restrictions.Eq("order.Id", id));
                Orderhd Ord = new OrderhdService().FindByCriteria(Crit);
                List<ICriterion> Crit2 = new List<ICriterion>();
                Crit2.Add(Restrictions.Eq("Id",id));
                Ord.status_data = status.ToString();
                Ord.lup = DateTime.Now;
             
                Ord.Save();
              
                Ordercust Ordcust = new OrdercustService().FindByCriteria(Crit2);
                if (Ordcust.status.Id < Convert.ToInt32(status) && Ordcust.status.Id>3)
                {
                    Ordcust.status = new StatusorderService().FindBy(int.Parse(status));
                    if (status == "5")
                    {
                        Ordcust.confirmed_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                    }
                    else if (status == "7")
                    {
                        Ordcust.cooking_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                    }
                    else if (status == "8") {
                        Ordcust.start_delivery_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                    }
              
                    if (Ordcust.status.Id>5&&Ordcust.confirmed_time != null && Ordcust.confirmed_time != "")
                    {
                        IFormatProvider theCultureInfo = new System.Globalization.CultureInfo("en-GB", true);
                        string format = "dd/MM/yyyy HH:mm:ss";
                        Ordcust.confirmed_time = DateTime.ParseExact(Ordcust.confirmed_time, format, theCultureInfo).ToString("yyyy-MM-dd HH:mm");
                        //model.delivery_time = DateTime.Parse(Request.Form["delivery_date"] + " " + Request.Form["delivery_time"]);
                    }
                    if (Ordcust.status.Id>7&&Ordcust.cooking_time != null && Ordcust.cooking_time != "")
                    {
                        IFormatProvider theCultureInfo = new System.Globalization.CultureInfo("en-GB", true);
                        string format = "dd/MM/yyyy HH:mm:ss";
                        Ordcust.cooking_time = DateTime.ParseExact(Ordcust.cooking_time, format, theCultureInfo).ToString("yyyy-MM-dd HH:mm");
                        //model.delivery_time = DateTime.Parse(Request.Form["delivery_date"] + " " + Request.Form["delivery_time"]);
                    }
                    if (Ordcust.status.Id>8&&Ordcust.start_delivery_time != null && Ordcust.start_delivery_time != "")
                    {
                        IFormatProvider theCultureInfo = new System.Globalization.CultureInfo("en-GB", true);
                        string format = "dd/MM/yyyy HH:mm:ss";
                        Ordcust.start_delivery_time = DateTime.ParseExact(Ordcust.start_delivery_time, format, theCultureInfo).ToString("yyyy-MM-dd HH:mm");
                        //model.delivery_time = DateTime.Parse(Request.Form["delivery_date"] + " " + Request.Form["delivery_time"]);
                    }
                    Ordcust.Save();
                    
   
                }
                return Content("success");
            }
            catch (Exception e){
               return Content("failed("+e.Message+")");
            }
          
        }


        /*
        [HttpPost]
        public ActionResult Orderan(SoapMessage Message)
        {
            object ret = Message.GetInParameterValue(0);
            
            XElement root = new XElement("root");

            return new XmlResultHelper(root);
        }*/

    }

}
