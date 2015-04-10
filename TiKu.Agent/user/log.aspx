<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="log.aspx.cs" Inherits="TiKu.Agent.user.log" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>日志管理</title>
    <!--#include file="/include/base.html"-->
</head>
<body>
<script type="text/javascript">window.loading();</script> 
<form id="form1" runat="server">
<div class="form-inline definewidth m20">
关键词：<input type="text" runat="server" id="txtKeywords" class="abc input-default" placeholder="操作" value="">&nbsp;&nbsp;  
        <button type="submit" runat="server" id="btnQuery" class="btn btn-primary">查询</button>
</div>
<table class="table table-bordered table-hover definewidth m10">
    <thead>
    <tr>
        <th width="100px">编号</th>
        <th>操作</th>
        <th>消息</th>
        <th>时间</th>
        <th>IP</th>
        <th>操作</th>
    </tr>
    </thead>
    <tbody>
       <asp:Repeater runat="server" ID="RepList">
          <ItemTemplate>
	           <tr>
                 <td><%#Eval("ID")%></td>
                 <td><%#Eval("Action")%></td>
                 <td><%#Eval("Msg")%></td>
                 <td><%#Eval("AddDate","{0:yyyy-MM-dd HH:mm}")%></td>
                 <td><%#Eval("IP")%></td>
                 <td>
                 <asp:LinkButton runat="server" CommandArgument='<%#Eval("ID")%>' ID="btnDel" OnClientClick="return confirm('确定要删除该信息吗？');">删除</asp:LinkButton>                
                </td>
             </tr>
          </ItemTemplate>
       </asp:Repeater>	
    </tbody>
</table>
<!--分页 page-->
<%=__PagenationHtml%>
</form>
</body>
</html>