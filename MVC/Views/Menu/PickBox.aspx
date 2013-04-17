<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>PickBox</title>
</head>
<script type="text/javascript">
    function submitVal() {
        var ret = true;
        var atLeastOneIsChecked1 = $('input:radio[name=boxsingle]:checked').length > 0;
        var atLeastOneIsChecked2 = $('input:radio[name=boxcouple]:checked').length > 0;

        if (!(atLeastOneIsChecked1 || atLeastOneIsChecked2)) {
            alert('Please at least select one of the box');
            ret = false;
        }
        else {
            if (window.confirm('Are you sure you want to chose this box?')) {
                if (atLeastOneIsChecked1) {
                    $("#box").val($('input:radio[name=boxsingle]:checked').val())
                    $('#MenuUtama').submit();
                    ret = true;
                }
                if (atLeastOneIsChecked2) {
                    $("#box").val($('input:radio[name=boxcouple]:checked').val())
                    $('#PromoDetail').submit();
                    ret = true;
                }                
            }
        }
        
        return ret;
    }

    function random(id) {
        if (window.confirm('Are you sure you want to chose this box?')) {
            if (id == 1) {
                $("#box").val(Math.ceil(Math.random() * 6));
                $('#MenuUtama').submit();
            }
            if (id == 8) {
                $("#box").val(Math.ceil(Math.random() * 2) + 6);
                alert($("#box").val());
                $('#PromoDetail').submit();
            }
        }
    }
    function getVal() {
        var value;
        if ($('input:radio[name=boxsingle]:checked').length > 0) {
            value = $('input:radio[name=boxsingle]:checked').val();
        }
        if ($('input:radio[name=boxcouple]:checked').length > 0) {
            value = $('input:radio[name=boxcouple]:checked').val();
        }

        //alert($('input:radio[name=boxcouple]:checked').val());
        $("#box").val(value);

    }
    function getValCouple() {
        alert($("#boxcouple").val());
        $("#box").val($("#boxcouple").val());
 
    }
</script>
<body>

    <div class="popup-valentine">
	<div id="valentine2" class="wrapper">
		<h1>
			<img src="<%:Url.Content("~/Content/_design/images/text-valentine2.png")%>">
		</h1>
        <% string radchecked = ""; %>
            <%if (ViewBag.id == 1)
           { %>
		<div class="valentine-box-list">
			<h2><img src="<%:Url.Content("~/Content/_design/images/text-valentine3.png")%>"></h2>
			<ul>
            <%foreach (var item in ViewBag.boxall)
              {%>
              <%if (item.type == 1)
                { %>
                <% if (Convert.ToInt16(item.sequence) == 1)
                   {
                       radchecked = "checked";
                   }
                   else {
                       radchecked = "";
                   }
                   %>
				<li>
					<div class="number">
						<span><%: item.sequence%></span>
					</div>
					<label for="option1">
						<img src="<%:Url.Content("~"+item.image)%>">
					</label>
						<input type="radio" name="boxsingle" id="boxsingle" onclick="getVal()"value="<%:item.Id %>" <%: radchecked %>>
					
				</li>
                <%}
              } %>
				
			</ul>
		</div>
        <%}
           else if (ViewBag.id == 20 || ViewBag.id == 21 || ViewBag.id == 22)
           { %>
		<div class="valentine-box-list" id="couple-box">
			<h2><img src="<%:Url.Content("~/Content/_design/images/text-valentine4.png")%>"></h2>
			<ul>
				<%foreach (var item in ViewBag.boxall)
      {%>
              <%if (item.type == 2)
                { %>
                <% if (Convert.ToInt16(item.sequence) == 1)
                   {
                       radchecked = "checked";
                   }
                   else {
                       radchecked = "";
                   }
                   %>
				<li>
					<div class="number">
						<span><%: item.sequence%></span>
					</div>
					<label for="option1">
						<img src="<%:Url.Content("~"+item.image)%>">
					</label>
						<input type="radio" name="boxcouple" id="boxcouple" onclick="getVal()" value="<%:item.Id %>"  <%: radchecked %>>
					
				</li>
                <%}
      } %>
			</ul>
		</div>
        <%} %>

		<div id="confirm-button">
			<p><a id="surprise" onclick="random(<%:ViewBag.id %>);"></a></p>
			<p><a onclick="submitVal();"></a></p>
		</div>

	</div>
	
</div>

</body>
</html>
