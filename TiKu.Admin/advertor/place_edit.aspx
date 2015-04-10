<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="place_edit.aspx.cs" Inherits="TiKu.Admin.advertor.place_edit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>广告位信息-<%=WebName%></title>
    <!--#include file="/include/base.html"-->
</head>
<body>
  <form id="form1" runat="server">
    <div class="place">
    <span>位置：</span>
    <ul class="placeul">
    <li><a href="/main/index.aspx">首页</a></li>
    <li><a href="javascript:;">广告位信息</a></li>
    </ul>
    </div>
    
    <div class="formbody">
    
    <div class="formtitle"><span>基本信息</span></div>
    
    <ul class="forminfo">
    <li><label>广告位名称<b>*</b></label><input id="txtAdpName" runat="server" maxlength="30" type="text" class="dfinput" /><i>广告名称不能超过60个字符</i></li>
    <li><label>是否启用</label><cite>
    <input id="radEnable" runat="server" type="radio"  checked="true" name="radState" />是&nbsp;&nbsp;&nbsp;&nbsp;
    <input id="radDisable" runat="server" type="radio"   name="radState">否</cite></li>
    <li><label>广告位描述</label>
      <textarea class="textinput" id="txtRemark" runat="server"></textarea>
    </li>
    <li><label>排序</label><input id="txtSort" runat="server" maxlength="9" type="text" class="dfinput" value="99" /></li>
    <li><label>&nbsp;</label>
    <input id="btnSubmit" runat="server" type="button" class="btn" value="确认保存"/>
    <input type="button" class="btn" value="返回列表>>" onclick="document.location='place_list.aspx';"/></li>
    </ul>
    </div>
    </form>
</body>
</html>
