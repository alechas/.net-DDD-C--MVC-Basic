<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<PHD.Session.Classes.Faq>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Details</h2>

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

</fieldset>
<p>
    <%: Html.ActionLink("Edit", "Edit", new { id=Model.Id }) %> |
    <%: Html.ActionLink("Back to List", "Index") %>
</p>

</asp:Content>
