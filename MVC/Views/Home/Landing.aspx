<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Landing</title>
</head>
<body>
 <div class="popup-valentine">
	<div id="valentine1" class="wrapper">
		<img id="valentine-image1" src="<%:Url.Content("~/Content/_design/images/img-valentine-box.png")%>">
		<img id="valentine-image2" src="<%:Url.Content("~/Content/_design/images/img-valentine1.png")%>">
		<div id="valentine-text">
			<p>
				<img src="<%:Url.Content("~/Content/_design/images/text-valentine1.png")%>" ><br />
				<span style="color:red;font-size:14px;">- for regular size and valid only while stock last -</span>
			</p>
			<p>
				&nbsp;
			</p>
			<p>
				<a href="<%:Url.Content("~/Menu/Menuutama/1")%>"><img src="<%:Url.Content("~/Content/_design/images/btn-valentine-get.png")%>"></a>
			</p>
		</div>
	</div>
	
</div>

</body>
</html>
