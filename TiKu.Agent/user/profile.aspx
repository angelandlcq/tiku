<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="TiKu.Agent.user.profile" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>代理商个人资料</title>
    <link rel="stylesheet" type="text/css" href="../Css/bootstrap.css" />
    <link rel="stylesheet" type="text/css" href="../Css/bootstrap-responsive.css" />
    <link rel="stylesheet" type="text/css" href="../Css/style.css" />
    <link href="../js/validateform/validate.css" rel="stylesheet" />
    <script type="text/javascript" src="../Js/jquery-1.7.2.min.js"></script>
    <script type="text/javascript" src="../Js/bootstrap.js"></script>
    <script type="text/javascript" src="../Js/ckform.js"></script>
    <script type="text/javascript" src="../Js/common.js"></script>
    <script src="/js/validateform/Validform_v5.3.2_min.js" type="text/javascript"></script>
    <script src="/js/lhgdialog/lhgdialog.js" type="text/javascript" language="javascript"></script>
    <style type="text/css">
        body {padding-bottom: 40px;}
        .sidebar-nav { padding: 9px 0;}
        @media (max-width: 980px) {
            /* Enable use of floated navbar text */
            .navbar-text.pull-right {float: none;padding-left: 5px;padding-right: 5px;}
        }

        #form1{width:980px;}
    </style>
</head>
<body>
    <script type="text/javascript">window.loading();</script>
    <form id="form1" runat="server">
        <table class="table table-bordered table-hover definewidth m10">
        <tr>
            <td width="11%" class="tableleft">登陆名</td>
            <td><%=AgentName%></td>
        </tr>
        <tr>
            <td class="tableleft">显示名称</td>
            <td><input type="text" id="txtShowName" maxlength="30" runat="server" datatype="s6-30" nullmsg="请输入显示名称" errormsg="请输入6-100个字符"/>&nbsp;<i class="Validform_checktip">显示名称不能超过100个字符</i></td>
        </tr>
        <tr>
            <td class="tableleft">联系人</td>
            <td><input type="text" id="txtContact" runat="server" datatype="s2-20" nullmsg="请输入联系人" errormsg="请输入2-20个字符" maxlength="20"/><i class="Validform_checktip">联系人不能超过20个汉字或字符</i></td>
        </tr>
        <tr>
            <td class="tableleft">手机号</td>
            <td><input type="text" id="txtMobile" runat="server" maxlength="15"  datatype="m" nullmsg="请输入手机号" errormsg="手机号格式错误" /><i class="Validform_checktip">请输入手机号</i></td>
        </tr>
        <tr>
            <td class="tableleft">固话</td>
            <td><input type="text" id="txtTel" datatype="phone" nullmsg="请输入固话" ignore="ignore"  errormsg="请输入正确的固话" runat="server" maxlength="30" /><i class="Validform_checktip">例如(0371-6666666或65568756)</i></td>
        </tr>
                    <tr>
            <td class="tableleft">QQ</td>
            <td><input type="text" id="txtQQ" ignore="ignore"  runat="server" datatype="n3-16" errormsg="QQ号码必须为3-16位数字！" maxlength="16"/><i class="Validform_checktip">请输入QQ</i></td>
        </tr>
        <tr>
            <td class="tableleft">邮箱</td>
            <td><input type="text" id="txtEmail" datatype="e" errormsg="邮箱格式无效！" ignore="ignore"  runat="server" maxlength="100" /><i class="Validform_checktip">请输入邮箱</i></td>
        </tr>
                    <tr>
            <td class="tableleft">联系地址</td>
            <td><input type="text" id="txtAddress"  runat="server" maxlength="100" /><i class="Validform_checktip">请输入联系地址</i></td>
        </tr>
         <tr>
            <td class="tableleft">淘宝店铺地址</td>
            <td><input type="text" id="txtTaobaoUrl" value="" datatype="url" errormsg="请输入正确的网址！" runat="server" maxlength="200" ignore="ignore" /><i class="Validform_checktip">淘宝店铺地址</i></</td>
        </tr>
        <tr>
            <td class="tableleft">旺旺号</td>
            <td><input type="text" id="txtAliAccount"  runat="server" maxlength="100" ignore="ignore" /><i class="Validform_checktip">旺旺号</i></td>
        </tr>
        <tr>
            <td class="tableleft">官方网址</td>
            <td><input type="text" id="txtUrl" value="" datatype="url" errormsg="请输入正确的网址！" runat="server" maxlength="200" ignore="ignore"  /><i class="Validform_checktip">官方网址！</i></td>
        </tr>
        <tr>
            <td class="tableleft"></td>
            <td>
                <input type="submit" id="btnSubmit" runat="server" class="btn btn-primary" value="保存" /> &nbsp;&nbsp;
            </td>
        </tr>
    </table>
    </form>
    <script type="text/javascript">
        $(document).ready(function () {
            //表单验证
            $("#form1").Validform({
                tiptype: 3,
                datatype: {
                    phone: function (gets, obj, curform, regxp) {
                        //参数gets是获取到的表单元素值，
                        //obj为当前表单元素，
                        //curform为当前验证的表单，
                        //regxp为内置的一些正则表达式的引用。
                        var reg = /^([0-9]{3,4}-)?[0-9]{7,8}$/;
                        if (reg.test(gets)) {
                            return true;
                        }
                        else {
                            return false;
                        }
                        //return false表示验证出错，没有return或者return true表示验证通过。
                    }
                }
            });
        });

    </script>
</body>
</html>
