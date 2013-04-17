<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<PHD.Session.Classes.Submenu>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Delete
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<fieldset>
    <legend>Submenu</legend>

    <div class="display-label">name</div>
    <div class="display-field"><%: Model.name %></div>

    <div class="display-label">description</div>
    <div class="display-field"><%: Model.description %></div>

    <div class="display-label">price</div>
    <div class="display-field"><%: Model.price %></div>

    <div class="display-label">type_submenu</div>
    <div class="display-field"><%: Model.type_submenu %></div>

    <div class="display-label">id_menu</div>
    <div class="display-field"><%: Model.id_menu %></div>

    <div class="display-label">id_submenu</div>
    <div class="display-field"><%: Model.id_submenu %></div>

    <div class="display-label">image</div>
    <div class="display-field"><%: Model.image %></div>

    <div class="display-label">text</div>
    <div class="display-field"><%: Model.text %></div>

    <div class="display-label">diskon</div>
    <div class="display-field"><%: Model.diskon %></div>

    <div class="display-label">status</div>
    <div class="display-field"><%: Model.status %></div>

    <div class="display-label">kode</div>
    <div class="display-field"><%: Model.kode %></div>

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

