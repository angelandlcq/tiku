using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
/*-=-=-=-=-=-=--=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
 * 
 * className:后台管理主界面
 * author:beisha
 * date:
 * modifyBy:
 * modifyOn:
 * mark:
 * 
 *-=-=-=-=-=-=--=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=*/
namespace TiKu.Admin.main
{
    public partial class main : TiKu.WebUI.Page.AdminBase
    {

        /// <summary>
        /// 默认页面地址
        /// </summary>
        protected string PageUrl
        {
            get
            {
                string strReturnUrl = TiKu.Common.TKRequest.GetQueryString("ReturnUrl");
                strReturnUrl = string.IsNullOrEmpty(strReturnUrl) ? "index.aspx" : UrlDecode(strReturnUrl);
                return strReturnUrl;
            }
        }

        /// <summary>
        /// 画面初始化
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
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