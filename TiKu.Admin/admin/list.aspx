<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="list.aspx.cs" Inherits="TiKu.Admin.admin.list" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>管理员管理</title>
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
    <li><a href="#">数据表</a></li>
    <li><a href="#">基本内容</a></li>
    </ul>
    </div>
    
    <div class="rightinfo">
    
    <div class="tools">
    
    	<ul class="toolbar">
        <li>
          <a href="add.aspx">
           <span><img src="/images/t01.png" /></span>添加
          </a>
        </li>
        </ul>
    </div>
    <table class="tablelist">
       <thead>
    	<tr>
        <th><input  type="checkbox" value='<%#Eval("ID")%>' onclick="__Tiku.checkAll(this);" checked="checked"/></th>
        <th>编号<i class="sort"><img src="/images/px.gif" /></i></th>
        <th>登陆名</th>
        <th>真实姓名</th>
        <th>所属角色</th>
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
        <td><%#Eval("AdminName") %></td>
        <td><%#Eval("TrueName") %></td>
        <td><%#((TiKu.Model.tb_Admin)Container.DataItem).Role.RoleName%></td>
        <td><%#Eval("ModifyOn","{0:yyyy-MM-dd}") %></td>
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
    
    <!--弹出层-->
    <div class="tip">
    	<div class="tiptop"><span>提示信息</span><a></a></div>
        
      <div class="tipinfo">
        <span><img src="/images/ticon.png" alt="提示"/></span>
        <div class="tipright">
        <p>是否确认对信息的修改 ？</p>
        <cite>如果是请点击确定按钮 ，否则请点取消。</cite>
        </div>
        </div>
        
        <div class="tipbtn">
        <input name="" type="button"  class="sure" value="确定" />&nbsp;
        <input name="" type="button"  class="cancel" value="取消" />
        </div>
    
    </div>
    </div>
    <script type="text/javascript">
        $('.tablelist tbody tr:odd').addClass('odd');
	</script>
    </form>
</body>
</html>
