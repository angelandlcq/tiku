<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="TiKu.Admin.admin.profile" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>修改个人资料</title>
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
    <li><label>登陆名<b>*</b></label><i><label><b><%=AdminName%></b></label></i></li>
    <li><label>真实姓名</label><input id="txtTrueName" runat="server" maxlength="20" type="text" class="dfinput" value="" /></li>
    </div>
    </li>
    <li><label>&nbsp;</label><input id="btnSubmit" runat="server" type="button" class="btn" value="确认保存"/></li>
    </ul>
    </div>
    </form>
</body>
</html>
