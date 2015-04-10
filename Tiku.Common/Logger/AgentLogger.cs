using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/*==================================================代理商日志===========================================================*/
namespace TiKu.Common.Logger
{
    public class AgentLogger
    {
        /// <summary>
        /// 日志记录器
        /// </summary>
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger("AgentLogger");



        /// <summary>
        /// 记录日志
        /// </summary>
        /// <param name="AgentID">代理商编号</param>
        /// <param name="action">操作</param>
        /// <param name="message">消息</param>
        public static void Info(int AgentID,
                        string action,
                        object message)
        {
            log4net.GlobalContext.Properties["AgentID"] = AgentID;
            log4net.ThreadContext.Properties["Action"] = action;
            log4net.ThreadContext.Properties["Level"] = "INFO";
            log4net.GlobalContext.Properties["AddDate"] = DateTime.Now;
            log4net.GlobalContext.Properties["IP"] = Util.GetIP(); ;
            log4net.GlobalContext.Properties["Msg"] = message;
            logger.Info(message);
        }
    }
}
