<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<PHD.Session.Classes.Submenu>>" %>

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
            name
        </th>
        <th>
            description
        </th>
        <th>
            price
        </th>
        <th>
            type_submenu
        </th>
        <th>
            id_menu
        </th>
        <th>
            id_submenu
        </th>
        <th>
            image
        </th>
        <th>
            text
        </th>
        <th>
            diskon
        </th>
        <th>
            status
        </th>
        <th>
            kode
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
            <%: item.name %>
        </td>
        <td>
            <%: item.description %>
        </td>
        <td>
            <%: item.price %>
        </td>
        <td>
            <%: item.type_submenu %>
        </td>
        <td>
            <%: item.id_menu %>
        </td>
        <td>
            <%: item.id_submenu %>
        </td>
        <td>
            <%: item.image %>
        </td>
        <td>
            <%: item.text %>
        </td>
        <td>
            <%: item.diskon %>
        </td>
        <td>
            <%: item.status %>
        </td>
        <td>
            <%: item.kode %>
        </td>
        <td>
            <%: item.IsPersisted %>
        </td>
    </tr>  
<% } %>

</table>

</asp:Content>

