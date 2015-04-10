<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="logView.aspx.cs" Inherits="TiKu.Admin._base.logView" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>查看日志</title>
    <link href="../css/common.css" rel="stylesheet" />
    <style type="text/css">
        body{ background:#efefef;}
        #container{ width:600px; height:400px;margin:0 auto;}
        #container textarea{
            margin:10px auto;
            border:solid 1px #cfcfcf;
            width:100%;
            overflow:auto;
            background:#fff;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
       <div id="container">
           <textarea rows="20" readonly="readonly" cols="200" id="txtBody" runat="server">
           </textarea>
       </div>
    </form>
</body>
</html>
