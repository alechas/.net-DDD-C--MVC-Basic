<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/PHD3.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>
<%@ Import Namespace="PHD.Session.Classes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="menu-title">					
	</div>
	<div class="content-left">
		<div class="content-left-container">						
			<div class="track-order clearfix">
            <%
                Ordercust order = (Ordercust)ViewBag.order;
                DateTime received = ViewBag.order.created;
                DateTime confirmed = order.confirmed_time.AsDateTime();
                DateTime cooking = order.cooking_time.AsDateTime();
                DateTime delivery = order.start_delivery_time.AsDateTime();
                 %>
				<a id="track1" href="" <%:ViewBag.order.status.Id >= 2 ?"class=active":"" %>> <span><%: received.ToString("hh:mm") %></span> </a>
				<a id="track2" href="" <%:ViewBag.order.status.Id >=5 ?"class=active":"" %>> <span><%: !order.confirmed_time.IsEmpty()? confirmed.ToString("hh:mm"): "- : -"%></span> </a>
				<a id="track3" href="" <%:ViewBag.order.status.Id >=7 ?"class=active":"" %>> <span><%: !order.cooking_time.IsEmpty()? cooking.ToString("hh:mm") :"- : -"%></span> </a>
				<a id="track4" href="" <%:ViewBag.order.status.Id >=8 ?"class=active":"" %>> <span><%:!order.start_delivery_time.IsEmpty()? delivery.ToString("hh:mm"):"- : -" %></span> </a>
			</div>
		</div>
					
		<div class="content-left-bottom">

		</div>
	</div>
				

</asp:Content>
