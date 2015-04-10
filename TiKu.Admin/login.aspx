<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="TiKu.Admin.login" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>欢迎登录后台管理系统</title>
<link href="css/style.css" rel="stylesheet" type="text/css" />
<script src="js/jquery-1.7.2.min.js" type="text/javascript"></script>
<script src="js/cloud.js" type="text/javascript"></script>
<script src="/js/lhgdialog/lhgdialog.js?skin=iblue" type="text/javascript"></script>   
<script language="javascript" type="text/javascript">
    $(function () {
        $('.loginbox').css({ 'position': 'absolute', 'left': ($(window).width() - 692) / 2 });
        $(window).resize(function () {
            $('.loginbox').css({ 'position': 'absolute', 'left': ($(window).width() - 692) / 2 });
        });
        if (top.location != self.location) top.location = self.location;
    });
</script>
</head>
 <body style="background-color:#1c77ac; background-image:url(images/light.png); background-repeat:no-repeat; background-position:center top; overflow:hidden;">
<div id="mainBody">
      <div id="cloud1" class="cloud"></div>
      <div id="cloud2" class="cloud"></div>
</div>  
<div class="logintop">    
    <span>欢迎登录后台管理界面平台</span>    
    <ul>
    <li><a href="javascript:;">回首页</a></li>
    <li><a href="javascript:;">帮助</a></li>
    <li><a href="javascript:;">关于</a></li>
    </ul>    
    </div>

<div class="loginbody">
    
    <span class="systemlogo"></span> 
    <form runat="server" id="form1">
    <div class="loginbox">
    <ul>
    <li><input name="txtAdminName" type="text" maxlength="30" class="loginuser" value="" onclick="JavaScript:this.value=''"/></li>
    <li><input name="txtAdminPwd" maxlength="16" type="password" class="loginpwd" value="" onclick="JavaScript:this.value=''"/></li>
    <li><input name="" type="submit" id="btnLogin" runat="server" class="loginbtn" value="登录"  onclick=""  />
    <label><input id="chkRemember" runat="server" type="checkbox"  />记住密码</label></li>
    </ul>
    </div>
    </form>
    </div>
<div class="loginbm">版权所有  2015  <a href="http://www.ibeisha.com">ibeisha.com</a></div>
</body>
</html>