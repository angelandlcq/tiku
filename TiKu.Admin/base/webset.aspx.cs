using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
/*=================================================================================================
 * 
 * className:站点设置
 * author:beisha
 * date:
 * modifyBy:
 * modifyOn:
 * mark:
 * 
 * ================================================================================================*/
namespace TiKu.Admin._base
{
    public partial class webset : TiKu.WebUI.Page.AdminBase
    {
        #region 成员
        /// <summary>
        /// BLL组件
        /// </summary>
        private readonly BLL.tb_WebSet bll = new BLL.tb_WebSet();
        #endregion

        #region  画面初始化
        /// <summary>
        /// 画面初始化
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInit(EventArgs e)
        {
            btnSubmit.ServerClick += new EventHandler(btnSubmit_ServerClick);
            btnSave.ServerClick += new EventHandler(btnSave_Click);
            base.OnInit(e);
        }
        #endregion

        #region  画面载入事件
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
                    //表单初始化
                    InitForm();
                }
                catch (Exception ex)
                {
                    TiKu.Common.LogUtil.Error(ex);
                }
            }
        }
        #endregion

        #region 保存按钮单击事件
        /// <summary>
        /// 保存按钮单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_ServerClick(object sender, EventArgs e)
        {
            //1>声明实体
            TiKu.Model.tb_WebSet model = new Model.tb_WebSet();
            //2>业务校验
            if (CheckInput(model) == false)
            {
                return;
            }
            //保存信息
            model.ID = 1;
            try
            {
                if (bll.Update(model))
                {
                    base.ShowMsg(":)信息保存成功！", MessageType.Success);
                }
                else
                {
                    base.ShowMsg("保存时出错，请稍后再试!", MessageType.Error);
                }
            }
            catch (Exception ex)
            {
                base.ShowMsg(ex.Message, MessageType.Error);
                TiKu.Common.LogUtil.Error(ex);
            }
        }

        /// <summary>
        /// 保存邮件设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            #region 输入
            string strSmtp = txtSmtp.Value.Trim();
            string strSmtpPort = txtPort.Value.Trim();
            string strEmailAccount = txtEmailAccount.Value.Trim();
            string strEmailPwd = txtEmailPwd.Value.Trim();
            #endregion

            #region 业务校验
            if (string.IsNullOrEmpty(strSmtp))
            {
                base.ShowMsg("SMTP服务器不能为空！", MessageType.Warn);
                return;
            }
            if (string.IsNullOrEmpty(strSmtpPort))
            {
                base.ShowMsg("SMTP端口不能为空！", MessageType.Warn);
                return;
            }
            if (string.IsNullOrEmpty(strEmailAccount))
            {
                base.ShowMsg("邮箱账号不能为空！", MessageType.Warn);
                return;
            }
            if (string.IsNullOrEmpty(strEmailPwd))
            {
                base.ShowMsg("邮箱密码不能为空！", MessageType.Warn);
                return;
            }
            int iPort = 0;
            Int32.TryParse(strSmtpPort, out iPort);
            #endregion

            //声明实体
            Model.tb_WebSet model = new Model.tb_WebSet();
            model.ID = 1;
            model.Smtp = strSmtp;
            model.SmtpPort = iPort;
            model.EmaiAccount = strEmailAccount;
            model.EmailPwd = strEmailPwd;
            try
            {
                //保存
                if (bll.Update(model))
                {
                    base.ShowMsg(":)信息保存成功！", MessageType.Success);
                }
            }
            catch (Exception ex)
            {
                base.ShowMsg(ex.Message, MessageType.Error);
                TiKu.Common.LogUtil.Error(ex);
            }
        }
        #endregion

        #region 私有方法》》》》》》》》》》》》》》》》》》》》》》》》》》》》》》》》》》》》》》》》》》》》》
        /// <summary>
        ///校验输入 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private bool CheckInput(TiKu.Model.tb_WebSet model)
        {
            //1>输入
            string strWebName = txtWebName.Value.Trim();
            string strCompanyName = txtCompanyName.Value.Trim();
            string strWebDomain = txtWebDomain.Value.Trim();
            string strICP = txtICP.Value.Trim();
            if (string.IsNullOrEmpty(strWebDomain))
            {
                base.ShowMsg("网站名称不能为空！", MessageType.Warn);
                return false;
            }
            if (string.IsNullOrEmpty(strCompanyName))
            {
                base.ShowMsg("公司名称不能为空！", MessageType.Warn);
                return false;
            }
            if (string.IsNullOrEmpty(strWebDomain))
            {
                base.ShowMsg("网站域名不能为空！", MessageType.Warn);
                return false;
            }
            model.WebName = strWebName;
            model.Domain = strWebDomain;
            model.ICP = strICP;
            model.Company = strCompanyName;
            model.IsEnableAdminLog = chkEnableAdminLog.Checked ? TiKu.Common.Constants.Common.ENABLE : TiKu.Common.Constants.Common.DISABLE;
            model.IsEnableAgentLog = chkAgentLog.Checked ? TiKu.Common.Constants.Common.ENABLE : TiKu.Common.Constants.Common.DISABLE;
            model.IsEnableDelete = chkEnableTrash.Checked ? TiKu.Common.Constants.Common.ENABLE : TiKu.Common.Constants.Common.DISABLE;
            model.IsEnableUserLog = chkEnableUserLog.Checked ? TiKu.Common.Constants.Common.ENABLE : TiKu.Common.Constants.Common.DISABLE;
            model.IsEnableAgentLog = chkAgentLog.Checked ? TiKu.Common.Constants.Common.ENABLE : TiKu.Common.Constants.Common.DISABLE;
            model.WebState = chkEnableSite.Checked ? TiKu.Common.Constants.Common.ENABLE : TiKu.Common.Constants.Common.DISABLE;
            return true;
        }
        /// <summary>
        ///初始化表单
        /// </summary>
        private void InitForm()
        {
            //获取实体
            TiKu.Model.tb_WebSet model = bll.GetWebSiteInfo();
            //1>表单初始化
            txtCompanyName.Value = model.Company;
            txtICP.Value = model.ICP;
            txtWebDomain.Value = model.Domain;
            txtWebName.Value = model.WebName;
            chkEnableAdminLog.Checked = (model.IsEnableAdminLog > 0);
            chkEnableSite.Checked = (model.WebState > 0);
            chkEnableTrash.Checked = (model.IsEnableDelete > 0);
            chkEnableUserLog.Checked = (model.IsEnableUserLog > 0);
            chkAgentLog.Checked = (model.IsEnableAgentLog > 0);
            //2>邮件服务器
            txtSmtp.Value = model.Smtp;
            txtPort.Value = model.SmtpPort.ToString();
            txtEmailAccount.Value = model.EmaiAccount;
            txtEmailPwd.Attributes["value"] = model.EmailPwd;

        }
        #endregion
    }
}