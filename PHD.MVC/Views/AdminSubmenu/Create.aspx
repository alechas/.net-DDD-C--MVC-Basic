<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<PHD.Session.Classes.Submenu>" %>
<%@ import Namespace="PHD.MVC.Helper" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Create</h2>

<script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
<script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>" type="text/javascript"></script>

<% using (Html.BeginForm(null, null, FormMethod.Post, new { enctype = "multipart/form-data" }))
   { %>
    <%: Html.ValidationSummary(true) %>
    <fieldset>
        <legend>Submenu</legend>

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
            <%: Html.DropDownListFor(
                          model => model.type_submenu,
                          new SelectList(new Dropdown().GetTypeSubMenu(),
                  "value",
                  "text",
                          Model.type_submenu
                        )
                    )
            %>
            <%: Html.ValidationMessageFor(model => model.type_submenu)%>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.id_menu) %>
        </div>
        <div class="editor-field">
            <%: Html.DropDownListFor(
                   model => model.id_menu, 
                   new SelectList(new Dropdown().GetMenu(),
                  "value",
                  "text",
                   Model.id_menu
                        )
                    )
            %>
            <%: Html.ValidationMessageFor(model => model.id_menu)%>
        </div>

                <div class="editor-label">
            <%: Html.LabelFor(model => model.id_submenu) %>
        </div>
        <div class="editor-field">
            <%: Html.DropDownListFor(
                   model => model.id_submenu, 
                   new SelectList(new Dropdown().GetSubmenu(),
                  "value",
                  "text",
                  Model.id_submenu
                        )
                    )
            %>
            <%: Html.ValidationMessageFor(model => model.id_submenu)%>
        </div>

        <div class="editor-label">
        <label for="file">
        image:</label>
        </div>
         <div class="editor-field">
        <input type="file" id="image" name="image"/>
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
            <%: Html.DropDownListFor(
                   model => model.status, 
                   new SelectList(new Dropdown().StatusSubmenu(),
                  "value",
                  "text",
                   Model.status
                        )
                    )
            %>
            <%: Html.ValidationMessageFor(model => model.status) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.kode) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.kode) %>
            <%: Html.ValidationMessageFor(model => model.kode) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.is_promo) %>
        </div>
        <div class="editor-field">
            <%: Html.DropDownListFor(
                          model => model.is_promo, 
                   new SelectList(new Dropdown().cat_submenu(),
                  "value",
                  "text",
                   Model.is_promo
                        )
                    )
            %>
            <%: Html.ValidationMessageFor(model => model.is_promo) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.is_hemat) %>
        </div>
        <div class="editor-field">
            <%: Html.DropDownListFor(
                          model => model.is_hemat, 
                   new SelectList(new Dropdown().cat_submenu(),
                  "value",
                  "text",
                          Model.is_hemat
                        )
                    )
            %>
            <%: Html.ValidationMessageFor(model => model.is_hemat) %>
        </div>


        <div class="editor-label">
            <%: Html.LabelFor(model => model.is_menu) %>
        </div>
        <div class="editor-field">
            <%: Html.DropDownListFor(
                          model => model.is_menu, 
                   new SelectList(new Dropdown().cat_submenu(),
                  "value",
                  "text",
                          Model.is_menu
                        )
                    )
            %>
            <%: Html.ValidationMessageFor(model => model.is_menu) %>
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

