<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/PHD3.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
				<div class="menu-title">
					<img src="<%:Url.Content("~/Content/_design/images/hang-out.png") %>">
				</div>
                <div id="twitter-feed"></div>
				<div class="content-left">
					<div class="content-left-container">
						<h1>Hang Out</h1>
						<div class="hang-out">
							<div class="social-media-list clearfix">
								<ul>
	                                <li>	
		                                <a href="http://instagram.com/PHD500600?ref=badge">
                                            <img src="//badges.instagram.com/static/images/ig-badge-24.png" alt="Instagram" />
	                                        <span>/PHD500600</span>
                                        </a>
                                    </li>
	                                <li>
		                                <a href="http://www.youtube.com/user/PHD500600?feature=creators_cornier-%2F%2Fs.ytimg.com%2Fyt%2Fimg%2Fcreators_corner%2FYouTube%2Fyoutube_24x24.png"><img src="//s.ytimg.com/yt/img/creators_corner/YouTube/youtube_24x24.png" alt="Subscribe to me on YouTube"/>
	                                    <span>/PHD500600</span>
                                        </a><img src="//www.youtube-nocookie.com/gen_204?feature=creators_cornier-//s.ytimg.com/yt/img/creators_corner/YouTube/youtube_24x24.png" style="display: none"/>
                                    </li>
									<li>
										<a href="https://www.facebook.com/PHD500600">
											<img src="<%:Url.Content("~/Content/_design/images/img-fb.png") %>" alt="Visit Us" style="width:24px;height:24px;" />
                                            <span>/PHD500600</span>
										</a>										
									</li>
									<li>
										<a href="https://twitter.com/PHD_500600">
                                        <img src="<%:Url.Content("~/Content/_design/images/img-twitter.png") %>" alt="Follow Us" style="width:24px;height:24px;" />
                                            <span>@PHD_500600</span>
										</a>
										
									</li>
								</ul>
							</div>
							<div class="social-media clearfix">
								<ul>
									<li class="twitter">
										<div class="title">
                                         <img src="<%:Url.Content("~/Content/_design/images/img-tweetus.png") %>">
										</div>
										<div class="content">
											<div class="header clearfix">
												<div class="avatar">
                                                <img src="<%:Url.Content("~/Content/_design/images/img-login-user.jpg") %>">
										
												</div>
												<div class="derscription">
													@PHD_500600
												</div>
											</div>
											<div id="tweet-list" class="tweet-list">
                                            <ul>
                                             <a class="twitter-timeline" href="https://twitter.com/search?q=PHD_500600" data-widget-id="297295978036334592">Tweets about "PHD_500600"</a>
                                            <script>    !function (d, s, id) { var js, fjs = d.getElementsByTagName(s)[0]; if (!d.getElementById(id)) { js = d.createElement(s); js.id = id; js.src = "//platform.twitter.com/widgets.js"; fjs.parentNode.insertBefore(js, fjs); } } (document, "script", "twitter-wjs");</script>
                                            </ul>
											</div>
										</div>
									</li>
									<li class="facebook">
										<div class="title">
                                        <img src="<%:Url.Content("~/Content/_design/images/img-facebook.png") %>">
										</div>
										<div class="content">
											<div class="header clearfix">
												<div class="avatar">
                                                <img src="<%:Url.Content("~/Content/_design/images/img-login-user.jpg") %>">
												</div>
												<div class="derscription">
													@PHD_500600
												</div>
											</div>
											<div id="fb-list" class="tweet-list">
                                            <div class="fb-like-box" data-href="http://www.facebook.com/PHD500600" data-width="292" data-show-faces="true" data-stream="true" data-header="true"></div>
											</div>
										</div>
									</li>
								</ul>
							</div>
						</div>
					</div>		
					<div class="content-left-bottom">

					</div>
				</div>

</asp:Content>
