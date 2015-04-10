<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="list.aspx.cs" Inherits="TiKu.Admin.advertor.list" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title><%=WebName%></title>
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
    <li><a href="javascript:;">广告</a></li>
    <li><a href="javascript:void(null);">广告信息管理</a></li>
    </ul>
    </div>
    
    <div class="rightinfo">
    
    <div class="tools">
    
    	<ul class="toolbar">
        <li>
          <a href="edit.aspx?action=add">
           <span><img src="/images/t01.png" /></span>添加
          </a>
        </li>
        </ul>
    </div>
    <ul class="seachform">
    <li><label>广告位</label>  
    <div class="vocation">
      <asp:DropDownList runat="server" ID="DrpAdplace" CssClass="select2">
      </asp:DropDownList>
    </div>
    </li>
    <li><label>广告状态</label>  
    <div class="vocation">
     <asp:DropDownList runat="server" ID="DrpState" CssClass="select3">
         <asp:ListItem Value="">请选择</asp:ListItem>
         <asp:ListItem Value="1">启用</asp:ListItem>
         <asp:ListItem Value="0">禁用</asp:ListItem>
     </asp:DropDownList>
    </div>
    </li>
    <li><label>&nbsp;</label><input runat="server" id="btnQuery" type="button" class="scbtn" value="查询"/></li>
    </ul>
    <table class="tablelist">
       <thead>
    	<tr>
        <th><input  type="checkbox" value='<%#Eval("ID")%>' onclick="__Tiku.checkAll(this);" checked="checked"/></th>
        <th>编号<i class="sort"><img src="/images/px.gif" alt=""/></i></th>
        <th>广告标题</th>
        <th>广告位</th>
        <th>广告链接</th>
        <th>创建/修改日期</th>
        <th>状态</th>
        <th>操作</th>
        </tr>
        </thead>
       <tbody>
        <asp:Repeater runat="server" ID="RepList" OnItemCommand="RepList_OnItemCommand">
         <ItemTemplate>
           <tr>
        <td><input name="chkID" type="checkbox" value="<%#Eval("ID")%>" /></td>
        <td><%#Eval("ID")%></td>
        <td><%#Eval("AdText")%></td>
        <td><%#Eval("APID")%></td>
        <td><%#Eval("AdUrl")%></td>
        <td><%#Eval("AddTime", "{0:yyyy-MM-dd}")%></td>
        <td><%#ShowStateLabel(Eval("State"))%></td>
        <td>
            <asp:LinkButton runat="server" ID="btnDelete" OnClientClick="return confirm('确定要删除吗？');" 
            CommandName="delete" CommandArgument='<%#Eval("ID")%>' CssClass="tablelink" Font-Underline="true">
            <img src="/images/t03.png" height="14" alt="删除"/>删除</asp:LinkButton>

            &nbsp;&nbsp; <asp:LinkButton runat="server" ID="btnEdit" CommandName="edit" CommandArgument='<%#Eval("ID")%>' CssClass="tablelink" Font-Underline="true">
            <img src="/images/t02.png" height="14" alt="修改"/>修改</asp:LinkButton>  
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
