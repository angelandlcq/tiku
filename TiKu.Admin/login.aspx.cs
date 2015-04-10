using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
/*=================================================================================================
 * 
 * className:Admin登陆画面
 * author:beisha
 * date:
 * modifyBy:
 * modifyOn:
 * mark:
 * 
 * ================================================================================================*/
namespace TiKu.Admin
{
    public partial class login : TiKu.WebUI.Page.AdminBase
    {

        /// <summary>
        /// 是否验证登陆状态
        /// </summary>
        protected override bool IsRequireLogin
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
            btnLogin.ServerClick += new EventHandler(btnLogin_ServerClick);
            base.OnInit(e);
        }

        /// <summary>
        /// 画面载入事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //验证是否登录
                BLL.tb_Admin bll = new BLL.tb_Admin();
                if (bll.CheckIsLogin())
                {
                    string strReturnUrl = TiKu.Common.TKRequest.GetQueryString("ReturnUrl");
                    if (!string.IsNullOrEmpty(strReturnUrl))
                    {
                        strReturnUrl = System.Web.HttpUtility.UrlDecode(strReturnUrl);
                    }
                    else
                    {
                        strReturnUrl = "~/main/main.aspx";
                    }
                    System.Web.HttpContext.Current.Response.Redirect(strReturnUrl, true);
                }
            }
        }

        /// <summary>
        /// 登陆按钮单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnLogin_ServerClick(object sender, EventArgs e)
        {
            try
            {
                string strAdminName = TiKu.Common.TKRequest.GetFormString("txtAdminName");
                string strAdminPwd = TiKu.Common.TKRequest.GetFormString("txtAdminPwd");
                //1>业务校验
                if (string.IsNullOrEmpty(strAdminName))
                {
                    base.ShowMsg("登陆名不能为空！", MessageType.Warn);
                    return;
                }
                if (string.IsNullOrEmpty(strAdminPwd))
                {
                    base.ShowMsg("登陆密码不能为空！", MessageType.Warn);
                    return;
                }
                //2>登陆验证
                TiKu.BLL.tb_Admin bll = new BLL.tb_Admin();
                string strError = string.Empty, strReturnUrl = "~/main/main.aspx";
                if (!string.IsNullOrEmpty(TiKu.Common.TKRequest.GetQueryString("ReturnUrl")))
                {
                    strReturnUrl += "?ReturnUrl=" + TiKu.Common.TKRequest.GetQueryString("ReturnUrl");
                }
                if (bll.CheckAdminSignIn(strAdminName,
                                         strAdminPwd,
                                         chkRemember.Checked,
                                         strReturnUrl,
                                         ref strError) == false)
                {
                    base.ShowMsg(strError, MessageType.Warn);
                }
            }
            catch (Exception ex)
            {
                TiKu.Common.LogUtil.Error(ex);
            }
        }
    }
}