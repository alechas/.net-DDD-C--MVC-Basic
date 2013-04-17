<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/PHD3.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Career
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
			                <li  class="active">
				                <a id="menu4" href="<%:Url.Content("~/about/career")%>#target"><span>Careers</span></a>
			                </li>
						</ul>
					</nav>
					<div class="content-left-container">
						
						
						<div class="about-us-container clearfix">
							<div class="career">
								<p style="text-align:center">
									<img src= "<%:Url.Content("~/Content/_design/images/img-career-title.png")%>">
								</p>
								<ul class="career-list clearfix">
									<li class="yellow">
										<div class="title">
											Outlet Manager
										</div>
										<ul>
											<li>Pengalaman minimum 2 tahun di level manajerial bidang industri servis makanan/FnB atau retail	
											</li>
											<li>
												Pendidikan min D3
											</li>
											<li>
												Usia maksimum 35 tahun
											</li>
										</ul>
										<div class="button-container">
											<a href="/about/quickapply" class="greenbtn">Quick Apply</a>
										</div>
									</li>
									<li class="blue">
										<div class="title">
											Shift Leader
										</div>
										<ul>
											<li>Pengalaman minimum 2 tahun di level manajerial bidang industri servis makanan/FnB atau retail	
											</li>
											<li>
												Pendidikan min D3
											</li>
											<li>
												Usia maksimum 35 tahun
											</li>
										</ul>
										<div class="button-container">
											<a href="/about/quickapply" class="greenbtn">Quick Apply</a>
										</div>
									</li>
								</ul>
								<p>
									<h2>Persyaratan Umum</h2>
									<ul>
										<li>- Tinggi minimum 165 untuk laki-laki dan 157 untuk perempuan</li>
										<li>- Berjiwa kepemimpinan yang kuat dengan kepribadian yang baik</li>
										<li>- Bersedia ditempatkan di outlet manapun sesuai kebutuhan perusahaan</li>
										<li>- Bersedia bekerja keras dan mampu bekerja dalam tekanan</li>
									</ul>
								</p>
							</div>
						</div>
					</div>
					
					<div class="content-left-bottom">

					</div>
				</div>

</asp:Content>
