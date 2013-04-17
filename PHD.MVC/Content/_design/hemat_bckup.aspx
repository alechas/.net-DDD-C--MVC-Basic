<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/PHD3.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>
<%@ Import Namespace="PHD.Session.Classes" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="NHibernate.Criterion" %>
<%@ Import Namespace="PHD.Service.ModelService" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Hemat
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript" language="javascript">
        function setvalue(position, sequence) {
            var hidden = Number(sequence) + Number(position) + 1;
            $("#hidden").val(hidden);
        }
    </script>
    <input type="hidden" id="hidden" name="hidden" />
    <div class="menu-title">
		<img src="<%:Url.Content("~/Content/_design/images/hothemat.png")%>">
	</div>
	<div class="content-left">
		<nav class="nav-content-left">
			<ul>
				<li>
					<a id="menu1" href="<%:Url.Content("~/menu/promo")%>"><span>Hot Promo</span></a>
				</li>
				<li class = "active">
					<a id="menu2" href="<%:Url.Content("~/menu/hemat/7")%>"><span>Hot Hemat</span></a>
				</li>
				<li>
					<a id="menu3" href="<%:Url.Content("~/menu/hotmenu")%>"><span>Hot Menu</span></a>
				</li>
				<li>
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
			<div class="hot-hemat-container">
							
				<div class="menu-paket-nav">
					<ul>
                    <% foreach (var item in ViewBag.menuhemat)
                    {%>
					<li id="<%:item.title %>">
						<a href="<%:Url.Content("~/menu/hemat/")%><%:item.Id%>"><span><%: item.title %></span></a>
					</li>
                    <%} %>
					</ul>
				</div>
				<div class="menu-container" id="<%: ViewBag.menucurrent.nama %>">
					<div class="title">
						<%: ViewBag.menucurrent.nama%>
					</div>
					<ul class="menu-list">
						<% Response.Write(ViewBag.menucurrent.description);%>
                        <%: ViewBag.modifiers[1].image %>
					</ul>
					<div class="price">
						Rp110.000,00
					</div>
                    <% IEnumerable<Modifier> modifiers = (IEnumerable<Modifier>)ViewBag.modifiers;%>
                    <% IEnumerable<Submenu> submenu = (IEnumerable<Submenu>)ViewBag.submenu;%>
					<div class="menu-slide-container">
						<ul class="menu-slide-list">
                        <% int i = 0; %>
                        <% while (i <= modifiers.Max(x => x.sequence))
                           {%>
                           <%
                               List<ICriterion> Crit = new List<ICriterion>();
                               Crit.Add(Restrictions.Eq("menu.id", ViewBag.data));
                               Crit.Add(Restrictions.Eq("sequence", i));
                               Modifier modifiergroup = new ModifierService().FindByCriteria(Crit);
                                        %>
                           <li <%= modifiergroup.htmlliprop %> >
								<div class="title">
							        <%: modifiergroup.text %>
								</div>
                                <div class="<%:modifiergroup.htmlclass%> menu-white-box">
                                	<ul class="slide">
                                     <% foreach (var item in ViewBag.modifiers)
                                        { %>
                                     <%if (i == item.sequence)
                                       { %>
                                        <li><div class="title">
                                            <%: item.name %>
											</div> 
                                            <img src= " <%: Url.Content("~"+item.image) %>">
                                            <%if (modifiergroup.htmlclass == "nav-choice")
                                              {%>
                                            <p><a href='<%: item.htmlidref %>' class='greenbtn' onclick='setvalue(<%:item.position %>, <%:item.sequence %>)'>Pilih</a></p>
                                            <% }
                                              else
                                              { %>
                                                <input id="modifier[<%:i%>]" name="modifier[<%:i%>]" type="radio" value="<%:item.Id %>">
                                            <%} %>
                                        </li>
                                        
                                    <%}
                                      } i++;%>
                                        
                                    </ul>
                                    <% /*if (modifiergroup.htmlclass != "nav-choice") {%>
                                    <input type='button' value='Pilih' class='greenbtn'>
                                    <% } */%>
								</div>
							</li>
                            <%
                              
                            } %>
                                 
						</ul>
									
					</div>

				</div>
							
				<input type="submit" value="Pesan" class="order-button">
							
			</div>
		</div>
					
		<div class="content-left-bottom">

		</div>
	</div>
				

</asp:Content>
