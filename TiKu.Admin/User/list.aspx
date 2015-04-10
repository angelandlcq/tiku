<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="list.aspx.cs" Inherits="TiKu.Admin.User.list" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>会员信息-<%=WebName%></title>
    <!--#include file="/include/base.html"-->
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
  <form id="form1" runat="server">
	<div class="place">
    <span>位置：</span>
    <ul class="placeul">
    <li><a href="/main/index.aspx" target="rightFrame">首页</a></li>
    <li><a href="javascript:void(null);">会员信息</a></li>
    </ul>
    </div>
    
    <div class="rightinfo">
    
    <div class="tools">
    	<ul class="toolbar"></ul>
    </div>
    <!--查询-->
    <ul class="seachform">  
    <li><label>综合查询</label><input placeholder="会员名/手机号/邮箱" runat="server" id="txtKeywords" maxlength="60" type="text" class="scinput" /></li>        
    <li><label>状态</label>  
    <div class="vocation">
  <asp:DropDownList CssClass="select3" runat="server" ID="DrpState">
      <asp:ListItem Value="">全部</asp:ListItem>
      <asp:ListItem Value="0">未激活</asp:ListItem>
      <asp:ListItem Value="1">激活</asp:ListItem>
      <asp:ListItem Value="2">冻结</asp:ListItem>
  </asp:DropDownList>
    </div>
    </li>
    <li><label>&nbsp;</label><input runat="server" id="btnQuery" type="button" class="scbtn" value="查询"/></li>
    </ul>
    <!--data-->
    <table class="tablelist">
       <thead>
    	<tr>
        <th><input  type="checkbox" value='<%#Eval("ID")%>' onclick="__Tiku.checkAll(this);" checked="checked"/></th>
                <th width="100px">会员编号</th>
                <th>会员名称</th>
                <th>显示名称</th>
                <th>手机号</th>
                <th>邮箱</th>
                <th>注册日期</th>
                <th>注册IP</th>
                <th width="100px">用户状态</th>
                <th>操作</th>
        </tr>
        </thead>
       <tbody>
        <asp:Repeater runat="server" ID="RepList" OnItemCommand="RepList_OnItemCommand">
         <ItemTemplate>
           <tr>
        <td><input name="chkID" type="checkbox" value="<%#Eval("ID")%>" /></td>
                <td><i>[<%#Eval("ID")%>]</i></td>
                <td title="<%#Eval("UserName")%>"><%#Eval("UserName")%></td>
                <td title="<%#Eval("NickName")%>"><%#Eval("NickName")%></td>
                <td><%#Eval("Mobile")%></td>
                <td><%#Eval("Email")%></td>
                <td><%#Eval("RegisterTime")%></td>
                <td><%#Eval("RegisterIP")%></td>
                <td><%#bll.ShowStateLabelText(Eval("State"))%></td>
                <td>
            <asp:LinkButton runat="server" ID="btnDelete" OnClientClick="return confirm('确定要删除吗？');" 
            CommandName="delete" CommandArgument='<%#Eval("ID")%>' CssClass="tablelink" Font-Underline="true">
            <img src="/images/t03.png" height="14" alt="删除"/>删除</asp:LinkButton>
        </tr>
         </ItemTemplate>
        </asp:Repeater> 
       </tbody>
    </table>
    
    <!--分页-->
    <%=__pagenation%>
    </div>
    <script type="text/javascript">
        $('.tablelist tbody tr:odd').addClass('odd');
	</script>
    </form>
</body>
</html>