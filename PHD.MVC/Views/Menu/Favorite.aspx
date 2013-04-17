<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/PHD3.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>
<%@ Import Namespace="PHD.MVC.Helper" %>
<%@ Import Namespace="PHD.Session.Classes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Favorite
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="menu-title">
		<img src="<%:Url.Content("~/Content/_design/images/ricevaganzatittle.png")%>">
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
						<a href="<%:Url.Content("~/Menu/Menuutama/")%><%:item.Id%>"><%: item.title %></a>
					</li>
                    <%} %>
				</ul>
			</nav>
            <p class="menu-notes">
				<small>Harga dalam .000 Rupiah dan sudah termasuk pajak.</small>
			</p>
            <form method="post">
            <input type = "hidden" id = "hidval" name = "hidval" />
            <script type="text/javascript" language="javascript">
                function SetValue(id) {
                    document.getElementById('hidval').value = id;
                    //alert(document.getElementById('hidval').value);
                }
                function validateForm(form) {
                    //alert('yakin?');
                }
            </script>
			<div class="myfavorite">
				<h1>
					My Favorite
				</h1>
				<ul class="fave-lists">
                	<li>
                    <%foreach (var sm in ViewBag.submenuordered)
                      {
                          int count = 0;
                          %>
                      <% foreach (var os in ViewBag.ordersubmenuall)
                         { %>
                         <% if (os.id_submenu == sm.Id)
                            {
                                count = count + 1; 
                            }
                         }%>
                        <div class="data-wrapper clearfix">
                            <% if (sm.menu.Id != 1 && sm.menu.Id != 3)
                               { %>
							<img src="<%:Url.Content("~"+ sm.image)%>">
                            <% }%>

							<div class="right">
								<div class="title">
									<%: sm.name %>
								</div>
								<input class="greenbtn" type="submit" value="Pesan" onclick="SetValue(<%:sm.Id %>)">
							</div>						
						</div> 
                        <div class="order">
							<%: count%>x Order <img src="<%:Url.Content("~/Content/_design/images/star.png")%>">
						</div>		
                      <%}%>						
					</li>
				</ul>
			</div>
            </form>			
		</div>
					
		<div class="content-left-bottom">

		</div>
	</div>
				

</asp:Content>
