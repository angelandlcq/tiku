<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeBehind="done.aspx.cs" Inherits="TiKu.Admin.q.done" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>信息保存成功！</title>
    <link href="../css/common.css" rel="stylesheet" />
    <style type="text/css">
        #container{max-width:1000px;margin:100px auto;border:dashed 2px #cfcfcf;padding:60px 0;text-align:center;background:#fff;}
        .btn{background: url("/images/btnbg.png") no-repeat scroll 0 0 rgba(0, 0, 0, 0);color: #fff;cursor: pointer;font-size: 14px;font-weight: bold;height: 35px;width: 137px;border:none;}
        #container p {padding:20px;font-size:16px;}
    </style>
</head>
<body>
<form runat="server" id="form1">
    <div id="container">
        <p><img src="/images/right.png" alt=""/>信息保存成功！</p>
        <input type="button" value="继续添加" class="btn" id="btnContinue" runat="server" />
        <input type="button" value="返回重选科目>>" class="btn" onclick="document.location = 'course.aspx?<%=Request.QueryString.ToString()%>'" />
        <input type="button" value="返回试题管理>>" class="btn" onclick="document.location = '/question/index.aspx';"/>
    </div>
    <script type="text/javascript" language="javascript">
        (function () {if (window.parent){window.parent.document.title = self.document.title;}}());
    </script>
</form>
</body>
</html>
