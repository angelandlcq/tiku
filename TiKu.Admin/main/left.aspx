<%@ Page Language="C#" EnableViewState="false" AutoEventWireup="true" CodeBehind="left.aspx.cs" Inherits="TiKu.Admin.main.left" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>导航</title>
<link href="/css/style.css" rel="stylesheet" type="text/css" />
<script language="JavaScript" type="text/javascript" src="/js/jquery.js"></script>
<script type="text/javascript">
    $(function () {
        //导航切换
        $(".menuson li").click(function () {
            $(".menuson li.active").removeClass("active")
            $(this).addClass("active");
        });

        $('.title').click(function () {
            var $ul = $(this).next('ul');
            $('dd').find('ul').slideUp();
            if ($ul.is(':visible')) {
                $(this).next('ul').slideUp();
            } else {
                $(this).next('ul').slideDown();
            }
        });
    })	
</script>
</head>
<body style="background:#f0f9fd;">
	<div class="lefttop"><span></span>管理菜单</div>
    <dl class="leftmenu">
    <dd for="tiku">
    <div class="title">
    <span><img src="/images/leftico01.png" /></span>题库管理
    </div>
    	<ul class="menuson">
        <li><cite></cite><a href="/question/index.aspx" target="rightFrame">题库管理</a><i></i></li>
        <li class="active"><cite></cite><a href="/q/course.aspx?action=add" target="rightFrame">录入题库</a><i></i></li>
        <li><cite></cite><a href="/category/index.aspx" target="rightFrame">课程分类管理</a><i></i></li>
        <li><cite></cite><a href="/course/index.aspx" target="rightFrame">课程管理</a><i></i></li>
        <li><cite></cite><a href="/chapter/index.aspx" target="rightFrame">章节管理</a><i></i></li>
        </ul>    
    </dd>
    <dd for="setting">
    <div class="title">
    <span><img src="/images/leftico02.png" /></span>系统设置
    </div>
    <ul class="menuson">
        <li><cite></cite><a href="/admin/list.aspx" target="rightFrame">管理员管理</a><i></i></li>
        <li><cite></cite><a href="/admin/add.aspx" target="rightFrame">添加管理员</a><i></i></li>
        <li><cite></cite><a href="/role/list.aspx" target="rightFrame">角色管理</a><i></i></li>
        <li><cite></cite><a href="/admin/password.aspx" target="rightFrame">修改密码</a><i></i></li>
        <li><cite></cite><a href="/admin/profile.aspx" target="rightFrame">修改个人资料</a><i></i></li>
        <li><cite></cite><a href="/base/webset.aspx" target="rightFrame">网站基本设置</a><i></i></li>
        <li><cite></cite><a href="/base/dict.aspx" target="rightFrame">字典设置</a><i></i></li>
        <li><cite></cite><a href="/seo/list.aspx" target="rightFrame">SEO设置</a><i></i></li>
        <li><cite></cite><a href="/level/index.aspx" target="rightFrame">管理级别</a><i></i></li>
        <li><cite></cite><a href="/base/cachelist.aspx" target="rightFrame">清除缓存</a><i></i></li>
        <li><cite></cite><a href="/admin/log.aspx" target="rightFrame">日志管理</a><i></i></li>
        <li><cite></cite><a href="/base/systemlog.aspx" target="rightFrame">异常日志</a><i></i></li>
    </ul>     
    </dd> 
    <dd for="advertor"><div class="title"><span><img src="/images/leftico03.png" /></span>广告管理</div>
    <ul class="menuson">
        <li><cite></cite><a href="/advertor/place_list.aspx" target="rightFrame">广告位管理</a><i></i></li>
        <li><cite></cite><a href="/advertor/place_edit.aspx?action=add" target="rightFrame">添加广告位</a><i></i></li>
        <li><cite></cite><a href="/advertor/list.aspx" target="rightFrame">广告信息管理</a><i></i></li>
        <li><cite></cite><a href="/advertor/edit.aspx?action=add" target="rightFrame">发布广告</a><i></i></li>
    </ul>    
    </dd>  
    <dd for="user"><div class="title"><span><img src="/images/leftico04.png" /></span>用户管理</div>
    <ul class="menuson">
        <li><cite></cite><a href="/Agent/list.aspx" target="rightFrame">代理商管理</a><i></i></li>
        <li><cite></cite><a href="/Agent/add.aspx" target="rightFrame">添加代理商</a><i></i></li>
        <li><cite></cite><a href="/Agent/audit.aspx" target="rightFrame">代理商审核</a><i></i></li>
        <li><cite></cite><a href="/User/list.aspx" target="rightFrame">会员管理</a><i></i></li>
        <li><cite></cite><a href="javascript:;" target="rightFrame">其他</a><i></i></li>
    </ul>
    </dd>   
    </dl>
</body>
</html>
