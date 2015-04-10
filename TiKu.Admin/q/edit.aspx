<%@ Page Language="C#" ValidateRequest="false" AutoEventWireup="true" CodeBehind="edit.aspx.cs" Inherits="TiKu.Admin.q.edit" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>添加/修改试题信息</title>
<!--#include file="/include/base.html"-->
<link href="../js/validateform/validate.css" rel="stylesheet" />
<link href="/plugin/kindeditor-4.1.7/themes/default/default.css" rel="stylesheet" />
<script src="../js/validateform/Validform_v5.3.2_min.js" type="text/javascript"></script>
<script type="text/javascript">
        $(document).ready(function (e) {$(".select1").uedSelect({width: 345});        });
</script>
<style type="text/css">
#RbtQtype label,#RbtState label,#RbtAnswer label{clear:both;float:none;display:inline-block;padding-right:4px;}
.forminfo li>label{float:left;}
#table-items {border: solid 1px #cfcfcf;width: auto;}
#table-items td {border-bottom:dashed 1px #cfcfcf;line-height: 0;padding: 15px 4px;}
#table-items td textarea {width: 100%;height: auto;border:1px solid #cfcfcf;}
#table-items th {background-color: #F0F0EE;text-align: left;padding: 4px 0;}
.forminfo h1{line-height:34px;}
.forminfo .textarea{ border:dashed 1px #cfcfcf;height:100px;width:70%;float:left;margin:0px 10px 10px 0;max-width:700px;padding:4px 4px;}
</style>
</head>
<body>
<form id="form1" runat="server">
        <asp:HiddenField runat="server" ID="Material" />
        <div class="place">
            <span>位置：</span>
            <ul class="placeul">
                <li><a href="/main/index.aspx">首页</a></li>
                <li><a href="javascript:;">试题信息</a></li>
            </ul>
        </div>
        <div class="formbody">

            <div class="formtitle"><span>试题信息</span></div>

            <ul class="forminfo">
                    <li><label>章节考点：</label><h1><%=UrlDecode(TiKu.Common.CookieUtil.GetCookieValue("__Chapter__"))%></h1></li>
                    <li><label>题  目：<b>*</b></label>
                        <textarea rows="10" cols="200" class="textinput editor" style="width:100px;" id="txtTitle" runat="server"></textarea>
                    </li>
                    <li runat="server" id="PnlQtype">
                        <label>题型：<b>*</b></label>
                        <asp:RadioButtonList  runat="server" ID="RbtQtype" RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="RbtQtype_SelectedIndexChanged">
                            <asp:ListItem Value="6" Selected="True">单选</asp:ListItem>
                            <asp:ListItem Value="7">多选</asp:ListItem>
                            <asp:ListItem Value="9">简答</asp:ListItem>
                            <asp:ListItem Value="8">判断</asp:ListItem>
                        </asp:RadioButtonList>
                        <asp:Label runat="server" ID="LblQtype" Visible="false">题型</asp:Label>
                    </li>
                <li id="PnlMateContainer" runat="server">
                    <label>材  料:</label>
                    <div class="textarea" runat="server" id="PnlMat"></div>
                </li>
            <li id="pnlOptions" runat="server">
                <label>选  项</label>
                <table id="table-items" cellpadding="0" cellspacing="0">
                    <thead>
                        <tr>
                            <th>&nbsp;&nbsp;选项(最多可添加7项,至少填写2项)</th>
                            <th width="80px">操作</th>
                        </tr>
                    </thead>
                    <%if(base.ActionType==TiKu.Common.ActionType.Add){%>
                    <tr>
                        <td><textarea rows="4" name="items" cols="100">A、</textarea></td>
                        <td><a href="javascript:void(0);" class="btnRemove" onclick="RemoveOpt(this);">移除</a></td>
                    </tr>
                    <tr>
                        <td><textarea rows="4" name="items" cols="100">B、</textarea></td>
                        <td><a href="javascript:void(0);" class="btnRemove" onclick="RemoveOpt(this);">移除</a></td>
                    </tr>
                    <%}%>
                    <tr>
                        <td align="center" colspan="2">
                            <img src="/images/t01.png" alt="添加" id="btnAddOption" title="点击，添加新的选择项！" />
                        </td>
                    </tr>
                </table>
            </li>
                    <li><label>答  案：<b>*</b></label>
                        <textarea rows="10" cols="200" class="textinput editor" id="txtAnswer" runat="server"></textarea>
                        <asp:RadioButtonList runat="server" RepeatDirection="Horizontal" ID="RbtAnswer">
                            <asp:ListItem Value="1" Selected="True">(√)正确</asp:ListItem>
                            <asp:ListItem Value="0">(×)错误</asp:ListItem>
                        </asp:RadioButtonList>
                    </li>
                    <li><label>排  序：<b>*</b></label><input type="text" id="txtSort" runat="server" class="input dfinput" value="999" errormsg="排序数字必须是大于等于0的整数" datatype="n" maxlength="9" /><i class="Validform_checktip"></i></li>
                    <li><label>分  值：<b>*</b></label><input type="text" id="txtScore" runat="server" value="1" class="input dfinput" maxlength="9" datatype="n" errormsg="分值必须是大于0的数字！" /><i class="Validform_checktip"></i></li>
                    <li><label>级  别: <b>*</b></label>
                        <div class="vocation">
                        <asp:DropDownList runat="server" errormsg="请选择试题级别！" ID="DrpLevel" CssClass="select1">
                            <asp:ListItem Value="">--请选择级别--</asp:ListItem>
                        </asp:DropDownList>
                        </div>
                    </li>
                    <li><label>状  态：</label>
                       <asp:RadioButtonList runat="server" ID="RbtState" RepeatDirection="Horizontal">
                            <asp:ListItem Selected="True" Value="1">启用</asp:ListItem>
                            <asp:ListItem Value="0">禁用</asp:ListItem>
                        </asp:RadioButtonList>
                    </li>
                    <li><label>解  析：</label><textarea rows="20" cols="200" class="textinput editor" id="txtAnalyze" runat="server"></textarea></li>
                    <li>
                        <input type="submit" value="保存信息" onclick="return checkInput();" class="btn" runat="server" id="btnDoSubmit" />
                        <input type="button" value="返回重选科目>>" class="btn" onclick="document.location = 'course.aspx';"/>
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
<script src="../plugin/kindeditor-4.1.7/kindeditor-min.js" type="text/javascript"></script>
<script type="text/javascript">
    var _options = <%=Options%>;
    var editor;
    KindEditor.ready(function (K) {
        editor = K.create('textarea.editor', {
            resizeType: 1,
            resizeMode: 1,
            height: 300,
            width:710,
            minWidth:700,
            allowPreviewEmoticons: false,
            allowImageUpload: false,
            items:[
                'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold', 'italic', 'underline',
                'removeformat', '|', 'justifyleft', 'justifycenter', 'justifyright', 'insertorderedlist',
                'insertunorderedlist', '|', 'emoticons', 'image', 'link', 'wordpaste', 'preview', 'removeformat', 'table'],
            afterBlur: function () { this.sync(); }
        });
    });
    //添加选项
    function CreateOption(target, item)
    {
        //添加选项
        var _indexEN = ["A", "B", "C", "D", "E", "F", "G"];
        if ($("#table-items tr").length > 8) { return; }
        var $newOption = $($("#tpl-items").html()).clone(true);
        if (item && item.length > 0) { $newOption.find("textarea").val(item); }
        else{$newOption.find("textarea").val(_indexEN[$("#table-items tr").length - 2] + "、");}
        if ($(target).parent().parent().prev().length == 0) {$(target).parent().parent().before($newOption);return;}
        $(target).parent().parent().prev().after($newOption);
    }
    //移除选项
    function RemoveOpt(obj) { if ($("#table-items tr").length <= 4) { return; }; $(obj).parent().parent().remove(); }
    $(document.body).ready(function ()
    {
        //添加选项
        $("#btnAddOption").bind("click", function () { CreateOption(this); });
        for(var i in _options)
        {
            CreateOption($("#btnAddOption")[0],_options[i]);
        }
    });
    //验证表单输入
    function checkInput()
    {
        var isValidate = true, msg = "";
        $("#table-items textarea[name='items']").each(function (i, item) { if ($(item).val().length <= 2) { isValidate = false; msg = "请添加试题选项!"; return false; } });
        if (KindEditor.instances[0].html().length == 0){isValidate = false;msg = "题目内容不能为空！";}
        if ($("#DrpLevel option:checked").val().length == 0){isValidate = false;msg = "请选择试题级别！";}
        if (isValidate == false) {window.ShowMsg('系统提示', msg, "", "confirm");}
        return isValidate;
    }
    </script>
<!--选项模板-->
<script type="text/html" id="tpl-items">
<tr>
<td><textarea rows="4" name="items" cols="100"></textarea></td>
<td width="80px"><a href="javascript:void(0);" class="btnRemove" onclick="RemoveOpt(this);">移除</a></td>
</tr>
<!--选项模板结束-->
</script>
</body>
</html>
