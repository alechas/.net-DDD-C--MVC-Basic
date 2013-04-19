using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using iTextSharp.text;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.IO;
//using System.Web.UI;
using System.Net;
using System.Web;
using System.Collections;


namespace Infrastructure.Helper
{
    public class ConvertToPDFHelper
    {
        public string Pdf (string htmlBuilder, string path, string htmlBuilder2)
        {
            //First create a new document object
            Document doc = new Document(PageSize.A3);

            //Create a new pdf writer object, specifying the output stream
            var output = new FileStream(path,FileMode.Create);

            PdfWriter.GetInstance(doc,output);

            //Open the document for writing
            doc.Open();

            //Read in the content of the .html file
            //string contents = File.ReadAllText(path2);

            //Parse the html string into a collection of elements
            var parsedHTMLElements = HTMLWorker.ParseToList(new StringReader(htmlBuilder),null);
            var parsedHTMLElements2 = HTMLWorker.ParseToList(new StringReader(htmlBuilder2), null);
            
            //Enumerate the elements, adding each one to the document
            foreach (var htmlElement in parsedHTMLElements)
            {
                doc.Add((IElement)htmlElement);
            }
            doc.NewPage();
            foreach (var htmlElement in parsedHTMLElements2)
            {
                doc.Add((IElement)htmlElement);
            }

            //Close the documents and save automatically...
            doc.Close();

            ////Membuat file stream pdf
            //Document doc2 = new Document(PageSize.A3);
            //var ms = new MemoryStream();
            //var parsedHTMLElement = HTMLWorker.ParseToList(new StringReader(htmlBuilder), null);
            //var parsedHTMLElement2 = HTMLWorker.ParseToList(new StringReader(htmlBuilder2), null);
            //PdfWriter.GetInstance(doc2, ms);
            //doc2.Open();
            //foreach (var htmlElement in parsedHTMLElement)
            //{
            //    doc2.Add((IElement)htmlElement);
            //}
            //doc2.NewPage();
            //foreach (var htmlElement in parsedHTMLElement2)
            //{
            //    doc2.Add((IElement)htmlElement);
            //}

            ////Close the documents and save automatically...
            //doc2.Close();
            return path;
        }
    }
}