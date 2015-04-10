using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
/*=================================================================================================
 * 
 * className:Admin页面基类
 * author:beisha
 * date:
 * modifyBy:
 * modifyOn:
 * mark:
 * 
 * ================================================================================================*/
namespace TiKu.WebUI.Page
{
    public partial class AdminBase : PageBase
    {
        #region 成员
        /// <summary>
        /// 是否启用管理员日志
        /// </summary>
        protected bool IsEnableAdminLog
        {
            get
            {
                return (new BLL.tb_WebSet().GetWebSiteInfo().IsEnableAdminLog > 0);
            }
        }
        /// <summary>
        /// 管理员id
        /// </summary>
        protected int AdminID
        {
            get
            {
                return LoginedAdminInfo.ID;
            }
        }
        /// <summary>
        /// 当前登录的管理员信息
        /// </summary>
        protected Model.tb_Admin LoginedAdminInfo
        {
            get
            {
                string strCookieVal = TiKu.Common.CookieUtil.GetCookieValue(TiKu.Common.Constants.ADMIN.COOKIE.COOKIE_SESSION);
                if (string.IsNullOrEmpty(strCookieVal)) { return null; }
                strCookieVal = System.Web.HttpUtility.UrlDecode(TiKu.Common.DES.Decode(strCookieVal, TiKu.Common.Constants.Encrypt.DES.ENCRYPT_KEY));
                Model.tb_Admin model = TiKu.Common.JsonHelper.MapToObject<Model.tb_Admin>(strCookieVal);
                return model;
            }
        }
        /// <summary>
        /// 登录名
        /// </summary>
        protected string AdminName
        {
            get
            {
                return LoginedAdminInfo.AdminName;
            }
        }
        /// <summary>
        /// 是否要求登录
        /// </summary>
        protected virtual bool IsRequireLogin
        {
            get { return true; }
        }
        /// <summary>
        /// 操作类别
        /// </summary>
        protected string ActionType
        {
            get
            {
                return TiKu.Common.TKRequest.GetQueryString("action");
            }
        }
        #endregion

        #region 画面初始化
        /// <summary>
        /// 画面初始化
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInit(EventArgs e)
        {
            //验证登陆状态
            if (IsRequireLogin)
            {
                if (new BLL.tb_Admin().CheckIsLogin() == false)
                {
                    //登陆地址
                    string strLoginUrl = string.Format("{0}?ReturnUrl={1}",
                                                        System.Web.Security.FormsAuthentication.LoginUrl,
                                                        Request.Url.ToString());

                    Response.Write("<script>alert(\"登陆超时，请重新登陆！\");top.location.href=\"" + strLoginUrl + "\";</script>");
                    Response.End();
                }
            }
            base.OnInit(e);
        }
        #endregion

        /// <summary>
        /// 提示消息
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="type">消息类别</param>
        protected void ShowMsg(string message, MessageType type)
        {
            TiKu.Common.MessageBox.ShowMsg(this,
                                           message,
                                           type);
        }

        /// <summary>
        ///  提示消息,并跳转至指定url
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="type">类别</param>
        /// <param name="url">跳转url</param>
        protected void ShowMsg(string message,
                               MessageType type,
                               string url)
        {
            TiKu.Common.MessageBox.ShowMsg(message,
                                           url,
                                           this,
                                           type);
        }


        #region  分页内容
        /// <summary>
        /// 分页内容
        /// </summary>
        /// <param name="size">页面大小</param>
        /// <param name="TotalCount">页面数量</param>
        /// <param name="currendIndex">当前页</param>
        /// <param name="pattern">url模式：demo.aspx?page={0}</param>
        /// <param name="target">窗口模式</param>
        /// <returns></returns>
        public static string get_pagenation(int size,
                                            int count,
                                            int currendIndex,
                                            string pattern,
                                            string target)
        {
            //打开窗口目标
            target = string.IsNullOrEmpty(target) ? "_top" : target;
            //总页数
            int pageCount = count / size;
            pageCount = pageCount * size == count ? pageCount : pageCount + 1;
            //分页内容
            StringBuilder strHtml = new StringBuilder();
            strHtml.Append("<div class='pagenation'>");

            #region 首部处理
            if (currendIndex > 1)
            {
                strHtml.AppendFormat("<a href='{0}' target='{1}'>[首页]</a>", string.Format(pattern, 1), target);
                strHtml.AppendFormat("<a href='{0}' target='{1}'>[上一页]</a>", string.Format(pattern, currendIndex - 1), target);
            }
            else
            {
                strHtml.Append("<span class='disabled'>首页</span>&nbsp;&nbsp;<span class='disabled'>上一页</span>");
            }
            #endregion

            #region 中间部分
            int i = 1;

            int right = (currendIndex + 4) > pageCount ? pageCount : currendIndex + 4;
            if (currendIndex > 6)
            {
                i = currendIndex - 5;
            }
            else
            {
                right = pageCount >= 10 ? 10 : pageCount;
            }
            for (; i <= right; i++)
            {
                if (i == currendIndex)
                {
                    strHtml.AppendFormat("<font class='current'>{0}</font>", i);
                    strHtml.AppendLine();
                    continue;
                }
                strHtml.AppendFormat("<a href='{0}' target='{1}'>{2}</a>", string.Format(pattern, i), target, i);
                strHtml.AppendLine();
            }
            #endregion

            #region 尾部处理
            if (currendIndex == pageCount)
            {
                strHtml.Append("<span class='disabled'>下一页</span><span class='disabled'>末页</span>");
                strHtml.AppendFormat("<span>总共({0})页</span>", pageCount);
            }
            else
            {
                strHtml.AppendFormat("<a href='{0}' target='{1}'>下一页</a>", string.Format(pattern, currendIndex + 1), target);
                strHtml.AppendFormat("<a href='{0}' target='{1}'>末页</a>", string.Format(pattern, pageCount), target);
                strHtml.AppendFormat("&nbsp;&nbsp;<span>总共({0})页</span>", pageCount);
            }
            #endregion

            strHtml.Append("</div>");

            return strHtml.ToString();
        }


        /// <summary>
        /// 分页内容
        /// </summary>
        /// <param name="size">页面大小</param>
        /// <param name="TotalCount">页面数量</param>
        /// <param name="currendIndex">当前页</param>
        /// <param name="pattern">url模式：demo.aspx?page={0}</param>
        /// <param name="target">窗口模式</param>
        /// <returns></returns>
        public string get_page_list(int size,
                                    int count,
                                    int currendIndex,
                                    string pageUrl)
        {
            //总页数
            int pageCount = (count + size - 1) / size;
            //分页内容
            StringBuilder strHtml = new StringBuilder();
            strHtml.Append("<div class=\"pagin\">");
            strHtml.AppendFormat("<div class=\"message\">共<i class=\"blue\">{0}</i>条记录，当前显示第&nbsp;<i class=\"blue\">{1}&nbsp;</i>页</div>", count, currendIndex);
            strHtml.Append("<ul class=\"paginList\">");
            #region 首部处理
            if (currendIndex > 1)
            {
                strHtml.AppendFormat("<li class=\"paginItem\"><a href=\"" + pageUrl + "\"><span class=\"pagepre\"></span></a></li>", currendIndex - 1);
            }
            else
            {
                strHtml.Append("<li class=\"paginItem\"><a href=\"javascript:;\"><span class=\"pagepre\"></span></a></li>");
            }
            #endregion

            #region 中间部分
            int i = 1;

            int right = (currendIndex + 4) > pageCount ? pageCount : currendIndex + 4;
            if (currendIndex > 6)
            {
                i = currendIndex - 5;
            }
            else
            {
                right = pageCount >= 10 ? 10 : pageCount;
            }
            for (; i <= right; i++)
            {
                if (i == currendIndex)
                {
                    strHtml.AppendFormat("<li class=\"paginItem current\"><a href=\"" + pageUrl + "\">{0}</a></li>", i);
                    strHtml.AppendLine();
                    continue;
                }
                if (i > right - 1 && pageCount > 10)
                {
                    strHtml.Append("<li class=\"paginItem more\"><a href=\"javascript:;\">...</a></li>");
                }
                strHtml.AppendFormat("<li class=\"paginItem\"><a href=\"" + pageUrl + "\">{0}</a></li>", i);
                strHtml.AppendLine();
            }
            #endregion

            #region 尾部处理
            if (currendIndex == pageCount)
            {
                strHtml.Append("<li class=\"paginItem\"><a href=\"javascript:;\"><span class=\"pagenxt\"></span></a></li>");
            }
            else
            {
                strHtml.AppendFormat("<li class=\"paginItem\"><a href=\"" + pageUrl + "\"><span class=\"pagenxt\"></span></a></li>", pageCount);
            }
            #endregion

            strHtml.Append("</ul>");

            strHtml.Append("</div>");

            return strHtml.ToString();
        }
        #endregion

        /// <summary>
        ///定向到， 404:未找到
        /// </summary>
        protected virtual void NotFound()
        {
            Response.Redirect("~/error.html", false);
        }

        /// <summary>
        /// 显示状态文本
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        protected virtual string ShowStateLabel(object state)
        {
            if (state == null || state == DBNull.Value)
            {
                return "未启用";
            }
            int iState = Convert.ToInt32(state);
            if (iState == TiKu.Common.Constants.Common.ENABLE)
            {
                return "已启用";
            }
            if (iState == TiKu.Common.Constants.Common.DISABLE)
            {
                return "未启用";
            }
            return "未启用";
        }

        /// <summary>
        /// 记录管理员日志
        /// </summary>
        /// <param name="strEvent">事件</param>
        /// <param name="action">操作</param>
        /// <param name="msg">消息</param>
        protected virtual void AdminLog(string strEvent,
                                        string action,
                                        string msg)
        {
            if (IsEnableAdminLog)
            {
                //记录日志
                TiKu.Common.Logger.AdminLogger.Info(AdminID,
                                                    strEvent,
                                                    action,
                                                    AdminName + msg);
            }
        }

        /// <summary>
        /// 设置RadioButtonList控件的值
        /// </summary>
        /// <param name="RbnLis"></param>
        /// <param name="value"></param>
        protected virtual void SetRadioButtonListValue(RadioButtonList RbnLis, string value)
        {
            ListItem item = RbnLis.Items.FindByValue(value);
            if (null != item)
            {
                item.Selected = true;
            }
        }
    }
}
