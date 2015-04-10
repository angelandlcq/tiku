<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="preview.aspx.cs" Inherits="TiKu.Admin.q.preview" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>预览试题</title>
    <!--#include file="/include/base.html"-->
    <style type="text/css">
        #wraper{max-width:1000px;margin:20px auto;border:solid 1px #cfcfcf;}
        #wraper ul{}
        #wraper ul li{padding:4px 10px;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="wraper">
            <ul>
                <li><label>题 目：</label></li>
                <li><label>题 型：</label></li>
                <li><label>选 项：</label></li>
                <li><label>答 案：</label></li>
                <li><label>解 析：</label></li>
                <li><label>修改时间：</label></li>
                <li><label>笔记数：</label></li>
                <li><label>错误数：</label></li>
            </ul>
        </div>
    </form>
</body>
</html>