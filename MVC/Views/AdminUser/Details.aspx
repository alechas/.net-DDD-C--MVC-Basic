<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<PHD.Session.Classes.User>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Details</h2>

<fieldset>
    <legend>User</legend>
    <%if (!Model.profpic.IsEmpty())
      { %>

    <img src=" <%: Url.Content(Model.profpic) %>" alt="" />

    <%} %>
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

    <div class="display-label">kota</div>
    <div class="display-field"><%: Model.kota %></div>

    <div class="display-label">provinsi</div>
    <div class="display-field"><%: Model.provinsi %></div>

     <div class="display-label">kode_pos</div>
    <div class="display-field"><%: Model.kode_pos %></div>

    <div class="display-label">hp</div>
    <div class="display-field"><%: Model.hp %></div>

    <div class="display-label">telepon</div>
    <div class="display-field"><%: Model.telepon %></div>

    <div class="display-label">status</div>
    <div class="display-field"><%: Model.status %></div>

    <div class="display-label">id_role</div>
    <div class="display-field"><%: Model.role.name %></div>

    <div class="display-label">IsPersisted</div>
    <div class="display-field"><%: Model.IsPersisted %></div>
</fieldset>
<p>
    <%: Html.ActionLink("Edit", "Edit", new { id=Model.Id}) %> |
    <%: Html.ActionLink("Back to List", "Index") %>
</p>

</asp:Content>

