<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<PHD.Session.Classes.Static>" %>
<%@ import Namespace="PHD.MVC.Helper" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Edit</h2>
<script type="text/javascript" src="../../Content/tinymce/jscripts/tiny_mce/tiny_mce.js"></script>
<script type="text/javascript">
    tinyMCE.init({
        mode: "textareas",
        theme: "simple"
    });
</script>
<script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
<script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>" type="text/javascript"></script>

<% using (Html.BeginForm(null, null, FormMethod.Post, new { enctype = "multipart/form-data" }))
   { %>
    <%: Html.ValidationSummary(true) %>
    <fieldset>
        <legend>Static</legend>

        <%: Html.HiddenFor(model => model.id) %>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.name) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.name) %>
            <%: Html.ValidationMessageFor(model => model.name) %>
        </div>

        <div class="editor-label">
        <label for="file">
        image:</label>
        </div>
         <div class="editor-field">
        <input type="file" id="image" name="image"/>
           <% if (!Model.url.IsEmpty()) {%>
        <div class="display-field"><img src=" <%: Url.Content(Model.url) %>" alt="" /></div>
        <% } %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.text) %>
        </div>
        <div class="editor-field">
            <%: Html.TextAreaFor(model => model.text, new { rows="15",cols="80",style="width: 80%" })%>
            <%: Html.ValidationMessageFor(model => model.text) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.position) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.position) %>
            <%: Html.ValidationMessageFor(model => model.position) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.type) %>
        </div>
        <div class="editor-field">
            <%: Html.DropDownListFor(
                   model => model.type, 
                   new SelectList(new Dropdown().TypeStatic(),
                  "value",
                  "text",
                   Model.type
                        )
                    )
            %>
            <%: Html.ValidationMessageFor(model => model.type) %>
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

