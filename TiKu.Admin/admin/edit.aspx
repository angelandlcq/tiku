<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="edit.aspx.cs" Inherits="TiKu.Admin.admin.edit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>修改管理员信息</title>
    <link href="/css/style.css" rel="stylesheet" type="text/css" />
    <link href="/css/select.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/js/jquery.js"></script>
    <script type="text/javascript" src="/js/select-ui.min.js"></script>
    <script src="/js/lhgdialog/lhgdialog.js?skin=iblue" type="text/javascript"></script> 
    <script src="../js/base.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function (e) {
            $(".select1").uedSelect({
                width: 345
            });
        });
</script>
</head>
<body>
    <script type="text/javascript">window.loading();</script>
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
    <li><label>登陆名</label><b><asp:Label runat="server" ID="lblAdminName" /></b><i></i></li>
    <li><label>是否启用</label><cite>
    <input id="radEnable" runat="server" type="radio" checked="true" name="radState"/>是&nbsp;&nbsp;&nbsp;&nbsp;
    <input id="radDisable" runat="server" type="radio" name="radState"/>否</cite></li>
    <li><label>真实姓名</label><input id="txtTrueName" runat="server" maxlength="20" type="text" class="dfinput" value="" /></li>
    <li><label>所属角色<b>*</b></label>
    <div class="vocation">
    <asp:DropDownList runat="server" CssClass="select1" ID="DrpRole" >
    <asp:ListItem>--请选择所属角色--</asp:ListItem>
    </asp:DropDownList>
    </div>
    </li>
    <li><label>&nbsp;</label><input id="btnSubmit" runat="server" type="button" class="btn" value="确认保存"/>
    <input onclick="document.location='list.aspx';"  type="button" class="btn" value="返回列表>>"/>
    </li>
    </ul>
    </div>
    </form>
</body>
</html>
