
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PHD.Session.Classes;
using PHD.Service.ModelService;
using PHD.MVC.Helper;
using System.Configuration;
using System.Web.Security;
using System.Xml;
namespace PHD.MVC.Controllers
{
    public class TransactionController : Controller
    {
        //
        // GET: /Transaction/

        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Mandiri(int idcust) {

            ViewBag.message = "";
            Ordercust ord = new OrdercustService().FindBy(idcust);
            if (!User.Identity.IsAuthenticated || ord.status.Id!=1)
            {
                return RedirectToAction("logon", "account");
            }
            return View(ord);
        }
        [HttpPost]
        public ActionResult Mandiri(int idcust, FormCollection col) {

            Ordercust ord = new OrdercustService().FindBy(idcust);
            if (!User.Identity.IsAuthenticated || ord.status.Id != 1)
            {
                return RedirectToAction("logon", "account");
            }
            String cardNo = col["noKartu"];
            string responToken = col["respToken"];
            string waktu = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString("00") + DateTime.Now.Day.ToString("00") +
              DateTime.Now.Hour.ToString("00") + DateTime.Now.Minute.ToString("00") + DateTime.Now.Second.ToString("00");
           // string itemName = "pesanan PHD";
            string data1 = new StringHelper().GetLast(cardNo, 10);
            string postData = "<payment_request> <user_id>user</user_id>" +
              "<password>pwd</password>" +
              "<card_no>" + cardNo + "</card_no> " +
              "<amount>" + ord.total_price + "</amount>" +
              "<transaction_id>" + ord.Id + "</transaction_id>" +
              "<data_field1>" + data1 + "</data_field1> " +
              "<data_field2>" + ord.total_price+ "</data_field2>" +
              "<data_field3>" + ord.Id + "</data_field3>" +
              "<token_response>" + responToken + "</token_response> " +
              "<date_time>" + waktu + "</date_time>" +
              "<bank_id>1</bank_id>" +
              "<items count=\"1\"> " +
                "<item no=\"1\" name=\"" + ord.payment.name + "\" price=\"" + ord.total_price + "\" qty=\"1\" />" +
              "</items> </payment_request>";

            XmlDocument response = new CommHelper().kirimDataXML(postData);
             XmlNode root = response.DocumentElement;
             int jumlah = root.ChildNodes.Count;
             string temp = root.SelectSingleNode("response_code").ChildNodes[0].Value;
             if (root.SelectSingleNode("response_code").ChildNodes[0].Value == "0000")
            {
                ord.status = new StatusorderService().FindBy(2);
                ord.Save();

                ViewBag.message = "sukses";
             //suksess
            }
            else
            {
                ViewBag.message = "gagal";
                //gagal
            }
            return View(ord);
        }

        public ActionResult Infinitium(int idcust) {
            Ordercust ord = new OrdercustService().FindBy(idcust);
           

            if (!User.Identity.IsAuthenticated || ord.status.Id != 1)
            {
                return RedirectToAction("logon", "account");
            }
            Dictionary<string, string> Datum = new Dictionary<string, string>();
            Datum["MERCHANT_TRANID"] = ord.Id + "_" + DateTime.Now.Hour.ToString("00") +
              DateTime.Now.Minute.ToString("00") + DateTime.Now.Second.ToString("00");
            Datum["AMOUNT"] = ord.total_price + ".00";

            Datum["CUSTNAME"] = ord.user.nama;
            Datum["CUSTEMAIL"] = ord.user.email;
            Datum["SHOPPER_IP"] = ConfigurationManager.AppSettings["shopperIP"].ToString();
            Datum["INFINITIUM"] = ConfigurationManager.AppSettings["urlInfitium"].ToString();
            Datum["MERCHANTID"] = ConfigurationManager.AppSettings["merchantId"].ToString();
            Datum["TXN_PASSWORD"] = ConfigurationManager.AppSettings["TXN_PASSWORD"].ToString();
            Datum["SIGNATURE"] = FormsAuthentication.HashPasswordForStoringInConfigFile("##" + Datum["MERCHANTID"].ToUpper() + "##"
              + Datum["TXN_PASSWORD"].ToUpper() + "##" + Datum["MERCHANT_TRANID"].ToUpper() + "##" + Datum["AMOUNT"].ToUpper() + "##0##", "SHA1");
           
            string host = Request.Url.Host;


            Datum["RETURN_URL"] = "http://"+host+"/Transaction/InfitiumResult?idcust=" + ord.Id;
            ViewBag.data = Datum;
       
            if (!User.Identity.IsAuthenticated || ord.status.Id != 1)
            {
                return RedirectToAction("logon", "account");
            }
            return View(ord);
        }

        [HttpPost]
        public ActionResult Infinitium(int idcust, FormCollection col)
        {
            Ordercust ord = new OrdercustService().FindBy(idcust);

            if (!User.Identity.IsAuthenticated || ord.status.Id != 1)
            {
                return RedirectToAction("logon", "account");
            }
            Dictionary<string, string> Datum = new Dictionary<string, string>();
            Datum["MERCHANT_TRANID"] = ord.Id + "_" + DateTime.Now.Hour.ToString("00") +
              DateTime.Now.Minute.ToString("00") + DateTime.Now.Second.ToString("00");
            Datum["AMOUNT"] = ord.total_price + ".00";
            
            Datum["CUSTNAME"] = ord.user.nama;
            Datum["CUSTEMAIL"] = ord.user.email;
            Datum["SHOPPER_IP"] = ConfigurationManager.AppSettings["shopperIP"].ToString();
            Datum["INFINITIUM"] = ConfigurationManager.AppSettings["urlInfitium"].ToString();
            Datum["MERCHANTID"] = ConfigurationManager.AppSettings["merchantId"].ToString();
            Datum["TXN_PASSWORD"] = ConfigurationManager.AppSettings["TXN_PASSWORD"].ToString();
            Datum["SIGNATURE"] = FormsAuthentication.HashPasswordForStoringInConfigFile("##" + Datum["MERCHANTID"].ToUpper() + "##"
              + Datum["TXN_PASSWORD"].ToUpper() + "##" + Datum["MERCHANT_TRANID"].ToUpper() + "##" + Datum["AMOUNT"].ToUpper() + "##0##", "SHA1");
            string host = Request.Url.Host;

            Datum["RETURN_URL"] = "http://"+host+"/Transaction/InfitiumResult?idcust="+ord.Id;
            ViewBag.data = Datum;
            return View(ord);
        }

        /*[HttpPost]
        public ActionResult Infinitium(int idcust, FormCollection col)
        {
            Ordercust ord = new OrdercustService().FindBy(idcust);
            
           
            return View(ord);
        }
        */
        [HttpPost,ValidateInput(false)]
        public ActionResult InfitiumResult(int idcust, FormCollection col) {
            Ordercust ord = new OrdercustService().FindBy(idcust);
            string status;
            try
            {
                if (!string.IsNullOrEmpty(col["TXN_STATUS"]))
                {
                    status = col["TXN_STATUS"];
                    //insert payment

                    if (status == "A" || status == "S")
                    {
                        string id = col["MERCHANT_TRANID"].Substring(0, 5);
                        //update success
                        ord.status = new StatusorderService().FindBy(2);
                        ord.Save();
                        Session["InfinitiumOK"] = "yes";
                        ViewBag.message = "success";
                    }
                    else
                    {
                        string id = col["MERCHANT_TRANID"].Substring(0, 5);
                        //update failed

                        Session["InfinitiumGagal"] = "yes";
                        //SendEmailPaymentGagal(id);
                        ViewBag.message = "gagal";
                    }
                }
            }
            catch (Exception e)
            {
                ViewBag.message = e.Message;
            }
            ViewBag.idcust = idcust;
            return View();
        }
    }
}
