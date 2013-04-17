<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/PHD3.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    QuickApply
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

				<div class="menu-title">
					<img src= "<%:Url.Content("~/Content/_design/images/career.png")%>">
				</div>
				<div class="content-left">
					<nav class="nav-content-left">
						<ul>
							<li>
				                <a id="menu1" href="<%:Url.Content("~/about/index")%>#target"><span>About Us</span></a>
			                </li>
			                <li>
				                <a id="menu2" href="<%:Url.Content("~/about/outlet")%>#target"><span>PHD Outlet</span></a>
			                </li>
			                <li>
				                <a id="menu3" href="<%:Url.Content("~/about/survey")%>#target"><span>Service Input</span></a>
			                </li>
			                <li class="active">
				                <a id="menu4" href="<%:Url.Content("~/about/career")%>#target"><span>Careers</span></a>
			                </li>
						</ul>
					</nav>
					<div class="content-left-container">
						
						
						<div class="about-us-container clearfix">
							<div class="career">
								<h1>Quick Apply</h1>
								<p>
									Mail to CSC@phd.co.id
								</p>
								<form>
									<textarea></textarea>
									<div class="button-container">
										<input type="submit" class="greenbtn" value="Apply">
									</div>
								</form>
								
							</div>
						</div>
					</div>
					
					<div class="content-left-bottom">

					</div>
				</div>

</asp:Content>
