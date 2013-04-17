<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<PHD.Session.Classes.Menu>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Delete
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<fieldset>
    <legend>Menu</legend>

    <div class="display-label">nama</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.nama) %>
    </div>

    <div class="display-label">description</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.description) %>
    </div>

    <div class="display-label">title</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.title) %>
    </div>

    <div class="display-label">sequence</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.sequence) %>
    </div>

    <div class="display-label">status</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.status) %>
    </div>
</fieldset>
<% using (Html.BeginForm()) { %>
    <p>
        <input type="submit" value="Delete" /> |
        <%: Html.ActionLink("Back to List", "Index") %>
    </p>
<% } %>

</asp:Content>
