<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/PHD3.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>
<%@ Import Namespace="PHD.Session.Classes" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="NHibernate.Criterion" %>
<%@ Import Namespace="PHD.Service.ModelService" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Hemat
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
   
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
					<a id="menu2" href="<%:Url.Content("~/menu/hemat")%>"><span>Hot Hemat</span></a>
				</li>
                <li>
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
            <form method="post" name="hothemat" onsubmit="return validateForm(<%:ViewBag.data %>);">
             <script type="text/javascript" language="javascript">
             $(document).ready(function () {
             showmenu();
             });
                function setvalue(id, index, idelement) {
                    var radio = document.getElementById(idelement);
                    var value = id;
                    radio.value = id;
                    radio.checked = true
                    //if (<%:ViewBag.data %> == 8)
                        showmenu();
                }
                function showmenu() {
                        $('.nav-choice2 li a').click(function () {
                            var link = $(this).attr('href');
                            //alert(link);
                            console.log(link);
                            
                            $('.menu-slide-list > li#drinks').addClass("hidden");
                            $('.menu-slide-list > li#drinks').removeClass("chosen");
                            $('.menu-slide-list > li#snacks').addClass("hidden");
                            $('.menu-slide-list > li#snacks').removeClass("chosen");
                            
                            $('.menu-slide-list > li' + link).removeClass("hidden");

                            $('.menu-slide-list > li' + link).addClass("chosen");
                            $('.menu-slide-list > li' + link + ' .slide').css('width', '610px !important');
                            $('.menu-slide-list > li' + link + ' .slide').movingBoxes({
                                width: 610,
                                startPanel: 1,
                                reducedSize: 0.6,
                                fixedHeight: true,
                                initAnimation: true,
                                stopAnimation: false,
                                hashTags: false,
                                wrap: true,
                                buildNav: false,
                                navFormatter: function (index, panel) {
                                    return "&#9679;" // bullets
                                },
                                easing: 'swing',
                                speed: 500,
                                delayBeforeAnimate: 0,
                                currentPanel: 'current',
                                tooltipClass: 'tooltip',
                                disabled: 'disabled'
                            });
                        });

                        $('.nav-choice3 li a').click(function () {
                            var link = $(this).attr('href');
                            //alert(link);
                            console.log(link);

                            $('.menu-slide-list > li#pasta').addClass("hidden");
                            $('.menu-slide-list > li#pasta').removeClass("chosen");
                            $('.menu-slide-list > li#ricevaganza').addClass("hidden");
                            $('.menu-slide-list > li#ricevaganza').removeClass("chosen");

                            $('.menu-slide-list > li' + link).removeClass("hidden");
                             $('.menu-slide-list > li' + link).addClass("chosen");
                            
                            $('.menu-slide-list > li' + link + ' .slide').css('width', '610px !important');
                            $('.menu-slide-list > li' + link + ' .slide').movingBoxes({
                                width: 610,
                                startPanel: 1,
                                reducedSize: 0.6,
                                fixedHeight: true,
                                initAnimation: true,
                                stopAnimation: false,
                                hashTags: false,
                                wrap: true,
                                buildNav: false,
                                navFormatter: function (index, panel) {
                                    return "&#9679;" // bullets
                                },
                                easing: 'swing',
                                speed: 500,
                                delayBeforeAnimate: 0,
                                currentPanel: 'current',
                                tooltipClass: 'tooltip',
                                disabled: 'disabled'
                            });
                        });
	            }
                function validateForm(idhemat) {
                    var ret = true;

                    if (idhemat == 7) {
                        if ($('input:radio[name=modifier0]:checked').length <= 0) {
                            alert('Pilih topping Original Pizza Regular');
                            ret = false;
                        }
                        if ($('input:radio[name=modifier1]:checked').length <= 0) {
                            alert('Pilih Pasta atau Ricevaganza');
                            ret = false;
                        }
                        if ($('input:radio[name=modifier2]:checked').length <= 0 && $('input:radio[name=modifier1]:checked').val() == 53 ) {
                            alert('Pilih Pasta');
                            ret = false;
                        }
                        if ($('input:radio[name=modifier3]:checked').length <= 0 && $('input:radio[name=modifier1]:checked').val() == 54) {
                            alert(' Pilih Ricevaganza ');
                            ret = false;
                        }
                        if ($('input:radio[name=modifier5]:checked').length <= 0) {
                            alert('Pilih Wingstreet');
                            ret = false;
                        }
                    }

                    if (idhemat == 8) {
                        if ($('input:radio[name=modifier0]:checked').length <= 0) {
                            alert('Pilih topping Original Pizza Regular');
                            ret = false;
                        }
                        if ($('input:radio[name=modifier2]:checked').length <= 0 && $('input:radio[name=modifier1]:checked').val() == 42) {
                            alert('Pilih Snacks ');
                            ret = false;
                        }
                        if ($('input:radio[name=modifier3]:checked').length <= 0 && $('input:radio[name=modifier1]:checked').val() == 43) {
                            alert('Pilih 2 Lite Drinks');
                            ret = false;
                        }
                        if ($('input:radio[name=modifier5]:checked').length <= 0 && $('input:radio[name=modifier4]:checked').val() == 99) {
                            alert('Pilih Pasta');
                            ret = false;
                        }
                        if ($('input:radio[name=modifier6]:checked').length <= 0 && $('input:radio[name=modifier4]:checked').val() == 100) {
                            alert(' Pilih Ricevaganza ');
                            ret = false;
                        }
                    }

                    if (idhemat == 9) {
                        if ($('input:radio[name=modifier0]:checked').length <= 0) {
                            alert('Pilih topping Original Pizza Regular');
                            ret = false;
                        }
                        if ($('input:radio[name=modifier1]:checked').length <= 0) {
                            alert('Pilih Snacks');
                            ret = false;
                        }
                        if ($('input:radio[name=modifier2]:checked').length <= 0) {
                            alert('Pilih Minuman 1');
                            ret = false;
                        }
                        if ($('input:radio[name=modifier3]:checked').length <= 0) {
                            alert('Pilih Minuman 2');
                            ret = false;
                        }
                    }
                    if (idhemat == 10) {
                        if ($('input:radio[name=modifier0]:checked').length <= 0) {
                            alert('Pilih topping Original Pizza Regular');
                            ret = false;
                        }
                        if ($('input:radio[name=modifier1]:checked').length <= 0) {
                            alert('Pilih Minuman');
                            ret = false;
                        }
                        if ($('input:radio[name=modifier2]:checked').length <= 0) {
                            alert('Pilih Wingstreet');
                            ret = false;
                        }
                    }

                    return ret;
                }
                function validate(id) {
                    var ret = true;
                    alert('yakin?');
                    return ret;
                }
            </script>

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
				<div class="menu-container" id="<%: ViewBag.menucurrent.nama %>">
					<div class="title">
						<%: ViewBag.menucurrent.nama%>
					</div>
					<ul class="menu-list">
						<% Response.Write(ViewBag.menucurrent.description);%>
					</ul>
					<div class="price">
						Rp.<%:String.Format("{0:0,0}", ViewBag.submenucurrent.price) %> 
					</div>
                    <% IEnumerable<Modifier> modifiers = (IEnumerable<Modifier>)ViewBag.modifiers;%>
                    <% IEnumerable<Submenu> submenu = (IEnumerable<Submenu>)ViewBag.submenu;%>
                    <script type="text/javascript">
                    $(document).ready(function () {      
                        function ArrayUnique(a) {
                            var temp = {};
                            for (var i = 0; i < a.length; i++)
                                temp[a[i]] = true;
                            var r = [];
                            for (var k in temp)
                                r.push(k);
                            return r;
                        } 
                           
                        <% int max = modifiers.Max(x => x.sequence); %>    
                        <% for (int j = 0; j <= max; j++) {%>
                            var selMdf<%= j %> = null;
                            $('input[name=modifier<%= j %>]').click(function () {
                                selMdf<%= j %> = $(this).attr('id');
                                if ($('[name=mdf-'+<%: (j + 1)  %>+']').attr("class") == 'hidden' ){
                                    $('html, body').animate({
                                        scrollTop: $('<%= (max == j) ? "#submitbtn" : "[name=mdf-" + (j + 2) + "]"%>').offset().top
                                    }, 'slow', 'swing');   
                                } 
                                else
                                {
                                    $('html, body').animate({
                                        scrollTop: $('<%= (max == j) ? "#submitbtn" : "[name=mdf-" + (j + 1) + "]"%>').offset().top
                                    }, 'slow', 'swing');   
                                }
                                <% if(max == j) { %> 
                                    $('#submitbtn').focus();
                                <% }  else {%>  
                                    var selMdf = new Array();  
                                    <% for(int k = 0; k <=j; k++) { %>   
                                        selMdf.push(selMdf<%= k %>);
                                    <% } %>    
                                    var kode_mdf = '';
                                    var length = selMdf.length;
                                    for (var i = 0; i < length; i++) {
                                        kode_mdf += selMdf[i] + (((length - 1) != i) ? '-' :'');
                                    }
                                    
                                <% } %>
                            });
                        <% } %> 
                    });
                </script>
					<div class="menu-slide-container">
						<ul class="menu-slide-list">
                        <% int i = 0; %>
                        <% if (modifiers.Count() > 0)
                        {
                            while (i <= modifiers.Max(x => x.sequence))
                           {%>
                           <%
                               List<ICriterion> Crit = new List<ICriterion>();
                               Crit.Add(Restrictions.Eq("menu.id", ViewBag.data));
                               Crit.Add(Restrictions.Eq("sequence", i));
                               Modifier modifiergroup = new ModifierService().FindByCriteria(Crit);
                               string txtchecked = "";
                            %>

                           <li <%= modifiergroup.htmlliprop %> name="mdf-<%: i %>">
								<div class="title">

							        <%: modifiergroup.text %>
								</div>
                                <div class="<%:modifiergroup.htmlclass%> menu-white-box">
                                	<ul class="slide">
                                    <%  IEnumerable<Modifier> check = (IEnumerable<Modifier>) ViewBag.modifiers ;
                                        ArrayList list = new ArrayList();
                                        ArrayList listgabung = new ArrayList{74,76,77,78,79,80,148,150,151,153,154,155};//wingstreet
                                    %>

                                     <% foreach (Modifier item in check.OrderBy(x=>x.position))
                                        { %>
                                     <%if (item.sequence == i && !listgabung.Contains(item.Id))
                                       { 
                                            if(item.position==0) 
                                            {
                                                txtchecked = "checked";
                                            } 
                                            else 
                                            {
                                                txtchecked = null;
                                            }
                                        %>
                                        <li>
                                            <label>
                                                <div class="title">
                                                    <%: item.name %>
											    </div> 
                                                <img src= " <%: Url.Content("~"+item.image) %>">
                                            </label>
                                           <% int temp = check.Count(x => x.sequence == i); %>

                                          
                                            <%if (modifiergroup.htmlclass == "nav-choice" || modifiergroup.htmlclass == "nav-choice2" || modifiergroup.htmlclass == "nav-choice3")
                                              {%>
                                            <p><a href='<%: item.htmlidref %>' class='greenbtn' onclick="setvalue(<%:item.Id %>, <%: i%>, 'modifier[<%:i %>]')">Pilih</a></p>
                                            <input id="modifier[<%:i%>]" name="modifier<%:i%>" type="radio" value="<%:item.Id %>" class="hidden" >
                                            <% }
                                              else
                                              { %>
                                                
                                              <div <%: temp == 1 ? "style=display:none" : "" %>>
                                                   <input id="modifier[<%:i%>]" name="modifier<%:i%>" type="radio" value="<%:item.Id %>" <%: temp == 1 ? "checked" :""%> >
                                              </div>
                                                
                                            <%} %>
                                        </li>
                                        
                                    <%}
                                    else
                                    {
                                        if(listgabung.Contains(item.Id) && item.sequence == i)
                                        {
                                            list.Add(item.Id);
                                        }
                                    }
                                    }
                                      %>
                                        
                                      <%  if(list.Count>0)//cek wingstreet
                                      { 
  
                                        Modifier item = new ModifierService().FindBy((int)list[0]);
                                      %>
                                      <li>
                                            <label>
                                                <div class="title">
                                                 Wingstreet Kombinasi
											    </div> 
                                                <img src= " <%: Url.Content("~"+item.image) %>">
                                            </label>
                                           <% int temp = check.Count(x => x.sequence == i); %>

                                       
                                            <% foreach(int koleksi in list)
                                                { Modifier anak = new ModifierService().FindBy(koleksi);
                                            %>
                                              <input id="modifier[<%:i%>]" name="modifier<%:i%>" type="radio" value="<%:anak.Id %>"> <%:anak.name %> <br/>
                                           <%} %>
                                        </li>
                                      <%} %>                                 
                                      </ul><% i++;
                                      }%>
                                    <% /*if (modifiergroup.htmlclass != "nav-choice") {%>
                                    <input type='button' value='Pilih' class='greenbtn' onclick="validateForm(<%:ViewBag.data %>)">
                                    <% } */%>
								</div>
							</li>
                            <%
                            } %>        
						</ul>								
					</div>
				</div>			
				<input type="submit" id="submitbtn" value="Pesan" class="order-button">		
			</div>
            </form>
		</div>
					
		<div class="content-left-bottom">

		</div>
	</div>
				

</asp:Content>
