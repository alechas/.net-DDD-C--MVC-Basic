<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/RegLog.Master" Inherits="System.Web.Mvc.ViewPage<Session.Classes.User>" %>
<%@ Import Namespace="MVC.Helper" %>
<%@ import Namespace="Session.Classes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    PHD
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<script language="javascript">

    function changeAddress(opt) {

        //  var opt = sel.options[sel.selectedIndex].value;
        if (opt == "-1") {
            $('#blok').hide();
            $('#jalan').hide();
            $('#gedung').hide();
            $('#tempat').hide();
            $('#lantai').hide();
            $('#perusahaan').hide();
            $('#ket').hide();
        }

        if (opt == "1") {
            $('#blok').show();
            $('#jalan').show();
            $('#gedung').hide();
            $('#tempat').hide();
            $('#lantai').hide();
            $('#perusahaan').hide();
            $('#ket').show();
        }
        if (opt == "2") {
            $('#blok').hide();
            $('#jalan').show();
            $('#gedung').show();
            $('#tempat').hide();
            $('#lantai').show();
            $('#perusahaan').hide();
            $('#ket').show();
        }
        if (opt == "3") {

            $('#blok').hide();
            $('#jalan').show();
            $('#gedung').show();
            $('#tempat').hide();
            $('#lantai').show();
            $('#ket').show();
            $('#perusahaan').show();
        }
        if (opt == "4") {
            $('#blok').hide();
            $('#jalan').show();
            $('#gedung').show();
            $('#tempat').show();
            $('#lantai').hide();
            $('#perusahaan').hide();
            $('#ket').show();
        }
        return true;
    }

    function submitform() 
    {
        var value = $("#custom-select").val();
        var id_jalan = $("#id_jalan").val();
       var email = $("#email").val();
       var password = $("#password").val();
       var telepon = $("telepon").val();
       
       if (email == "") 
       {
            alert("Email Harus diisi");
            return false;
        }
        if (password == "" || password.length < 6) 
        {
            alert("Password Harus diisi minimal 6 karakter");
            return false;
        }
        if (telepon = "") {
            alert("Telepon Harus diisi");
            return false;
        }
        if (email = "") {
            alert("Email Harus diisi");
            return false;
        }
       if (value == "-1") 
       {
           alert("Pilih Jenis Alamat Terlebih Dahulu");
           return false;
       }
       if (id_jalan == "") {
           alert("Jalan Tidak Valid");
           return false;
       }

     
       else {
           $("#form-register").submit();
       }    
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
<h2>Registrasi</h2>

<p>Enter your email and password</p>
<% Address address = (Address) ViewBag.address; %>
<% using (Html.BeginForm("register","home",FormMethod.Post , new { @class = "form-member-section" ,@id="form-register"}))
       { %>
       <%Html.EnableClientValidation(); %>
        <%: Html.ValidationSummary(true, "Registrasi Gagal, Silahkan Perbaiki data yang salah.") %>
        <%= ViewBag.message %>
	<fieldset>
		<div class="control-group">
			<label class="control-label" for="">Email</label>
            <%:Html.EditorFor(model => model.email) %>
            </div>
		<div class="control-group">
			<label class="control-label" for="">Password</label>
            <%:Html.PasswordFor(model => model.password) %>
		</div>
		<div class="control-group">
			<label class="control-label" for="">No. Telepon</label>
			 <%:Html.EditorFor(model => model.telepon) %>
		</div>
		<div class="control-group clearfix">
			<label class="control-label" for="">Alamat delivery*</label>
			 <%: Html.DropDownList("typeaddress",
                   new SelectList(new Dropdown().TypeAddress(),
                  "value",
                  "text",1
                    ), new { @class = "control-select", @id = "custom-select", @onchange = "changeAddress(this.value)", @onload = "changeAddress(this.value)" }
                    )
            %>
		</div>

            <div class="control-group" id="jalan" style="display:none">
				<label class="control-label" for="">Nama jalan*</label>
				<input id="nama-jalan" type="text">
                <input type="hidden" name="id_jalan" id="id_jalan" type="text">
			</div>

            <div class="control-group" id="gedung" style="display:none">
				<label class="control-label" for="">Nama gedung*</label>
				<input id="gedung" name="gedung" type="text">
			</div>
			
            <div class="control-group clearfix" id="blok" style="display:none">
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
					<input type="text" name="no_lantai">
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

		<div id="ket" class="control-group" style="display:none">
			<label class="control-label" for="">Keterangan tambahan</label>
			<input type="text" name="ket">
		</div>
		<div class="form-action">
			<div class="actions">

          	<a onclick="submitform()" class="greenbtn" >OK</a>
			</div>
		</div>
	</fieldset>
 <% } %>

 <script language="javascript">

//     changeAddress(1);
 </script>
</asp:Content>
