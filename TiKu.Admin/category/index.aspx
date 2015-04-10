<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="TiKu.Admin.category.index" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>题库类别（科目分类）-<%=WebName%></title>
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
                width: 300
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
    <li><a href="javascript:void(null);">题库类别（科目分类）</a></li>
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
    <!--查询-->
    <ul class="seachform">  
    <li><label>综合查询</label><input runat="server" maxlength="30" placeholder="分类名称" id="txtKeywords" type="text" class="scinput" /></li>        
    <li><label>所属分类</label>  
    <div class="vocation">
  <asp:DropDownList runat="server" CssClass="select3" Width="140" ID="DrpCategory">

  </asp:DropDownList>
    </div>
    </li>
    <li><label>&nbsp;</label><input id="btnQuery" runat="server" type="button" class="scbtn" value="查询"/></li>
    </ul>
    <!--data-->
    <table class="tablelist">
       <thead>
    	<tr>
        <th><input  type="checkbox" value='<%#Eval("ID")%>' onclick="__Tiku.checkAll(this);" checked="checked"/></th>
                <th>编号</th>
                <th>分类名称</th>
                <th>排序</th>
                <th>创建者</th>
                <th>创建日期</th>
                <th>更新者</th>
                <th>更新日期</th>
                <th>操作</th>
        </tr>
        </thead>
       <tbody>
        <asp:Repeater runat="server" ID="RepList" OnItemCommand="RepList_OnItemCommand">
         <ItemTemplate>
           <tr>
        <td><input name="chkID" type="checkbox" value="<%#Eval("ID")%>" /></td>
                <td><%#Eval("ID")%></td>
                <td><%#Eval("CateName")%></td>
                <td><%#Eval("Orders")%></td>
                <td><%#Eval("CreatedBy")%></td>
                <td><%#Eval("CreatedOn")%></td>
                <td><%#Eval("ModifyBy")%></td>
                <td><%#Eval("ModifyOn")%></td>
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
