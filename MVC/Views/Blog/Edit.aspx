<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Session.Classes.Blog>" %>

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
        <legend>Blog</legend>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.header) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.header) %>
            <%: Html.ValidationMessageFor(model => model.header) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.text) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.text) %>
            <%: Html.ValidationMessageFor(model => model.text) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.created) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.created) %>
            <%: Html.ValidationMessageFor(model => model.created) %>
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

