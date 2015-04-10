<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="TiKu.Agent.index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>代理商管理后台</title>
    <link href="assets/css/dpl-min.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/bui-min.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/main-min.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div class="header">
        <div class="dl-title">
          <%-- <h1 style="color:#fff;">代理商管理平台</h1>--%>
            <img src="/images/logo.png" />
        </div>

        <div class="dl-log">
            欢迎您，<span class="dl-log-user"><%=AgentName%></span><a href="javascript:if(confirm('确定要退出系统吗?')){top.location.href='/login.aspx';};" title="退出系统" class="dl-log-quit">[退出]</a>
        </div>
    </div>
    <div class="content">
        <div class="dl-main-nav">
            <div class="dl-inform">
                <div class="dl-inform-title"><s class="dl-inform-icon dl-up"></s></div>
            </div>
            <ul id="J_Nav" class="nav-list ks-clear">
                <li class="nav-item dl-selected">
                    <div class="nav-item-inner nav-home">系统管理</div>
                </li>
                <li class="nav-item dl-selected">
                    <div class="nav-item-inner nav-order">业务管理</div>
                </li>

            </ul>
        </div>
        <ul id="J_NavContent" class="dl-tab-conten">
        </ul>
    </div>
    <script type="text/javascript" src="assets/js/jquery-1.8.1.min.js"></script>
    <script type="text/javascript" src="assets/js/bui-min.js"></script>
    <script type="text/javascript" src="assets/js/common/main-min.js"></script>
    <script type="text/javascript" src="assets/js/config-min.js"></script>
    <script type="text/javascript">
        BUI.use('common/main', function () {
            var config = [{
                id: '1', menu: [{
                    text: '系统管理', items: [
                        { id: '12', text: '个人资料', href: 'user/profile.aspx' },
                        { id: '3', text: '修改密码', href: 'user/repwd.aspx' },
                        { id: '4', text: '日志管理', href: 'user/log.aspx' },
                        { id: '6', text: '充值/消费记录', href: 'user/till.html' }]
                }]
            },
            {
                id: '7', homePage: '9', menu: [{
                    text: '业务管理', items: [
                        { id: '9', text: '查询激活码', href: 'code/index.html' },
                        { id: '10', text: '获取激活码', href: 'code/get.html' }
                    ]
                }]
            }];
            new PageUtil.MainPage({
                modulesConfig: config
            });
        });
    </script>
</body>
</html>
