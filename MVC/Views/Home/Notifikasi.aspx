<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Notifikasi</title>
</head>
<body>
   <div class="popup-notif">
	<div class="message">
		<p>
			<%:ViewBag.message %>
		</p>
	</div>
</div>
</body>
</html>
