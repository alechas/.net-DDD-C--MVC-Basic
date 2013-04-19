<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Session.Classes.Blog>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Details</h2>

<fieldset>
    <legend>Blog</legend>

    <div class="display-label">header</div>
    <div class="display-field"><%: Model.header %></div>

    <div class="display-label">text</div>
    <div class="display-field"><%: Model.text %></div>

    <div class="display-label">created</div>
    <div class="display-field"><%: String.Format("{0:g}", Model.created) %></div>

    <div class="display-label">IsPersisted</div>
    <div class="display-field"><%: Model.IsPersisted %></div>
</fieldset>
<p>

    <%: Html.ActionLink("Edit", "Edit", new { id=Model.Id }) %> |
    <%: Html.ActionLink("Back to List", "Index") %>
</p>

</asp:Content>

