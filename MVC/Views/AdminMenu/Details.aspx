<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<PHD.Session.Classes.Menu>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Details</h2>

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
<p>
    <%: Html.ActionLink("Edit", "Edit", new { id=Model.Id }) %> |
    <%: Html.ActionLink("Back to List", "Index") %>
</p>

</asp:Content>
