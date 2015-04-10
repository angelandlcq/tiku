<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="password.aspx.cs" Inherits="TiKu.Admin.admin.password" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>修改密码</title>
    <link href="/css/style.css" rel="stylesheet" type="text/css" />
    <link href="/css/select.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/js/jquery.js"></script>
    <script type="text/javascript" src="/js/select-ui.min.js"></script>
    <script src="/js/lhgdialog/lhgdialog.js?skin=iblue" type="text/javascript"></script> 
    <script type="text/javascript">
        $(document).ready(function (e) {
            $(".select1").uedSelect({
                width: 345
            });
        });
</script>
</head>
<body>
    <form id="form1" runat="server">
       <div class="place">
    <span>位置：</span>
    <ul class="placeul">
    <li><a href="#">首页</a></li>
    <li><a href="#">修改密码</a></li>
    </ul>
    </div>
    
       <div class="formbody">
    
    <div class="formtitle"><span>修改密码</span></div>
    
    <ul class="forminfo">
    <li><label>登陆名<b>*</b></label>Admin</li>
    <li><label>原始密码<b>*</b></label><input id="txtOldPwd" runat="server" maxlength="16" type="password" class="dfinput" /><i>密码长度6-16位数字、字母或特殊符号</i></li>
    <li><label>新密码<b>*</b></label><input id="txtNewPwd" runat="server" maxlength="16" type="password" class="dfinput" /><i></i></li>
    <li><label>确认密码<b>*</b></label><input id="txtConfirmPwd" runat="server" maxlength="16" type="password" class="dfinput" /><i></i></li>
    <li><label>&nbsp;</label><input id="btnSubmit" runat="server" type="button" class="btn" value="修改密码"/></li>
    </ul>
    </div>
    </form>
</body>
</html>
