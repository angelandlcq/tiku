/**********************************js version1.0***************************************/
(function (target) {

    target.__Tiku = {

        //全选
        checkAll: function (obj) { $("input[name='chkID']").attr("checked", obj.checked); },
        //询问是否删除
        delConfirm: function () {
            if ($("input[name='chkID']:checked").length == 0) {
                alert("请选择你要删除的信息？");
                return false;
            }
            return window.confirm("确定要删除选中的数据吗？");
        },
        isCheckItem: function () {
            if ($("input[name='chkID']:checked").length == 0) {
                alert("请选择你要操作的信息？");
                return false;
            }
            return window.confirm("确定要操作选中的数据吗？");
        }
        //基于lhgdialog插件的函数
        , openWin: function (title, url) {

            $.dialog({
                content: "url:" + url,
                lock: true,
                ok: function () { },
                cancel: function () { }
            }).max();
        },
        //转换为字母
        toEN: function (input, target) { target.value = getSpell(input, ""); },
        //获取查询字符串
        queryString: function (name) {
            var uri = window.location.search;
            var re = new RegExp("" + val + "=([^&?]*)", "ig");
            return ((uri.match(re)) ? (uri.match(re)[0].substr(val.length + 1)) : null);
        },
        //是否是顶层窗口
        isTopWin: function () {
            if (top == window) { }
        }
    }

}(window));
//准备函数
$(document).ready(function () {
    //关闭加载特效window.closeLoading();
    document.body.onload = function () { window.closeLoading(); }
    parent.document.title = self.document.title;
});