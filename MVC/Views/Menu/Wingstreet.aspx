<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

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
		    <div class="menu-wingstreet">
			    <div class="wingstreet-title clearfix">
				    <img src="../../Content/_design/images/logo_wingstreet.png"><h1>Silahkan pilih wingstreet yang diinginkan</h1>
			    </div>
			    <div class="price-group wingstreet">
				    <ul class="clearfix">
					    <li class="menu-list">
						    <label for="pizza-type1">
							    <span><a href="#" class="spin"></a><br><a href="#" class="sfb"></a><a href="#" class="stwt"></a><b class="ttlshare"></b></span>
							    <div class="menu-image">
								    <img src="../../Content/_design/images/price_23.png"><img src="../../Content/_design/images/wings_4.png">
							    </div>
						    </label>
										
						    <input id="pizza-type1" type="radio">
					    </li>
					    <li class="menu-list">
						    <label for="pizza-type1">
							    <span><a href="#" class="spin"></a><br><a href="#" class="sfb"></a><a href="#" class="stwt"></a><b class="ttlshare"></b></span>
							    <div class="menu-image">
								    <img src="../../Content/_design/images/price_40.png"><img src="../../Content/_design/images/wings_8.png">
							    </div>
						    </label>
										
						    <input id="pizza-type1" type="radio">
					    </li>
									
				    </ul>
			    </div>
			    <div class="price-group wingstreet-sauce">
				    <h3>
					    Silahkan pilih kombinasi saus yang diinginkan
				    </h3>
				    <p>
					    Hanya wingstreet 8 potong yang bisa memilih saus kombinasi 2 pilihan rasa
				    </p>
				    <ul class="clearfix">
					    <li class="menu-list">
						    <label for="pizza-topping1">
							    <span><a href="#" class="spin"></a><br><a href="#" class="sfb"></a><a href="#" class="stwt"></a><b class="ttlshare"></b></span>
							    <div class="menu-image">
								    <img src="../../Content/_design/images/logo-wing-bbq.png">
							    </div>
							    <p>
								    Berlumur sauce spicy yang manis pedas.
							    </p>
						    </label>
										
						    <input id="pizza-topping1" type="radio">
					    </li>
					    <li class="menu-list">
						    <label for="pizza-topping2">
							    <span><a href="#" class="spin"></a><br><a href="#" class="sfb"></a><a href="#" class="stwt"></a><b class="ttlshare"></b></span>
							    <div class="menu-image">
								    <img src="../../Content/_design/images/logo-wing-cheese.png">
							    </div>
							    <p>
								    Berlumur sauce spicy yang manis pedas.
							    </p>
						    </label>
										
						    <input id="pizza-topping2" type="radio">
					    </li>
					    <li class="menu-list">
						    <label for="pizza-topping3">
							    <span><a href="#" class="spin"></a><br><a href="#" class="sfb"></a><a href="#" class="stwt"></a><b class="ttlshare"></b></span>
							    <div class="menu-image">
								    <img src="../../Content/_design/images/logo-wing-honey.png">
							    </div>
							    <p>
								    Berlumur sauce spicy yang manis pedas.
							    </p>
						    </label>
										
						    <input id="pizza-topping3" type="radio">
					    </li>
					    <li class="menu-list">
						    <label for="pizza-topping4">
							    <span><a href="#" class="spin"></a><br><a href="#" class="sfb"></a><a href="#" class="stwt"></a><b class="ttlshare"></b></span>
							    <div class="menu-image">
								    <img src="../../Content/_design/images/logo-wing-spicy.png">
							    </div>
							    <p>
								    Berlumur sauce spicy yang manis pedas.
							    </p>
						    </label>
										
						    <input id="pizza-topping4" type="radio">
					    </li>
									
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
				
