<%@ Page Language="C#" MasterPageFile="~/Views/Shared/RegLog.Master" Inherits="System.Web.Mvc.ViewPage<PHD.MVC.Models.LogOnModel>" %>

<asp:Content ID="loginTitle" ContentPlaceHolderID="TitleContent" runat="server">
    PHD
</asp:Content>

<asp:Content ID="loginContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Member Login</h2>
    <p>
      Enter your email and password
    </p>

    <script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
    <script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>" type="text/javascript"></script>

    <% using (Html.BeginForm("logon","account",FormMethod.Post , new { @class = "form-member-section" }))
       { %>
        <%: Html.ValidationSummary(true, "Login was unsuccessful. Please correct the errors and try again.") %>
        <div>
            <fieldset>
               <div class="control-group">
			    <label class="control-label" for="">Email</label>
                
                    <%: Html.TextBoxFor(m => m.UserName) %>
                    <%: Html.ValidationMessageFor(m => m.UserName) %>
                </div>
                
                </div>
	        	<div class="control-group">
			        <label class="control-label" for="">Password</label>
                    <%: Html.PasswordFor(m => m.Password) %>
                    <%: Html.ValidationMessageFor(m => m.Password) %>
                </div>
                
                <div class="form-action clearfix">
			        <label class="remember" for="">
                    <%: Html.CheckBoxFor(m => m.RememberMe) %>
                    <%: Html.LabelFor(m => m.RememberMe) %>
			        </label>
			        <div class="actions clearfix">
				        <%: Html.ActionLink("Register", "register", "home")%> | <%: Html.ActionLink("Back", "index", "home")%>
				        <button type="submit">Login</button>
			        </div>
		        </div>
            </fieldset>
        </div>
    <% } %>
</asp:Content>
