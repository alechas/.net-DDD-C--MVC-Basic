<%@ Page Title="" Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>



    <div class="menu-title">
		<img src="../../Content/_design/images/pizzalist.png">
	</div>
	<div class="content-left">
		<nav class="nav-content-left">
			<ul>
				<li>
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
			<div class="menu-pizza">
				<div class="price-group">
					<h3>
						Pilih Jenis Pizza yang Anda Inginkan
					</h3>
					<ul class="clearfix">
                    <% int i = 0; %>
                         <% foreach (var item in ViewBag.modifiers)
                        {%>
                        <%if (i == item.sequence)
                          { %>
					    <li class="menu-list">
							<label for="pizza-type1">
								<span><a href="#" class="spin"></a><br><a href="#" class="sfb"></a><a href="#" class="stwt"></a><b class="ttlshare"></b></span>
								<div class="menu-image">
									<img src="<%: item.image %>">
								</div>
							</label>									
							<input id="pizza-type1" name="modifier[<%:i%>>]" type="radio" value="<%:item.Id %>">
						</li>
                        <%} %>
                        <%} i++; %>						
					</ul>
				</div>
				<div class="price-group">
					<h3>
						Pilih Topping Pizza yang Anda Inginkan
					</h3>
					<ul class="clearfix">
						
                         <% foreach (var item in ViewBag.modifiers)
                            {%>
                        <%if (i == item.sequence)
                          { %>
                        <li class="menu-list">
							<label for="pizza-topping1">
								<span><a href="#" class="spin"></a><br><a href="#" class="sfb"></a><a href="#" class="stwt"></a><b class="ttlshare"></b></span>
								<h4><%: item.name %></h4>
								<div class="menu-image">
									<img src="<%: item.image %>">
								</div>
							</label>
										
							<input id="pizza-topping1" type="radio" name="modifier[<%:i%>>]" type="radio" value="<%:item.Id %>">
						</li>
                        <% }
                            } i++; %>>
					</ul>
				</div>
				<div class="price-group">
					<h3>
						Pilih tambahan topping pizza yang Anda inginkan
					</h3>
					<ul class="clearfix">
                    
                         <% foreach (var item in ViewBag.modifiers)
                            {%>
                        <%if (i == item.sequence)
                          { %>
						<li class="menu-list">
							<label for="pizza-cheese1">
								<span><a href="#" class="spin"></a><br><a href="#" class="sfb"></a><a href="#" class="stwt"></a><b class="ttlshare"></b></span>
								<h4><%: item.name %></h4>
								<div class="menu-image">
									<img src="../../Content/_design/images/xtra-cheesy.jpg">
								</div>
							</label>
										
							<input id="pizza-cheese1" type="radio" name="modifier[<%:i%>>]" type="radio" value="<%:item.Id %>">
						</li>
						 <% }
                            } i++; %>
					</ul>
				</div>

				<div class="button-container">
					<input type="submit" value="pesan" class="order-button">
				</div>
			</div>
		</div>
					
		<div class="content-left-bottom">

		</div>
	</div>
				

