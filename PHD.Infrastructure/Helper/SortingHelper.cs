using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Routing;
using System.Web;

using System.Web.Mvc;


namespace PHD.Infrastructure.Helper
{
    public static class SortingHelper 
    {
        public static string SortableColumn(this HtmlHelper htmlHelper, string linkText, string columnName, object routeValues)
        {
            //automatically determine the current action
            System.Web.Routing.RouteData data = htmlHelper.ViewContext.Controller.ControllerContext.RouteData;
            string actionName = data.GetRequiredString("action");

            StringBuilder sb = new StringBuilder();
            var vals = new RouteValueDictionary(routeValues);

            string sidx = String.Empty;
            if (System.Web.HttpContext.Current.Request["sidx"] != null)
            {
                sidx = System.Web.HttpContext.Current.Request["sidx"].ToString();
            }

            //modify the sidx
            if (vals.ContainsKey("sidx") == false)
            {
                vals.Add("sidx", columnName);
            }
            else
            {
                vals["sidx"] = columnName;
            }

            //get the sort order from the request variable if it exists
            string sord = String.Empty;
            if (System.Web.HttpContext.Current.Request["sord"] != null)
            {
                sord = System.Web.HttpContext.Current.Request["sord"].ToString();
            }

            //add the sord key if needed
            if (vals.ContainsKey("sord") == false)
            {
                vals.Add("sord", String.Empty);
            }

            //if column matches
            if (sidx.Equals(columnName, StringComparison.CurrentCultureIgnoreCase) == true)
            {
                if (sord.Equals("asc", StringComparison.CurrentCultureIgnoreCase) == true)
                {
                    //draw the ascending sort indicator using the wingdings font. 
                    sb.Append(" <font face='Wingdings 3'>&#112;</font>");
                    vals["sord"] = "desc";
                }
                else
                {
                    sb.Append(" <font face='Wingdings 3'>&#113;</font>");
                    vals["sord"] = "asc";
                }
            }
            else
            {
                //if the column does not match then force the next sort to ascending order
                vals["sord"] = "asc";
            }

            //Use the ActionLink to build the link and insert it into the string
            sb.Insert(0, System.Web.Mvc.Html.LinkExtensions.ActionLink(htmlHelper, linkText, actionName, vals));
            return sb.ToString();
        }
    }
}
