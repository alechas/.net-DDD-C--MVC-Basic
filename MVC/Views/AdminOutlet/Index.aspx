<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<PHD.Session.Classes.Outlet>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Index</h2>

<p>
    <%: Html.ActionLink("Create New", "Create") %>
</p>
<table>
    <tr>
        <th></th>
        <th>
            kode
        </th>
        <th>
            name
        </th>
        <th>
            description
        </th>
        <th>
            id_kota
        </th>
        <th>
            IsPersisted
        </th>
    </tr>

<% foreach (var item in Model) { %>
    <tr>
        <td>
            <%: Html.ActionLink("Edit", "Edit", new { /* id=item.PrimaryKey */ }) %> |
            <%: Html.ActionLink("Details", "Details", new { /* id=item.PrimaryKey */ }) %> |
            <%: Html.ActionLink("Delete", "Delete", new { /* id=item.PrimaryKey */ }) %>
        </td>
        <td>
            <%: item.kode %>
        </td>
        <td>
            <%: item.name %>
        </td>
        <td>
            <%: item.description %>
        </td>
        <td>
            <%: item.id_kota %>
        </td>
        <td>
            <%: item.IsPersisted %>
        </td>
    </tr>  
<% } %>

</table>

</asp:Content>

