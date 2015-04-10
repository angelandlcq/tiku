<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="systemLog.aspx.cs" Inherits="TiKu.Admin._base.systemLog" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>系统日志</title>
    <style type="text/css">
        html,body,form,div,p,span,input,label,b,i,img,image,button,a{margin:0;padding:0;}
        body{font-size:14px;font-family:'Microsoft YaHei';color:#000;}
        #container{margin:20px auto;}
        #table-data{ border-collapse:collapse; table-layout:fixed;width:auto;margin:10px 10px;}
        #table-data th{ background: url("../images/th.gif") repeat-x scroll 0 0 rgba(0, 0, 0, 0);
    border: 1px solid #b6cad2;
    height: 34px;
    line-height: 34px;
    text-align: left;
    text-indent: 11px;}
        #table-data t0h{border:solid 1px #cfcfcf;padding:6px 6px; background-color:#066CAD;color:#fff; }
        #table-data td{border:solid 1px #cfcfcf;padding:10px 6px; overflow:hidden; text-overflow:ellipsis;}
        .title{ width:100%;padding:4px 0; background:#066CAD;color:#fff;margin:1px auto;}
        #btnClear{padding:4px 10px;border:solid 1px #cfcfcf;}
        .btn-red{color:#fff; background:#FF8400;padding:4px 10px;border-radius:10%;font-size:12px; text-decoration:none;}
        .btn-green{color:#fff; background:#7ACE7A;padding:4px 10px;border-radius:10%;font-size:12px; text-decoration:none;}
        </style>
    <script src="../js/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../js/lhgdialog/lhgdialog.js" type="text/javascript"></script>
</head>
<body onload="$load.close();">
   <script type="text/javascript">
      var $load= $.dialog({close:false,title:false,max:false,min:false});
   </script>
    <form id="form1" runat="server">
    <div class="title">&nbsp;&nbsp;&nbsp;&nbsp;共计：<%=RepList.Items.Count%>个日志文件,异常日志是由系统每天自动创建
        &nbsp;&nbsp;所占空间（<asp:Label runat="server" ID="lblSize"></asp:Label>）
    </div>
    <div id="container">
       <table id="table-data" cellpadding="0" cellspacing="0">
           <tr>
               <th width="100px">日志级别</th>
               <th width="360px">文件名</th>
               <th width="100px">文件类型</th>
               <th width="200px">文件大小</th>
               <th width="180px">最近修改日期</th>
               <th width="300px">操作</th>
           </tr>
           <asp:Repeater runat="server" ID="RepList" OnItemCommand="RepList_ItemCommand">
               <ItemTemplate>
                <tr>
               <td>Error</td>
               <td><%#((System.IO.FileInfo)Container.DataItem).Name%></td>
               <td><%#((System.IO.FileInfo)Container.DataItem).Extension%></td>
               <td><%#TiKu.Common.Util.FormatBytesStr(((System.IO.FileInfo)Container.DataItem).Length)%></td>
               <td><%#((System.IO.FileInfo)Container.DataItem).LastWriteTime.ToString("yyyy/MM/dd HH:mm")%></td>
               <td>
                   <asp:LinkButton Visible='<%#Eval("LastWriteTime","{0:yyyy/MM/dd}")!=DateTime.Now.ToString("yyyy/MM/dd")%>' runat="server" ID="btnDel" CssClass="btn-red" OnClientClick="return confirm('确定要删除该信息吗?');" CommandArgument='<%#Eval("Name")%>'  CommandName="delete">删除</asp:LinkButton>
                   <asp:LinkButton runat="server" OnClientClick='<%#"ShowViewLog(\""+((System.IO.FileInfo)Container.DataItem).Name+"\");return false;"%>' CssClass="btn-green" ID="btnView" CommandName="view" CommandArgument='<%#Eval("Name")%>'>查看日志</asp:LinkButton>
               </td>
                </tr>
               </ItemTemplate>
           </asp:Repeater>
           <tr>
               <td colspan="6" align="center">
                   <asp:Button runat="server" ID="btnClear" OnClientClick="return confirm('确定要清空信息吗？');"  Text="清空过期日志" OnClick="btnClear_Click"/>(清空过期日志，节省系统空间)
               </td>
           </tr>
       </table>
    </div>
    </form>
    <script type="text/javascript">
        function ShowViewLog(name) {
            $.dialog({
                title: "查看日志",
                content: "url:logView.aspx?name=" + name,
                close: function () { },
                width: 660,
                height: 450,
                max: false,
                min:false
            });
        }

    </script>
</body>
</html>
