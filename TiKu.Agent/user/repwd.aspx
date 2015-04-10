<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="repwd.aspx.cs" Inherits="TiKu.Agent.user.repwd" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>修改密码</title>
    <!--#include file="/include/base.html"-->
    <script src="/js/validateform/Validform_v5.3.2_min.js" type="text/javascript"></script>
</head>
<body>
    <script type="text/javascript">window.loading();</script>
    <form id="form1" runat="server">
        <table class="table table-bordered table-hover definewidth m10">
            <tr>
                <td class="">原始密码</td>
                <td>
                    <input type="password" id="txtOldPwd" maxlength="16" runat="server" datatype="s6-16" nullmsg="请输入显示名称" errormsg="请输入6-16个字符" />&nbsp;<i class="Validform_checktip">密码为6-16个字母数字或符号</i></td>
            </tr>
            <tr>
                <td class="">新密码</td>
                <td>
                    <input type="password" id="txtNewPwd" runat="server" datatype="s6-16" nullmsg="请输入新密码" errormsg="请输入6-16个字符" maxlength="16" /><i class="Validform_checktip">密码为6-16个字母数字或符号</i></td>
            </tr>
            <tr>
                <td class="">确认密码</td>
                <td>
                    <input type="password" id="txtConfirmPwd" runat="server" datatype="s6-16" nullmsg="请再次输入新密码" errormsg="请输入6-16个字符" maxlength="16" /><i class="Validform_checktip"></i></td>
            </tr>
            <tr>
                <td class=""></td>
                <td>
                    <input type="submit" id="btnSubmit" runat="server" class="btn btn-primary" value="保存" />
                    &nbsp;&nbsp;
                </td>
            </tr>
        </table>
    </form>
    <script type="text/javascript">
        $(document).ready(function () {
            //表单验证
            $("#form1").Validform({
                tiptype: 3,
                datatype: {   }
            });
        });

    </script>
</body>
</html>
