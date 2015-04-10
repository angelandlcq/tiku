<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="edit.aspx.cs" Inherits="TiKu.Admin.seo.edit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>SEO设置-<%=WebName%></title>
 <!--#include file="/include/base.html"-->
<link href="../js/validateform/validate.css" rel="stylesheet" />
<script src="../js/validateform/Validform_v5.3.2_min.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="place">
    <span>位置：</span>
    <ul class="placeul">
    <li><a href="/main/index.aspx">首页</a></li>
    <li><a href="javascript:;">SEO基本信息</a></li>
    </ul>
    </div>
    <div class="formbody">
    
    <div class="formtitle"><span>SEO基本信息</span></div>
    
    <ul class="forminfo">
    <li><label>网页标题<b>*</b></label><input id="txtTitle" datatype="*6-80" errormsg="请输入6-80个字符" runat="server" maxlength="80" type="text" class="dfinput" /><i class="Validform_checktip">标题不能超过80个字符</i></li>
    <li><label>调用别名<b>*</b></label><input id="txtCallName" datatype="callname" errormsg="别名只能是数字、字母、下划线" runat="server" maxlength="20" type="text" class="dfinput" value="" /><i class="Validform_checktip"></i></li>
    <li><label>关键词<b>*</b></label><input id="txtKeywords" datatype="s2-80" errormsg="请输入2-80个字符" runat="server" maxlength="80" type="text" class="dfinput" value="" /><i class="Validform_checktip"></i></li>
    <li><label>网页描述<b>*</b></label><input id="txtDescription" runat="server" maxlength="80" type="text" class="dfinput" value="" /><i class="Validform_checktip"></i></li>
    <li><label>排序<b>*</b></label><input id="txtSort" runat="server" datatype="n" errormsg="请输正整数" maxlength="9" type="text" class="dfinput" value="99" /><i class="Validform_checktip">请输正整数</i></li>
    <li><label>&nbsp;</label><input id="btnSubmit" runat="server" type="submit" class="btn" value="确认保存"/></li>
    </ul>
    </div>
    </form>
    <script type="text/javascript" language="javascript">
        $(document.body).ready(function () {
            $("#form1").Validform({
                tiptype: 3,
                datatype: {
                    callname: function (gets, obj, curform, regxp)
                    {
                //参数gets是获取到的表单元素值，
                //obj为当前表单元素，
                //curform为当前验证的表单，
                //regxp为内置的一些正则表达式的引用。
                var reg = /^[0-9a-zA-Z_]+$/;
                if (reg.test(gets)) {    return true;     } else {    return false;    }
               //return false表示验证出错，没有return或者return true表示验证通过。
        }}
            });
        });
    </script>
</body>
</html>
