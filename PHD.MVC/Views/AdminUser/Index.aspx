<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>
<%@ import Namespace="MvcPaging" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<% object routeValues = new { dbaid = "", sidx = Request["table"], sord = Request["desc"], start_date = Request["start_date"], end_date = Request["end_date"], status_filter = Request["status_filter"] }; %>
<% var total = (int)ViewData["TotalCount"]; %>
<% var pageSize = (int)ViewData["PageSize"]; %>
<% var Current = (int)ViewData["current"]; %>
<h2>Index</h2>
<p>
    <%: Html.ActionLink("Create New", "Create") %>
</p>

<table>
    <tr>
        <th>
            id
        </th>
        <th>
            username
        </th>
        <th>
            password
        </th>
        <th>
            nama
        </th>
        <th>
            email
        </th>
        <th>
            alamat
        </th>
        <th>
            kota
        </th>
        <th>
            provinsi
        </th>
        <th>
            hp
        </th>
        <th>
            telepon
        </th>
        <th>
            status
        </th>
        <th>
            role
        </th>
        <th>
            aksi
        </th>
    </tr>

<% foreach (var item in ViewBag.data) { %>
    <tr>
        
        <td>
            <%: item.Id %>
        </td>
         <td>
            <%: item.username %>
        </td>
        <td>
            <%: item.password %>
        </td>
        <td>
            <% if (item.nama != null)
               {%>
            <%: item.nama%>
            <% }%>
        </td>
        <td>
            <% if (item.email != null)
               {%>
            <%: item.email%>
            <% }%>
        </td>
        <td>

            <%: item.alamat %>
        </td>
        <td>
            <% if (item.kota != null)
               {%>
            <%: item.kota%>
            <% }%>
        </td>
        <td>
            <% if (item.provinsi != null)
               {%>
            <%: item.provinsi%>
            <% }%>
        </td>
        <td>
            <% if (item.hp != null)
               {%>
            <%: item.hp%>
            <% }%>
        </td>
        <td>
            <% if (item.telepon != null)
               {%>
            <%: item.telepon%>
            <% }%>
        </td>
        <td>
            <% if (item.status != null)
               {%>
            <%: item.status%>
            <% }%>
        </td>
        <td>
            <% if (item.role != null)
               {%>
            <%: item.role.name%>
            <% }%>
        </td>
        <td>
            <%: Html.ActionLink("Edit", "Edit", new { id=item.Id }) %> |
            <%: Html.ActionLink("Details", "Details", new { id=item.Id }) %> |
            <%: Html.ActionLink("Delete", "Delete", new { id=item.Id }) %>
        </td>
        
    </tr>  
<% } %>

</table>
<div class="pager">
<%= Html.Pager(pageSize,Current,total,routeValues) %>
</div>
</asp:Content>
