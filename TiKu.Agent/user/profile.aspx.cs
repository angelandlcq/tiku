using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
/*======================================================================代理商个人资料===============================================*/
namespace TiKu.Agent.user
{
    public partial class profile : TiKu.WebUI.Page.AgentBase
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
            btnSubmit.ServerClick += new EventHandler(btnSubmit_Click);
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
                    data();
                }
                catch (Exception ex)
                {
                    TiKu.Common.LogUtil.Error(ex);
                }
            }
        }

        /// <summary>
        /// 保存按钮单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
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
            model.ID = AgentID;
            model.Contact = strContact;//联系人
            model.AliAcount = strAliAccount;//旺旺
            model.Email = strEmail;
            model.Tel = strEmail;
            model.Url = strUrl;
            model.TaoBaoUrl = strTaobaoUrl;
            model.Address = strAddress;
            model.ModifyBy = 0;
            model.ModifyOn = DateTime.Now;
            model.QQ = strQQ;
            model.ShowName = strShowName;
            //添加代理商
            DoUpdate(model);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model"></param>
        private void DoUpdate(Model.tb_Agent model)
        {
            model.ID = AgentID;
            if (bll.Update(model))
            {
                base.ShowMsg(":)资料保存成功！", MessageType.Success);
                base.LogInfo("修改资料！", string.Format("代理商{0}修改个人资料", AgentName));
            }
        }

        /// <summary>
        /// 数据初始化
        /// </summary>
        private void data()
        {
            //获取实体信息
            Model.tb_Agent model = bll.GetModel(AgentID);
            if (null == model)
            {
                return;
            }
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
        }
    }
}