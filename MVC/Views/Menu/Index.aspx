<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/PHD3.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    PHD - Ahlinya Delivery! :: Menu
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	
	<div class="menu-title">
		<img src="<%:Url.Content("~/Content/_design/images/hotpromo.png") %>">
	</div>
	<div class="content-left">
		<nav class="nav-content-left">
			<ul>
				<li>
					<a id="menu1" href="<%:Url.Content("~/menu/promo")%>"><span>Hot Promo</span></a>
				</li>
				<li>
					<a id="menu2" href="<%:Url.Content("~/menu/hemat")%>"><span>Hot Hemat</span></a>
				</li>
                   <li>
					<a id="menu5" href="<%:Url.Content("~/menu/DoublePizza")%>"><span>Double Pizza</span></a>
				</li>
				<li>
					<a id="menu3" href="<%:Url.Content("~/menu/hotmenu")%>"><span>Hot Menu</span></a>
				</li>
				<li class = "active">
					<a id="menu4" href="<%:Url.Content("~/menu/favorite")%>"><span>My Favorite</span></a>
				</li>
			</ul>
		</nav>
		<div class="content-left-container">
			<nav class="nav-menu">
				<ul>
                <% foreach (var item in ViewBag.menu)
                    {%>
					<li>
						<a href="/Menu/MenuUtama/<%:item.Id%>"><%: item.title %></a>
					</li>
                    <%} %>
				</ul>
			</nav>
			<p class="menu-notes">
				<small>Harga dalam .000 Rupiah dan sudah termasuk pajak.</small>
			</p>
			<div class="hot-promo-container">
				<div class="image-container">

				</div>
				<div class="slide-container">
					<div class="slide-arrows">
						<a href="" class="left">

						</a>
						<a href="" class="right">

						</a>
					</div>
					<ul>
						<li>
							<div class="inner-whitebox">
								<img src="../../Content/_design/images/promo-slide1.jpg">
							</div>
										
							<div class="menu-text">
								<div class="title">
									Double Frenzy Regular
								</div>
								<div class="text">
									2 Pizza Original Regular + 1 Tipco 1L
									<div class="price">
										Rp 100,000
									</div>
								</div>
							</div>
						</li>
						<li>
							<div class="inner-whitebox">
								<img src="../../Content/_design/images/promo-slide1.jpg">
							</div>
										
							<div class="menu-text">
								<div class="title">
									Double Frenzy Regular
								</div>
								<div class="text">
									2 Pizza Original Regular + 1 Tipco 1L
									<div class="price">
										Rp 100,000
									</div>
								</div>
							</div>
						</li>
					</ul>
					<div class="slider-nav-container">
						<div class="slider-nav"></div>
					</div>
								
				</div>

				<form>
					<input type="submit" value="Pesan" class="order-button">
				</form>
							
			</div>
		</div>
					
		<div class="content-left-bottom">

		</div>
	</div>

</asp:Content>
