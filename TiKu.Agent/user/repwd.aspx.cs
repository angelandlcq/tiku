using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TiKu.Agent.user
{
    public partial class repwd : TiKu.WebUI.Page.AgentBase
    {


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
        /// 画面载入
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
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //输入
            string strOldPwd = txtOldPwd.Value.Trim();
            string strNewPwd = txtNewPwd.Value.Trim();
            string strConfimPwd = txtConfirmPwd.Value.Trim();
            //业务校验
            if (string.IsNullOrEmpty(strOldPwd))
            {
                base.ShowMsg("原始密码不能为空！", MessageType.Warn);
                return;
            }
            if (string.IsNullOrEmpty(strNewPwd))
            {
                base.ShowMsg("新密码不能为空！", MessageType.Warn);
                return;
            }
            if (string.IsNullOrEmpty(strConfimPwd))
            {
                base.ShowMsg("确认密码不能为空！", MessageType.Warn);
                return;
            }
            if (strConfimPwd != strNewPwd)
            {
                base.ShowMsg("两次输入密码不一致！", MessageType.Warn);
                return;
            }
            try
            {
                //密码加密
                strOldPwd = TiKu.Common.MD5.Md5(strOldPwd);
                strConfimPwd = TiKu.Common.MD5.Md5(strConfimPwd);
                //BLL
                BLL.tb_Agent bll = new BLL.tb_Agent();
                Model.tb_Agent model = bll.GetAgentInfoByNameAndPwd(AgentName, strOldPwd);
                if (null == model)
                {
                    base.ShowMsg("原始密码错误！", MessageType.Warn);
                    return;
                }
                Model.tb_Agent agent = new Model.tb_Agent();
                agent.ID = model.ID;
                agent.AgentPwd = strConfimPwd;
                if (bll.Update(model))
                {
                    base.ShowMsg("密码修改成功，下次请用新密码登陆！", MessageType.Success);
                }
            }
            catch (Exception ex)
            {
                TiKu.Common.LogUtil.Error(ex);
            }

        }

    }
}