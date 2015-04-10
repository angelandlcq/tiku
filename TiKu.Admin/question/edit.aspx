<%@ Page Language="C#" ValidateRequest="false" AutoEventWireup="true" CodeBehind="edit.aspx.cs" Inherits="TiKu.Admin.question.edit" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>题库信息-<%=WebName%></title>
    <!--#include file="/include/base.html"-->
    <link href="../js/validateform/validate.css" rel="stylesheet" />
    <link href="../css/zTreeStyle/zTreeStyle.css" rel="stylesheet" />
    <link href="../plugin/kindeditor-4.1.7/themes/default/default.css" rel="stylesheet" />
    <script src="../js/validateform/Validform_v5.3.2_min.js" type="text/javascript"></script>
    <script src="../js/jquery.ztree.core-3.5.min.js" type="text/javascript"></script>
    <script src="../plugin/kindeditor-4.1.7/kindeditor-min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function (e) {$(".select1").uedSelect({width: 345});});
        var setting = {
            data: {simpleData: {enable: true}},
            async: {
                dataType: "json",
                url: "/tools/AjaxSubmit.ashx?action=getChaptersJson",
                type: "post",
                enable:true
            },
            callback: {
                onClick: function (event, treeId, treeNode) {}
            }
        };

        $(document).ready(function () {
            $.fn.zTree.init($("#chapterList"), setting);
            //选择课程
            $(".course li").bind("click", function ()
            {
                $(this).addClass("checked").siblings().removeClass("checked");
            });
        });
    </script>
    <style type="text/css">
        #content{max-width:1000px;background:#fff;width:100%;margin:10px auto;}
        #content .left-frame{ width:30%; height:600px;border:solid 1px #cfcfcf;float:left;overflow:auto;}
        #content .right-frame{width:68%;height:auto;border:solid 1px #cfcfcf;float:left;margin-left:16px;}
        #content .top-frame{width:100%;border:dashed 1px #cfcfcf;padding-bottom:20px;}
        #content .top-frame legend{padding:4px 0;width:100px;border:solid 1px #cfcfcf; text-align:center;margin-left:60px;}
        .clear{clear:both;height:0;}
        #content .course{list-style:none;margin:10px auto;}
        #content .course li{float:left;border:solid 1px #cfcfcf;padding:4px 10px;margin:4px 6px;}
        #content .left-frame h2{font-size:14px;width:100%;padding:4px 0;text-align:center;background:#efefef;border-bottom:solid 1px #cfcfcf;}
        #content .form-group{color:#333;}
        #content .form-group li{line-height:30px;padding:2px 0;overflow:hidden;border-bottom:solid 1px #cfcfcf;width:100%;border-collapse:collapse;}
        #content .form-group li label{margin:2px 6px;}
        #content .form-group li .input{height:30px;width:80%;}
        #RbtQtype label,#RbtState label{clear:both;float:none;display:inline-block;}
        .editor{height:200px;}
        #table-items{border:solid 1px #cfcfcf;width:540px;max-width:550px;}
        #table-items td{ border-bottom:dashed 1px #cfcfcf;line-height:0;padding:15px 4px;}
        #table-items td textarea{width:100%;height:auto}
        #table-items th{background-color:#F0F0EE;text-align:left;padding:4px 0;}
        #content .course .checked{border:1px solid #f06101;font-weight:bold;background:#f06101;}
        #content .course .checked a{color:#fff;}
        .forminfo li h1{line-height:34px;}
        .tpl-container{display:none;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="content">
            <fieldset class="top-frame">
                <legend>科目</legend>
                <ul class="course">
                    <li class="checked"><a href="#">一级建造师</a></li>
                    <li><a href="#">一级建造师</a></li>
                    <li><a href="#">一级建造师</a></li>
                    <li><a href="#">一级建造师</a></li>
                    <li><a href="#">一级建造师</a></li>
                    <li><a href="#">一级建造师</a></li>
                    <li><a href="#">一级建造师</a></li>
                    <li><a href="#">一级建造师</a></li>
                    <li><a href="#">一级建造师</a></li>
                    <li><a href="#">一级建造师</a></li>
                    <li><a href="#">一级建造师</a></li>
                    <li><a href="#">一级建造师</a></li>
                </ul>
                <div class="clear"></div>
            </fieldset>
            <div style="margin:10px auto;">
            <div class="left-frame">
                <h2>《章节考点》</h2>
                <div id="chapterList" class="ztree">
                    
                </div>
            </div>
            <div class="right-frame">
                <ul class="forminfo">
                    <li><label>科  目：</label><h1>一级建造师市政专业</h1></li>
                    <li><label>题  目：<b>*</b></label>
                        <textarea class="textinput editor" style="width:100px;" id="Textarea2" runat="server"></textarea>
                        <div class="clear"></div>
                    </li>
                    <li><label>题  型：<b>*</b></label>
                        <asp:RadioButtonList runat="server" ID="RbtQtype" RepeatDirection="Horizontal">
                            <asp:ListItem>单选</asp:ListItem>
                            <asp:ListItem>多选</asp:ListItem>
                            <asp:ListItem>简答</asp:ListItem>
                            <asp:ListItem>判断</asp:ListItem>
                            <asp:ListItem>分析</asp:ListItem>
                        </asp:RadioButtonList>
                    </li>
                    <li>
                        <label>选  项</label>
                        <table id="table-items" cellpadding="0" cellspacing="0">
                            <thead>
                                <tr>
                                    <th>&nbsp;&nbsp;选项</th>
                                    <th width="80px">操作</th>
                                </tr>
                            </thead>
                            <tr>
                                <td><textarea rows="4" cols="100"></textarea></td>
                                <td><a href="javascript:void(0);" class="btnRemove">移除</a></td>
                            </tr>
                           <tr>
                               <td align="center" colspan="2">
                                   <img src="/images/t01.png" alt="添加" id="btnAddOption" title="点击，添加新的选择项！"/>
                               </td>
                           </tr>
                        </table>
                    </li>
                    <li><label>答  案：<b>*</b></label><textarea class="textinput editor" id="txtRemark" runat="server"></textarea></li>
                    <li><label>排  序：</label><input type="text" class="input dfinput" value="999" errormsg="排序数字必须是大于等于0的整数" datatype="n" maxlength="9" /></li>
                    <li><label>分  值：</label><input type="text" class="input dfinput" maxlength="9" /></li>
                    <li><label>状  态：</label>
                       <asp:RadioButtonList runat="server" ID="RbtState" RepeatDirection="Horizontal">
                            <asp:ListItem Selected="True">启用</asp:ListItem>
                            <asp:ListItem>禁用</asp:ListItem>
                        </asp:RadioButtonList>
                    </li>
                    <li><label>解  析：</label><textarea class="textinput editor" id="Textarea1" runat="server"></textarea></li>
                    <li style="text-align:center;"><input type="submit" value="保存信息" class="btn" /></li>
                </ul>
            </div>
            <div class="clear"></div>
            </div>
        </div>
    </form>
    <!--模板-->
     <div class="tpl-container">
         <table id="table-tpl-option">
             <tr>
                <td><textarea rows="4" cols="100"></textarea></td>
                <td width="80px"><a href="javascript:void(0);" class="btnRemove">移除</a></td>
            </tr>
         </table>
     </div>
    <script type="text/javascript">
        var editor;
        KindEditor.ready(function (K) {
            editor = K.create('textarea.editor', {
                resizeType:1,
                resizeMode:1,
                width: 540,
                minWidth:540,
                allowPreviewEmoticons: false,
                allowImageUpload: false,
                items: [
                    'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold', 'italic', 'underline',
                    'removeformat', '|', 'justifyleft', 'justifycenter', 'justifyright', 'insertorderedlist','wordpaste',
                    'insertunorderedlist', '|', 'emoticons', 'image', 'link','preview']
            });
        });
        $(document.body).ready(function () {
            //添加选项
            $("#btnAddOption").bind("click", function ()
            {
                if ($("#table-items tr").length > 9) { return; }
                var $newOption = $("#table-tpl-option tr").first().clone(true);
                if ($(this).parent().parent().prev().length == 0)
                {
                    $(this).parent().parent().before($newOption);
                    return;
                }
                $(this).parent().parent().prev().after($newOption);
            });
            //移除选项
            $(".btnRemove").bind("click", function ()
            {
                $(this).parent().parent().remove();
            });
        });
    </script>
    <script type="text/html">
        <div>
            <%for(var i=0;i<data.length;i++){ %>
            <%} %>
        </div>
    </script>
</body>
</html>
