using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TiKu.Admin._base
{
    public partial class cacheList : TiKu.WebUI.Page.AdminBase
    {
        /// <summary>
        /// 页面载入事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        /// <summary>
        /// 清除缓存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtClear_Click(object sender, EventArgs e)
        {
            string strCacheKey = (sender as LinkButton).CommandArgument;
            TiKu.Common.CacheHelper.RemoveCache(strCacheKey);
            base.ShowMsg("清除成功！", MessageType.Success);
        }
    }
}