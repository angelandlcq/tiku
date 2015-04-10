<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="TiKu.Admin.main.index" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>管理后台默认首页</title>
<link href="/css/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="/js/jquery.js"></script>
</head>
<body>
    <form id="form1" runat="server">
	<div class="place">
    <span>位置：</span>
    <ul class="placeul">
    <li><a href="/main/index.aspx" target="rightFrame">首页</a></li>
    </ul>
    </div>
    
    <div class="mainindex">
    
    
    <div class="welinfo">
    <span><img src="/images/sun.png" alt="天气" /></span>
    <b><%=LoginedAdminInfo.AdminName%>早上好，欢迎使用信息管理系统</b>(ourfat@163.com)
    <a href="/admin/profile.aspx">帐号设置</a>
    </div>
    
    <div class="welinfo">
    <span><img src="/images/time.png" alt="时间" /></span>
    <i>您上次登录的时间：<%=string.Format("{0:yyyy-MM-dd HH:mm}",LoginedAdminInfo.LastTime)%></i> （不是您登录的？<a href="#">请点这里</a>）
    </div>
    
    <div class="xline"></div>
    
    <ul class="iconlist">
    
    <li><img src="/images/ico01.png" /><p><a href="/base/webset.aspx">管理设置</a></p></li>
    <li><img src="/images/ico02.png" /><p><a href="#">录入题库</a></p></li>
    <li><img src="/images/ico03.png" /><p><a href="#">数据统计</a></p></li>
    <li><img src="/images/ico04.png" /><p><a href="#">文件上传</a></p></li>
    <li><img src="/images/ico05.png" /><p><a href="#">代理商管理</a></p></li>
    <li><img src="/images/ico06.png" /><p><a href="#">查询</a></p></li> 
            
    </ul>
    
    <div class="ibox"><a class="ibtn"><img src="/images/iadd.png" />添加新的快捷功能</a></div>
    
    <div class="xline"></div>
    <div class="box"></div>
    
    <div class="welinfo">
    <span><img src="/images/dp.png" alt="提醒" /></span>
    <b>天一题库管理系统使用指南</b>
    </div>
    
    <ul class="infolist">
    <li><span>您可以快速进行题库信息录入管理操作</span><a class="ibtn">录入题库</a></li>
    <li><span>您可以快速发布题库信息</span><a class="ibtn">发布或管理题库信息</a></li>
    <li><span>您可以进行密码修改、账户设置等操作</span><a class="ibtn">账户管理</a></li>
    </ul>
    
    <div class="xline"></div>
    
    <div class="uimakerinfo"><b>查看网站使用指南</b>(<a href="#" target="_blank">www.tiku.com</a>)</div>
    <ul class="umlist">
    <li><a href="#">如何录入题库</a></li>
    <li><a href="#">如何访问网站</a></li>
    <li><a href="#">如何管理广告</a></li>
    <li><a href="#">后台用户设置(权限)</a></li>
    <li><a href="/base/webset.aspx">系统设置</a></li>
    </ul>
    </div>
    </form>
</body>
</html>
