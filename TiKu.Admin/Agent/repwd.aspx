<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="repwd.aspx.cs" Inherits="TiKu.Admin.Agent.repwd" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>重置代理商密码</title>
    <!--#include file="/include/base.html"-->
    <link href="../js/validateform/validate.css" rel="stylesheet" />
    <script src="../js/validateform/Validform_v5.3.2_min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function (e) {
            $(".select1").uedSelect({ width: 345 });
            //表单验证
            $("#form1").Validform({
                tiptype: 3,
                datatype: {}
            });
        });
    </script>
</head>
<body style="width:600px;min-width:500px;">
  <script type="text/javascript">window.loading();</script>
 <form id="form1" runat="server">
    <div class="place">
    <span>位置：</span>
    <ul class="placeul">
    <li><a href="/main/index.aspx">首页</a></li>
    <li><a href="javascript:void(null);">重置代理商密码</a></li>
    </ul>
    </div>
    
    <div class="formbody">
    
    <div class="formtitle"><span>重置代理商密码</span></div>
    
    <ul class="forminfo">
    <li><label>登录名</label><b><asp:Label runat="server" ID="lblAgentName">lichaoqiang</asp:Label></b></li>
    <li><label>新密码<b>*</b></label><input id="txtPwd" style="width:200px"  datatype="s6-16" errormsg="请输入6-16位字符" runat="server" maxlength="16" type="password" class="dfinput" /><i class="Validform_checktip">密码长度6-16位数字、字母或特殊符号</i></li>
    <li><label>确认密码<b>*</b></label><input recheck="txtPwd" style="width:200px" id="txtConfirmPwd" datatype="s6-16" errormsg="请输入6-16位字符" runat="server" maxlength="16" type="password" class="dfinput" /><i class="Validform_checktip">密码长度6-16位数字、字母或特殊符号</i></li>
    <li><label>&nbsp;</label><input id="btnSubmit" runat="server"  type="submit" class="btn" value="确认保存"/></li>
    </ul>
    </div>
    </form>
</body>
</html>
