<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/RegLog.Master" Inherits="System.Web.Mvc.ViewPage<PHD.Session.Classes.Ordercust>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Mandiri
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Infinitium</h2>
<% Dictionary<string, string> data = (Dictionary<string, string>)ViewBag.data;%>
<% using (Html.BeginForm(null, null, FormMethod.Post, new { @action = data["INFINITIUM"] }))
   { %>
    <%: Html.ValidationSummary(true) %>
<fieldset>
    <input id="TRANSACTIONTYPE" name="TRANSACTIONTYPE" type="hidden" value="1" />
    <input id="TXN_PASSWORD" name="TXN_PASSWORD" type="hidden" value="<%: data["TXN_PASSWORD"] %>" />
    <input id="MERCHANTID" name="MERCHANTID" type="hidden" value="<%: data["MERCHANTID"] %>" />
    <input id="MERCHANT_TRANID" name="MERCHANT_TRANID" type="hidden" value="<%: data["MERCHANT_TRANID"] %>" />
    <input id="CURRENCYCODE" name="CURRENCYCODE" type="hidden" value="IDR" />
    <input id="AMOUNT" name="AMOUNT" type="hidden" value="<%: data["AMOUNT"] %>" />
    <input id="SIGNATURE" name="SIGNATURE" type="hidden" value="<%: data["SIGNATURE"] %>" />
    <input id="CUSTNAME" name="CUSTNAME" type="hidden" value="<%: data["CUSTNAME"] %>" />
    <input id="CUSTEMAIL" name="CUSTEMAIL" type="hidden" value="<%: data["CUSTEMAIL"] %>" />
    <input id="SHOPPER_IP" name="SHOPPER_IP" type="hidden" value="<%: data["SHOPPER_IP"] %>" />
    <input id="RESPONSE_TYPE" name="RESPONSE_TYPE" type="hidden" value="1" />
    <input id="RETURN_URL" name="RETURN_URL" type="hidden" value="<%: data["RETURN_URL"] %>" />
    <button type="submit">Lanjut</button>
</fieldset>

<% } %>

</asp:Content>

