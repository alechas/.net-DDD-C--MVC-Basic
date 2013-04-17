<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Test
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
            id
        </th>
        <th>
            name
        </th>
        <th>
            description
        </th>
    </tr>

<% foreach (var item in ViewBag.datas) { %>
    <tr>
        
        <td>
            <%: item.Id %>
        </td>
        <td>
            <%: item.name %>
        </td>
        <td>
            <%: String.Format("{0:g}", item.description) %>
        </td>
        <td>
            <%: Html.ActionLink("Edit", "Edit", new { id=item.Id }) %> |
            <%: Html.ActionLink("Details", "Details", new { id=item.Id }) %> |
            <%: Html.ActionLink("Delete", "Delete", new { id=item.Id }) %>
        </td>
        
    </tr>  
<% } %>

</table>

</asp:Content>

