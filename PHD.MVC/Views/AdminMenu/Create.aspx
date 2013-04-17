<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<PHD.Session.Classes.Menu>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Create</h2>

<script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
<script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>" type="text/javascript"></script>

<% using (Html.BeginForm()) { %>
    <%: Html.ValidationSummary(true) %>
    <fieldset>
        <legend>Menu</legend>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.nama) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.nama) %>
            <%: Html.ValidationMessageFor(model => model.nama) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.description) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.description) %>
            <%: Html.ValidationMessageFor(model => model.description) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.title) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.title) %>
            <%: Html.ValidationMessageFor(model => model.title) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.sequence) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.sequence) %>
            <%: Html.ValidationMessageFor(model => model.sequence) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.status) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.status) %>
            <%: Html.ValidationMessageFor(model => model.status) %>
        </div>

        <p>
            <input type="submit" value="Create" />
        </p>
    </fieldset>
<% } %>

<div>
    <%: Html.ActionLink("Back to List", "Index") %>
</div>

</asp:Content>
