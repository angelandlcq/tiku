<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cacheList.aspx.cs" Inherits="TiKu.Admin._base.cacheList" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<title>缓存管理-<%=WebName%></title>
<link href="../css/common.css" rel="stylesheet" type="text/css" />
<style type="text/css">
        #container{max-width:1000px;margin:10px auto;color:#333;font-size:14px;}
        #container a{color:#333;}
        #container a:link{color:#333; text-decoration:none;}
        #container .ul-cache-list{list-style:none;border:dashed 1px #cfcfcf;}
        #container .ul-cache-list .clear{clear:both; height:0px;float:none;border:none;}
        #container .ul-cache-list li{border:solid 1px #cfcfcf;float:left;padding:10px 30px;margin:10px 10px;}
        #container .ul-cache-list li a{text-align:center;display:inline-block;}
        #container .ul-cache-list .active{border:solid 1px #ff6a00;background:#F0F9FD;}
        #container .ul-cache-list li a span{ text-align:center;font-weight:bold;}
        #container .ul-cache-list li a i{color:#3F97C9;margin:4px auto;font-size:14px;}
        #container h2{font-size:14px;width:100%;background:#efefef;border:solid 1px #cfcfcf;padding:4px 0;}
        #container .ul-cache-list li a em{  background: url("/images/close1.png") no-repeat scroll 0 0 / 18px 18px rgba(0, 0, 0, 0);
    margin-left: 4px;padding: 2px 9px;}
</style>
<script src="../js/jquery-1.7.2.min.js" type="text/javascript"></script>
<script src="../js/lhgdialog/lhgdialog.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="container">
     <h2>&nbsp;&nbsp;&nbsp;&nbsp;缓存对象</h2>
      <ul class="ul-cache-list">
          <li>
               <asp:LinkButton runat="server" ToolTip="点击，清除缓存" OnClick="lbtClear_Click" OnClientClick="return confirm('确定要清除该缓存吗?');" CommandArgument="WEBSITESET_CACHE_KEY" ID="lbtClear">
               <span>网站配置信息缓存</span><em></em><br />
               <i>(WEBSITESET_CACHE_KEY)</i>
              </asp:LinkButton>
          </li>
          <li>
               <asp:LinkButton runat="server" ToolTip="点击，清除缓存" OnClick="lbtClear_Click" OnClientClick="return confirm('确定要清除该缓存吗?');" CommandArgument="_CACHE_ADMIN_ROLE" ID="lbtClear2">
               <span>管理员角色信息缓存</span><em></em><br />
               <i>(_CACHE_ADMIN_ROLE)</i>
              </asp:LinkButton>
          </li>
          <li>
               <asp:LinkButton runat="server" ToolTip="点击，清除缓存" OnClick="lbtClear_Click" OnClientClick="return confirm('确定要清除该缓存吗?');" CommandArgument="_CACHE_ADVERTOR_PALCE_KEY" ID="LinkButton1">
               <span>广告位</span><em></em><br />
               <i>(_CACHE_ADVERTOR_PALCE_KEY)</i>
              </asp:LinkButton>
          </li>
          <li>
              <asp:LinkButton runat="server" ToolTip="点击，清除缓存" OnClick="lbtClear_Click" OnClientClick="return confirm('确定要清除该缓存吗?');" CommandArgument="_CACHE_COURSE_CATEGORY_KEY" ID="LinkButton2">
               <span>课程分类缓存</span><em></em><br />
               <i>(_CACHE_COURSE_CATEGORY_KEY)</i>
              </asp:LinkButton>
          </li>
          <li>
               <asp:LinkButton runat="server" ToolTip="点击，清除缓存" OnClick="lbtClear_Click" OnClientClick="return confirm('确定要清除该缓存吗?');" CommandArgument="_CACHE_DATABASE_TABLES_KEY" ID="LinkButton3">
               <span>数据库表缓存</span><em></em><br />
               <i>(_CACHE_DATABASE_TABLES_KEY)</i>
              </asp:LinkButton>
          </li>
          <li class="clear"></li>
      </ul>
        <div class="clear"></div>
    </div>
    </form>
    <script type="text/javascript" language="javascript">
        $(document.body).ready(function () {
            $("#container .ul-cache-list li").hover(function ()
            {
                $(this).addClass("active").siblings().remove("active");

            }, function ()
            {
                $(this).removeClass("active");
            });

        });
    </script>
</body>
</html>
