using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
/*=================================================================================================
 * 
 * className:重置代理商密码（UI）
 * author:1058736170@qq.com
 * date:2015-03-05 14:02
 * modifyBy:1058736170@qq.com
 * modifyOn:2015-03-05 14:02
 * mark:本程序由代码生成器生成,了解更多,请登录http://my.oschina.net/lichaoqiang
 * 
 * ================================================================================================*/
namespace TiKu.Admin.Agent
{
    public partial class repwd : TiKu.WebUI.Page.AdminBase
    {

        /// <summary>
        /// BLL
        /// </summary>
        private readonly BLL.tb_Agent bll = new BLL.tb_Agent();

        /// <summary>
        /// 代理商编号
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
        /// 确认按钮单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_ServerClick(object sender, EventArgs e)
        {
            string strPwd = txtPwd.Value.Trim();
            string strConfirmPwd = txtConfirmPwd.Value.Trim();
            //业务校验
            if (string.IsNullOrEmpty(strPwd))
            {
                base.ShowMsg("请输入密码！", MessageType.Warn);
                return;
            }
            if (string.IsNullOrEmpty(strConfirmPwd))
            {
                base.ShowMsg("请输入确认密码！", MessageType.Warn);
                return;
            }
            //加密
            strConfirmPwd = TiKu.Common.MD5.Md5(strConfirmPwd);
            //重置密码
            TiKu.Model.tb_Agent model = new Model.tb_Agent();
            try
            {
                model.ID = id;
                model.AgentPwd = strConfirmPwd;
                model.ModifyBy = AdminID;
                model.ModifyOn = DateTime.Now;
                if (bll.Update(model))
                {
                    //日志
                    if (base.IsEnableAdminLog)
                    {
                        TiKu.Common.Logger.AdminLogger.Info(AdminID,
                                                            "重置代理商密码",
                                                            TiKu.Common._Active.EDIT,
                                                            string.Format("{0}重置代理商密码", AdminName));
                    }
                    //关闭窗口
                    ClientScript.RegisterStartupScript(GetType(),
                                                       "_CloseWin",
                                                       "parent._CloseWin();",
                                                       true);
                    return;
                }
            }
            catch (Exception ex)
            {
                base.ShowMsg(ex.Message, MessageType.Error);
                TiKu.Common.LogUtil.Error(ex);
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
                    data();
                }
                catch (Exception ex)
                {
                    TiKu.Common.LogUtil.Error(ex);
                }
            }
        }

        /// <summary>
        /// 数据初始化
        /// </summary>
        private void data()
        {
            Model.tb_Agent model = bll.GetModel(id);
            if (null == model)
            {
                base.NotFound();
                return;
            }
            lblAgentName.Text = model.AgentName;
        }
    }
}