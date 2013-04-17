<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/RegLog.Master" Inherits="System.Web.Mvc.ViewPage<PHD.Session.Classes.User>" %>
<%@ Import Namespace="PHD.MVC.Helper" %>
<%@ import Namespace="PHD.Session.Classes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    PHD
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h2>Select Address</h2>

<% //Address address = (Address) ViewBag.address; %>
<% using (Html.BeginForm(null,null,FormMethod.Post , new { @class = "form-member-section" }))
       { %>
	<fieldset>
		<div class="control-group clearfix">
			<label class="control-label" for="">Alamat delivery*</label>

			 <%: Html.DropDownList("id_address",
                   new SelectList(new Dropdown().getUserAddress(Page.User.Identity.Name),
                  "value",
                  "text",1
                    ), new { @class = "control-select", @id = "custom-select", @onchange = "changeAddress(this.value)", @onload = "changeAddress(this.value)" }
                    )
            %>
		</div>

		<div class="form-action">
         <%: Html.ActionLink("Tambah Alamat Pengiriman", "index", "paddict")%>
			<div class="actions">
               
				<button type="submit">OK</button>
			</div>
		</div>
	</fieldset>
 <% } %>

 <script language="javascript">

     changeAddress(1);
 </script>
</asp:Content>
