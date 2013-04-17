<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<PHD.Session.Classes.Faq>>" %>

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
        <th>
            question
        </th>
        <th>
            answer
        </th>
        <th>
            status
        </th>
        <th>
            sequence
        </th>
        <th>
            Action
        </th>
        <th></th>
    </tr>

<% foreach (var item in Model) { %>
    <tr>
        <td>
            <%: Html.DisplayFor(modelItem => item.question) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.answer) %>
        </td>
        <td>
            <%: item.getStatus() %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.sequence) %>
        </td>
        <td>
            <%: Html.ActionLink("Edit", "Edit", new { id=item.Id}) %> |
            <%: Html.ActionLink("Details", "Details", new { id=item.Id}) %> |
            <%: Html.ActionLink("Delete", "Delete", new { id=item.Id }) %>
        </td>
    </tr>
<% } %>

</table>

</asp:Content>
