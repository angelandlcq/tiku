using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TiKu.Admin.q
{
    public partial class done : System.Web.UI.Page
    {

        /// <summary>
        /// 画面初始化
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInit(EventArgs e)
        {
            btnContinue.ServerClick += new EventHandler(btnContinue_ServerClick);
            base.OnInit(e);
        }

        /// <summary>
        /// 画面载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string strMaterial = PreviousPage.Request.Form["Material"];
                ClientScript.RegisterHiddenField("TxtMaterial", strMaterial);
            }
        }

        /// <summary>
        /// 继续添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnContinue_ServerClick(object sender, EventArgs e)
        {
            string strUrl = string.Format("edit.aspx?action=add&qtype={0}&course={1}&chapter={2}&mat={3}",
                                           TiKu.Common.TKRequest.GetQueryString("qtype"),
                                           TiKu.Common.TKRequest.GetQueryString("course"),
                                           TiKu.Common.TKRequest.GetQueryString("chapter"),
                                           TiKu.Common.TKRequest.GetQueryString("mat"));
            Server.Transfer(strUrl, true);
        }
    }
}