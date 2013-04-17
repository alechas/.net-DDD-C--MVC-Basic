<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/PHD3.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>
<%@ Import Namespace="PHD.Session.Classes" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="NHibernate.Criterion" %>
<%@ Import Namespace="PHD.Service.ModelService" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    HematUpgrade
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="menu-title">
		<img src="<%:Url.Content("~/Content/_design/images/hothemat.png") %>">
	</div>
	<div class="content-left">
		<nav class="nav-content-left">
			<ul>
				<li>
					<a id="menu1" href="<%:Url.Content("~/menu/promo")%>"><span>Hot Promo</span></a>
				</li>
				<li class = "active">
					<a id="menu2" href="<%:Url.Content("~/menu/hemat")%>"><span>Hot Hemat</span></a>
				</li>
                <li>
					<a id="menu5" href="<%:Url.Content("~/menu/DoublePizza")%>"><span>Double Pizza</span></a>
				</li>
				<li>
					<a id="menu3" href="<%:Url.Content("~/menu/hotmenu")%>"><span>Hot Menu</span></a>
				</li>
				<li >
					<a id="menu4" href="<%:Url.Content("~/menu/favorite")%>"><span>My Favorite</span></a>
				</li>
                

			</ul>
		</nav>
        <form method="post" name="hothematupgrade" onsubmit="return validateForm();">
        <script language="javascript">
            function validateForm() {
                var ret = true;

                if ($('input:radio[name=upgradepizza]:checked').length <= 0) {
                    alert('Pilih tipe upgrade yang anda inginkan');
                    ret = false;
                }
                
                return ret;
            }
        </script>
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
			<div class="hot-hemat-container">
							
				<div class="menu-paket-nav">
					<ul>
                    <% foreach (var item in ViewBag.menuhemat)
                    {%>
					<li id="<%:item.title %>">
						<a href="<%:Url.Content("~/menu/hemat?idhemat=")%><%:item.Id%>"><span><%: item.title %></span></a>
					</li>
                    <%} %>
					</ul>
				</div>
				<div class="menu-container" id="paket-a">
					<div class="title">
						<%: ViewBag.menucurrent.nama%>
					</div>
					<ul class="menu-list">
						<% Response.Write(ViewBag.menucurrent.description);%>
					</ul>
					<div class="price">
						Rp.<%:String.Format("{0:0,0}", ViewBag.submenucurrent.price) %> 
					</div>
					<div class="menu-slide-container">
						<ul class="menu-slide-list">
							<li>
								<div class="title">
									Upgrade Pizza
								</div>
								<div class="menu-white-box upgrade">
									<table>
										<tr>
                                         <% foreach (var item in ViewBag.submenuall)
                                            {%>
                                            <td>
												<% if (item.kodejenis == "OR/R")
                                                   Response.Write(item.text);%>
                                                   <img src="<%: Url.Content("~"+item.image) %>">
                                                <% if (item.kodejenis != "OR/R")
                                                   {%>
                                                <p><%:item.text%></p>
                                                <%} %>
                                                <input id="upgradepizza" name="upgradepizza" type="radio" value="<%: item.Id %>" >
                                                <% if (item.kodejenis == "OR/R")
                                                   {  %>
                                                   <label>Tidak</label>
											    <%}%>
                                                
											</td>
                                            <%} %>
										</tr>
									</table>
												
								</div>
							</li>
										
						</ul>
									
					</div>

				</div>
							
				<input type="submit" value="Pesan" class="order-button">
							
			</div>
		</div>
        </form>					
		<div class="content-left-bottom">

		</div>
	</div>
				

</asp:Content>
