<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="edit.aspx.cs" Inherits="TiKu.Admin.Agent.edit" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>代理商信息-<%=WebName%></title>
    <!--#include file="/include/base.html"-->
    <link href="../js/validateform/validate.css" rel="stylesheet" />
    <script src="../js/validateform/Validform_v5.3.2_min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function (e) {
            $(".select1").uedSelect({ width: 345 });
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
                        if (reg.test(gets))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                        //return false表示验证出错，没有return或者return true表示验证通过。
                    }
                }
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
                <li><a href="/main/index.aspx">首页</a></li>
                <li><a href="javascript:;">代理商信息</a></li>
            </ul>
        </div>

        <div class="formbody">

            <div class="formtitle"><span>代理商基本信息</span></div>

            <ul class="forminfo">
                <li>
                    <label>登录名</label><b><asp:Label runat="server" ID="lblAgentName" ></asp:Label></b></li>
                <li>
                    <label>显示名称<b>*</b></label><input id="txtShowName" datatype="s6-30" nullmsg="请输入显示名称" errormsg="请输入6-100个字符" runat="server" maxlength="100" type="text" class="dfinput" /><i class="Validform_checktip">显示名称不能超过100个字符</i></li>
                <li>
                    <label>联系人<b>*</b></label><input id="txtContact" datatype="s2-20" nullmsg="请输入联系人" errormsg="请输入2-20个字符" runat="server" maxlength="20" type="text" class="dfinput" /><i class="Validform_checktip">联系人不能超过20个汉字或字符</i></li>
                <li>
                    <label>手机号<b>*</b></label><input id="txtMobile" datatype="m" nullmsg="请输入手机号" errormsg="手机号格式错误" runat="server" maxlength="30" type="text" class="dfinput" /><i class="Validform_checktip">请输入手机号</i></li>
                <li>
                    <label>固话</label><input id="txtTel" datatype="phone" nullmsg="请输入固话" ignore="ignore"  errormsg="请输入正确的固话" runat="server" maxlength="30" type="text" class="dfinput" /><i class="Validform_checktip">例如(0371-6666666或65568756)</i></li>
                 <li>
                    <label>QQ</label><input id="txtQQ" ignore="ignore"  runat="server" datatype="n3-16" errormsg="QQ号码必须为3-16位数字！" maxlength="16" type="text" class="dfinput" /><i class="Validform_checktip">请输入QQ</i></li>
                 <li>
                    <label>邮箱</label><input id="txtEmail" datatype="e" errormsg="邮箱格式无效！" ignore="ignore"  runat="server" maxlength="100" type="text" class="dfinput" /><i class="Validform_checktip">请输入邮箱</i></li>
                 <li>
                    <label>联系地址</label><input id="txtAddress"  runat="server" maxlength="100" type="text" class="dfinput" /><i class="Validform_checktip">请输入联系地址</i></li>
                 <li>
                    <label>淘宝店铺地址</label><input id="txtTaobaoUrl" value="" datatype="url" errormsg="请输入正确的网址！" runat="server" maxlength="200" ignore="ignore" type="text" class="dfinput" /><i class="Validform_checktip">淘宝店铺地址</i></li>
                 <li>
                    <label>旺旺号</label><input id="txtAliAccount"  runat="server" maxlength="100" ignore="ignore" type="text" class="dfinput" /><i class="Validform_checktip">旺旺号</i></li>
                                 <li>
                    <label>官方网址</label><input id="txtUrl" value="" datatype="url" errormsg="请输入正确的网址！" runat="server" maxlength="200" ignore="ignore" type="text" class="dfinput" /><i class="Validform_checktip">官方网址！</i></li>
                <li>
                    <label>状态</label><cite>
                        <input id="radAuditing" runat="server" type="radio" name="radState" />待审核
                        <input id="radPost" runat="server" type="radio" checked="true" name="radState" />通过&nbsp;&nbsp;&nbsp;&nbsp;
                        <input id="radLock" runat="server" type="radio" name="radState" />冻结</cite>
                </li>
                <li>
                    <label>&nbsp;</label>
                    <input id="btnSubmit" runat="server" type="submit" class="btn" value="确认保存" />
                    <input type="button" class="btn" value="返回列表>>" onclick="document.location = 'list.aspx';" /></li>
            </ul>
        </div>
    </form>
</body>
</html>
