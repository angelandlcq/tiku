<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="list.aspx.cs" Inherits="TiKu.Admin.Agent.list" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>经销商-<%=WebName%></title>
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
         <li><a href="add.aspx"><span><img src="/images/t01.png" alt="添加"/></span>添加</a></li>
         <li><a href="javascript:_Show();"><span><img src="/images/t02.png" alt="添加"/></span>重置密码</a></li>
        </ul>
    </div>
    <!--查询-->
    <ul class="seachform">  
    <li><label>登录名</label><input id="txtAgentName" runat="server" maxlength="60" type="text" class="scinput" /></li>        
    <li><label>状态</label>  
    <div class="vocation">
      <asp:DropDownList runat="server" ID="DrpState" CssClass="select3">
          <asp:ListItem Value="">请选择</asp:ListItem>
          <asp:ListItem Value="0">待审核</asp:ListItem>
          <asp:ListItem Value="1">通过</asp:ListItem>
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
                    </td> 
        </tr>
         </ItemTemplate>
        </asp:Repeater> 
       </tbody>
        <tfoot>
            <tr>
                <td class="tf-tools" colspan="13">
                    <asp:Button runat="server" ID="btnLock"  OnClientClick="return __Tiku.isCheckItem();"   CommandArgument="2"  Text="冻结" CssClass="btn-red" OnClick="btnAudit_Click"/>
                    <asp:Button runat="server" ID="btnUnLock"  OnClientClick="return __Tiku.isCheckItem();"  CommandArgument="1"  Text="解除冻结" CssClass="btn-green" OnClick="btnAudit_Click"/>
                    <asp:Button runat="server" ID="btnAudit" OnClientClick="return __Tiku.isCheckItem();"  Text="审核" CssClass="btn-green" CommandArgument="1" OnClick="btnAudit_Click"/>
                </td>
            </tr>
        </tfoot>
    </table>
    
    <!--分页-->
    <%=__pagenation%>
    </div>
    <script type="text/javascript">
        $('.tablelist tbody tr:odd').addClass('odd');
        var _dialog;
        function _Show() {
            var $checkedIDs=$("input[name='chkID']:checked");
            if($checkedIDs.length==0){
                alert("请选择你要修改的信息！");
                return;
            }
            if($checkedIDs.length>1)
            {
                alert("最多只能选择一条记录！");
                return;
            }
            _dialog=  $.dialog({
                title: "重置代理商密码",
                content: "url:/Agent/repwd.aspx?id=" + $checkedIDs.val(),
                width: 600,
                height: 400,
                lock: true
            });
        }
        //关闭窗口
        function _CloseWin() {_dialog.close();}
    </script>
    </form>
</body>
</html>