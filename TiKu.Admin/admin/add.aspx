<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="add.aspx.cs" Inherits="TiKu.Admin.admin.add" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>管理员信息</title>
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
    <li><a href="#">管理员基本信息</a></li>
    </ul>
    </div>
    
    <div class="formbody">
    
    <div class="formtitle"><span>基本信息</span></div>
    
    <ul class="forminfo">
    <li><label>登陆名<b>*</b></label><input id="txtAdminName" runat="server" maxlength="30" type="text" class="dfinput" /><i>标题不能超过30个字符</i></li>
    <li><label>登陆密码<b>*</b></label><input id="txtAdminPwd" runat="server" maxlength="16" type="password" class="dfinput" /><i>密码长度6-16位数字、字母或特殊符号</i></li>
    <li><label>是否启用</label><cite>
    <input id="radEnable" runat="server" type="radio"  checked="true" name="radState" />是&nbsp;&nbsp;&nbsp;&nbsp;
    <input id="radDisable" runat="server" type="radio"   name="radState">否</cite></li>
    <li><label>真实姓名</label><input id="txtTrueName" runat="server" maxlength="20" type="text" class="dfinput" value="" /></li>
    <li><label>所属角色<b>*</b></label>
    <div class="vocation">
    <asp:DropDownList runat="server" CssClass="select1" ID="DrpRole" >
    <asp:ListItem Value="">--请选择所属角色--</asp:ListItem>
    </asp:DropDownList>
    </div>
    </li>
    <li><label>&nbsp;</label><input id="btnSubmit" runat="server" type="button" class="btn" value="确认保存"/></li>
    </ul>
    </div>
    </form>
</body>
</html>
