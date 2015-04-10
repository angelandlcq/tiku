using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
/*-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
 * 
 * 
 * 
 *说 明： 安全退出系统
 * 
 * 
 * =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-*/
namespace TiKu.Admin
{
    public partial class exit : TiKu.WebUI.Page.AdminBase
    {


        /// <summary>
        /// 画面初始化
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInit(EventArgs e)
        {
            //安全退出系统
            new BLL.tb_Admin().ExitSystem(() =>
            {
                //日志
                if (IsEnableAdminLog)
                {
                    TiKu.Common.Logger.AdminLogger.Info(AdminID,
                                                        "安全退出",
                                                        TiKu.Common._Active.EXIT,
                                                        "安全退出系统");
                }
                //重定向到登陆页
                Response.Redirect(System.Web.Security.FormsAuthentication.LoginUrl);
            });
            base.OnInit(e);
        }


        /// <summary>
        /// 安全退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }
    }
}