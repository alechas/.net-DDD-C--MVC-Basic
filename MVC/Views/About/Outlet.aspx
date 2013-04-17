<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/PHD3.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>
<%@ Import Namespace="PHD.MVC.Helper" %>
<%@ Import Namespace="PHD.Session.Classes" %>
<%@ Import Namespace=" System.Collections.Generic" %>
<%@ import Namespace="MvcPaging" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Outlet
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<% object routeValues = new { dbaid = "", area = Request["area"], sord = Request["desc"], end_date = Request["end_date"], status_filter = Request["status_filter"] }; %>
<% var total = (int)ViewData["TotalCount"]; %>
<% var pageSize = (int)ViewData["PageSize"]; %>
<% var Current = (int)ViewData["current"]; %>

<% IEnumerable<Outlet> outlets = (IEnumerable<Outlet>)ViewBag.outlets; %>
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
							<div class="phd-outlet">
                            <% using (Html.BeginForm("outlet", null, FormMethod.Get))
                               { %>
								<select name="area" onchange="this.form.submit()">
									<option value="-1">
										Silahkan pilih wilayah Anda
									</option>
                                    <%foreach (var area in ViewBag.data_area)
                                      { %>
                                      <% string temp = ""; if (area.Id.ToString() == Request["area"]) { temp = "selected=" + "'true'"; }%>

                                    <option <%: temp %> value="<%: area.Id %>"><%: area.name%></option>
                                    <% } %>
								</select>
                                <% } %>
								<div class="map-lists">
									
									<ul class="left">
                                    <%for (int i = 0; i < 3 && (i < outlets.Count<Outlet>()); i++)
                                      {
                                        
                                    %>
                                       <li>
											<div class="title">
												<%: outlets.ElementAt<Outlet>(i).name%><a href="<%:Url.Content("~/About/Map/"+outlets.ElementAt<Outlet>(i).Id) %>"><input type="button" value="Map" class="greenbtn"></a>
											</div>
											<p>
												<%= outlets.ElementAt<Outlet>(i).address%>
											</p>
											<p>
												Jam Operasional<br>
												Senin - Minggu <%: outlets.ElementAt<Outlet>(i).WorkingTimeMondayStart%> - <%: outlets.ElementAt<Outlet>(i).WorkingTimeSundayEnd%>  WIB
											</p>
											<p>
												Jam Pesan Online<br>
												Senin - Minggu <%: outlets.ElementAt<Outlet>(i).DeliveryTimeMondayStart%> - <%: outlets.ElementAt<Outlet>(i).DeliveryTimeSundayEnd%> WIB
											</p>
										</li>

                                   <%} %>
									</ul>
									<ul>
										<%for (int i = 3; i < 6 && (i < outlets.Count<Outlet>()); i++)
                                      {
                                        
                                    %>
                                       <li>
											<div class="title">
												<%: outlets.ElementAt<Outlet>(i).name%><a href="<%:Url.Content("~/About/Map/"+outlets.ElementAt<Outlet>(i).Id) %>"><input type="button" value="Map" class="greenbtn"></a>
											</div>
											<p>
												<%= outlets.ElementAt<Outlet>(i).address%>
											</p>
											<p>
												Jam Operasional<br>
												Senin - Minggu <%: outlets.ElementAt<Outlet>(i).WorkingTimeMondayStart%> - <%: outlets.ElementAt<Outlet>(i).WorkingTimeSundayEnd%>  WIB
											</p>
											<p>
												Jam Pesan Online<br>
												Senin - Minggu <%: outlets.ElementAt<Outlet>(i).DeliveryTimeMondayStart%> - <%: outlets.ElementAt<Outlet>(i).DeliveryTimeSundayEnd%> WIB
											</p>
										</li>

                                   <%} %>
										
									</ul>
								</div>
                           
							</div>
						</div>
                             <div class="pager" style="align:center">
<%= Html.Pager(pageSize,Current,total,routeValues) %>
</div>
					</div>
					
					<div class="content-left-bottom">

					</div>
				</div>

</asp:Content>
