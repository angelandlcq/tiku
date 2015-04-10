using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TiKu.Agent
{
    public partial class index : TiKu.WebUI.Page.AgentBase
    {

        /// <summary>
        /// 是否需要回话
        /// </summary>
        protected override bool IsRequirSession
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// 画面载入事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { }
        }
    }
}