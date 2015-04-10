using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
/*=============================================================================
 * 
 * 说 明：课程分类信息（添加/修改）
 * 
 * 
 * ===========================================================================*/
namespace TiKu.Admin.category
{
    public partial class edit : TiKu.WebUI.Page.AdminBase
    {

        /// <summary>
        /// BLL组件
        /// </summary>
        private readonly BLL.tb_CourseCategory bll = new BLL.tb_CourseCategory();

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
            if (ActionType == TiKu.Common.ActionType.Edit)
            {
                if (id <= 0)
                {
                    NotFound();
                    return;
                }
            }
            btnSubmit.ServerClick += new EventHandler(btnSubmit_Click);
            base.OnInit(e);
        }

        /// <summary>
        /// 页面载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    bll.BindCourseCategory(DrpCategory);//绑定课程分类
                    if (ActionType == TiKu.Common.ActionType.Edit)
                    {
                        data();//数据绑定
                    }
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
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //输入
            string strTitle = txtTitle.Value.Trim();
            string strSort = txtSort.Value.Trim();
            string strRemark = txtRemark.Value.Trim();
            string strParentCate = DrpCategory.SelectedValue.Trim();
            string strDeep = DrpCategory.SelectedItem.Attributes["deep"];
            string strVal = txtVal.Value.Trim();
            //业务校验
            if (string.IsNullOrEmpty(strTitle))
            {
                base.ShowMsg("分类名称不能为空！", MessageType.Warn);
                return;
            }
            //==========================================================================
            Model.tb_CourseCategory model = new Model.tb_CourseCategory();
            model.CateName = strTitle;
            model.Del = TiKu.Common.Constants.Common.NORMAL;
            model.ModifyBy = AdminID;
            model.ModifyOn = DateTime.Now;
            int iParentID = 0,
                deep = 0,
                iSort = 99;
            Int32.TryParse(strParentCate, out iParentID);
            Int32.TryParse(strDeep, out deep);
            model.ParentID = iParentID;
            model.Deep = (iParentID * iParentID + deep);
            model.Remark = strRemark;
            iSort = Int32.TryParse(strSort, out iSort) ? iSort : 99;
            model.Orders = iSort;
            model.Val = strVal;
            try
            {
                //添加
                if (ActionType == TiKu.Common.ActionType.Add)
                {
                    model.CreatedOn = DateTime.Now;
                    model.CreatedBy = AdminID;
                    DoAdd(model);//添加
                }
                //修改
                if (ActionType == TiKu.Common.ActionType.Edit)
                {
                    DoUpdate(model);//修改
                }
            }
            catch (Exception ex)
            {
                TiKu.Common.LogUtil.Error(ex);
            }
        }


        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        private void DoAdd(Model.tb_CourseCategory model)
        {
            if (bll.Add(model))
            {
                base.ShowMsg(":)信息保存成功！", MessageType.Success, "index.aspx");
                //管理员日志
                if (IsEnableAdminLog)
                {
                    //记录日志
                    TiKu.Common.Logger.AdminLogger.Info(AdminID,
                                                        "添加课程分类",
                                                        TiKu.Common._Active.ADD,
                                                        AdminName + "管理员添加课程分类信息");
                }
            }
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model"></param>
        private void DoUpdate(Model.tb_CourseCategory model)
        {
            model.ID = id;
            model.ModifyBy = AdminID;
            if (bll.Update(model))
            {
                base.ShowMsg(":)信息保存成功！", MessageType.Success, "index.aspx");
                //管理员日志
                if (IsEnableAdminLog)
                {
                    //记录日志
                    TiKu.Common.Logger.AdminLogger.Info(AdminID,
                                                        "修改课程分类",
                                                        TiKu.Common._Active.EDIT,
                                                        AdminName + "管理员修改课程分类信息");
                }
            }
        }


        /// <summary>
        /// 数据初始化
        /// </summary>
        private void data()
        {
            Model.tb_CourseCategory model = bll.GetModel(id);
            if (null == model)
            {
                return;
            }
            txtTitle.Value = model.CateName;
            txtSort.Value = model.Orders.ToString();
            txtRemark.Value = model.Remark;
            txtVal.Value = model.Val;
            DrpCategory.SelectedValue = model.ParentID.ToString();
        }
    }
}