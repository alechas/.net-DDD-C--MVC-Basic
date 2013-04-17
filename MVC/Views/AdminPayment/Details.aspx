<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<PHD.Session.Classes.Payment>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Details</h2>

<fieldset>
    <legend>Payment</legend>

    <div class="display-label">name</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.name) %>
    </div>

    <div class="display-label">description</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.description) %>
    </div>

    <div class="display-label">IsPersisted</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.IsPersisted) %>
    </div>
</fieldset>
<p>
    <%: Html.ActionLink("Edit", "Edit", new {  id=Model.Id  }) %> |
    <%: Html.ActionLink("Back to List", "Index") %>
</p>

</asp:Content>
