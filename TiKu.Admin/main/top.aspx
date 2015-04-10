<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="top.aspx.cs" Inherits="TiKu.Admin.main.top" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>顶部导航</title>
    <link href="/css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="JavaScript" src="/js/jquery.js"></script>
    <script type="text/javascript">
        $(function () {
            //顶部导航切换
            $(".nav li a").click(function () {
                $(".nav li a.selected").removeClass("selected")
                $(this).addClass("selected");
            });
            //导航
            $(".nav li").bind("click", function () {
                var _for = $(this).attr("nav");
                $(parent.frames["leftFrame"].document).find("dd[for='" + _for + "']").show().siblings().hide();
                $(parent.frames["leftFrame"].document).find("dd[for='" + _for + "']").find("ul").show();
            });
        })
        function _showMenue(){
            //console.log(parent.frames["leftFrame"]);
           $(parent.frames["leftFrame"].document).find("dd[for='system']").show().siblings().hide();
        }	
    </script>
</head>
<body style="background:url(/images/topbg.gif) repeat-x;">

    <div class="topleft">
    <a href="main.aspx" target="_parent"><img src="/images/logo.png" alt="系统首页" title="系统首页" /></a>
    </div>
        
    <ul class="nav">
    <li nav="tiku"><a href="javascript:" onclick="_showMenue()" target="rightFrame" class="selected"><img src="/images/icon01.png" title="题库" /><h2>题库</h2></a></li>
    <li nav="user"><a href="javascript:" target="rightFrame"><img src="/images/icon02.png" title="用户管理" /><h2>用户管理</h2></a></li>
    <li nav="advertor"><a href="javascript:"  target="rightFrame"><img src="/images/icon03.png" title="广告管理" /><h2>广告管理</h2></a></li>
    <li><a href="javascript:"  target="rightFrame"><img src="/images/icon04.png" title="常用工具" /><h2>常用工具</h2></a></li>
    <li><a href="javascript:" target="rightFrame"><img src="/images/icon05.png" title="文件管理" /><h2>文件管理</h2></a></li>
    <li nav="setting"><a href="javascript:"  target="rightFrame"><img src="/images/icon06.png" title="系统设置" /><h2>系统设置</h2></a></li>
    </ul>
            
    <div class="topright">    
    <ul>
    <li><span><img src="/images/help.png" title="帮助"  class="helpimg"/></span><a href="#">帮助</a></li>
    <li><a href="javascript:;">关于</a></li>
    <li><a href="javascript:;" target="_parent" onclick="if(confirm('确定要退出系统吗？')){top.location.href='/exit.aspx';}">退出</a></li>
    </ul>
    <div class="user">
    <span>admin</span>
    <i>消息</i>
    <b>0</b>
    </div>     
    </div>
</body>
</html>
