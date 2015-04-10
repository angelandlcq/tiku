using System;
using System.Collections.Generic;
#if CSHARP4 
 using System.Linq;
#endif
using System.Text;
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
    public class LogUtil
    {
        #region 日志记录器
        /// <summary>
        /// 系统错误日志
        /// </summary>
        public static readonly log4net.ILog SystemErrorLogger = log4net.LogManager.GetLogger("SystemErrorLogger");

        /// <summary>
        /// 系统通知
        /// </summary>
        public static readonly log4net.ILog SystemInforLogger = log4net.LogManager.GetLogger("SystemInforLog");
        #endregion

        #region 记录日志=========================================================异常日志
        /// <summary>
        /// 记录错误日志
        /// </summary>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        public static void Error(object message, Exception ex)
        {
            SystemErrorLogger.Error(message, ex);
        }
        /// <summary>
        /// 记录错误日志
        /// </summary>
        /// <param name="message"></param>
        public static void Error(object message)
        {
            SystemErrorLogger.Error(message);
        }
        /// <summary>
        /// 错误日志
        /// </summary>
        /// <param name="format"></param>
        /// <param name="parameters"></param>
        public static void ErrorFormat(string format, params object[] parameters)
        {
            SystemErrorLogger.ErrorFormat(format, parameters);
        }
        #endregion

        #region 记录日志=============================================================信息日志
        /// <summary>
        /// 信息日志
        /// </summary>
        /// <param name="message"></param>
        public static void Info(object message)
        {
            SystemInforLogger.Info(message);
        }
        /// <summary>
        /// 信息日志
        /// </summary>
        /// <param name="format"></param>
        /// <param name="parameters"></param>
        public static void Info(string format, params object[] parameters)
        {
            SystemInforLogger.InfoFormat(format, parameters);
        }
        #endregion
    }
}
