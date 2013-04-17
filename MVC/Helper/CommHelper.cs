using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.IO;
using System.Configuration;
using System.Text;
using System.Xml;

namespace PHD.MVC.Helper
{
    public class CommHelper
    {
        public XmlDocument kirimDataXML(string sXML)
        {
            string url = ConfigurationManager.AppSettings["urlMandiri"];
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);

            byte[] requestBytes = System.Text.Encoding.ASCII.GetBytes(sXML);
            req.Method = "POST";
            req.ContentType = "text/xml";
            req.ContentLength = requestBytes.Length;

            Stream requestStream = req.GetRequestStream();
            requestStream.Write(requestBytes, 0, requestBytes.Length);
            requestStream.Close();

            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            StreamReader sr = new StreamReader(res.GetResponseStream(), System.Text.Encoding.Default);
            string respon = sr.ReadToEnd();

            sr.Close();
            res.Close();
            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml(respon);
            return xdoc;
        }
        public string kirimDataArray(Dictionary<string,string> Datum) {
            WebRequest request = WebRequest.Create(ConfigurationManager.AppSettings["urlInfitium"]);
            request.Method = "POST";
            StringBuilder b = new StringBuilder();
            foreach (KeyValuePair<string, string> data in Datum)
            {
                b.Append(HttpUtility.UrlEncode(data.Key)).Append("=").Append(HttpUtility.UrlEncode(data.Value ?? "")).Append("&");
            }
            string postData = b.ToString(0, b.Length - 1);
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;

            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

            WebResponse response = request.GetResponse();
            
            return response.GetResponseStream().ToString();
        }
    }
}