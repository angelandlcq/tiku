<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="audit.aspx.cs" Inherits="TiKu.Admin.Agent.audit" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>代理商审核-<%=WebName%></title>
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
<script type="text/javascript">window.loading();</script>
<form id="form1" runat="server">
	<div class="place">
    <span>位置：</span>
    <ul class="placeul">
    <li><a href="/main/index.aspx" target="rightFrame">首页</a></li>
    <li><a href="javascript:void(null);">代理商管理</a></li>
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
    <!--查询-->
    <ul class="seachform">  
    <li><label>登录名</label><input id="txtAgentName" runat="server" maxlength="60" type="text" class="scinput" /></li>        
    <li><label>&nbsp;</label><input runat="server" id="btnQuery" type="button" class="scbtn" value="查询"/></li>
    </ul>
    <!--data-->
    <table class="tablelist">
       <thead>
    	<tr>
        <th><input  type="checkbox" value='<%#Eval("ID")%>' onclick="__Tiku.checkAll(this);" checked="checked"/></th>
                <th>编号</th>
                <th>登录名</th>
                <th>显示名称</th>
                <th>手机号/固话</th>
                <th>QQ</th>
                <th>邮箱</th>
                <th>地址</th>
                <th>注册日期</th>
                <th>注册IP</th>
                <th>登录次数</th>
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
                <td><%#Eval("AgentName")%></td>
                <td><%#Eval("ShowName")%></td>
                <td><%#Eval("Mobile")+"/"+Eval("Tel")%></td>
                <td><%#Eval("QQ")%></td>
                <td><%#Eval("Email")%></td>
                <td><%#Eval("Address")%></td>
                <td><%#Eval("RegisterTime")%></td>
                <td><%#Eval("RegisterIP")%></td>
                <td><%#Eval("LogNum")%></td>
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
        <tfoot>
            <tr>
                <td class="tf-tools" colspan="13">
                    <asp:Button runat="server" ID="btnLock"  OnClientClick="return __Tiku.isCheckItem();" CommandName="lock"  Text="冻结" CssClass="btn-red" OnClick="btnLock_Click"/>
                    <asp:Button runat="server" ID="btnUnLock"  OnClientClick="return __Tiku.isCheckItem();"  CommandName="unlock" Text="解除冻结" CssClass="btn-green" OnClick="btnLock_Click"/>
                    <asp:Button runat="server" ID="btnAudit" OnClientClick="return __Tiku.isCheckItem();"  Text="审核" CssClass="btn-green" OnClick="btnAudit_Click"/>
                </td>
            </tr>
        </tfoot>
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
