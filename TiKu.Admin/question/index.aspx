<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="TiKu.Admin.question.index" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>题库信息-<%=WebName%></title>
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
    <li><a href="javascript:void(null);">题库信息</a></li>
    </ul>
    </div>
    
    <div class="rightinfo">
    
    <div class="tools">
    
    	<ul class="toolbar">
        <li>
          <a href="/q/course.aspx?action=add">
           <span><img src="/images/t01.png" alt=""/></span>添加
          </a>
        </li>
        </ul>
    </div>
    <!--查询-->
    <ul class="seachform">  
    <li><label>综合查询</label><input name="" type="text" class="scinput" /></li>        
    <li><label>状态</label>  
    <div class="vocation">
    <select class="select3">
    <option>全部</option>
    <option>其他</option>
    </select>
    </div>
    </li>
    <li><label>&nbsp;</label><input name="" type="button" class="scbtn" value="查询"/></li>
    </ul>
    <!--data-->
    <table class="tablelist">
       <thead>
    	<tr>
        <th><input  type="checkbox" value='<%#Eval("ID")%>' onclick="__Tiku.checkAll(this);" checked="checked"/></th>
                <th>编号</th>
                <th>题目</th>
                <th>题型</th>
                <th>正确次数</th>
                <th>错误次数</th>
                <th>平均难度</th>
                <th>收藏次数</th>
                <th>笔记数</th>
                <th>修改时间</th>
                <th>分值</th>
                <th>排序</th>
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
                <td><%#Eval("Title")%></td>
                <td><%#bll.ShowQTypeLabelText(Eval("QType"))%></td>
                <td><%#Eval("RigthtNum")%></td>
                <td><%#Eval("ErrorNum")%></td>
                <td><%#Eval("AvgDifficulty")%></td>
                <td><%#Eval("FavoriteNum")%></td>
                <td><%#Eval("NoteNum")%></td>
                <td><%#Eval("ModifyOn")%></td>
                <td><%#Eval("QScore")%></td>
                <td><%#Eval("Orders")%></td>
                <td><%#bll.ShowStateLabelText(Eval("State"))%></td>
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