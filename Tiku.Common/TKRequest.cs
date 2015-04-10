using System;
using System.Collections.Generic;
#if CSHARP4 
 using System.Linq;
#endif
using System.Text;
using System.Web;
/*****************************************************************************
 * 
 * className:提供请求数据的访问公共类
 * author:李朝强
 * date:2014/05/30
 * mark:
 * 
 * ***************************************************************************/
namespace TiKu.Common
{
    public class TKRequest
    {
        /// <summary>
        /// 获取请求的查询参数
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string GetQueryString(string name)
        {
            if (HttpContext.Current != null
                && HttpContext.Current.Request.QueryString[name] != null)
            {
                string value = HttpContext.Current.Request.QueryString[name].Trim();
                if (CheckSafe(value) == false)
                {
                    return "危险字符！";
                }
                return value;
            }
            return string.Empty;
        }

        /// <summary>
        /// 获取整形查询参数值
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static int GetQueryInt(string name)
        {
            int iValue = 0;
            string value = GetQueryString(name);
            int.TryParse(value, out iValue);
            return iValue;
        }

        /// <summary>
        /// 获取表单值
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string GetFormString(string name)
        {
            string strReturn = string.Empty;
            if (null != HttpContext.Current &&
                HttpContext.Current.Request.Form[name] != null)
            {
                strReturn = HttpContext.Current.Request.Form[name].Trim();
                if (CheckSafe(strReturn) == false)
                {
                    return "Unsafe char!";
                }
                return strReturn;
            }
            return strReturn;
        }

        /// <summary>
        /// 获取表单值-整形
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static int GetFormInt(string name)
        {
            int iValue = 0;
            checked
            {

                string value = GetFormString(name);
                int.TryParse(value, out iValue);
            }
            return iValue;
        }

        /// <summary>
        /// 获取表单值-浮点
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static decimal GetFormDecimal(string name)
        {
            decimal iValue = 0.00M;
            checked
            {
                string value = GetFormString(name);
                decimal.TryParse(value, out iValue);
            }
            return iValue;
        }

        /// <summary>
        /// 获取表单值-数组
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string[] GetFormArray(string name)
        {
            string value = GetFormString(name).TrimEnd(',').Trim();
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }
            return value.Split(',');
        }

        /// <summary>
        /// 获取表单值-数组
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string[] GetFormValues(string name)
        {
            return HttpContext.Current.Request.Form.GetValues(name);
        }


        /// <summary>
        /// 获取GET、POST的参数值
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string GetString(string name)
        {
            string strReturn = string.Empty;
            if (null != HttpContext.Current)
            {
                strReturn = HttpContext.Current.Request[name];
                if (!string.IsNullOrEmpty(strReturn) && CheckSafe(strReturn) == false)
                {
                    return "Unsafe char!";
                }
                return strReturn;
            }
            return strReturn;
        }

        /// <summary>
        ///安全监测
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool CheckSafe(string value)
        {
            return Util.IsSafe(value);
        }
    }
}