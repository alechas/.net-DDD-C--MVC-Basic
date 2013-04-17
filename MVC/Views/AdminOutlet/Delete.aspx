<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<PHD.Session.Classes.Outlet>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Delete
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<fieldset>
    <legend>Outlet</legend>

    <div class="display-label">kode</div>
    <div class="display-field"><%: Model.kode %></div>

    <div class="display-label">name</div>
    <div class="display-field"><%: Model.name %></div>

    <div class="display-label">description</div>
    <div class="display-field"><%: Model.description %></div>

    <div class="display-label">id_kota</div>
    <div class="display-field"><%: Model.id_kota %></div>

    <div class="display-label">IsPersisted</div>
    <div class="display-field"><%: Model.IsPersisted %></div>
</fieldset>
<% using (Html.BeginForm()) { %>
    <p>
        <input type="submit" value="Delete" /> |
        <%: Html.ActionLink("Back to List", "Index") %>
    </p>
<% } %>

</asp:Content>

