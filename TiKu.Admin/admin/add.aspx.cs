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
namespace TiKu.Admin.admin
{
    public partial class add : TiKu.WebUI.Page.AdminBase
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
        /// 提交按钮单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_ServerClick(object sender, EventArgs e)
        {
            //输入
            string strAdminName = txtAdminName.Value.Trim();
            string strAdminPwd = txtAdminPwd.Value.Trim();
            string strTrueName = txtTrueName.Value.Trim();
            string strRole = DrpRole.SelectedValue.Trim();
            //业务校验
            if (string.IsNullOrEmpty(strAdminName))
            {
                base.ShowMsg("管理员名称不能为空！", MessageType.Warn);
                return;
            }
            if (string.IsNullOrEmpty(strAdminPwd))
            {
                base.ShowMsg("登陆密码不能为空！", MessageType.Warn);
                return;
            }
            if (string.IsNullOrEmpty(strRole))
            {
                base.ShowMsg("请选择所属角色！", MessageType.Warn);
                return;
            }
            //BLL
            BLL.tb_Admin bll = new BLL.tb_Admin();
            //检验用户名是否存在
            if (bll.CheckIsExistsAdminName(strAdminName))
            {
                base.ShowMsg("登录名已经存在！", MessageType.Warn);
                return;
            }
            //密码加密
            strAdminPwd = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(strAdminPwd, "MD5");
            //声明实体
            TiKu.Model.tb_Admin model = new Model.tb_Admin();
            model.AdminName = strAdminName;
            model.AdminPwd = strAdminPwd;
            model.CreatedBy = AdminID;
            model.CreatedOn = DateTime.Now;
            model.Del = TiKu.Common.Constants.Common.NORMAL;
            model.RoleID = Convert.ToInt32(strRole);
            if (radEnable.Checked)
            {
                model.State = TiKu.Common.Constants.Common.ENABLE;
            }
            if (radDisable.Checked)
            {
                model.State = TiKu.Common.Constants.Common.DISABLE;
            }
            try
            {
                if (bll.Add(model))
                {
                    //添加成功
                    base.ShowMsg(":)信息保存成功！", MessageType.Success);
                }
                else
                {
                    base.ShowMsg("信息保存失败，请稍后再试!", MessageType.Error);
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
                    //绑定角色列表
                    BLL.tb_AdminRole bllRole = new BLL.tb_AdminRole();
                    bllRole.BindRoleDropDownList(DrpRole);
                }
                catch (Exception ex)
                {
                    TiKu.Common.LogUtil.Error(ex);
                }
            }
        }
    }
}