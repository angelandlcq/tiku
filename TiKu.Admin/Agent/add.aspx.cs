using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
/*=================================================================================================
 * 
 * className:添加代理信息（UI）
 * author:1058736170@qq.com
 * date:2015-03-05 14:02
 * modifyBy:1058736170@qq.com
 * modifyOn:2015-03-05 14:02
 * mark:本程序由代码生成器生成,了解更多,请登录http://my.oschina.net/lichaoqiang
 * 
 * ================================================================================================*/
namespace TiKu.Admin.Agent
{
    public partial class add : TiKu.WebUI.Page.AdminBase
    {
        /// <summary>
        /// BLL组件
        /// </summary>
        private readonly BLL.tb_Agent bll = new BLL.tb_Agent();

        /// <summary>
        /// 画面初始化
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInit(EventArgs e)
        {
            btnSubmit.ServerClick += new EventHandler(btnSubmit_ServerClick);
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

            }
        }

        /// <summary>
        /// 提交按钮单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_ServerClick(object sender, EventArgs e)
        {
            #region 输入
            string strAgentName = txtAgentName.Value.Trim();
            string strShowName = txtShowName.Value.Trim();
            string strMobile = txtMobile.Value.Trim();
            string strTel = txtTel.Value.Trim();
            string strQQ = txtQQ.Value.Trim();
            string strUrl = txtUrl.Value.Trim();
            string strTaobaoUrl = txtTaobaoUrl.Value.Trim();
            string strAliAccount = txtAliAccount.Value.Trim();
            string strContact = txtContact.Value.Trim();
            string strEmail = txtEmail.Value.Trim();
            string strPwd = txtPwd.Value.Trim();
            string strConfirmPwd = txtConfirmPwd.Value.Trim();
            string strAddress = txtAddress.Value.Trim();
            #endregion

            #region 业务校验
            if (string.IsNullOrEmpty(strAgentName))
            {
                base.ShowMsg("登录名不能为空！", MessageType.Warn);
                return;
            }
            if (string.IsNullOrEmpty(strShowName))
            {
                base.ShowMsg("显示名称不能为空！", MessageType.Warn);
                return;
            }
            if (string.IsNullOrEmpty(strMobile))
            {
                base.ShowMsg("手机号不能为空！", MessageType.Warn);
                return;
            }
            if (string.IsNullOrEmpty(strPwd))
            {
                base.ShowMsg("登陆密码不能为空！", MessageType.Warn);
                return;
            }
            if (string.IsNullOrEmpty(strConfirmPwd))
            {
                base.ShowMsg("确认密码不能为空！", MessageType.Warn);
                return;
            }
            if (strPwd != strConfirmPwd)
            {
                base.ShowMsg("两次输入密码不一致！", MessageType.Warn);
                return;
            }
            #endregion

            //声明实体
            Model.tb_Agent model = new Model.tb_Agent();

            model.Amount = 0.00M;//金额
            model.Contact = strContact;//联系人
            model.AliAcount = strAliAccount;//旺旺
            model.Del = TiKu.Common.Constants.Common.NORMAL;//删除
            model.Email = strEmail;
            model.Tel = strEmail;
            model.Url = strUrl;
            model.TaoBaoUrl = strTaobaoUrl;
            model.AgentName = strAgentName;
            model.Address = strAddress;
            model.CreatedBy = AdminID;
            model.CreatedOn = DateTime.Now;
            model.ModifyBy = AdminID;
            model.ModifyOn = DateTime.Now;
            model.QQ = strQQ;
            model.RegisterIP = TiKu.Common.Util.GetIP();
            model.RegisterTime = DateTime.Now;
            model.LastTime = DateTime.Now;
            model.ShowName = strShowName;
   
            if (radAuditing.Checked)
            {
                //待审核
                model.State = TiKu.Common.Constants.Common.AUDITING;
            }
            if (radPost.Checked)
            {
                //通过审核
                model.State = TiKu.Common.Constants.Common.POST;
            }
            if (radLock.Checked)
            {
                //冻结账户
                model.State = TiKu.Common.Constants.Common.LOCK;
            }
            //密码加密
            strConfirmPwd = TiKu.Common.MD5.Md5(strConfirmPwd);//密码加密
            model.AgentPwd = strConfirmPwd;
            //添加代理商
            DoAdd(model);

        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        private void DoAdd(Model.tb_Agent model)
        {
            //添加
            if (bll.Add(model))
            {
                base.ShowMsg(":)信息保存成功！", MessageType.Success, "list.aspx");
                //日志
                if (IsEnableAdminLog)
                {
                    TiKu.Common.Logger.AdminLogger.Info(AdminID,
                                                        "添加代理商",
                                                        TiKu.Common._Active.ADD,
                                                        string.Format("{0}添加代理商", AdminName));
                }
            }
        }
    }
}