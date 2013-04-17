<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/PHD3.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>
<%@ Import Namespace="PHD.Session.Classes" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="NHibernate.Criterion" %>
<%@ Import Namespace="PHD.Service.ModelService" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    PHD - Menu Ala Carte 
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<script type="text/javascript">
    function checkWingstreet(idmenu){
        if (idmenu == 3){            
            if ($('input:checkbox[name=modifier1]:checked').length >= 2)
            {
                var sList = "";
                $('input:checkbox[name=modifier1]').each(function () {
                    if (!this.checked){
                         var $this = $(this);
                         $this.prop('disabled', true)
                    }
                });
                $("#lenghtcb").val(true);
                
            }
            else
            {
                if($("#lenghtcb").val() == 'true')
                {
                    $("input:checkbox[name=modifier1]").removeAttr("disabled");
                    $("#lenghtcb").val('false');
                }
                
            }            
        }
    }
   
    function checkEvent(id) {
    //var nilai = document.getElementById("modifier[0]").value;
    var nilai = $('input:radio[name=modifier0]:checked').val();
    if(validate(id)){

    //alert(nilai);
        $.ajax({
            type: 'POST',
            dataType: 'json',
            cache: false,
            url: '<%:Url.Content("~/Menu/CheckEvent/") %>',
            data: {
            pizzatype : nilai,
        },
        success: function (data) {
            result = data;
            if (result != null) {
                //alert('usa');
                document.getElementById("popup").click();
                //$('#popup').trigger('click');
            }
            else {
                $("#MenuUtama").submit(); //$.post(id);
            }
        }
    })
    }
}

function validate(idmenu)
{
    var ret = true;

    if(idmenu == 1){
        if($('input:radio[name=modifier0]:checked').length <= 0){
            alert('Pilih jenis pizza yang anda inginkan.');
            ret = false;
        }
        if($('input:radio[name=modifier1]:checked').length <= 0){
            alert('Pilih topping pizza yang anda inginkan.');
            ret = false;
        }
    }

    if(idmenu == 3){
        if($('input:radio[name=modifier0]:checked').length <= 0){
            alert('Pilih jenis wingstreet yang anda inginkan.');
            ret = false;
        }
        if($('input:checkbox[name=modifier1]:checked').length <= 0){
            alert('Pilih kombinasi saus yang anda inginkan.');
            ret = false;
        }
    }

    return ret;
}
function jumpToAnchor(index, idmenu) {
if (index == 0 && idmenu == 1){
   window.location = String(window.location).replace(/\#.*$/, "") + "#1";
   }
}

</script>
    <div class="menu-title">
		<%--<img src=" <%: Url.Content("~"+"/Content/_design/images/pizzalist.png") %>" >--%>
        <img src="<%: Url.Content("~"+ViewBag.current.logourl) %>"  />
	</div>
	<div class="content-left">
		<nav class="nav-content-left">
			<ul>
				<li>
					<a id="menu1" href="<%: Url.Content("~/menu/promo")%>")"><span>Hot Promo</span></a>
				</li>
				<li>
					<a id="menu2" href="<%: Url.Content("~/menu/hemat")%>"><span>Hot Hemat</span></a>
				</li>
                <li>
					<a id="menu5" href="<%:Url.Content("~/menu/DoublePizza")%>"><span>Double Pizza</span></a>
				</li>
				<li>
					<a id="menu3" href="<%: Url.Content("~/menu/hotmenu")%>"><span>Hot Menu</span></a>
				</li>
				<li>
					<a id="menu4" href="<%: Url.Content("~/menu/favorite")%>"><span>My Favorite</span></a>
				</li>
             

			</ul>
		</nav>
		<div class="content-left-container">
			<nav class="nav-menu">
				<ul>
                <% foreach (var item in ViewBag.menu)
                    {%>
					<li>
						<a href="<%: Url.Content("~"+"/Menu/menuutama/"+item.Id)%>#target">     <%: item.title %></a>
					</li>
                    <%} %>
				</ul>
			</nav>
			<p class="menu-notes">
				<small>Harga dalam .000 Rupiah dan sudah termasuk pajak.</small>
			</p>
			<div class="menu-pizza">
            <% IEnumerable<Modifier> modifiers = (IEnumerable<Modifier>)ViewBag.modifiers;%>
            <% IEnumerable<Submenu> submenu = (IEnumerable<Submenu>)ViewBag.submenu;%>

            <% if (modifiers.Count() != 0) //pake modifier
               {%>
               
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
                                $('html, body').animate({
                                    scrollTop: $('<%= (max == j) ? "#submitbtn" : "#mdf-" + (j + 1)  %>').offset().top
                                }, 'slow', 'swing');   
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
                                    $.ajax({
                                        type: 'POST',
                                        dataType: 'json',
                                        cache: false,
                                        url: '<%:Url.Content("~/Menu/CheckModifier/") %>',
                                        data: {
                                            id_menu:<%= ViewBag.data %>,
                                            kode_modifier: kode_mdf
                                        },
                                        success: function (data) {
                                            result = data;
                                            if (result != null) {
                                                var tmp_a = new Array();
                                                jQuery.each(result, function(i, val) {
                                                    var n = val.split('+');
                                                    var r = n[1].replace(kode_mdf, '');
                                                    if (r.substring(0, 1) == '-') { 
                                                      r = r.substring(1);
                                                    }
                                                    var m = r.split('-');
                                                    if(m[1] == undefined)
                                                        tmp_a.push(r);
                                                    else 
                                                        tmp_a.push(m[0]);
                                                });
                                                
                                                $('input[name=modifier<%= (j + 1) %>]').each(function(i, obj) {
                                                    if(jQuery.inArray($(obj).attr('id'), tmp_a) === -1){   
                                                        $(obj).attr('disabled', 'disabled'); 
                                                        var temp_kode = $(obj).attr('id');
                                                        $('#li-'+temp_kode).attr('style','display:none');       
                                                    } else {
                                                        $(obj).removeAttr("disabled"); 
                                                        var temp_kode = $(obj).attr('id');
                                                        $('#li-'+temp_kode).removeAttr("style");
                                                    }
                                                });
                                            }
                                        }
                                    });
                                <% } %>
                            });
                        <% } %> 
                    });
                </script>
              <form method="post" id="MenuUtama">  
                                        
               <% int i = 0; %>
               <% while (i <= modifiers.Max(x => x.sequence))
                  {%>
                  <%
                List<ICriterion> Crit = new List<ICriterion>();
                Crit.Add(Restrictions.Eq("menu.id", ViewBag.data));
                Crit.Add(Restrictions.Eq("sequence", i));

                Modifier modifiertext = new ModifierService().FindByCriteria(Crit);                            
                %>	<% ArrayList a = new ArrayList();
                     
                       %>
				<div class="price-group" id="mdf-<%: i %>">
                <%if (ViewBag.current.Id == 3 )
                  {
                      if (i == 0 && ViewBag.current.image != "" &&ViewBag.current.image != "no image" && ViewBag.current.image != null)
                      {%> 					
                            <img src="<%: Url.Content("~"+ViewBag.current.image) %>" alt="" />
                            <%}}
                  else
                  { %>
                   <%if (ViewBag.current.image != ""&& ViewBag.current.image != "no image" && ViewBag.current.image != null)
                      {%> 					
                            <img src="<%: Url.Content("~"+ViewBag.current.image) %>" alt="" />
                            <%}%>
                            <%} %><%IEnumerable<Modifier> check = (IEnumerable<Modifier>)ViewBag.modifiers;
                                    
                                     %>
                            <h3><%: modifiertext.text%></h3>
					<ul class="<%: i==0 && ViewBag.data==1 ? "pizza-price-list" :"" %> clearfix">
                         <% foreach (Modifier item in check.OrderBy(x => x.position))
                            {%>
                        <%if (i == item.sequence)
                          { %>
					    <li class="menu-list" id="li-<%:item.kode%>">
							<label for="pizza-type1" >
						   <span><a class="sfb" href="http://www.facebook.com/sharer.php?u=http://www.phd.co.id"></a><a class="stwt" href="http://twitter.com/share?text=An%20Awesome%20Service%20from%20PHD&url=http://www.phd.co.id"></a></a><b class="ttlshare"></b></span>
                                <h4><%: item.name %></h4>
                                <div class="menu-image">
									<img src="<%: Url.Content("~"+item.image) %>" alt="" />
								</div>
							</label>
                            <%if (item.Id == 15 || (item.menu.Id == 3 && item.sequence == 1))
                              {%>
                              <input id="<%:item.kode%>" name="modifier<%:i%>" type="checkbox" value="<%:item.Id %>" onclick="checkWingstreet(<%:item.menu.Id %>)"/>
                            <%}
                              else
                              { %>
							<input id="<%:item.kode%>" name="modifier<%:i%>" type="radio" value="<%:item.Id %>"/>
                            <%} %>
						</li>
                        <%} %>
                        <%} i++; %>						
					</ul>
				</div>
                
                <%} %>
                <input type="hidden" name="box" id="box"/>
                <input type="hidden" name="lenghtcb" id="lenghtcb" value=""/>
				<div class="button-container">
                <input type="button" id="submitbtn" onclick="checkEvent(<%:ViewBag.data %>);" class="order-button" value="Pesan"></input>
				</div>
                </form>
            <%} %>
            <% else // kalau ga ada modifiernya, hanya submenu
               {%>
                <h1>
                    <%if (ViewBag.current.image != null && ViewBag.current.image != "")
                      {%>
                       <img src="<%: Url.Content("~"+ViewBag.current.image) %>" alt="" />
                    <%} %>
			    </h1>
                <% int i = 0;%>
                  
                   <%while (i < submenu.Count())
                     {%>
                     <% 
                         if (i == 0 || submenu.ElementAt<Submenu>(i).prizegroup.Id != submenu.ElementAt<Submenu>(i - 1).prizegroup.Id)
                        {%>
                           <div class="price-group">                         
                         <h2>
                            <img src="<%: Url.Content("~/"+submenu.ElementAt<Submenu>(i).prizegroup.image) %>" alt="" />
				         </h2>
                             <ul class="clearfix">
                     <%} %>
					    <li  style="margin-bottom:20px" class="menu-list">
                                <% string u = Request.Url.AbsoluteUri;
                                   u = Url.Encode(u);
                                   
                                   string textfb = ConfigurationManager.AppSettings["shareFB"].ToString() + " " + submenu.ElementAt<Submenu>(i).name;
                                   //textfb = Url.Encode(textfb);
                                   string texttw = ConfigurationManager.AppSettings["shareTwitter"].ToString() + " " + submenu.ElementAt<Submenu>(i).name;
                                   //texttw = Url.Encode(texttw);
                                %>


						   <span><a class="sfb" href="http://www.facebook.com/sharer.php?s=100
                                    &p[url]=<%:u %>
                                    &p[images][0]=<%: "http://"+Request.Url.Host+Url.Content("~"+submenu.ElementAt<Submenu>(i).image) %>
                                    &p[title]=PHD
                                    &p[summary]=<%:textfb%>">
                                    </a>
                                    <a class="stwt" href="http://twitter.com/share?url=<%= u %>&text=<%=texttw %>"></a>
                                    <a class="spin" data-pin-config="above" href="//pinterest.com/pin/create/button/?url=<%=u %>F&media=<%= "http://"+Request.Url.Host+Url.Content("~"+submenu.ElementAt<Submenu>(i).image) %>&description=<%:textfb %>" data-pin-do="buttonPin" >
                                    </a>
                                    <b class="ttlshare"></b>
                                    </span>

						    <div class="menu-image">
                                    <img src="<%: Url.Content("~"+submenu.ElementAt<Submenu>(i).image) %>"  alt=""  />
						    </div>
						    <h4><%:submenu.ElementAt<Submenu>(i).name%></h4>
						    <p><%:submenu.ElementAt<Submenu>(i).text%></p>
						    <a href="<%: Url.Content("~/Menu/orderSubmenu/"+submenu.ElementAt<Submenu>(i).kode) %>">
                            <input  type="button" class="order-button" value="pesan"></a>
					    </li>
                     <% i++;
                    if (i==submenu.Count() || submenu.ElementAt<Submenu>(i).prizegroup.Id != submenu.ElementAt<Submenu>(i-1).prizegroup.Id)
                        {%>
                        </ul>
                        </div>
                    <%} %>
                <% 
                     }
                   } %>
			</div>
		</div>
					
		<div class="content-left-bottom">
        <div style="display:none">
        <a id="popup" class="ir fancybox-area fancybox.ajax"
        href="<%:Url.Content("~/Menu/PickBox/"+ViewBag.data) %>"><span>asdf</span></a>
        </div>
		</div>
	</div>
</asp:Content>
