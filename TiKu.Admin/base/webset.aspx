<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="webset.aspx.cs" Inherits="TiKu.Admin._base.webset" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>网站基本信息设置</title>
<link href="/css/style.css" rel="stylesheet" type="text/css" />
<link href="/css/select.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="/js/jquery.js"></script>
<script type="text/javascript" src="/js/jquery.idTabs.min.js"></script>
<script type="text/javascript" src="/js/select-ui.min.js"></script>
<script src="/js/lhgdialog/lhgdialog.js?skin=iblue" type="text/javascript"></script>
<script src="../js/base.js" type="text/javascript"></script>
<script type="text/javascript">
    $(document).ready(function (e) {
        $(".select1").uedSelect({
            width: 345
        });
        $(".select2").uedSelect({
            width: 167
        });
        $(".select3").uedSelect({
            width: 100
        });
    });
</script>
</head>
<body>
    <script type="text/javascript">window.loading();</script>
    <form id="form1" runat="server">
	<div class="place">
    <span>位置：</span>
    <ul class="placeul">
    <li><a href="/main/index.aspx">首页</a></li>
    <li><a href="javascript:;">系统设置</a></li>
    </ul>
    </div>
    
    <div class="formbody">
    
    <div id="usual1" class="usual"> 
    
    <div class="itab">
  	<ul> 
      <li><a href="#tab1" class="selected">网站基本信息</a></li>
      <li><a href="#tab2">邮件服务器设置</a></li>  
  	</ul>
    </div> 
    
  	<div id="tab1" class="tabson">
    
    <div class="formtext">Hi，<b><%=AdminName %></b>，欢迎您试用系统设置功能！</div>
    
    <ul class="forminfo">
    <li><label>网站名称<b>*</b></label>
    <input id="txtWebName" runat="server" maxlength="100" type="text" class="dfinput"  placeholder="网站名称" value=""  style="width:518px;"/>
    </li>
    <li>
       <label>企业名称<b>*</b></label>  
       <input id="txtCompanyName" runat="server" maxlength="100" type="text" class="dfinput" placeholder="企业名称"  value=""  style="width:518px;"/>
    </li>
    <li>
       <label>网站域名<b>*</b></label>  
       <input id="txtWebDomain"  runat="server" maxlength="200" type="text" class="dfinput" placeholder="网站域名" value=""  style="width:518px;"/>
    </li>
        <li>
       <label>ICP备案号：</label>  
       <input id="txtICP" runat="server" maxlength="100" type="text" class="dfinput" placeholder="ICP备案号"  value=""  style="width:518px;"/>
    </li>
    <li><label>管理员日志<b>*</b></label>
    <cite><asp:CheckBox runat="server" ID="chkEnableAdminLog" />&nbsp;&nbsp;(启用该功能会影响系统性能)</cite>
    </li>
   <li><label>会员日志<b>*</b></label>
    <cite><asp:CheckBox runat="server" ID="chkEnableUserLog" />&nbsp;&nbsp;(启用该功能会影响系统性能)</cite>
    </li>
        <li><label>代理商日志<b>*</b></label>
    <cite><asp:CheckBox runat="server" ID="chkAgentLog" />&nbsp;&nbsp;(启用该功能会影响系统性能)</cite>
    </li>
    <li><label>回收站<b>*</b></label>
    <cite><asp:CheckBox runat="server" ID="chkEnableTrash" />&nbsp;&nbsp;(启用后，误删的数据可以恢复)</cite>
    </li>
     <li><label>开启关闭站点<b>*</b></label>
    <cite><asp:CheckBox runat="server" ID="chkEnableSite" />&nbsp;&nbsp;(关闭后，网站不能访问)</cite>
    </li>
    <li><label>&nbsp;</label><input name="" runat="server" id="btnSubmit" type="button" class="btn" value="保存信息"/></li>
    </ul>
    </div>
    <!--邮件服务器-->
    <div id="tab2" class="tabson">
        <ul class="forminfo">
    <li><label>SMTP服务器<b>*</b></label>
    <input id="txtSmtp" runat="server" maxlength="100" type="text" class="dfinput"  placeholder="SMTP服务器" value=""  style="width:518px;"/>
    </li>
    <li>
       <label>SMTP端口<b>*</b></label>  
       <input id="txtPort" runat="server" maxlength="100" type="text" class="dfinput" placeholder="SMTP端口"  value=""  style="width:518px;"/>
    </li>
    <li>
       <label>邮箱账号<b>*</b></label>  
       <input id="txtEmailAccount" runat="server" maxlength="100" type="text" class="dfinput" placeholder="邮箱账号"  value=""  style="width:518px;"/>
    </li>
    <li>
       <label>邮箱密码<b>*</b></label>  
       <input id="txtEmailPwd" runat="server" maxlength="100" type="password" class="dfinput" placeholder="邮箱密码"  value=""  style="width:518px;"/>
    </li>
    <li><label>&nbsp;</label><input name="" runat="server" id="btnSave" type="button" class="btn" value="保存设置"/></li>
    </ul>
    </div>
   </div> 
	<script type="text/javascript">
	    $("#usual1 ul").idTabs(); 
    </script>
    </div>
    </form>
</body>
</html>
