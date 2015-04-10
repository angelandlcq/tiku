using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
/*=================================================================================================
 * 
 * className:角色管理
 * author:beisha
 * date:
 * modifyBy:
 * modifyOn:
 * mark:
 * 
 * ================================================================================================*/
namespace TiKu.Admin.role
{
    public partial class edit : TiKu.WebUI.Page.AdminBase
    {

        #region 成员
        /// <summary>
        /// BLL组件
        /// </summary>
        private readonly BLL.tb_AdminRole bll = new BLL.tb_AdminRole();

        /// <summary>
        /// 角色编号
        /// </summary>
        private int id
        {
            get
            {
                return TiKu.Common.TKRequest.GetQueryInt("id");
            }
        }
        #endregion

        /// <summary>
        ///画面初始化
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
                //编辑初始化
                if (ActionType == TiKu.Common.ActionType.Edit)
                {
                    if (id <= 0)
                    {
                        base.StopRequest("请求参数无效！");
                    }
                    //编辑初始化
                    EditInit();
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
            string strRoleName = txtRoleName.Value.Trim();
            string strOrders = txtOrders.Value.Trim();
            string strRemark = txtRemark.Value.Trim();
            //实体
            Model.tb_AdminRole model = new Model.tb_AdminRole();
            model.RoleName = strRoleName;
            int iOrders = 0;
            iOrders = Int32.TryParse(strOrders, out iOrders) ? iOrders : 99;
            model.Orders = iOrders;
            model.Remark = strRemark;
            if (radEnable.Checked)
            {
                model.State = TiKu.Common.Constants.Common.ENABLE;
            }
            if (radDisable.Checked)
            {
                model.State = TiKu.Common.Constants.Common.DISABLE;
            }
            //业务校验
            if (string.IsNullOrEmpty(strRoleName))
            {
                base.ShowMsg("角色名称不能为空！", MessageType.Warn);
                return;
            }

            #region 添加========================================
            if (ActionType == TiKu.Common.ActionType.Add)
            {
                model.CreatedOn = DateTime.Now;
                model.CreatedBy = AdminID;
                model.Del = TiKu.Common.Constants.Common.NORMAL;
                if (bll.Add(model))
                {
                    base.ShowMsg("信息保存成功！", MessageType.Success);
                    //清除该缓存
                    TiKu.Common.CacheHelper.RemoveCache(TiKu.Common.Constants.CACHE_KEY._CACHE_ADMIN_ROLE);
                    //记录日志
                    if (IsEnableAdminLog)
                    {
                        TiKu.Common.Logger.AdminLogger.Info(AdminID,
                                                            "添加角色",
                                                             TiKu.Common._Active.ADD,
                                                             "添加管理员角色");
                    }
                }
            }
            #endregion

            #region 修改========================================
            if (ActionType == TiKu.Common.ActionType.Edit)
            {
                model.ID = id;
                if (bll.Update(model))
                {
                    base.ShowMsg("信息保存成功！", MessageType.Success);
                    //记录日志
                    if (IsEnableAdminLog)
                    {
                        TiKu.Common.Logger.AdminLogger.Info(AdminID,
                                                            "修改角色信息",
                                                             TiKu.Common._Active.EDIT,
                                                             "修改角色信息");
                    }
                }
            }
            #endregion
        }

        /// <summary>
        /// 编辑初始化
        /// </summary>
        private void EditInit()
        {
            //声明实体
            Model.tb_AdminRole model = new Model.tb_AdminRole();
            model = bll.GetModel(id);
            if (null == model) { return; }
            txtRoleName.Value = model.RoleName;
            txtOrders.Value = model.Orders.ToString();
            txtRemark.Value = model.Remark;
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