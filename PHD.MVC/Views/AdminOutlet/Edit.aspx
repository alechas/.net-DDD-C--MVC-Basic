<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<PHD.Session.Classes.Outlet>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Edit</h2>

<script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
<script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>" type="text/javascript"></script>

<% using (Html.BeginForm()) { %>
    <%: Html.ValidationSummary(true) %>
    <fieldset>
        <legend>Outlet</legend>

        <%: Html.HiddenFor(model => model.id) %>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.kode) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.kode) %>
            <%: Html.ValidationMessageFor(model => model.kode) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.name) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.name) %>
            <%: Html.ValidationMessageFor(model => model.name) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.description) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.description) %>
            <%: Html.ValidationMessageFor(model => model.description) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.id_kota) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.id_kota) %>
            <%: Html.ValidationMessageFor(model => model.id_kota) %>
        </div>

        <%: Html.HiddenFor(model => model.Id) %>

        <p>
            <input type="submit" value="Save" />
        </p>
    </fieldset>
<% } %>

<div>
    <%: Html.ActionLink("Back to List", "Index") %>
</div>

</asp:Content>

