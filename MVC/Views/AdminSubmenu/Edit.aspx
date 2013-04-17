<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<PHD.Session.Classes.Submenu>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Edit</h2>

<script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
<script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>" type="text/javascript"></script>

<% using (Html.BeginForm(null, null, FormMethod.Post, new { enctype = "multipart/form-data" })) { %>
    <%: Html.ValidationSummary(true) %>
    <fieldset>
        <legend>Submenu</legend>

        <%: Html.HiddenFor(model => model.id) %>

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
            <%: Html.LabelFor(model => model.price) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.price) %>
            <%: Html.ValidationMessageFor(model => model.price) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.type_submenu) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.type_submenu) %>
            <%: Html.ValidationMessageFor(model => model.type_submenu) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.id_menu) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.id_menu) %>
            <%: Html.ValidationMessageFor(model => model.id_menu) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.id_submenu) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.id_submenu) %>
            <%: Html.ValidationMessageFor(model => model.id_submenu) %>
        </div>

        <div class="editor-label">
        <label for="file">
        image:</label>
        </div>
         <div class="editor-field">
        <input type="file" id="image" name="image"/>
        <% if (!Model.image.IsEmpty()) {%>
        <div class="display-field"><img src=" <%: Url.Content(Model.image) %>" alt="" /></div>
        <% } %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.text) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.text) %>
            <%: Html.ValidationMessageFor(model => model.text) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.diskon) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.diskon) %>
            <%: Html.ValidationMessageFor(model => model.diskon) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.status) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.status) %>
            <%: Html.ValidationMessageFor(model => model.status) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.kode) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.kode) %>
            <%: Html.ValidationMessageFor(model => model.kode) %>
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

