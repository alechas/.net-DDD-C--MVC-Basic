using System.Web.Mvc;
using System.Xml.Serialization;

namespace PHD.MVC.Helper
{
    public class XmlResultHelper : ActionResult
    {
        private object _objectToSerialize;

        public XmlResultHelper(object objectToSerialize)
        {
            _objectToSerialize = objectToSerialize;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            if (_objectToSerialize != null)
            {
                var xs = new XmlSerializer(_objectToSerialize.GetType());
                context.HttpContext.Response.ContentType = "text/xml";
                xs.Serialize(context.HttpContext.Response.Output, _objectToSerialize);
            }
        }
    }
}