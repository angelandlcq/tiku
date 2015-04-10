using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/*=================================================================================================
 * 
 * className:Agent页面基类
 * author:beisha
 * date:
 * modifyBy:
 * modifyOn:
 * mark:
 * 
 * ================================================================================================*/
namespace TiKu.WebUI.Page
{
    public class AgentBase : PageBase
    {

        #region 成员

        /// <summary>
        /// 代理商编号
        /// </summary>
        protected int AgentID
        {
            get
            {
                return LoginedInfo.ID;
            }
        }

        /// <summary>
        /// 登陆名
        /// </summary>
        protected string AgentName
        {
            get
            {
                return LoginedInfo.AgentName;
            }
        }

        /// <summary>
        /// 显示名称
        /// </summary>
        protected string ShowName
        {
            get
            {
                return LoginedInfo.ShowName;
            }
        }


        /// <summary>
        /// 是否启用代理商日志
        /// </summary>
        protected virtual bool IsEnableAgentLog
        {
            get
            {
                return (BLL.tb_WebSet.WebSiteInfo.IsEnableAgentLog > 0);
            }
        }

        /// <summary>
        /// 获取当前登录用户
        /// </summary>
        protected Model.tb_Agent LoginedInfo
        {
            get
            {
                return BLL.tb_Agent.GetAgentLoginedInfo();
            }
        }
        /// <summary>
        /// 是否要求登录
        /// </summary>
        protected virtual bool IsRequirSession
        {
            get
            {
                return true;
            }

        }
        #endregion


        /// <summary>
        /// 画面初始化
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInit(EventArgs e)
        {
            if (IsRequirSession)
            {
                if (new BLL.tb_Agent().CheckLoginState() == false)
                {
                    System.Web.HttpContext.Current.Response.Write("<script type=\"text/javascript\">alert(\"登陆超时，请重新登陆！\");top.location.href=\"/login.aspx\";</script>");
                    System.Web.HttpContext.Current.Response.End();
                    return;
                }
            }
            base.OnInit(e);
        }

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

        /// <summary>
        /// 代理商日志
        /// </summary>
        /// <param name="action">操作</param>
        /// <param name="message">消息</param>
        protected virtual void LogInfo(string action, string message)
        {
            if (IsEnableAgentLog)
            {
                TiKu.Common.Logger.AgentLogger.Info(AgentID,
                                                    action,
                                                    message);
            }
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
            strHtml.Append("<div class=\"inline pull-right page\">");
            strHtml.AppendFormat("共{0}条记录，当前{1}/{2}", count, currendIndex, pageCount);
            #region 首部处理
            strHtml.AppendFormat("<a href=\"{0}\">首页</a>", string.Format(pageUrl, 1));
            if (currendIndex > 1)
            {
                strHtml.AppendFormat("<a href=\"" + pageUrl + "\">上一页</a>", currendIndex - 1);
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
                    strHtml.AppendFormat("<span>{0}</span>", i);
                    strHtml.AppendLine();
                    continue;
                }
                if (i > right - 1 && pageCount > 10)
                {
                    strHtml.AppendFormat("<a href=\"{0}\">...</a>", string.Format(pageUrl, right + 1));
                }
                strHtml.AppendFormat("<a href=\"" + pageUrl + "\">{0}</a>", i);
                strHtml.AppendLine();
            }
            #endregion

            #region 尾部处理
            if (currendIndex == pageCount)
            {
                strHtml.Append("<span class=\"pagenxt\"></span>");
            }
            else
            {
                strHtml.AppendFormat("<a href=\"" + pageUrl + "\">尾页</a>", pageCount);
            }
            #endregion


            strHtml.Append("</div>");

            return strHtml.ToString();
        }
    }
}
