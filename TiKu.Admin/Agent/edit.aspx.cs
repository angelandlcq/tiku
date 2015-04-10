using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
/*=================================================================================================
 * 
 * className:修改代理信息（UI）
 * author:1058736170@qq.com
 * date:2015-03-05 14:02
 * modifyBy:1058736170@qq.com
 * modifyOn:2015-03-05 14:02
 * mark:本程序由代码生成器生成,了解更多,请登录http://my.oschina.net/lichaoqiang
 * 
 * ================================================================================================*/
namespace TiKu.Admin.Agent
{
    public partial class edit : TiKu.WebUI.Page.AdminBase
    {
        /// <summary>
        /// BLL组件
        /// </summary>
        private readonly BLL.tb_Agent bll = new BLL.tb_Agent();

        /// <summary>
        /// 编号
        /// </summary>
        private int id
        {

            get
            {
                return TiKu.Common.TKRequest.GetQueryInt("id");
            }
        }

        /// <summary>
        /// 画面初始化
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInit(EventArgs e)
        {
            if (id <= 0)
            {
                base.NotFound();
                return;
            }
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
                try
                {
                    //数据初始化
                    data();
                }
                catch (Exception ex)
                {
                    TiKu.Common.LogUtil.Error(ex);
                }
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
            string strShowName = txtShowName.Value.Trim();
            string strMobile = txtMobile.Value.Trim();
            string strTel = txtTel.Value.Trim();
            string strQQ = txtQQ.Value.Trim();
            string strUrl = txtUrl.Value.Trim();
            string strTaobaoUrl = txtTaobaoUrl.Value.Trim();
            string strAliAccount = txtAliAccount.Value.Trim();
            string strContact = txtContact.Value.Trim();
            string strEmail = txtEmail.Value.Trim();
            string strAddress = txtAddress.Value.Trim();
            #endregion

            #region 业务校验
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
            #endregion

            //声明实体
            Model.tb_Agent model = new Model.tb_Agent();
            model.ID = id;
            model.Contact = strContact;//联系人
            model.AliAcount = strAliAccount;//旺旺
            model.Del = TiKu.Common.Constants.Common.NORMAL;//删除
            model.Email = strEmail;
            model.Tel = strEmail;
            model.Url = strUrl;
            model.TaoBaoUrl = strTaobaoUrl;
            model.Address = strAddress;
            model.ModifyBy = AdminID;
            model.ModifyOn = DateTime.Now;
            model.QQ = strQQ;
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
            //修改代理商
            DoUpdate(model);

        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        private void DoUpdate(Model.tb_Agent model)
        {
            //添加
            if (bll.Update(model))
            {
                base.ShowMsg(":)信息保存成功！", MessageType.Success, "list.aspx");
                //日志
                if (IsEnableAdminLog)
                {
                    TiKu.Common.Logger.AdminLogger.Info(AdminID,
                                                        "修改代理商",
                                                        TiKu.Common._Active.ADD,
                                                        string.Format("{0}修改代理商", AdminName));
                }
            }
        }

        /// <summary>
        /// 数据初始化
        /// </summary>
        private void data()
        {
            //获取实体信息
            Model.tb_Agent model = bll.GetModel(id);
            if (null == model)
            {
                base.NotFound();
                return;
            }
            lblAgentName.Text = model.AgentName;
            txtAddress.Value = model.Address;
            txtAliAccount.Value = model.AliAcount;
            txtContact.Value = model.Contact;
            txtEmail.Value = model.Email;
            txtMobile.Value = model.Mobile;
            txtQQ.Value = model.QQ;
            txtShowName.Value = model.ShowName;
            txtTaobaoUrl.Value = model.TaoBaoUrl;
            txtTel.Value = model.Tel;
            txtUrl.Value = model.Url;
            if (model.State == TiKu.Common.Constants.Common.AUDITING)
            {
                radAuditing.Checked = true;
                radLock.Checked = false;
                radPost.Checked = false;
            }
            if (model.State == TiKu.Common.Constants.Common.POST)
            {
                radAuditing.Checked = false;
                radLock.Checked = false;
                radPost.Checked = true;
            }
            if (model.State == TiKu.Common.Constants.Common.LOCK)
            {
                radAuditing.Checked = false;
                radLock.Checked = true;
                radPost.Checked = false;
            }
        }
    }
}