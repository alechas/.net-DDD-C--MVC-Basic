using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using OfficeOpenXml;
using Microsoft.Win32;

namespace PHD.Infrastructure.Helper
{
    public class ReadExcelHelper
    {
        //Filter file yang akan diambil        
        public string GetMiMeType(FileInfo fileInfo)
        {
            string mimeType = "application/vnd.ms-excel";

            RegistryKey regKey = Registry.ClassesRoot.OpenSubKey(
                fileInfo.Extension.ToLower()
                );

            if (regKey != null)
            {
                object contentType = regKey.GetValue("Content Type");

                if (contentType != null)
                {
                    mimeType = contentType.ToString();
                }
            }
            return mimeType;
        }

        //Buat string untuk memproses file yang dikirim HttpPosttedFileBase

        public IList<dataData> Excel(string namafile, string folder)
        {
            
            string filePath = Path.Combine(folder, namafile);
            var file = new FileInfo(filePath);

            //Buat list untuk menampung data2 excel
            IList<dataData> dataExcel = new List<dataData>();

            //deklarasi variabel untuk pesan error
            //string errColumn = "";

            //Baca file excel yang telah diupload
            using (var paket = new ExcelPackage(file))
            {
                ExcelWorkbook workbook = paket.Workbook;
                ExcelWorksheet worksheet = workbook.Worksheets.First();
                object type = worksheet.Cells[11, 4].Value.ToString();
                int p = 0;
                for (int i = 17; i <= worksheet.Dimension.End.Row; i++)
                {
                    object col1 = worksheet.Cells[i, 1].Value == null ? "" : worksheet.Cells[i, 1].Value;
                    object col2 = worksheet.Cells[i, 2].Value == null ? "" : worksheet.Cells[i, 2].Value;
                    object col3 = worksheet.Cells[i, 3].Value == null ? "" : worksheet.Cells[i, 3].Value;
                    object col4 = worksheet.Cells[i, 4].Value == null ? "" : worksheet.Cells[i, 4].Value;
                    object col5 = worksheet.Cells[i, 5].Value == null ? "" : worksheet.Cells[i, 5].Value;
                    object col6 = worksheet.Cells[i, 6].Value == null ? "" : worksheet.Cells[i, 6].Value;
                    object col7 = worksheet.Cells[i, 7].Value == null ? "" : worksheet.Cells[i, 7].Value;
                    object col8 = worksheet.Cells[i, 8].Value == null ? "" : worksheet.Cells[i, 8].Value;
                    object col9 = worksheet.Cells[i, 9].Value == null ? "" : worksheet.Cells[i, 9].Value;
                    object col10 = worksheet.Cells[i, 10].Value == null ? "" : worksheet.Cells[i, 10].Value;
                    object col11 = worksheet.Cells[i, 11].Value == null ? "" : worksheet.Cells[i, 11].Value;
                    object col12 = worksheet.Cells[i, 12].Value == null ? "" : worksheet.Cells[i, 12].Value;
                    object col13 = worksheet.Cells[i, 13].Value == null ? "" : worksheet.Cells[i, 13].Value;
                    object col14 = worksheet.Cells[i, 14].Value == null ? "" : worksheet.Cells[i, 14].Value;
                    object col15 = worksheet.Cells[i, 15].Value == null ? "" : worksheet.Cells[i, 15].Value;
                    object col16 = worksheet.Cells[i, 16].Value == null ? Convert.ToDouble(0).ToString() : worksheet.Cells[i, 16].Value;
                    object col17 = worksheet.Cells[i, 17].Value == null ? "" : worksheet.Cells[i, 17].Value;
                    object col18 = worksheet.Cells[i, 18].Value == null ? "" : worksheet.Cells[i, 18].Value;
                    object col19 = worksheet.Cells[i, 19].Value == null ? "" : worksheet.Cells[i, 19].Value;
                   
                    //Jika row pada excel terisi semua, akan dimasukkan kedalam list
                    if ((col1 != null) && (col2 != null) && (col3 != null) && (col4 != null) && (col5 != null) && (col6 != null) && (col7 != null) && (col8 != null) && (col9 != null) && (col10 != null) && (col11 != null) && (col12 != null) && (col13 != null) && (col14 != null) && (col15 != null) && (col16 != null) && (col17 != null) && (col18 != null) && (col19 != null))
                    {
                        try
                        {

                            dataExcel.Add(new dataData { receiverNo = Convert.ToInt32(col1), interface_type = type.ToString(), receiverCompanyName = col2.ToString(), receiverInterfaceContact = col3.ToString(), receiverRIEName = col4.ToString(), receiverRIEDiscipline = col5.ToString(), supplierCompanyName = col6.ToString(), supplierInterfaceContact = col7.ToString(), supplierRIEName = col8.ToString(), supplierRIEDiscipline = col9.ToString(), worksRMTNo = col10.ToString(), worksRMTTitle = col11.ToString(), ITIDNo = col12.ToString(), ITTitle = col13.ToString(), ITShortDescription = col14.ToString(), ReqIntInfoAndDeliverable = col15.ToString(), needDate = col16.ToString(), critical = col17.ToString(), WITP = col18.ToString(), status = col19.ToString() });
                            p = 0;
                        }
                        catch {
                            p++;
                            if (p > 2) {
                                break;
                            }
                        
                        }
                    }

                    //Jika ada yang kosong pada salah satu kolom, maka akan di throw exception
                    /*
                    else
                    {   //append
                        errColumn += i.ToString();                        
                    }
                    */
                }

                /*
                if (errColumn != "")
                {
                    throw (new ReadExcelException(errColumn));
                }
                */
                return dataExcel;
            }

        }

        //buat kelas untuk throw exception
        /*
        public class ReadExcelException : Exception {
            public string message;
            public ReadExcelException(string error)
            {
                message = "There is an error in row "+ error;
            }          
        
        }
         */

        //Buat kelas untuk menampung data excel sementara untuk dimasukkan kedalam list
        

    }
    public class dataData
    {
        
        public virtual int receiverNo { get; set; }
        public virtual string interface_type { get; set; }
        public virtual string receiverCompanyName { get; set; }
        public virtual string receiverInterfaceContact { get; set; }
        public virtual string receiverRIEName { get; set; }
        public virtual string receiverRIEDiscipline { get; set; }
        public virtual string supplierCompanyName { get; set; }
        public virtual string supplierInterfaceContact { get; set; }
        public virtual string supplierRIEName { get; set; }
        public virtual string supplierRIEDiscipline { get; set; }
        public virtual string worksRMTNo { get; set; }
        public virtual string worksRMTTitle { get; set; }
        public virtual string ITIDNo { get; set; }
        public virtual string ITTitle { get; set; }
        public virtual string ITShortDescription { get; set; }
        public virtual string ReqIntInfoAndDeliverable { get; set; }
        public virtual string needDate { get; set; }
        public virtual string critical { get; set; }
        public virtual string WITP { get; set; }
        public virtual string status { get; set; }
        
        public override string ToString()
        {
            string tampil = "<table border='1'>";
            tampil = tampil + "<tr><td>" + receiverNo + "</td><td>" + receiverCompanyName + "</td><td>" + receiverInterfaceContact + "</td><td>" + receiverRIEName + "</td><td>" + receiverRIEDiscipline + "</td><td>" + supplierCompanyName + "</td><td>" + supplierInterfaceContact + "</td><td>" + supplierRIEName + "</td><td>" + supplierRIEDiscipline + "</td><td>" + worksRMTNo + "</td><td>" + worksRMTTitle + "</td><td>" + ITIDNo + "</td><td>" + ITTitle + "</td><td>" + ITShortDescription + "</td><td>" + ReqIntInfoAndDeliverable + "</td><td>" + needDate + "</td><td>" + critical + "</td><td>" + WITP + "</td><td>" + status + "</td></tr></table>";
            return tampil;
        }
    }
}