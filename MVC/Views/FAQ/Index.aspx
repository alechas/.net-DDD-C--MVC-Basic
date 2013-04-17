<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/PHD3.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
     PHD - Ahlinya Delivery! :: FAQ
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">			

				<div class="menu-title">
					<img src="<%:Url.Content("~/Content/_design/images/faq.png") %>">
				</div>
				<div class="content-left">
					<div class="content-left-container">												
						<div class="faq">
							<ol>
                            <% foreach (var item in ViewBag.data)
                               { %>
								<li>
                                    <%: item.question %>
									<p>
										<%= item.answer %>
									</p>
								</li>
                                <% }%>
								
							</ol>
						</div>
					</div>
					
					<div class="content-left-bottom">

					</div>
				</div>
</asp:Content>
