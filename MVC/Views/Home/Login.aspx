<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/RegLog.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    PHD
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Member Login</h2>

<p>Enter your email and password</p>

<form class="form-member-section" action="/Account/LogOn" method = "POST">
	<fieldset>
		<div class="control-group">
			<label class="control-label" for="">Email</label>
			<input name="email" type="text">
		</div>
		<div class="control-group">
			<label class="control-label" for="">Password</label>
			<input name="password" type="password">
		</div>
		<div class="form-action clearfix">
			<label class="remember" for="">
				<input type="checkbox">
				Remember me
			</label>
			<div class="actions clearfix">
				<a class="btn-reg" href="#">Register</a> | <a href="#">Back</a>
				<button type="submit">Login</button>
			</div>
		</div>
	</fieldset>
</form>
</asp:Content>
