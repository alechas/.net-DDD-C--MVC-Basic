<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/PHD3.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>
<%@ Import Namespace="PHD.Session.Classes" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="NHibernate.Criterion" %>
<%@ Import Namespace="PHD.Service.ModelService" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Double Pizza
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="menu-title">
		<img src="<%:Url.Content("~/Content/_design/images/hotpromo.png")%>">
	</div>
	<div id="load" class="content-left">
		<nav class="nav-content-left">
			<ul>
				<li>
					<a id="menu1" href="<%:Url.Content("~/menu/promo")%>"><span>Hot Promo</span></a>
				</li>
				<li>
					<a id="menu2" href="<%:Url.Content("~/menu/hemat")%>"><span>Hot Hemat</span></a>
				</li>
                <li class="active">
					<a id="menu5" href="<%:Url.Content("~/menu/DoublePizza")%>"><span>Double Pizza</span></a>
				</li>
				<li>
					<a id="menu3" href="<%:Url.Content("~/menu/hotmenu")%>"><span>Hot Menu</span></a>
				</li>
				<li>
					<a id="menu4" href="<%:Url.Content("~/menu/favorite")%>"><span>My Favorite</span></a>
				</li>
               
			</ul>
		</nav>
        
        <script type="text/javascript" language="javascript">
            function setvalue(id) {
                document.getElementById('hidvalue').value = id;
                $("#formdouble").submit();
            }
            </script>
		<div class="content-left-container">
        <form method="post" id="formdouble">
        <input type="hidden" id="hidvalue" name="hidvalue" value="" />
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
					<ul style="height:539px;widht:620px">
                    <% foreach (var item in ViewBag.menudouble)
                        {%>
					    <li>
                            
                            <div class="inner-whitebox">
								<img src="<%:Url.Content("~" + item.image)%>" width="614" height="370">
							</div>
							<%
                            List<ICriterion> Crit = new List<ICriterion>();
                            Crit.Add(Restrictions.Eq("menu.id", item.Id));
                            Submenu submenu= new SubmenuService().FindByCriteria(Crit);
                            if(submenu!=null) 
                              {%>		
							<div class="menu-text">
								<div class="title">
									<%: item.title%>
								</div>
								<div class="text">
									<%: item.description%>
									<div class="price">
										Rp. <%:String.Format("{0:0,0}",  submenu.price)%>
									</div>
								</div>
							</div>
                            <%--<a href="<%: Url.Content("~/Menu/orderSubmenu/"+submenu.kode) %>">--%>
						    <input type="button" value="Pesan" class="order-button" onclick="setvalue(<%:item.Id %>);">
                            </a>
                            <%} %>
					    </li>
                        <%
                        } %>
					</ul>
					<div class="slider-nav-container">
						<div class="slider-nav"></div>
					</div>								
				</div>							
			</div>
            </form>
         </div>
       
       					
		<div class="content-left-bottom">

		</div>
    </div>
		

				

</asp:Content>
