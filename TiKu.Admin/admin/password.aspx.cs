using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
/*=================================================================================================
 * 
 * className:Admin修改登录密码
 * author:beisha
 * date:
 * modifyBy:
 * modifyOn:
 * mark:
 * 
 * ================================================================================================*/
namespace TiKu.Admin.admin
{
    public partial class password : TiKu.WebUI.Page.AdminBase
    {

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
            if (!IsPostBack) { }
        }

        /// <summary>
        /// 保存修改按钮单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_ServerClick(object sender, EventArgs e)
        {
            //0>输入
            string strOldPwd = txtOldPwd.Value.Trim();
            string strNewPwd = txtNewPwd.Value.Trim();
            string strConfirmPwd = txtConfirmPwd.Value.Trim();
            try
            {
                #region 校验
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
                if (string.IsNullOrEmpty(strConfirmPwd))
                {
                    base.ShowMsg("确认密码不能为空！", MessageType.Warn);
                    return;
                }
                if (strNewPwd != strConfirmPwd)
                {
                    base.ShowMsg("两次输入密码不一致！", MessageType.Warn);
                    return;
                }
                if (strOldPwd == strNewPwd)
                {
                    base.ShowMsg("新密码和原始密码不能一致！", MessageType.Warn);
                    return;
                }
                BLL.tb_Admin bll = new BLL.tb_Admin();
                //密码加密
                strOldPwd = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(strOldPwd, "MD5");
                strConfirmPwd = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(strConfirmPwd, "MD5");
                //根据用户名和密码，获取管理员信息
                Model.tb_Admin adminInfo = bll.GetAdminInfoByNameAndPwd(AdminName, strOldPwd);
                if (null == adminInfo)
                {
                    base.ShowMsg("原始密码错误！", MessageType.Warn);
                    return;
                }
                #endregion

                //修改密码
                Model.tb_Admin model = new Model.tb_Admin();
                model.ID = AdminID;
                model.AdminPwd = strConfirmPwd;
                if (bll.Update(model))
                {
                    base.ShowMsg("密码修改成功，下次请用新密码登陆！", MessageType.Success);
                    //记录日志
                    if (IsEnableAdminLog)
                    {
                        TiKu.Common.Logger.AdminLogger.Info(AdminID,
                                                            "修改密码",
                                                            TiKu.Common._Active.EDIT,
                                                            "修改密码！");
                    }
                }
                else
                {
                    base.ShowMsg("密码修改失败，请稍后再试！", MessageType.Warn);
                }
            }
            catch (Exception ex)
            {
                base.ShowMsg(ex.Message, MessageType.Error);
                TiKu.Common.LogUtil.Error(ex);
            }
        }
    }
}