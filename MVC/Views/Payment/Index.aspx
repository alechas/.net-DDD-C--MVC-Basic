<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/PHD3.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="menu-title">
		<img src="<%:Url.Content("~/Content/_design/images/payment.png") %>">
	</div>
	<div class="content-left">
		<nav class="nav-content-left">
			<ul>
				<li>
					<a id="menu6" href=""><span>Term Of Payment</span></a>
				</li>
			</ul>
		</nav>
		<div class="content-left-container">
			<div class="payment-options">
				<%= ViewBag.payment.text %>
                 
			</div>
		</div>		
		<div class="content-left-bottom">
		</div>
	</div>
</asp:Content>
