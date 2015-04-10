<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="edit.aspx.cs" Inherits="TiKu.Admin.advertor.edit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>广告信息-<%=WebName%></title>
    <!--#include file="/include/base.html"-->
    <link href="../js/validateform/validate.css" rel="stylesheet" />
    <link href="/js/uploadify/uploadify.css" rel="stylesheet" />
    <style type="text/css">
        #file_upload {float: left;}
        #btnUpload {display: none;}
        #dv-list{ height:100px; width:200px;}
        #dv-list img{ height:100%;width:100%;}
    </style>
    <script src="/js/uploadify/jquery.uploadify.min.js" type="text/javascript"></script>
    <script src="../js/validateform/Validform_v5.3.2_min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function (e) {
            $(".select1").uedSelect({ width: 345 });
            //表单验证
            $("#form1").Validform({ tiptype: 3 });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="place">
            <span>位置：</span>
            <ul class="placeul">
                <li><a href="/main/index.aspx">首页</a></li>
                <li><a href="javascript:;">广告信息</a></li>
            </ul>
        </div>

        <div class="formbody">

            <div class="formtitle"><span>基本信息</span></div>

            <ul class="forminfo">
                <li>
                    <label>广告文字<b>*</b></label><input id="txtAdText" datatype="s6-100" nullmsg="请输入广告文字" errormsg="请输入6-100个字符" runat="server" maxlength="100" type="text" class="dfinput" /><i class="Validform_checktip">广告文字不能超过100个字符</i></li>
                <li>
                    <label>广告位<b>*</b></label>
                    <div class="vocation">
                        <asp:DropDownList runat="server" CssClass="select1" ID="DrpAplace" datatype="*" sucmsg=" ">
                            <asp:ListItem>--请选择广告位--</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </li>
                <li>
                    <label>是否启用</label><cite>
                        <input id="radEnable" runat="server" type="radio" checked="true" name="radState" />是&nbsp;&nbsp;&nbsp;&nbsp;
    <input id="radDisable" runat="server" type="radio" name="radState" />否</cite></li>
                <li>
                    <label>广告链接<b>*</b></label><input id="txtUrl" value="http://" runat="server" maxlength="200" type="text" class="dfinput" /><i>广告链接必须以：http://或https://开头</i></li>
                <li>
                    <label>广告图片</label>
                    <div style="position: absolute; left: 140px; width: 300px;">
                        <input id="file_upload" name="file_upload" type="file" multiple="true" />
                        &nbsp;&nbsp;<a href="javascript:$('#file_upload').uploadify('upload');" id="btnUpload">上传</a>
                    </div>
                    <div style="clear: both;"></div>
                    <div id="dv-list">
                        <div id="uploadfileQueue"></div>
                    </div>
                    <asp:HiddenField runat="server" ID="HidImageUrl" />
                </li>
                <li>
                    <label>优先级</label><input id="txtSort" runat="server" maxlength="9" type="text" class="dfinput" value="99" /></li>
                <li>
                    <label>&nbsp;</label>
                    <input id="btnSubmit" runat="server" type="submit" class="btn" value="确认保存" />
                    <input type="button" class="btn" value="返回列表>>" onclick="document.location = 'list.aspx';" /></li>
            </ul>
        </div>
    </form>
    <script type="text/javascript">
        $(function () {
            $('#file_upload').uploadify({
                'swf': '/js/uploadify/uploadify.swf',
                'uploader': '/tools/UpfileTool.ashx',//指定服务器端上传处理文件，默认‘upload.php’
                'cancelImage': '/js/uploadify/cancel.png',
                'formData': { 'folder': 'true' },
                'removeTimeout': 1,
                'removeCompleted': false,
                'buttonText': '',
                'width': 65,
                'height': 25,
                'queueID': 'uploadfileQueue',
                'fileTypeDesc': '*.gif;*.jpeg;*.png;*.jpg',  //出现在上传对话框中的文件类型描述
                'fileTypeExts': '*.gif;*.jpeg;*.png;*.jpg', //控制可上传文件的扩展名，启用本项时需同时声明fileDesc
                'auto': false,                //选定文件后是否自动上传，默认false
                'multi': false,               //是否允许同时上传多文件，默认false
                'fileSizeLimit': '6MB',          //控制上传文件的大小，单位byte   500MB
                'uploadLimit': 1,            //多文件上传时，同时上传文件数目限制
                'formData': {},
                'onUploadSuccess': function (file, data, response) {
                    var _json = $.parseJSON(data);
                    $("#btnUpload").hide();
                    $('#file_upload').uploadify('disable', true);
                    $("#HidImageUrl").val(_json.filename);
                    $("#uploadfileQueue").remove();
                    $("#dv-list").append($("<img src='" + _json.filename + "' />"));
                },
                'onUploadError': function (file, errorCode, errorMsg, errorString) {
                    if (errorString == "Cancelled") { return; }
                    alert(file.name + ' 上传失败。详细信息: ' + errorString);
                },
                onCancel: function (file) {
                    $("#btnUpload").hide();
                    //console.log("取消");
                }, //文件被移除出队列时触发,返回file参数
                onClearQueue: function (queueItemCount) { console.log("取消"); },
                onSelect: function (file) { $("#btnUpload").show(); }
            });
        });
        function removeImage(target) {

            $('#file_upload').uploadify('cancel');
            $('#file_upload').uploadify('disable', false);
            $(target).parent().children().remove();

        }
    </script>
</body>
</html>
