<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/PHD3.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>
<%@ Import Namespace="PHD.MVC.Helper" %>
<%@ Import Namespace="PHD.Session.Classes" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="NHibernate.Criterion" %>
<%@ Import Namespace="PHD.Service.ModelService" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<script type="text/javascript" language="javascript">
    function del(id) {
        if (window.confirm('Apakah anda yakin ingin menghapus alamat ini')) 
        {
            $('#deladdress').val(id);
            $('#formdeladd').submit();
        }
        alert('a');
    }

    function changeAddress(opt) {
        //  var opt = sel.options[sel.selectedIndex].value;
        if (opt == "1") {
            $('#blok').show();
            $('#jalan').show();
            $('#gedung').hide();
            $('#tempat').hide();
            $('#lantai').hide();
            $('#perusahaan').hide();
        }
        if (opt == "2") {
            $('#blok').hide();
            $('#jalan').show();
            $('#gedung').show();
            $('#tempat').hide();
            $('#lantai').show();
            $('#perusahaan').hide();
        }
        if (opt == "3") {

            $('#blok').hide();
            $('#jalan').show();
            $('#gedung').show();
            $('#tempat').hide();
            $('#lantai').show();
            $('#perusahaan').show();
        }
        if (opt == "4") {
            $('#blok').hide();
            $('#jalan').show();
            $('#gedung').show();
            $('#tempat').show();
            $('#lantai').hide();
            $('#perusahaan').hide();
        }
        return true;
    }
</script>
<script type="text/javascript" language="javascript">
    $(document).ready(function () {
        $('#nama-jalan').autocomplete({
           // source: '<%:Url.Content("~/Home/")%>Autocompleteaddress'
           source: function (request, response) {
                        $.ajax({
                            url: "<%:Url.Content("~/Home/")%>Search?term="+$("#nama-jalan").val(), type: "POST", dataType: "json",
                            data: { searchText: request.term, maxResults: 100 },//original code
                            success: function (data) {
                                response($.map(data, function (item) {
                                    //return { label: item.FullName, value: item.FullName, id: item.TagId }; //original code
                                    return { label: item.label, value: item.label, id: item.id };//updated code
                                }));
                            },
                            
                        });
                    },
                     minLength: 3,
                    select: function (event, ui) {
                                $("#id_jalan").val(ui.item.id);//update the jQuery selector here to your target hidden field
                            }
        
        });
    }) 
</script>
				<div class="menu-title">
					<img src= "<%:Url.Content("~/Content/_design/images/p-addict.png")%>" />
				</div>
				<div class="content-left">
					<nav class="nav-content-left">
						<ul>
							<li class="active">
								<a id="menu1" href="<%:Url.Content("~/paddict")%>"><span>My Profile</span></a>
							</li>
							<li>
								<a id="menu2" href="<%:Url.Content("~/paddict/orderhistory")%>"><span>Order History</span></a>
							</li>
							<li>
								<a id="menu3" href="<%:Url.Content("~/paddict/point")%>"><span>Points</span></a>
							</li>
						</ul>
					</nav>
					<div class="content-left-container">
						
						<h1>My Profile</h1>
                        <%= ViewBag.message %>
						<div class="about-us-container clearfix">
							<div class="p-addict">
								<div class="customer-data">
									<div class="login clearfix">
										<div class="avatar">
											<img src= "<%:Url.Content("~/Content/_design/images/img-login-user.jpg")%>" />
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
												<li class="edit clearfix">
													<a href=""><img src="<%:Url.Content("~/Content/_design/images/img-edit.png")%>"> Edit</a>
												</li>
												<form style="display:none" method="post">
													<ul>
														<li>
															<label>Nama</label>
															<input type="email" id="nama" name="nama">
														</li>
														<li>
															<label>Password</label>
															<input type="password" id="password" name="password">
														</li>
														<li>
															<label>Telephone</label>
															<input type="text" id="telepon" name="telepon">
														</li>
													</ul>
													<div class="button-container">
														<input class="greenbtn" type="submit" value="submit"> <input type="button" class="greenbtn" value="cancel">
													</div>
												</form>
											</ul>
										</div>
									</div>
									<div class="address-list">
                                        <form id="formdeladd" method="post">
                                        <input type="hidden" name="del_address" id="deladdress" />
										<ul>
                                            <% IEnumerable<Address> useraddress = (IEnumerable<Address>)ViewBag.useraddress;%>
                                            <% int i = 1; %>
                                            <% if (useraddress.Count() != 0)
                                               { %>
                                               <%foreach (Address item in ViewBag.useraddress)
                                                 {%>
											    <li>
												<div class="edit">
													<h2>Alamat Pengiriman <%: i %></h2>
                                                    <% if (useraddress.Count() > 1)
                                                       { %>
													<a href="#" onclick="del(<%:item.Id %>)"><img src="<%:Url.Content("~/Content/_design/images/img-x.png")%>"/> Delete</a>
												    <%} %>
                                                </div>
												<p>
                                                <%if (item.typeaddress.Id == 1)
                                                  {%>
                                                    Outlet : <%: item.street.outlet.name == null ? "" : item.street.outlet.name + " " + item.street.outlet.area.name%><br />
                                                    Jalan : <%: item.street.name == null ? "" : item.street.name%><br />
                                                    Blok : <%: item.blok %><br />
                                                    No : <%: item.no_alamat %><br />
                                                    Keterangan : <%: item.ket == null ? "" : item.ket %><br />
                                                    <%}
                                                  else if (item.typeaddress.Id == 2)
                                                  {%>
                                                    Outlet : <%: item.street.outlet.name %><br />
                                                    Jalan : <%: item.street.name %><br />
                                                    Nama Gedung : <%: item.gedung %><br />
                                                    Lantai : <%: item.lantai %><br />
                                                    No Kamar : <%: item.no_lantai %><br />
                                                    <%//= item.ket %><br />
                                                  <%}
                                                  else if (item.typeaddress.Id == 3)
                                                  { %>
                                                    Outlet : <%: item.street.outlet.name %><br />
                                                    Jalan : <%: item.street.name %><br />
                                                    Gedung : <%: item.gedung %><br />
                                                    lantai :<%: item.lantai %><br />
                                                    No Ruangan : <%: item.no_lantai %><br />
                                                    Perusahaan : <%: item.perusahaan %><br />
                                                    <%//= item.ket %><br />
                                                  <%}
                                                  else
                                                  { %>
                                                    Outlet : <%: item.street.outlet.name %><br />
                                                    Jalan : <%: item.street.name %><br />
                                                    Gedung : <%: item.gedung %><br />
                                                    Tempat : <%: item.tempat %><br />
                                                    No : <%: item.no_tempat %><br />
                                                    <%//= item.ket %><br />
                                                  <%} %>
												</p>
											</li>
                                                <%i++;
                                                 }
                                               }%>
										</ul>
                                        </form>
										<div id="add" class="edit clearfix">
											<a href=""><img src="<%:Url.Content("~/Content/_design/images/img-edit.png")%>"> Add Address</a>
										</div>
										<div class="address-add">
											<form style="display:none" method="post">
                                            <label>Tipe Alamat</label>
        	                                 <%: Html.DropDownList("typeaddress",
                                                   new SelectList(new Dropdown().TypeAddress(),
                                                  "value",
                                                  "text",1
                                                    ), new { @class = "control-select",  @onchange = "changeAddress(this.value)", @onload = "changeAddress(this.value)" }
                                                    )
                                            %>
                                                <div class="control-group" id="jalan" style="display:block">
				                                        <label class="control-label" for="">Nama jalan*</label>
				                                        <input id="nama-jalan" type="text">
                                                        <input type="hidden" name="id_jalan" id="id_jalan" type="text">
			                                    </div>

                                                <div class="control-group" id="gedung" style="display:none">
				                                    <label class="control-label" for="">Nama gedung*</label>
				                                    <input id="gedung" name="gedung" type="text">
			                                    </div>
			
                                                <div class="control-group clearfix" id="blok" style="display:block">
				                                    <div class="control-half">
					                                    <label class="control-label" for="">Blok</label>
					                                    <input type="text" name="blok">
				                                    </div>
				                                    <div class="control-half">
					                                    <label class="control-label" for="">No. Alamat</label>
					                                    <input type="text" name="no_alamat">
				                                    </div>
			                                    </div>

			                                    <div class="control-group clearfix" id="lantai" style="display:none">
				                                    <div class="control-half">
					                                    <label class="control-label" for="">Lantai*</label>
					                                    <input type="text" name="lantai">
				                                    </div>
				                                    <div class="control-half">
					                                    <label class="control-label" for="">No. kamar*</label>
					                                    <input type="text" name="no_kamar">
				                                    </div>
			                                    </div>

			                                    <div class="control-group clearfix" id="tempat" style="display:none">
				                                    <div class="control-half">
					                                    <label class="control-label" for="">Nama tempat*</label>
					                                    <input type="text" name="tempat">
				                                    </div>
				                                    <div class="control-half">
					                                    <label class="control-label" for="">Nomor*</label>
					                                    <input type="text" name="no_tempat">
				                                    </div>
			                                    </div>

                                                <div class="control-group" id="perusahaan" style="display:none">
							                                    <label class="control-label" for="">Nama perusahaan</label>
							                                    <input type="text" name="perusahaan">
			                                    </div>

		                                        <div class="control-group">
			                                        <label class="control-label" for="">Keterangan tambahan</label>
			                                        <input type="text" name="ket">
		                                        </div>

												<div class="button-container">
													<input class="greenbtn" type="submit" value="submit"> <input type="button" class="greenbtn" value="cancel">
												</div>
											</form>
										</div>
									</div>
									<div class="user-data">
										<ul>
											<li>
												<div class="edit">
													<h2>Tempat Tanggal Lahir</h2>
													<a href=""><img src="<%:Url.Content("~/Content/_design/images/img-edit.png") %>"> Edit</a>
												</div>
												<p>
                                                    <% User current = ViewBag.usercurrent; %>
													<%: current.tempat_lahir == null ? "" : current.tempat_lahir%> - 
                                                    <%: current.tanggal_lahir == null ? "-" : current.tanggal_lahir.ToString("dd/MM/yyyy")%>
												</p>
												<form style="display:none" method="post">

													Tempat Kelahiran : <input id="tempat_lahir" name="tempat_lahir" type="text" value=<%:current.tempat_lahir %>><br />
                                                    Tanggal Lahir &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp : <input id="tanggal_lahir" name="tanggal_lahir" type="text" value=<%: current.tanggal_lahir.ToString("dd/MM/yyyy") %>> dd/mm/yyyy
													<div class="button-container">
														<input class="greenbtn" type="submit" value="submit"> <input type="button" class="greenbtn" value="cancel">
													</div>
												</form>
											</li>
											<li>
												<div class="edit">
													<h2>Jenis Kelamin</h2>
													<a href=""><img src="<%:Url.Content("~/Content/_design/images/img-edit.png")%>"> Edit</a>
												</div>
												<p class="data">
													<%:ViewBag.usercurrent.jenis_kelamin=="2"?"Perempuan": "Laki-Laki" %>
												</p>
												<form style="display:none" method="post">
													<select id="jenis_kelamin" name="jenis_kelamin">
														<option value=1>Laki-laki</option>
                                                        <option value=2>Perempuan</option>
													</select>
													<div class="button-container">
														<input class="greenbtn" type="submit" value="submit"> <input type="button" class="greenbtn" value="cancel">
													</div>
												</form>
											</li>
											<li>
												<div class="edit">
													<h2>Profesi</h2>
													<a href=""><img src="<%:Url.Content("~/Content/_design/images/img-edit.png")%>"> Edit</a>
												</div>
												<p class="data">
													<%: ViewBag.usercurrent.prof == null ? "-" : ViewBag.usercurrent.prof.name%>
												</p>
												<form style="display:none" method="post">
                                                    <select id="radprofesi" name="profesi">
                                                    <% foreach(Profesi  profesi in ViewBag.professions)
                                                       { %>
														<option value="<%:profesi.Id %>" <%: ViewBag.usercurrent.prof != null && ViewBag.usercurrent.prof.Id == profesi.Id? "selected":"" %>><%:profesi.name %></option>
                                                   <%} %>
                                                   </select>
													<div class="button-container">
														<input class="greenbtn" type="submit" value="submit" > <input type="button" class="greenbtn" value="cancel">
													</div>
												</form>
											</li>
											<li>
												<div class="edit">
													<h2>Hobi</h2>
													<a href=""><img src="<%:Url.Content("~/Content/_design/images/img-edit.png")%>"> Edit</a>
												</div>
												<p class="data">
													<%: ViewBag.usercurrent.hobirel == null ? "-" : ViewBag.usercurrent.hobirel.name%>
												</p>
												<form style="display:none" method="post">
													 <select id="hobi" name="hobi">
                                                    <% foreach(Hobi  hobi in ViewBag.hobbies)
                                                       { %>
														<option value="<%:hobi.Id %>" <%: ViewBag.usercurrent.hobirel != null && ViewBag.usercurrent.hobirel.Id == hobi.Id? "selected":"" %>><%:hobi.name %></option>
                                                   <%} %>
                                                   </select>
													<div class="button-container">
														<input class="greenbtn" type="submit" value="submit"> <input type="button" class="greenbtn" value="cancel">
													</div>
												</form>
											</li>
											
										</ul>
                                        <%  
                                            User user = (User)ViewBag.usercurrent;
                                            int x = 0;
                                            %>
										<div class="user-favorite">
											<div class="edit">
												<h2>Favorit Saya</h2>
												<a href=""><img src="<%:Url.Content("~/Content/_design/images/img-edit.png")%>"> Edit</a>
											</div>
											<form method="post">
												<ul>
													<li>
														<label>Tempang hangout</label>
														<div class="content"><%:String.IsNullOrEmpty(ViewBag.usercurrent.fav_hangout) ? "-" :ViewBag.usercurrent.fav_hangout %></div>
														<input type="text" style="display:none" id="fav_hangout" name="fav_hangout">
													</li>
													<li>
														<label>Makanan</label>
														<div class="content"><%:String.IsNullOrEmpty( ViewBag.usercurrent.fav_makanan) ? "-" : ViewBag.usercurrent.fav_makanan%></div>
														<input type="text" style="display:none" id="fav_makanan" name="fav_makanan">
													</li>
													<li>
														<label>Lokasi</label>
														<div class="content"><%: String.IsNullOrEmpty(ViewBag.usercurrent.fav_lokasi) ? "-" : ViewBag.usercurrent.fav_lokasi%></div>
														<input type="text" style="display:none" id="fav_lokasi" name="fav_lokasi">
													</li>
													<li>
														<label>Fashion brands</label>
														<div class="content"><%: String.IsNullOrEmpty(ViewBag.usercurrent.fav_brands) ? "-" : ViewBag.usercurrent.fav_brands%></div>
														<input type="text" style="display:none" id="fav_brands" name="fav_brands">
													</li>
												</ul>
											
												
												<div style="display:none" class="button-container">
													<input class="greenbtn" type="submit" value="submit"> <input type="button" class="greenbtn" value="cancel">
												</div>
											</form>
										</div>
									</div>
									
								</div>
										
							</div>
						</div>
					</div>
					
					<div class="content-left-bottom">

					</div>
				</div>
</asp:Content>
