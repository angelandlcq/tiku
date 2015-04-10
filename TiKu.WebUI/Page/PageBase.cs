using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/**************************************************************************
 * 
 * Author:
 * Date:2015/04/02
 * Description:Page基类
 * Mark:
 * 
 * **********************************************************************/
namespace TiKu.WebUI.Page
{
    public class PageBase : System.Web.UI.Page
    {
        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public PageBase() { }
        #endregion

        #region 成员
        /// <summary>
        /// 主机头
        /// </summary>
        protected string WebDomain
        {
            get { return System.Web.HttpContext.Current.Request.Url.DnsSafeHost; }
        }
        /// <summary>
        /// 站点名称
        /// </summary>
        protected string WebName
        {
            get
            {
                return new BLL.tb_WebSet().GetWebSiteInfo().WebName;
            }
        }
        /// <summary>
        /// 公司名称
        /// </summary>
        protected string Company
        {
            get
            {
                return new BLL.tb_WebSet().GetWebSiteInfo().Company;
            }
        }

        /// <summary>
        /// 是否启用回收站
        /// </summary>
        protected bool IsEnableDel
        {
            get
            {
                return (new BLL.tb_WebSet().GetWebSiteInfo().IsEnableDelete > 0);
            }
        }

        /// <summary>
        /// 每页显示记录数（默认：10);
        /// </summary>
        protected virtual int PageSize
        {
            get
            {
                return 10;
            }
        }
        #endregion

        #region 派生方法
        /// <summary>
        /// 结束当前请求
        /// </summary>
        protected virtual void StopRequest(string notify)
        {
            System.Web.HttpContext.Current.Response.Buffer = false;
            System.Web.HttpContext.Current.Response.ClearContent();
            System.Web.HttpContext.Current.Response.Write(notify);
            System.Web.HttpContext.Current.ApplicationInstance.CompleteRequest();
            System.Web.HttpContext.Current.Response.Close();
        }

        /// <summary>
        /// Url解码
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        protected virtual string UrlDecode(string input)
        {
            return System.Web.HttpUtility.UrlDecode(input);
        }

        /// <summary>
        /// Url编码
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        protected virtual string UrlEncode(string input)
        {
            return System.Web.HttpUtility.UrlEncode(input);
        }

        /// <summary>
        /// html编码
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        protected virtual string HtmlEncode(string input)
        {
            return System.Web.HttpUtility.HtmlEncode(input);
        }
        /// <summary>
        /// html 解码
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        protected virtual string HtmlDecode(string input)
        {
            return System.Web.HttpUtility.HtmlDecode(input);
        }
        #endregion
    }
}
