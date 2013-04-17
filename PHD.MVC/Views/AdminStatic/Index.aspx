<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<PHD.Session.Classes.Static>>" %>

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
            image
        </th>
        <th>
            text
        </th>
        <th>
            position
        </th>
        
    </tr>

<% foreach (var item in Model) { %>
    <tr>
        <td>
            <%: Html.ActionLink("Edit", "Edit", new {  id=item.Id  }) %> |
            <%: Html.ActionLink("Details", "Details", new { id = item.Id })%> |
            <%: Html.ActionLink("Delete", "Delete", new { id = item.Id })%>
        </td>
        <td>
            <%: item.name %>
        </td>
        <td>
          <% if (!item.url.IsEmpty()) {%>
       <img src=" <%: Url.Content(item.url) %>" height=50px width=50px alt="" />
        <% } %>
        </td>
        <td>
            <%= item.text %>
        </td>
        <td>
            <%: item.position %>
        </td>
       
    </tr>  
<% } %>

</table>

</asp:Content>

