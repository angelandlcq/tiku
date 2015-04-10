using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
/*==============================================退出系统=================================================================*/
namespace TiKu.Agent
{
    public partial class exit : TiKu.WebUI.Page.AgentBase
    {

        /// <summary>
        /// 是否需要回话
        /// </summary>
        protected override bool IsRequirSession
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// 画面初始化
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInit(EventArgs e)
        {
            //退出系统
            new BLL.tb_Agent().ExitSystem(() =>
            {
                //日志
                if (BLL.tb_WebSet.WebSiteInfo.IsEnableAgentLog > 0)
                {
                    TiKu.Common.Logger.AgentLogger.Info(AgentID,
                                                        "退出系统",
                                                        string.Format("代理商{0}退出系统！", AgentName));
                }
            });
            base.OnInit(e);
        }
    }
}