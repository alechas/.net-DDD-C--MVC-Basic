<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<PHD.Session.Classes.Faq>" %>
<%@ import Namespace="PHD.MVC.Helper" %>
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
        <legend>Faq</legend>

        <%: Html.HiddenFor(model => model.id) %>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.question) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.question) %>
            <%: Html.ValidationMessageFor(model => model.question) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.answer) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.answer) %>
            <%: Html.ValidationMessageFor(model => model.answer) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.status) %>
        </div>
        <div class="editor-field">
            <%: Html.DropDownListFor(
                   model => model.status, 
                   new SelectList(new Dropdown().StatusFaq(),
                  "value",
                  "text",
                   Model.status
                        )
                    )
            %>
            <%: Html.ValidationMessageFor(model => model.status) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.sequence) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.sequence) %>
            <%: Html.ValidationMessageFor(model => model.sequence) %>
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
