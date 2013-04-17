<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<PHD.Session.Classes.Faq>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Delete
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<fieldset>
    <legend>Faq</legend>

    <div class="display-label">question</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.question) %>
    </div>

    <div class="display-label">answer</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.answer) %>
    </div>

    <div class="display-label">status</div>
    <div class="display-field">
        <%: Model.getStatus() %>
    </div>

    <div class="display-label">sequence</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.sequence) %>
    </div>

    <div class="display-label">IsPersisted</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.IsPersisted) %>
    </div>
</fieldset>
<% using (Html.BeginForm()) { %>
    <p>
        <input type="submit" value="Delete" /> |
        <%: Html.ActionLink("Back to List", "Index") %>
    </p>
<% } %>

</asp:Content>
