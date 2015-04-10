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
    public partial class edit : TiKu.WebUI.Page.AdminBase
    {

        #region 成员
        /// <summary>
        /// BLL组件
        /// </summary>
        private readonly BLL.tb_Admin bll = new BLL.tb_Admin();
        /// <summary>
        /// 参数，Admin编号
        /// </summary>
        private int Id
        {
            get
            {
                return TiKu.Common.TKRequest.GetQueryInt("id");
            }
        }
        #endregion

        /// <summary>
        /// 画面初始化
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInit(EventArgs e)
        {
            if (Id <= 0)
            {
                Response.Write("参数无效！");
                Response.End();
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
                //绑定角色列表
                BLL.tb_AdminRole bllRole = new BLL.tb_AdminRole();
                bllRole.BindRoleDropDownList(DrpRole);
                //编辑初始化
                data();
            }
        }


        /// <summary>
        /// 提交按钮单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_ServerClick(object sender, EventArgs e)
        {
            //输入
            string strTrueName = txtTrueName.Value.Trim();
            string strRole = DrpRole.SelectedValue.Trim();
            //业务校验
            if (string.IsNullOrEmpty(strRole))
            {
                base.ShowMsg("请选择所属角色！", MessageType.Warn);
                return;
            }
            //声明实体
            TiKu.Model.tb_Admin model = new Model.tb_Admin();
            model.ID = Id;
            model.TrueName = strTrueName;
            model.ModifyBy = AdminID;
            model.ModifyOn = DateTime.Now;
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
            //添加操作
            BLL.tb_Admin bll = new BLL.tb_Admin();
            try
            {
                if (bll.Update(model))
                {
                    //添加成功
                    base.ShowMsg(":)信息保存成功！", MessageType.Success);
                    if (IsEnableAdminLog)
                    {
                        TiKu.Common.Logger.AdminLogger.Info(AdminID,
                                                            "修改管理员信息",
                                                            TiKu.Common._Active.EDIT,
                                                            "修改管理员信息");
                    }
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
        /// 数据初始化
        /// </summary>
        private void data()
        {
            Model.tb_Admin model = new Model.tb_Admin();
            model = bll.GetModel(Id);
            if (null == model)
            {
                base.StopRequest("参数无效，信息不存在！");
                return;
            }
            //表单初始化
            lblAdminName.Text = model.AdminName;
            txtTrueName.Value = model.TrueName;
            DrpRole.SelectedValue = model.RoleID.ToString();
            if (model.State == TiKu.Common.Constants.Common.ENABLE)
            {
                radEnable.Checked = true;
                radDisable.Checked = false;
            }
            if (model.State == TiKu.Common.Constants.Common.DISABLE)
            {
                radEnable.Checked = false;
                radDisable.Checked = true;
            }
        }
    }
}