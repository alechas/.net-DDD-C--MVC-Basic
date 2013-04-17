<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html>

    <div class="menu-title">
		<img src="../../Content/_design/images/drinktittle.png">
	</div>
	<div class="content-left">
		<nav class="nav-content-left">
			<ul>
				<li class="active">
					<a id="menu1" href="/menu/promo"><span>Hot Promo</span></a>
				</li>
				<li>
					<a id="menu2" href="/menu/hemat"><span>Hot Hemat</span></a>
				</li>
				<li>
					<a id="menu3" href="/menu/hotmenu"><span>Hot Menu</span></a>
				</li>
				<li>
					<a id="menu4" href="/menu/favorite"><span>My Favorite</span></a>
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
			<div class="menu-common">
				<h1>
					<img src="../../Content/_design/images/logo_drink.png">
				</h1>
				<div class="price-group">
					<h2>
						<img src="../../Content/_design/images/Harga_6.png">
					</h2>
					<ul class="clearfix">
						<li class="menu-list">
							<span><a href="#" class="spin"></a><br><a href="#" class="sfb"></a><a href="#" class="stwt"></a><b class="ttlshare"></b></span>
							<div class="menu-image">
								<img  src="../../Content/_design/images/drink-black-current-shake.png">
							</div>
							<h4>Mozz Sticks</h4>
							<input type="button" class="order-button" value="pesan">
						</li>
						<li class="menu-list">
							<span><a href="#" class="spin"></a><br><a href="#" class="sfb"></a><a href="#" class="stwt"></a><b class="ttlshare"></b></span>
							<div class="menu-image">
								<img  src="../../Content/_design/images/drink-black-current-shake.png">
							</div>
							<h4>Mozz Sticks</h4>
							<input type="button" class="order-button" value="pesan">
						</li>
						<li class="menu-list">
							<span><a href="#" class="spin"></a><br><a href="#" class="sfb"></a><a href="#" class="stwt"></a><b class="ttlshare"></b></span>
							<div class="menu-image">
								<img  src="../../Content/_design/images/drink-black-current-shake.png">
							</div>
							<h4>Mozz Sticks</h4>
							<input type="button" class="order-button" value="pesan">
						</li>
					</ul>

				</div>
				<div class="price-group">
					<h2>
						<img src="../../Content/_design/images/Harga_10.png">
					</h2>
					<ul class="clearfix">
						<li class="menu-list">
							<span><a href="#" class="spin"></a><br><a href="#" class="sfb"></a><a href="#" class="stwt"></a><b class="ttlshare"></b></span>
							<div class="menu-image">
								<img  src="../../Content/_design/images/drink-black-current-shake.png">
							</div>
							<h4>Mozz Sticks</h4>
							<input type="button" class="order-button" value="pesan">
						</li>
						<li class="menu-list">
							<span><a href="#" class="spin"></a><br><a href="#" class="sfb"></a><a href="#" class="stwt"></a><b class="ttlshare"></b></span>
							<div class="menu-image">
								<img  src="../../Content/_design/images/drink-black-current-shake.png">
							</div>
							<h4>Mozz Sticks</h4>
							<input type="button" class="order-button" value="pesan">
						</li>
						<li class="menu-list">
							<span><a href="#" class="spin"></a><br><a href="#" class="sfb"></a><a href="#" class="stwt"></a><b class="ttlshare"></b></span>
							<div class="menu-image">
								<img  src="../../Content/_design/images/drink-black-current-shake.png">
							</div>
							<h4>Mozz Sticks</h4>
							<input type="button" class="order-button" value="pesan">
						</li>
					</ul>

				</div>
				<div class="price-group">
					<h2>
						<img src="../../Content/_design/images/Harga_15.png">
					</h2>
					<ul class="clearfix">
						<li class="menu-list">
							<span><a href="#" class="spin"></a><br><a href="#" class="sfb"></a><a href="#" class="stwt"></a><b class="ttlshare"></b></span>
							<div class="menu-image">
								<img  src="../../Content/_design/images/drink-black-current-shake.png">
							</div>
							<h4>Mozz Sticks</h4>
							<input type="button" class="order-button" value="pesan">
						</li>
						<li class="menu-list">
							<span><a href="#" class="spin"></a><br><a href="#" class="sfb"></a><a href="#" class="stwt"></a><b class="ttlshare"></b></span>
							<div class="menu-image">
								<img  src="../../Content/_design/images/drink-black-current-shake.png">
							</div>
							<h4>Mozz Sticks</h4>
							<input type="button" class="order-button" value="pesan">
						</li>
						<li class="menu-list">
							<span><a href="#" class="spin"></a><br><a href="#" class="sfb"></a><a href="#" class="stwt"></a><b class="ttlshare"></b></span>
							<div class="menu-image">
								<img  src="../../Content/_design/images/drink-black-current-shake.png">
							</div>
							<h4>Mozz Sticks</h4>
							<input type="button" class="order-button" value="pesan">
						</li>
					</ul>

				</div>
			</div>
		</div>
					
		<div class="content-left-bottom">

		</div>
	</div>
				
