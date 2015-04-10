<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="edit.aspx.cs" Inherits="TiKu.Admin.role.edit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>角色信息</title>
    <link href="/css/style.css" rel="stylesheet" type="text/css" />
    <link href="/css/select.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/js/jquery.js"></script>
    <script type="text/javascript" src="/js/select-ui.min.js"></script>
    <script src="/js/lhgdialog/lhgdialog.js?skin=iblue" type="text/javascript"></script> 
    <script type="text/javascript">
        $(document).ready(function (e) {
            $(".select1").uedSelect({
                width: 345
            });
        });
</script>
</head>
<body>
 <form id="form1" runat="server">
    <div class="place">
    <span>位置：</span>
    <ul class="placeul">
    <li><a href="/main/index.aspx">首页</a></li>
    <li><a href="javascript:;">角色信息</a></li>
    </ul>
    </div>
    <div class="formbody">
    <div class="formtitle"><span>角色信息</span></div>
    <ul class="forminfo">
    <li><label>角色名称<b>*</b></label><input id="txtRoleName" runat="server" maxlength="30" type="text" class="dfinput" /><i>角色名称不能超过30个字符</i></li>
    <li><label>排序<b>*</b></label><input id="txtOrders" runat="server" maxlength="10" value="99" type="text" class="dfinput" /><i>排序必须为大于0的整数，越小越靠前</i></li>
    <li><label>是否启用</label><cite>
    <input id="radEnable" runat="server" name="radState" type="radio" />是&nbsp;&nbsp;&nbsp;&nbsp;
    <input id="radDisable" runat="server" name="radState"  type="radio" />否</cite></li>
    <li>
    <label>备注</label>
    <textarea class="textinput" id="txtRemark" runat="server"></textarea>
    </li>
    <li><label>&nbsp;</label>
    <input id="btnSubmit" runat="server" type="button" class="btn" value="确认保存"/>
    <input type="button" value="返回列表>>" class="btn" onclick="document.location='list.aspx';"/>
    </li>
    </ul>
    </div>
    </form>
</body>
</html>
