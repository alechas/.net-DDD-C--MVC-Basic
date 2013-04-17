<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<PHD.Session.Classes.User>" %>
<%@ import Namespace="PHD.MVC.Helper" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Edit</h2>

<script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
<script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>" type="text/javascript"></script>

<% using (Html.BeginForm(null, null, FormMethod.Post, new { enctype = "multipart/form-data" }))
   { %>
    <%: Html.ValidationSummary(true) %>
    <fieldset>
        <legend>User</legend>
         <label for="file">
        Filename:</label>
        <input type="file" id="profile" name="profile"/>
        <%: Html.HiddenFor(model => model.Id) %>

        <label for="file">
        Profpic:</label>
        <input type="file" id="profile" name="profile"/>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.username) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.username) %>
            <%: Html.ValidationMessageFor(model => model.username) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.password) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.password) %>
            <%: Html.ValidationMessageFor(model => model.password) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.nama) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.nama) %>
            <%: Html.ValidationMessageFor(model => model.nama) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.email) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.email) %>
            <%: Html.ValidationMessageFor(model => model.email) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.alamat) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.alamat) %>
            <%: Html.ValidationMessageFor(model => model.alamat) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.kota) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.kota) %>
            <%: Html.ValidationMessageFor(model => model.kota) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.provinsi) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.provinsi) %>
            <%: Html.ValidationMessageFor(model => model.provinsi) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.kode_pos) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.kode_pos) %>
            <%: Html.ValidationMessageFor(model => model.kode_pos) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.hp) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.hp) %>
            <%: Html.ValidationMessageFor(model => model.hp) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.telepon) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.telepon) %>
            <%: Html.ValidationMessageFor(model => model.telepon) %>
        </div>

         <div class="editor-label">
            <%: Html.LabelFor(model => model.status) %>
        </div>
        <div class="editor-field">
            <%: Html.DropDownListFor(
                   model => model.status, 
                   new SelectList(new Dropdown().Status(),
                  "value",
                  "text",
                   Model.status
                        )
                    )
            %>
            <%: Html.ValidationMessageFor(model => model.status) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.id_role) %>
        </div>
        <div class="editor-field">
    
            <%: Html.DropDownListFor(
                   model => model.id_role, 
                   new SelectList(new Dropdown().Role(),
                  "value",
                  "text",
                   Model.id_role
                        )
                    )
            %>

            <%: Html.ValidationMessageFor(model => model.id_role) %>
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

