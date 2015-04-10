<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="TiKu.Agent.login" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>代理商登陆-<%=WebName%></title>
    <link href="css/vip.css" rel="stylesheet" type="text/css" />
    <link href="css/skin_01.css" rel="stylesheet" type="text/css" id="skin" />
    <script src="js/lhgdialog/lhgdialog.js" type="text/javascript" language="javascript"></script>
    <style type="text/css">
     .w100{ width:100px;}
    </style>
</head>
<body>
<script type="text/javascript" src="js/jquery-1.7.2.min.js"></script>
<script type="text/javascript" src="js/jquery.lqper.js"></script>
<script type="text/javascript" src="js/login.js"></script>
 <script src="/js/lhgdialog/lhgdialog.js" type="text/javascript"></script>
<div class="main">
        <div class="main_t"></div>
        <div class="main_m">
            <div class="main_bd">
                <div class="run">
                    <a href="javascript:void(0)" class="a1 run_skin" title="皮肤设置"></a><a href="javascript:void(0)"
                        class="a2 run_tm" title="透明度设置"></a>
                </div>
                <div class="yskj step1">
                    <div class="yskj_tt"><b>代理商登陆</b></div>
                    <form id="formLogin" runat="server">
                    <div class="yskj_bd">
                        <ul class="ul">
                            <li>
                                <label>登录名：</label>
                                <input  runat="server" id="txtAgentName"  autocomplete="off"  maxlength="60" value=""  type="text" class="txt1 txt" placeholder="请输入代理商账号..."></li>
                            <li>
                                <label>密&nbsp;&nbsp;码：</label>
                                <input runat="server"  id="txtPwd" autocomplete="off" maxlength="16" type="password" class="txt1 txt" placeholder="请输入代理商密码..." /></li>
                            <%if(IsRequirVerifyCode){%>
                            <li>
                                <label>验证码：</label>
                                <input id="txtVerifyCode" runat="server" class="txt2 w100" autocomplete="off"  type="text" maxlength="6"  />
                                <img src="/tools/validate.ashx" alt="验证码" onclick="_switchVerifyCode(this);"  title="点击图片，切换验证码" />
                            </li>
                            <%}%>
                        </ul>
                        <div class="reg">
                            <input type="submit" class="btn2" value="立即登陆" runat="server" id="btnSubmit" />
                        </div>
                    </div>
                    </form>
                </div>
                <div class="main_bg opcity">
                </div>
            </div>
        </div>
        <div class="main_b">
        </div>
    </div>
    <script type="text/javascript">
        $(document).ready(function () {      });
        //切换验证码
        function _switchVerifyCode(target) {var vSrc = "/tools/validate.ashx?v=" + Math.random();target.src = vSrc;}
    </script>
</body>
</html>