<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="edit.aspx.cs" Inherits="TiKu.Admin.course.edit" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>课程信息-<%=WebName%></title>
    <!--#include file="/include/base.html"-->
    <link href="../js/validateform/validate.css" rel="stylesheet" />
    <script src="../js/validateform/Validform_v5.3.2_min.js" type="text/javascript"></script>
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
                <li><a href="/main/index.aspx">首页</a></li>
                <li><a href="javascript:;">课程专业信息</a></li>
            </ul>
        </div>
        <div class="formbody">

            <div class="formtitle"><span>课程专业信息</span></div>

            <ul class="forminfo">
                <li>
                    <label>课程名称<b>*</b></label><input id="txtTitle" placeholder="请输入2-60个字符" datatype="*2-80" errormsg="请输入2-60个字符" runat="server" maxlength="60" type="text" class="dfinput" /><i class="Validform_checktip">课程名称不能超过60个字符</i></li>
                <li>
                    <label>课程分类</label>
                    <div class="vocation">
                        <asp:DropDownList runat="server" CssClass="select1" ID="DrpCategory">
                        </asp:DropDownList>
                    </div>
                </li>
               <li>
                    <label>调用别名<b>*</b></label><input id="txtVal" datatype="s2-30" errormsg="调用别名必须有数字、字母、下划线等组成！" runat="server" maxlength="30" type="text" class="dfinput" value="" /><i class="Validform_checktip">调用别名必须有数字、字母、下划线等组成！</i></li>
                <li>
                <li>
                    <label>排序<b>*</b></label><input id="txtSort" datatype="n" errormsg="请输入大于0的整数" runat="server" maxlength="8" type="text" class="dfinput" value="99" /><i class="Validform_checktip"></i></li>
                <li>
                    <label>备注</label><textarea runat="server" id="txtRemark" class="textinput" rows="10" cols="100"></textarea></li>
                <li>
                    <label>状态</label>
                    <label for="RbtEnable"><input type="radio" checked="true" name="state" id="RbtEnable"   runat="server"/>启用</label>
                    <label for="RbnDisbale"><input type="radio" name="state" id="RbnDisbale"  runat="server"/>禁用</label>
                </li>
                <li>
                    <label>&nbsp;</label>
                    <input id="btnSubmit" runat="server" type="submit" class="btn" value="确认保存" />
                    <input type="button" value="返回列表>>" class="btn"  onclick="document.location = 'index.aspx';"/>
                </li>
            </ul>
        </div>
    </form>
    <script type="text/javascript" language="javascript">
        $(document.body).ready(function () {
            $("#form1").Validform({
                tiptype: 3,
                datatype: {
                    callname: function (gets, obj, curform, regxp) {
                        //参数gets是获取到的表单元素值，
                        //obj为当前表单元素，
                        //curform为当前验证的表单，
                        //regxp为内置的一些正则表达式的引用。
                        var reg = /^[0-9a-zA-Z_]+$/;
                        if (reg.test(gets)) { return true; } else { return false; }
                        //return false表示验证出错，没有return或者return true表示验证通过。
                    }
                }
            });
        });
    </script>
</body>
</html>
