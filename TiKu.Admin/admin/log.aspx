<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="log.aspx.cs" Inherits="TiKu.Admin.admin.log" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>管理员日志-<%=WebName%></title>
<link href="/css/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="/js/jquery.js"></script>
<script src="/js/lhgdialog/lhgdialog.js?skin=iblue" type="text/javascript"></script> 
<script src="/js/base.js" type="text/javascript"></script>
<script type="text/javascript">
    $(document).ready(function () {
        $(".click").click(function () {
            $(".tip").fadeIn(200);
        });

        $(".tiptop a").click(function () {
            $(".tip").fadeOut(200);
        });

        $(".sure").click(function () {
            $(".tip").fadeOut(100);
        });

        $(".cancel").click(function () {
            $(".tip").fadeOut(100);
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
    <li><a href="#">首页</a></li>
    <li><a href="#">日志</a></li>
    </ul>
    </div>
    
    <div class="rightinfo">
    
    <div class="tools">
    
    	<ul class="toolbar">
        <li>
          <asp:LinkButton runat="server" ID="btnDel" OnClick="btnDel_Click" OnClientClick="return __Tiku.delConfirm();">
           <span><img src="/images/t03.png" alt="删除"/></span>删除
          </asp:LinkButton>
        </li>
        </ul>
    </div>
    <table class="tablelist">
       <thead>
    	<tr>
        <th><input  type="checkbox" value='<%#Eval("ID")%>' onclick="__Tiku.checkAll(this);" /></th>
        <th>编号<i class="sort"><img src="/images/px.gif" /></i></th>
        <th>操作类别</th>
        <th>事件</th>
        <th>日志级别</th>
        <th>日期</th>
        <th>IP</th>
        <th>操作员编号</th>
        <th>操作</th>
        </tr>
        </thead>
       <tbody>
        <asp:Repeater runat="server" ID="RepList" OnItemCommand="RepList_OnItemCommand">
         <ItemTemplate>
           <tr>
        <td><input name="chkID" type="checkbox" value="<%#Eval("ID")%>" /></td>
        <td><%#Eval("ID")%></td>
        <td><%#Eval("ActionType") %></td>
        <td><%#Eval("Event") %></td>
        <td><%#Eval("ActionLevel")%></td>
        <td><%#Eval("CreatedOn","{0:yyyy-MM-dd}") %></td>
        <td><%#Eval("IP")%></td>
        <td><%#Eval("AdminID")%></td>
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
    <!--弹出层-->
    </div>
    <script type="text/javascript">
        $('.tablelist tbody tr:odd').addClass('odd');
	</script>
</form>
</body>
</html>
