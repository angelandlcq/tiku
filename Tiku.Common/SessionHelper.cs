using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/*****************************************************************************
 * 
 * className:回话帮助类(Session)
 * author:李朝强
 * date:2014/05/30
 * mark:
 * 
 * ***************************************************************************/
namespace TiKu.Common
{
    public class SessionHelper
    {
        /// <summary>
        /// 保存Session
        /// </summary>
        /// <param name="name">回话name</param>
        /// <param name="value">值</param>
        public static void SaveToSession(string name, object value)
        {
            System.Web.HttpContext.Current.Session[name] = value;
        }

        /// <summary>
        /// 从回话中取值
        /// </summary>
        /// <typeparam name="T">返回值类型</typeparam>
        /// <param name="name">会员名</param>
        /// <returns></returns>
        public static T GetFromSession<T>(string name)
        {
            if (System.Web.HttpContext.Current.Session[name] == null)
            {
                return default(T);
            }
            return (T)System.Web.HttpContext.Current.Session[name];
        }


        /// <summary>
        /// 移除回话
        /// </summary>
        /// <param name="name">name</param>
        public static void Remove(string name)
        {
            System.Web.HttpContext.Current.Session[name] = null;
        }

        /// <summary>
        /// 回话是否存在
        /// </summary>
        /// <param name="name">name</param>
        /// <returns></returns>
        public static bool Exists(string name)
        {
            return (System.Web.HttpContext.Current.Session[name] != null);
        }
    }
}
