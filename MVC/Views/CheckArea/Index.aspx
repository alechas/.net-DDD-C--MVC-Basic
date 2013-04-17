<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>


	<!--[if lt IE 7]>
		<p class="chrome-frame">Your browser is <em>ancient!</em> <a href="http://browsehappy.com/">Upgrade to a different browser</a> or <a href="http://www.google.com/chromeframe/?redirect=true">install Google Chrome Frame</a> to experience this site.</p>
	<![endif]-->
    <script type="text/javascript" language="javascript">
    function checkaddress()
    {
        var temp =  $('#id_jalan').val();
        if (temp!='-1')
        {
            $('#map').hide();
            $('#result').show();
             $('#search-jalan').hide();
            $('#covered').show();
        }
    }

    function togglerefresh()
    {
        
            $('#map').show();
            $('#result').hide();
             $('#search-jalan').show();

             $('#id-jalan').val("-1");
           $('#nama-jalan').val("");
            $('#covered').hide();
      
    }

    $(document).ready(function () {
        $('#nama-jalan').autocomplete({
           // source: '<%:Url.Content("~/Home/")%>Autocompleteaddress'
           source: function (request, response) {
                        $.ajax({
                            url: "<%:Url.Content("~/Home/")%>Search?term="+$("#nama-jalan").val(), type: "POST", dataType: "json",
                            data: { searchText: request.term, maxResults: 20 },//original code
                            success: function (data) {
                                response($.map(data, function (item) {
                                    //return { label: item.FullName, value: item.FullName, id: item.TagId }; //original code
                                    return { label: item.label, value: item.label, id: item.id };//updated code
                                }));
                            },
                            
                        });
                    },
                     minLength: 2,
                    select: function (event, ui) {
                                $("#id_jalan").val(ui.item.id);//update the jQuery selector here to your target hidden field
                                var n = ui.item.label.split("-");
                                 $("#outlet").text(n[1]);
                   }
        
        });
    }) 
   
</script>
	    <div style="width: 800px;
        height: 530px;position:relative;border: 5px solid #d70000;">
		<div id="map">
        <img src="<%:Url.Content("~/Content/_design/images/backpeta.png") %>" />
		</div>
        <div style="display:none" id="result">
        <img src="<%:Url.Content("~/Content/_design/images/backpeta.png") %>" />
	     </p>
		</div>
		</div>
		<div class="search-area" id="search-jalan" style="width: 400px;
        margin-bottom: 0px;
        position: absolute;
        bottom: 150px;
        left: 20px;">
            <form>
			<input id="nama-jalan" type="text">
            <input type="hidden" name="id_jalan" id="id_jalan" type="text" value="-1">
            <a class="greenbtn" onclick="checkaddress()" >Cari</a>
			</form>
            <p style="color: #d70000;
            font-family: 'helveticaneueltstd-bdcno';
            text-transform: uppercase;
            font-size:20px;
            margin: 5px 0;">
				Is your address <br />
				in our coverage area?
			</p>
		</div>

          	<div class="search-area" id="covered" style="display:none;width: 400px;
            margin-bottom: 0px;
            position: absolute;
            bottom: 150px;
            left: 20px;">>
            <h2 align="center" class="coveredtxt">
              Your address is covered by PHD <label id="outlet"></label>
            </h2>

            <p style="text-align:center">
                <input type="button" value="Check Adress Again" onclick="togglerefresh()" class="greenbtn">
            </p>

        </div>
		<div>

		</div>
	</div>
	<script type="text/javascript">
	  // Site.initializeGoogleMaps(-6.20131, 106.84513, "google-map");
	</script>

