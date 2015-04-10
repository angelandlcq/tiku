using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
/**************************************************************************
 * 
 * Author:lichaoqiang@sina.cn
 * Date:
 * Description:Cookie操作类
 * Mark:
 * 
 * **********************************************************************/
namespace TiKu.Common
{
    public class CookieUtil
    {

        /// <summary>
        /// 写入Cookie(注意：默认过期时间1天)
        /// </summary>
        /// <param name="name">Cookie名</param>
        /// <param name="value">值</param>
        public static void WriteCookie(string name, string value)
        {
            //1>创建Cookie
            HttpCookie cookie = new HttpCookie(name);
            cookie.Path = "/";
            cookie.Domain = HttpContext.Current.Request.Url.DnsSafeHost;
            cookie.Expires = DateTime.Now.AddDays(1);
            cookie.Value = value;
            //2>发送Cookie
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        /// <summary>
        /// 写入Cookie
        /// </summary>
        /// <param name="name">Cookie名</param>
        /// <param name="value">值</param>
        /// <param name="expire">过期时间戳</param>
        /// <param name="isReadOnly">是否允许客户端访问</param>
        public static void WriteCookie(string name,
                                       string value,
                                       TimeSpan expire,
                                       bool isReadOnly,
                                       string domain = "")
        {
            //1>创建Cookie
            HttpCookie cookie = HttpContext.Current.Request.Cookies[name] ?? new HttpCookie(name);
            cookie.Path = "/";
            cookie.Domain = domain;
            cookie.Expires = DateTime.Now.Add(expire);
            cookie.Value = value;
            cookie.HttpOnly = isReadOnly;
            //2>发送Cookie
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        /// <summary>
        /// 获取Cookie值
        /// </summary>
        /// <param name="name">Cookie名</param>
        /// <returns>返回Cookie值</returns>
        public static string GetCookieValue(string name)
        {
            if (null == HttpContext.Current.Request.Cookies[name])
            {
                return null;
            }
            return HttpContext.Current.Request.Cookies[name].Value;
        }

        /// <summary>
        /// Cookie是否存在
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool IsExistsCookie(string name)
        {
            return (HttpContext.Current.Request.Cookies[name] != null);
        }
    }
}
