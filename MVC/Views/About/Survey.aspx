<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/PHD3.Master" Inherits="System.Web.Mvc.ViewPage<PHD.Session.Classes.Saran>" %>
<%@ Import Namespace="PHD.MVC.Helper" %>
<%@ Import Namespace="PHD.Session.Classes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Survey
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% Saran saran = (Saran)ViewBag.saran; %>
				<div class="menu-title">
					 <img src= "<%:Url.Content("~/Content/_design/images/service-input.png")%>">
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
			                <li class="active">
				                <a id="menu3" href="<%:Url.Content("~/about/survey")%>#target"><span>Service Input</span></a>
			                </li>
			                <li>
				                <a id="menu4" href="<%:Url.Content("~/about/career")%>#target"><span>Careers</span></a>
			                </li>
						</ul>
					</nav>
					<div class="content-left-container">
						
						
						<div class="about-us-container clearfix">
							<h1>Service Input</h1>
							<div class="phd-outlet">
								<div class="survey">
									<form method="post">
										<div class="customer-data">
                                             <%if (!Request.IsAuthenticated)
                                               { %>
											<div class="regular">
												<ul>
													<li>
														<label>E-mail</label>
														<%: Html.EditorFor(model => model.email) %>
                                                         <%: Html.ValidationMessageFor(model => saran.email)%>
													</li>
													<li>
														<label>Telephone</label>
													<%: Html.EditorFor(model => model.phone) %>
                                                     <%: Html.ValidationMessageFor(model => saran.phone)%>
													</li>
												</ul>
												<%} %>
											</div>
                                            <%if (Request.IsAuthenticated)
                                              { %>
                                              <% User user = new userHelper().GetUser(Page.User.Identity.Name); %>
											<div class="login clearfix">
												<div class="avatar">
												<img src= "<%:Url.Content("~/Content/_design/images/img-login-user.jpg")%>">
												</div>
												<div class="data">
													<ul>
														<li class="name">
														<%: user.nama %>
														</li>
														<li>
															<span>Email</span> <%:user.email %>
														</li>
														<li>
															<span>Telephone</span> <%:user.telepon %>
														</li>
													</ul>
												</div>
											</div>
                                            <%} %>
										</div>
										<div class="notification">
											1000 karakter
										</div>
										 <%: Html.TextAreaFor(model => model.pesan) %>
                                         <%: Html.ValidationMessageFor(model => model.pesan) %>
										<div class="button-container">
											<input type="submit" value="Kirim Saran" class="greenbtn">
										</div>
									</form>
								</div>

								
							</div>
						</div>
					</div>
					
					<div class="content-left-bottom">

					</div>
				</div>

</asp:Content>
