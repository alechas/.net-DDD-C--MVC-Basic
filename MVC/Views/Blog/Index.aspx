<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Session.Classes.Blog>>" %>
<%@ import Namespace="MvcPaging" %>
<%@ Import Namespace="MVC.Helper" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<% object routeValues = new { text = Request["text"],  header= Request["header"] }; %>
<% var total = (int)ViewData["TotalCount"]; %>
<% var pageSize = (int)ViewData["PageSize"]; %>
<% var Current = (int)ViewData["current"]; %>

<h2>Index</h2>

<p>
    <%: Html.ActionLink("Create New", "Create") %>
</p>
<table>
    <tr>
        <th></th>
        <th>
            header
        </th>
        <th>
            text
        </th>
        <th>
            created
        </th>
        <th>
            IsPersisted
        </th>
    </tr>

<% foreach (var item in Model) { %>
    <tr>
        <td>
            <%: Html.ActionLink("Edit", "Edit", new { id=item.Id }) %> |
            <%: Html.ActionLink("Details", "Details", new { id=item.Id }) %> |
            <%: Html.ActionLink("Delete", "Delete", new { id=item.Id }) %>
        </td>
        <td>
            <%: item.header %>
        </td>
        <td>
            <%: item.text %>
        </td>
        <td>
            <%: String.Format("{0:g}", item.created) %>
        </td>
        <td>
            <%: item.IsPersisted %>
        </td>
    </tr>  
<% } %>

</table>
<div class="pager">
<%= Html.Pager(pageSize,Current,total,routeValues) %>
</div>
</asp:Content>

