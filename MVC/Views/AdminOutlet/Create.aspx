﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<PHD.Session.Classes.Outlet>" %>

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
        <legend>Outlet</legend>

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

       

        <p>
            <input type="submit" value="Create" />
        </p>
    </fieldset>
<% } %>

<div>
    <%: Html.ActionLink("Back to List", "Index") %>
</div>

</asp:Content>

