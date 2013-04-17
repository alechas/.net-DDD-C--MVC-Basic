<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/PHD3.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>
<%@ Import Namespace="PHD.Session.Classes" %>
<%@ Import Namespace="PHD.Service.ModelService" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    OrderHistory
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

				<div class="menu-title">
										<img src= "<%:Url.Content("~/Content/_design/images/p-addict.png")%>" />
				</div>
				<div class="content-left">
					<nav class="nav-content-left">
						<ul>
							<li>
								<a id="menu1" href="<%:Url.Content("~/paddict")%>"><span>My Profile</span></a>
							</li>
							<li class="active">
								<a id="menu2" href="<%:Url.Content("~/paddict/orderhistory")%>"><span>Order History</span></a>
							</li>
							<li>
								<a id="menu3" href="<%:Url.Content("~/paddict/point")%>"><span>Points</span></a>
							</li>
						</ul>
					</nav>
					<div class="content-left-container">
						
						<h1>Order History</h1>
						<div class="about-us-container clearfix">
							<div class="p-addict">
								<div class="customer-data">
									<div class="login clearfix">
										<div class="avatar">
                                        <%if (ViewBag.usercurrent.profpic!="" && ViewBag.usercurrent.profpic != null) {%>
											<img src="<%: Url.Content("~"+ViewBag.usercurrent.profpic) %>">
                                            <%} else
                                            { %>
                                            <img src="<%: Url.Content("~/Content/_design/images/img-login-user.jpg") %>">
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
                                <form method="post">
                                <input type = "hidden" id = "hidval" name = "hidval" />
                                <script type="text/javascript" language="javascript">
                                    function SetValue(id) {
                                        document.getElementById('hidval').value = id;
                                        //alert(document.getElementById('hidval').value);
                                    }
                                    function validateForm(form) {
                                        //alert('yakin?');
                                    }
                                </script>
								<div class="order-history">
									<h2>History Order</h2>
								

                                    <%
                                        int count = 0;
                                        int limit = 3;
                                        int i =0;
                                        IEnumerable<Ordercust> allorder = (IEnumerable<Ordercust>) ViewBag.ordercustall;
                                        int total = allorder.Count();
                                        foreach (Ordercust itemoc in ViewBag.ordercustall)
                                      { %>   
                                      
                                      <% if (count == 0)
                                         {%>
                                         	<ul class="clearfix">
                                          <%} %>                                
										<li>                                        
											<div class="date">
                                            <% %>
												<%: itemoc.delivery_time.ToString("dd-MM-yyyy HH:mm")%>
											</div>
                                            <table class="menu">
                                             <%foreach (Ordersubmenu itemosm in ViewBag.ordersubmenuall)
                                               {
                                                   int subtotal = 0; %>
											<% if (itemosm.id_order == itemoc.Id)
                                                {%>
                                                <% Submenu sm = new SubmenuService().FindBy(itemosm.id_submenu);%>
												<tr>
													<td><%: itemosm.quantity %> x</td>
													<td><%: sm.name%></td>
												</tr>
                                                <%}
                                               }%>
											</table>
											<table class="price">
                                                <tr>
													<td>Subtotal</td>
													<td>:</td>
													<td><%:String.Format("{0:0,0}",itemoc.price )%></td>
												</tr>
												<tr>
													<td>Restaurant Tax</td>
													<td>:</td>
													<td><%:String.Format("{0:0,0}",itemoc.tax )%></td>
												</tr>
												<tr>
													<td>Delivery Cost</td>
													<td>:</td>
													<td><%:String.Format("{0:0,0}",itemoc.delivery )%></td>
												</tr>
											</table>
											<div class="grand-total">
												Grand Total : <%:String.Format("{0:0,0}", itemoc.total_price) %>
											</div>
											<div class="button-container" style="visibility: hidden; display:inline;">
												<input class="order-button" value="Reorder" type="submit" onclick="SetValue(<%:itemoc.Id %>);" >
											</div>
										</li>
                                        <% 
                                            count ++;
                                            i++;
                                            if (count == limit || i == total)
                                            {
                                             %>
                                             </ul>
                                             <%
                                                count = 0;
                                            } %>
                                        <%
                                          }
                                       %>
									
								</div>
								</form>		
							</div>
						</div>
					</div>
					
					<div class="content-left-bottom">

					</div>
				</div>

</asp:Content>
