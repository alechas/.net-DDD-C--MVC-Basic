<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<PHD.Session.Classes.Street>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Details</h2>

<fieldset>
    <legend>Street</legend>

    <div class="display-label">name</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.name) %>
    </div>

    <div class="display-label">id_city</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.id_city) %>
    </div>

    <div class="display-label">id_outlet</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.id_outlet) %>
    </div>

</fieldset>
<p>
    <%: Html.ActionLink("Edit", "Edit", new {  id=Model.Id  }) %> |
    <%: Html.ActionLink("Back to List", "Index") %>
</p>

</asp:Content>
