<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/PHD3.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Map
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


				<div class="menu-title">
					<img src= "<%:Url.Content("~/Content/_design/images/phd-outlet.png")%>">
				</div>
				<div class="content-left">
					<nav class="nav-content-left">
						<ul>
							<li>
				                <a id="menu1" href="<%:Url.Content("~/about/index")%>#target"><span>About Us</span></a>
			                </li>
			                <li class="active">
				                <a id="menu2" href="<%:Url.Content("~/about/outlet")%>#target"><span>PHD Outlet</span></a>
			                </li>
			                <li>
				                <a id="menu3" href="<%:Url.Content("~/about/survey")%>#target"><span>Service Input</span></a>
			                </li>
			                <li>
				                <a id="menu4" href="<%:Url.Content("~/about/career")%>#target"><span>Careers</span></a>
			                </li>
						</ul>
					</nav>
					<div class="content-left-container">
						
						
						<div class="about-us-container clearfix">
							<h1>PHD Outlet</h1>
                             <%: Html.ActionLink("Back To Outlet", "outlet")%>

							<div class="phd-outlet">

								<div class="google-map" id="google-map">

								</div>
							</div>
						</div>
					</div>
					
					<div class="content-left-bottom">

					</div>
				</div>



    <script type="text/javascript">

    function initialize(lat,lang,map_canvas) {
	var myLatlng = new google.maps.LatLng(lat,lang);
	var mapOptions = {
		zoom: 17,
		center: myLatlng,
		mapTypeId: google.maps.MapTypeId.ROADMAP
	}
 
	var map = new google.maps.Map(document.getElementById(map_canvas), mapOptions);

	var image = '<%:Url.Content("~/Content/_design/images/img-area-pin.png")%>';
	var myLatLng = new google.maps.LatLng(lat,lang);
	var beachMarker = new google.maps.Marker({
		position: myLatLng,
		map: map,
		icon: image
		});
	}
		initialize(<%:ViewBag.outlet.map %>,"google-map");
	</script>
</asp:Content>
