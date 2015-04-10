<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dictEdit.aspx.cs" Inherits="TiKu.Admin._base.dictEdit" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>数据字典信息-<%=WebName%></title>
    <!--#include file="/include/base.html"-->
    <link href="../js/validateform/validate.css" rel="stylesheet" />
    <script src="../js/validateform/Validform_v5.3.2_min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function (e) {
            $(".select1").uedSelect({
                width: 345
            });
            //增加一排
            $("#btnAppend").bind("click", function ()
            {
                var $row = $("#table-item tr");
                if ($row.size() > 10)
                {
                    return;
                }
                $(this).parent().parent().prev().after($("#dvRow tr").clone());
            });
        });
        //验证字典名是否重复
        function _checkInput()
        {
            var isValidate = true;
            var _keys = "";
            $("#table-item input[name='key']").each(function (index, item)
            {
                if (item.value.length == 0) { return false;}
                if (_keys.indexOf(item.value) >= 0&&_keys.length>0)
                {
                    alert("字典键不能重复！");
                    isValidate = false;
                    return false;
                }
                _keys += $.trim(item.value) + ",";
            });
            return isValidate;
        }
        //移除一行
        function RemoveOneRow(target)
        {
            $(target).parent().parent().remove();
        }
    </script>
    <style type="text/css">
        #table-item{}
        #table-item td{ padding:2px 4px;}
    </style>
</head>
<body>
<form id="form1" runat="server">
        <div class="place">
            <span>位置：</span>
            <ul class="placeul">
                <li><a href="/main/index.aspx">首页</a></li>
                <li><a href="javascript:;">数据字典</a></li>
            </ul>
        </div>
        <div class="formbody">

            <div class="formtitle"><span>数据字典</span></div>

            <ul class="forminfo">
                <li><label>字典名称<b>*</b></label><input id="txtNames" placeholder="请输入2-100个字符" datatype="*2-80" errormsg="请输入2-60个字符" runat="server" maxlength="100" type="text" class="dfinput" /><i class="Validform_checktip">名称不能超过100个字符</i></li>
                <li><label>字典编号<b>*</b></label><input id="txtCode" placeholder="调用别名" datatype="s2-30" errormsg="请输入2-30数字、字母或下划线"  runat="server" maxlength="30" type="text" class="dfinput" value="" /><i class="Validform_checktip"></i></li>
                <li><label>字典值</label>
                    <table id="table-item">
                        <tr>
                            <th>名（Key）不能重复</th>
                            <th>值（Value）</th>
                            <th>操作</th>
                        </tr>
                        <%if(ActionType==TiKu.Common.ActionType.Edit){ %>
                           <%foreach(System.Collections.Generic.KeyValuePair<string,object> item in dictValues){%>
                           <tr>
                            <td><input name="key" maxlength="30" value="<%=item.Key%>" type="text" class="dfinput" style="width:100px;"/>&nbsp;&nbsp;&nbsp;&nbsp;</td>
                            <td><input name="val" maxlength="100" value="<%=item.Value%>" type="text" class="dfinput" style="width:180px;"/></td>
                            <td><input type="button" value="移除" onclick="RemoveOneRow(this);" class="scbtn"/></td>
                          </tr>
                           <%}%>
                        <%}else{ %>
                        <tr>
                            <td><input name="key" maxlength="30" type="text"  class="dfinput" style="width:100px;"/>&nbsp;&nbsp;&nbsp;&nbsp;</td>
                            <td><input name="val" maxlength="100" type="text" class="dfinput" style="width:180px;"/></td>
                            <td><input type="button" value="移除" onclick="RemoveOneRow(this);" class="scbtn"/></td>
                        </tr>
                        <tr>
                            <td><input name="key" maxlength="30" type="text" class="dfinput" style="width:100px;"/>&nbsp;&nbsp;&nbsp;&nbsp;</td>
                            <td><input name="val" maxlength="100" type="text" class="dfinput" style="width:180px;"/></td>
                            <td><input type="button" value="移除" onclick="RemoveOneRow(this);" class="scbtn"/></td>
                        </tr>
                        <tr>
                            <td><input name="key" maxlength="30" type="text" class="dfinput" style="width:100px;"/>&nbsp;&nbsp;&nbsp;&nbsp;</td>
                            <td><input name="val" maxlength="100" type="text" class="dfinput" style="width:180px;"/></td>
                            <td><input type="button" value="移除" onclick="RemoveOneRow(this);" class="scbtn"/></td>
                        </tr>
                        <tr>
                            <td><input name="key" maxlength="30" type="text" class="dfinput" style="width:100px;"/>&nbsp;&nbsp;&nbsp;&nbsp;</td>
                            <td><input name="val" maxlength="100" type="text" class="dfinput" style="width:180px;"/></td>
                            <td><input type="button" value="移除" onclick="RemoveOneRow(this);" class="scbtn"/></td>
                        </tr>
                        <%}%>
                        <tr>
                            <td colspan="2">
                                <input type="button" id="btnAppend" class="btn" value="增加一排"/>
                            </td>
                        </tr>
                    </table>
                    <table style="display:none" id="dvRow">
                         <tr>
                            <td><input name="key" maxlength="30" type="text" class="dfinput" style="width:100px;"/>&nbsp;&nbsp;&nbsp;&nbsp;</td>
                            <td><input name="val" maxlength="100" type="text" class="dfinput" style="width:180px;"/></td>
                            <td><input type="button" value="移除" onclick="RemoveOneRow(this);" class="scbtn"/></td>
                        </tr>
                    </table>
                </li>
                <li><label>描述</label><textarea runat="server" id="txtDescription" class="textinput" rows="10" cols="100"></textarea></li>
                <li><label>状态</label>
                    <label><input type="radio" name="state" checked="true"  runat="server" id="RbtEnable"/>启用</label>
                    <label><input type="radio" name="state"  runat="server" id="RbtDisable"/>禁用</label>
                </li>
                <li>
                    <label>&nbsp;</label>
                    <input id="btnSubmit" runat="server" onclick="return _checkInput();" type="submit" class="btn" value="确认保存" />
                    <input type="button" value="返回列表>>" class="btn"  onclick="document.location = 'dict.aspx';"/>
                </li>
            </ul>
        </div>
    </form>
    <script type="text/javascript" language="javascript">
        $(document.body).ready(function () {
            $("#form1").Validform({
                tiptype: 3,
                datatype: {
                    callname: function (gets, obj, curform, regxp) {
                        //参数gets是获取到的表单元素值，
                        //obj为当前表单元素，
                        //curform为当前验证的表单，
                        //regxp为内置的一些正则表达式的引用。
                        var reg = /^[0-9a-zA-Z_]+$/;
                        if (reg.test(gets)) { return true; } else { return false; }
                        //return false表示验证出错，没有return或者return true表示验证通过。
                    }
                }
            });
        });
    </script>
</body>
</html>
