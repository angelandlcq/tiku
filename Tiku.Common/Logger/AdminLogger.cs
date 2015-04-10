using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/*****************************************************************************
 * 
 * className:Admin日志记录
 * author:李朝强
 * date:2015/02/30
 * mark:
 * 
 * ***************************************************************************/
namespace TiKu.Common.Logger
{
    public class AdminLogger
    {
        /// <summary>
        /// 日志记录器
        /// </summary>
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger("AdminLogger");


        /// <summary>
        /// 记录日志信息
        /// </summary>
        /// <param name="AdminID">管理员变化</param>
        /// <param name="strEvent">事件</param>
        /// <param name="actionType">操作类别</param>
        /// <param name="message">日志内容</param>
        public static void Info(int AdminID,
                                string strEvent,
                                string actionType,
                                object message)
        {

            log4net.GlobalContext.Properties["ActionType"] = actionType;
            log4net.ThreadContext.Properties["AdminID"] = AdminID;
            log4net.ThreadContext.Properties["Event"] = strEvent;
            log4net.GlobalContext.Properties["ActionLevel"] = "INFO";
            log4net.GlobalContext.Properties["CreatedOn"] = DateTime.Now;
            log4net.GlobalContext.Properties["IP"] = Util.GetIP(); ;
            log4net.GlobalContext.Properties["Msg"] = message;
            logger.Info(message);
        }

        /// <summary>
        /// 错误日志
        /// </summary>
        /// <param name="AdminID">管理员编号</param>
        /// <param name="strEvent">事件</param>
        /// <param name="actionType">操作类别</param>
        /// <param name="ex">异常对象</param>
        public static void Error(int AdminID,
                                 string strEvent,
                                 string actionType,
                                 Exception ex)
        {

            log4net.GlobalContext.Properties["ActionType"] = actionType;
            log4net.ThreadContext.Properties["AdminID"] = AdminID;
            log4net.ThreadContext.Properties["Event"] = strEvent;
            log4net.GlobalContext.Properties["ActionLevel"] = "ERROR";
            log4net.GlobalContext.Properties["CreatedOn"] = DateTime.Now;
            log4net.GlobalContext.Properties["IP"] = Util.GetIP(); ;
            log4net.GlobalContext.Properties["Msg"] = ex.Message;
            logger.Error(ex);
        }


    }
}
