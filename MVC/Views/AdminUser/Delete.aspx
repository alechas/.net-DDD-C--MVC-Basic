<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<PHD.Session.Classes.User>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Delete
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<fieldset>
    <legend>User</legend>

    <div class="display-label">username</div>
    <div class="display-field"><%: Model.username %></div>

    <div class="display-label">password</div>
    <div class="display-field"><%: Model.password %></div>

    <div class="display-label">nama</div>
    <div class="display-field"><%: Model.nama %></div>

    <div class="display-label">email</div>
    <div class="display-field"><%: Model.email %></div>

    <div class="display-label">alamat</div>
    <div class="display-field"><%: Model.alamat %></div>

    <div class="display-label">kode_pos</div>
    <div class="display-field"><%: Model.kode_pos %></div>

    <div class="display-label">kota</div>
    <div class="display-field"><%: Model.kota %></div>

    <div class="display-label">provinsi</div>
    <div class="display-field"><%: Model.provinsi %></div>

    <div class="display-label">hp</div>
    <div class="display-field"><%: Model.hp %></div>

    <div class="display-label">telepon</div>
    <div class="display-field"><%: Model.telepon %></div>

    <div class="display-label">status</div>
    <div class="display-field"><%: Model.status %></div>

    <div class="display-label">id_role</div>
    <div class="display-field"><%: Model.id_role %></div>

   
</fieldset>
<% using (Html.BeginForm()) { %>
    <p>
        <input type="submit" value="Delete" /> |
        <%: Html.ActionLink("Back to List", "Index") %>
    </p>
<% } %>

</asp:Content>

