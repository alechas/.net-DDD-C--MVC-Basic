<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/RegLog.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    InfitiumResult
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>InfitiumResult</h2>
<br/>

<%: ViewBag.message %>
<br/>
<% if (ViewBag.message == "gagal")
   { %>

     <p>
    <%: Html.ActionLink("Retry", "Infinitium", "Transaction", new { @idcust = ViewBag.idcust })%>
    </p>
   <%}
   else
   { %>
    <p>
    <%: Html.ActionLink("Back To Home", "Index", "Home")%>
    </p>
    <%} %>
</asp:Content>
