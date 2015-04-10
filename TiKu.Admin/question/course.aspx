<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="course.aspx.cs" Inherits="TiKu.Admin.question.course" %>
<%@ Import Namespace="System.Collections.Generic" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>专业科目选择</title>
    <script src="../js/jquery-1.7.2.min.js" type="text/javascript"></script>
    <link href="../css/common.css" rel="stylesheet" />
    <link href="../css/course.css" rel="stylesheet" />
    <style type="text/css">
        body{ background:#F8F7F3;}
        #container h2{font-size:14px;width:100%; text-align:center;padding:6px 0;border-bottom:solid 1px #cfcfcf;border-top:solid 1px #cfcfcf;border-collapse:collapse;background:#efefef;}
    </style>
    <script type="text/javascript">
        $(document.body).ready(function () {
            $(".course>li").click(function () {
                $(this).addClass("checked").siblings().removeClass("checked");
                $("#cate-" + $(this).attr("for")).show().siblings().hide();
            });
            $(".course-item li").click(function () {
                $(this).addClass("checked").siblings().removeClass("checked");
            });
            $(".course>li").first().click();
        });
        parent.document.title = self.document.title;
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="container">
    <h2>专业课程</h2>
    <ul class="course">
         <%List<TiKu.Model.tb_CourseCategory> list = GetCourseCategory();%>
         <%foreach (TiKu.Model.tb_CourseCategory item in list.FindAll((m) => {return m.ParentID == 0; })){ %>
         <li class="" for="<%=item.ID%>">
             <a href="javascript:void(null);" >
                 <em class="<%=item.Val%>"></em>
                 <span><%=item.CateName%></span>
             </a>
         </li>
        <%}%>
    </ul>
     <div class="clear"></div>
    <div>
    <%foreach (TiKu.Model.tb_CourseCategory item in list.FindAll((m) => {return m.ParentID == 0; })){ %>
    <ul class="course-item" id="cate-<%=item.ID%>">
      <%foreach (TiKu.Model.tb_CourseCategory children in list.FindAll((m) => { return m.ParentID ==item.ID; })){ %>
         <li><a href="javascript:;"><%=children.CateName%></a></li>
      <%}%>
    </ul>
    <%}%>
    </div>
        <div class="clear"></div>
        <div class="btn-group">
            <input type="button" value="确认选择" onclick="document.location = 'edit.aspx';"/>
        </div>
        <div class="clear"></div>
    </div>
    </form>
<script src="../plugin/kindeditor-4.1.7/kindeditor-min.js" type="text/javascript"></script>
    <script type="text/javascript">
        var editor;
        KindEditor.ready(function (K) {
            editor = K.create('textarea.editor', {
                resizeType: 1,
                resizeMode: 1,
                width: 540,
                minWidth: 540,
                height: 300,
                allowPreviewEmoticons: false,
                allowImageUpload: false,
                items: [
                    'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold', 'italic', 'underline',
                    'removeformat', '|', 'justifyleft', 'justifycenter', 'justifyright', 'insertorderedlist',
                    'insertunorderedlist', '|', 'emoticons', 'image', 'link']
            });
        });
    </script>
</body>
</html>
