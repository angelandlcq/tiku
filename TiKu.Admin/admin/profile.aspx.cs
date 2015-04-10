using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
/*=================================================================================================
 * 
 * className:修改个人资料
 * author:beisha
 * date:
 * modifyBy:
 * modifyOn:
 * mark:
 * 
 * ================================================================================================*/
namespace TiKu.Admin.admin
{
    public partial class profile : TiKu.WebUI.Page.AdminBase
    {

        /// <summary>
        /// BLL组件
        /// </summary>
        private readonly BLL.tb_Admin bll = new BLL.tb_Admin();

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
            try
            {
                if (!IsPostBack)
                {
                    data();//数据初始化
                }
            }
            catch (Exception ex)
            {
                base.ShowMsg(ex.Message, MessageType.Error);
                TiKu.Common.LogUtil.Error(ex);
            }
        }

        /// <summary>
        /// 提交按钮单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_ServerClick(object sender, EventArgs e)
        {
            string strAdminTrueName = txtTrueName.Value.Trim();
            Model.tb_Admin model = new Model.tb_Admin();
            model.ID = AdminID;
            model.TrueName = strAdminTrueName;
            model.ModifyBy = AdminID;
            model.ModifyOn = DateTime.Now;
            try
            {
                //修改
                if (bll.Update(model))
                {
                    base.ShowMsg("信息保存成功！", MessageType.Success);
                    if (IsEnableAdminLog)
                    {
                        TiKu.Common.Logger.AdminLogger.Info(AdminID,
                                                     "修改资料",
                                                     TiKu.Common._Active.EDIT,
                                                     "修改管理员个人资料信息");
                    }
                }
                else
                {
                    base.ShowMsg("修改失败，请稍后再试！", MessageType.Warn);
                }
            }
            catch (Exception ex)
            {
                base.ShowMsg(ex.Message, MessageType.Error);
                TiKu.Common.LogUtil.Error(ex);
            }
        }

        /// <summary>
        /// 表单数据初始化
        /// </summary>
        private void data()
        {
            Model.tb_Admin model = bll.GetModel(AdminID);
            if (null == model) { return; }
            txtTrueName.Value = model.TrueName;
        }
    }
}