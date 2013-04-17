<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/PHD3.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Point
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<script type="text/javascript" language="javascript">
    function setvalue(id) {
        var hidden = id;
        $("#idreedem").val(hidden);
    }
    </script>
    <input type="hidden" id="idreedem" name="idreedem" />
				<div class="menu-title">
	                <img src= "<%:Url.Content("~/Content/_design/images/p-addict.png")%>" />
				</div>
				<div class="content-left">
					<nav class="nav-content-left">
						<ul>
                            <li>
								<a id="menu1" href="<%:Url.Content("~/paddict")%>"><span>My Profile</span></a>
							</li>
							<li>
								<a id="menu2" href="<%:Url.Content("~/paddict/orderhistory")%>"><span>Order History</span></a>
							</li>
							<li class="active">
								<a id="menu3" href="<%:Url.Content("~/paddict/point")%>"><span>Points</span></a>
							</li>
						</ul>
					</nav>
					<div class="content-left-container">
						
						<h1>Points</h1>
						<div class="about-us-container clearfix">
							<div class="p-addict">
								<div class="customer-data">
									<div class="login clearfix">
										<div class="avatar">
                                        <%if (ViewBag.usercurrent.profpic!="" && ViewBag.usercurrent.profpic != null) {%>
											<img src="<%: Url.Content("~"+ViewBag.usercurrent.profpic) %>">
                                            <%} else{ %>
                                            <img src="<%:Url.Content("~/Content/_design/images/img-login-user.jpg")%>">
                                            ")
                                            <%} %>
										</div>
										<div class="data">
											<ul>
												<li class="name">
													<%: ViewBag.usercurrent.nama %>
												</li>
												<li>
													<span>Email</span> <%: ViewBag.usercurrent.email %>
												</li>
												<li>
													<span>Telephone</span> <%: ViewBag.usercurrent.telepon %>
												</li>
											</ul>
										</div>
									</div>
								</div>

								<div class="points">
                                <form method="post">
									<div class="amounts">
										<h2>Points</h2>
										<p>
											<%: ViewBag.usercurrent.point %>
										</p>
									</div>
									<div class="redeem-points">
                                    
										<h2>Redeem Points</h2>
										<ul class="clearfix">
                                        <% foreach (var item in ViewBag.reedemall)
                                        {%>
					                    <li>
                                            <p> 
                                                <img src=" <%: Url.Content("~"+item.image) %>" alt="" />
                                            </p>
                                            <%: item.point %>
						                   <p><input type="submit" class="greenbtn" value="Tukar Poin" onclick="setvalue(<%:item.Id %>)"></p>
					                    </li>
                                        <%} %>											
											<li>
												
												<p>
													<img src="../../Content/_design/images/example-bb.png">
												</p>
												10 point
												<p><input type="submit" class="greenbtn" value="Tukar Poin"></p>
												
											</li>
											<li>
												
												<p>
													<img src="../../Content/_design/images/example-bb.png">
												</p>
												10 point
												<p><input type="button" class="greenbtn" value="Tukar Poin"></p>
												
											</li>
											<li>
												
												<p>
													<img src="../../Content/_design/images/example-bb.png">
												</p>
												10 point
												<p><input type="button" class="greenbtn" value="Tukar Poin"></p>
												
											</li>
											<li>
												
												<p>
													<img src="../../Content/_design/images/example-bb.png">
												</p>
												10 point
												<p><input type="button" class="greenbtn" value="Tukar Poin"></p>
												
											</li>
										</ul>
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
