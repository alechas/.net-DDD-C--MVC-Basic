<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/PHD3.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>
<%@ Import Namespace="PHD.Session.Classes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="menu-title">
	    <img src= "<%:Url.Content("~/Content/_design/images/about-phd.png")%>">
    </div>
    <div class="content-left">
	    <nav class="nav-content-left">
		    <ul>
			    <li class="active">
				    <a id="menu1" href="<%:Url.Content("~/about/index")%>#target"><span>About Us</span></a>
			    </li>
			    <li>
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
						
						
		    <div class="about-us-container">
			    <h1><%: ViewBag.about.name %></h1>
			    <%= ViewBag.about.text %>
		    </div>
	    </div>
					
	    <div class="content-left-bottom">

	    </div>
    </div>

</asp:Content>
