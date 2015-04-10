using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TiKu.WebUI.Page;
/*=================================================================================================
 * 
 * className:代理商登陆画面
 * author:beisha
 * date:
 * modifyBy:
 * modifyOn:
 * mark:
 * 
 * ================================================================================================*/
namespace TiKu.Agent
{
    public partial class login : AgentBase
    {

        /// <summary>
        /// 用户名错误次数
        /// </summary>
        private const string LOGIN_ERROR_NUM = "LOGIN_ERROR_NUM";

        /// <summary>
        /// 获取是否需要验证码
        /// </summary>
        protected bool IsRequirVerifyCode
        {
            get
            {
                int iLoginNumb = TiKu.Common.SessionHelper.GetFromSession<Int32>(LOGIN_ERROR_NUM);
                return (iLoginNumb > 4);
            }
        }

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
            btnSubmit.ServerClick += new EventHandler(btnSubmit_Click);
            base.OnInit(e);
        }

        /// <summary>
        /// 登陆事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //输入  
            string strAgentName = txtAgentName.Value.Trim();
            string strPwd = txtPwd.Value.Trim();
            string strVerifyCode = txtVerifyCode.Value.Trim();
            //业务校验
            if (string.IsNullOrEmpty(strAgentName))
            {
                base.ShowMsg("登陆名不能为空", MessageType.Warn);
                return;
            }
            if (string.IsNullOrEmpty(strPwd))
            {
                base.ShowMsg("密码不能为空", MessageType.Warn);
                return;
            }
            //是否需要验证码
            if (IsRequirVerifyCode)
            {
                if (string.IsNullOrEmpty(strVerifyCode))
                {
                    //验证码不能为空
                    base.ShowMsg("验证码不能为空", MessageType.Warn);
                    return;
                }
                if (strVerifyCode != TiKu.Common.SessionHelper.GetFromSession<string>(TiKu.Common.VerifyCode.VERIFY_CODE))
                {
                    base.ShowMsg("验证码错误", MessageType.Warn);
                    return;
                }
                else
                {
                    //清除登陆计数
                    TiKu.Common.SessionHelper.Remove(LOGIN_ERROR_NUM);
                }
            }
            //密码加密
            strPwd = TiKu.Common.MD5.Md5(strPwd);
            //BLL组件
            TiKu.BLL.tb_Agent bll = new BLL.tb_Agent();
            string error = string.Empty, returnUrl = System.Web.Security.FormsAuthentication.DefaultUrl;
            string strReturnUrl = TiKu.Common.TKRequest.GetQueryString("ReturnUrl");
            returnUrl = !string.IsNullOrEmpty(strReturnUrl) ? UrlDecode(strReturnUrl) : returnUrl;
            if (bll.CheckAgentLogin(strAgentName,
                                    strPwd,
                                    ref error,
                                    returnUrl) == false)
            {
                //用户名或密码错误
                base.ShowMsg(error, MessageType.Warn);
                int iLoginNum = 0;
                if (TiKu.Common.SessionHelper.Exists(LOGIN_ERROR_NUM))
                {
                    iLoginNum = TiKu.Common.SessionHelper.GetFromSession<Int32>(LOGIN_ERROR_NUM);
                    iLoginNum++;
                }
                TiKu.Common.SessionHelper.SaveToSession(LOGIN_ERROR_NUM, iLoginNum);
                return;
            }

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
                try
                {
                    //验证是否登录
                    if (new BLL.tb_Agent().CheckLoginState())
                    {
                        //已登录
                        string strReturnUrl = TiKu.Common.TKRequest.GetQueryString("ReturnUrl");
                        if (!string.IsNullOrEmpty(strReturnUrl))
                        {
                            Response.Redirect(strReturnUrl);
                        }
                    }
                }
                catch (Exception ex)
                {
                    TiKu.Common.LogUtil.Error(ex);
                }
            }
        }
    }
}