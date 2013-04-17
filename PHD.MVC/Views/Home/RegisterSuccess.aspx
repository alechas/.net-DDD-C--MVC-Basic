<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/RegLog.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    RegisterSuccess
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Register Success</h2>
<br>
<br>
<p style="text-align:center"> Silahkan menunggu dihubungi oleh agent PHD
</p>
<br>
<br>
<p style="text-align:center"> <%: Html.ActionLink("Back to Home", "index", "home")%>
</p>
</asp:Content>
