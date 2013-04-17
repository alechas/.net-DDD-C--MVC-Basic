<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<PHD.Session.Classes.Sitemenu>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Details</h2>

<fieldset>
    <legend>Sitemenu</legend>

    <div class="display-label">name</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.name) %>
    </div>

    <div class="display-label">position</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.position) %>
    </div>

    <div class="display-label">url</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.url) %>
    </div>

    <div class="display-label">image</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.image) %>
    </div>

    <div class="display-label">type</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.type) %>
    </div>

</fieldset>
<p>
    <%: Html.ActionLink("Edit", "Edit", new { id=Model.Id }) %> |
    <%: Html.ActionLink("Back to List", "Index") %>
</p>

</asp:Content>
