<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/RegLog.Master" Inherits="System.Web.Mvc.ViewPage<PHD.Session.Classes.Ordercust>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Mandiri
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<script type="text/javascript">
    /*$(document).ready(function () {
        var div = $('#display-text-akhir')[0];
        $('#noKartu').keyup(function () {

            var data = $('#noKartu').val();
            var kode = data.substring(str.length - 10, str.length);
            // alert(data);
            $('div.display-text-akhir').val(data);
        });
    })
    */
    function change(nomer) {

        if (nomer.length < 10) {
            $("#noKartu10").val(nomer);
        }
        else {
            $("#noKartu10").val(nomer.slice( -10 ));        
        }
    }

   
</script>
<h2>Online Payment Mandiri</h2>

<% if (ViewBag.Message != "sukses")
   { %>
<% using (Html.BeginForm(null, null, new { idcust = Model.Id }, FormMethod.Post, new { @class = "form-member-section" }))
   { %>
    <%: Html.ValidationSummary(true)%>
    <p>
      <%:ViewBag.message %>
    </p>
<fieldset>

    <div class="control-group">
			<label class="control-label" for="">email</label>
			  <%: Model.user.email%>
    </div>
  
    <div class="control-group">
        <label class="control-label" for="">status</label>
     <div class="display-field"><%: Model.status.description%></div>
     </div>

    <div class="control-group">
     <label class="control-label" for="">Address</label>
    <div class="display-field"><%: Model.address.street.name%></div>
    </div>

    <div class="control-group">
    <label class="control-label" for="">No Kartu Debit</label>
    <input maxlength="16" id= "noKartu" name="noKartu" type="text" onkeyup="change(this.value)"/>
    <div class= "display-keterangan">(* Masukkan 16 digit Kartu Debit Mandiri Anda)</div>
    </div>
    
    <div class="control-group">
     <label class="control-label" for="">10 Digit Terakhir Nomor Kartu Debit</label>
    
    <input id = "noKartu10" name="noKartu10" type="text" disabled="true" />
    <div class="display-text-akhir" ></div>
 
    </div>
    
    <div class="control-group">
    <label class="control-label" for="">Total Transaksi</label>
    <div class="display-field"><%:"Rp " + String.Format("{0:0,0}", Model.total_price)%></div>
    </div>
    
    <div class="control-group">
    <label class="control-label" for="">No Transaksi</label>
    <div class="display-field"><%: Model.Id%></div>
    <div class= "display-keterangan"></div>
    </div>
    <div class="control-group">
    <label class="control-label" for="">Respon Token Mandiri</label>
    <input name="respToken" type="text" />
    <div class= "display-keterangan">(* Masukkan Respon Kartu Debit Mandiri Anda)</div>
    </div>
    <button type="submit">Lanjut</button>
</fieldset>
<% } %>
<%}

   else
   {
       
  %><br/>

  <%:ViewBag.message %>
  <br/>

  <p>
    <%: Html.ActionLink("Back To Home", "Index","Home") %>
   </p>

<%} %>
</asp:Content>

