<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<PHD.Session.Classes.Static>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Details</h2>

<fieldset>
    <legend>Static</legend>

    <div class="display-label">name</div>
    <div class="display-field"><%: Model.name %></div>

    <div class="display-label">url</div>
    <% if (!Model.url.IsEmpty()) {%>
    <div class="display-field"><img src=" <%: Url.Content(Model.url) %>" alt="" /></div>
    <% } %>
    <div class="display-label">text</div>
    <div class="display-field"><%= Model.text%></div>

    <div class="display-label">position</div>
    <div class="display-field"><%: Model.position %></div>

    <div class="display-label">type</div>
    <div class="display-field"><%: Model.typestatic.name %></div>
</fieldset>
<p>
    <%: Html.ActionLink("Edit", "Edit", new {  id=Model.Id  }) %> |
    <%: Html.ActionLink("Back to List", "Index") %>
</p>

</asp:Content>

