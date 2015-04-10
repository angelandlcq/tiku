<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeBehind="course.aspx.cs" Inherits="TiKu.Admin.q.course" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<title>选择课程分类</title>
<link href="../css/common.css" rel="stylesheet" />
<link href="../js/validateform/validate.css" rel="stylesheet" />
<link href="/plugin/kindeditor-4.1.7/themes/default/default.css" rel="stylesheet" />
<link href="../css/zTreeStyle/zTreeStyle.css" rel="stylesheet" />
<style type="text/css">
#container {width:800px;margin: 0 auto;max-width:1000px;min-width:700px;font-size: 14px;color: #000;border: dashed 1px #3C95C8;margin:10px auto;}
#container .table-select{width:100%;margin:10px auto;}
#container .table-select th{}
#container .table-select textarea{width:100%;min-height:200px;}
#container .table-select td{padding:4px 10px;}
#container .multi-select{ height:300px;width:100%;margin:10px 0;}
#container .select-auto{border:none;height:300px;width:100%;}
#container input[type='submit'],#container input[type='button']{border:solid 1px #cfcfcf;padding:6px 10px;color:#333;background:#efefef;}
#container label{padding:4px;float:left;}
#RbtQType  label{clear:both;float:none;}
#container select{border:solid 1px #828790;}
</style>
<script type="text/javascript" src="/js/jquery-1.7.2.min.js"></script>
<script type="text/javascript" src="/js/select-ui.min.js"></script>
<script src="/js/lhgdialog/lhgdialog.js?skin=iblue" type="text/javascript"></script>
<script src="/js/base.js" type="text/javascript"></script> 
<script src="../js/jquery.ztree.core-3.5.min.js" type="text/javascript"></script>
</head>
<body onload="closeLoading();">
<script type="text/javascript">loading();</script>
<form id="form1" runat="server">
<div id="container">
        <table class="table-select" cellpadding="0" cellspacing="0">
            <thead>
                <tr>
                    <th width="32%">课程分类</th>
                    <th width="32%">课程</th>
                    <th width="36%">章节考点</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>
                         <asp:DropDownList multiple="multiple" AutoPostBack="true" CssClass="multi-select" runat="server" ID="DrpCategory" OnSelectedIndexChanged="DrpCategory_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:DropDownList multiple="multiple" CssClass="multi-select" AutoPostBack="true" runat="server" ID="DrpCourse" OnSelectedIndexChanged="DrpCourse_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:DropDownList multiple="multiple" CssClass="multi-select" runat="server" ID="DrpChapter">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <label>题&nbsp;&nbsp;型：</label>
                        <asp:RadioButtonList runat="server" ID="RbtQType" RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="RbtQType_SelectedIndexChanged">
                            <asp:ListItem Value="1" Selected="True">单选</asp:ListItem>
                            <asp:ListItem Value="2">多选</asp:ListItem>
                            <asp:ListItem Value="3">判断</asp:ListItem>
                            <asp:ListItem Value="4">简答</asp:ListItem>
                            <asp:ListItem Value="5">一题多问</asp:ListItem>
                        </asp:RadioButtonList>
                        <asp:Label runat="server" ID="LblQtype" Visible="false">题型</asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" id="tbEditor" runat="server" visible="false">
                        <label>材&nbsp;&nbsp;料(针对一题多问):</label>
                        <textarea id="TxtMaterial" class="editor" runat="server" rows="10" cols="200"></textarea>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" align="center">
                        <asp:Button runat="server" ID="btnSubmit" Text="确认选择，进行下一步" />
                        <input type="button" value="重置" onclick="document.location = 'course.aspx';"/>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
</form>
<script src="../plugin/kindeditor-4.1.7/kindeditor-min.js" type="text/javascript"></script>
<script type="text/javascript">
    var editor;
    KindEditor.ready(function (K) {
        editor = K.create('.editor', {
            resizeType: 1,
            resizeMode: 1,
            width: 0,
            minWidth: 540,
            height: 300,
            allowPreviewEmoticons: false,
            allowImageUpload: false,
            items: [
                'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold', 'italic', 'underline',
                'removeformat', '|', 'justifyleft', 'justifycenter', 'justifyright', 'insertorderedlist',
                'insertunorderedlist', '|', 'emoticons', 'image', 'link'],
            afterBlur: function () { this.sync(); }
        });
    });
    $(document.body).ready(function () {
        $("#form1").bind("submit", function () {
            if ($(".edior").length > 0 && $("#TxtMaterial").val().length == 0) { window.ShowMsg("系统提示", "材料内容不能为空！", "", "confirm",null); return false; }
            return true;
        });
    });

    var setting = {
        data: { simpleData: { enable: true } },
        async: {
            dataType: "json",
            url: "/tools/AjaxSubmit.ashx?action=getChaptersJson&cid="+$("#DrpCourse").val(),
            type: "post",
            enable: true
        },
        callback: {onClick: function (event, treeId, treeNode) { }}
    };
    $(document).ready(function () {$.fn.zTree.init($("#chapterList"), setting);    });
    </script>
</body>
</html>
