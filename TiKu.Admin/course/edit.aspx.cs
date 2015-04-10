using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
/*=================================================================================================
 * 
 * 
 * 说 明：课程信息
 * 
 * 
 * =============================================================================================*/
namespace TiKu.Admin.course
{
    public partial class edit : TiKu.WebUI.Page.AdminBase
    {

        /// <summary>
        /// BLL
        /// </summary>
        private readonly BLL.tb_CourseInfo bll = new BLL.tb_CourseInfo();

        /// <summary>
        /// 获取课程编号
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
                //课程分类
                new BLL.tb_CourseCategory().BindCourseCategory(DrpCategory);
                if (ActionType == TiKu.Common.ActionType.Edit)
                {
                    if (id <= 0)
                    {
                        StopRequest("参数无效！");
                        return;
                    }
                    //数据初始化
                    data();
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
            //录入信息
            string strTitle = txtTitle.Value.Trim();
            string strCateID = DrpCategory.SelectedValue.Trim();
            string strOrders = txtSort.Value.Trim();
            string strVal = txtVal.Value.Trim();
            string strRemark = txtRemark.Value.Trim();
            //业务校验
            if (string.IsNullOrEmpty(strTitle))
            {
                base.ShowMsg("课程名称不能为空！", MessageType.Warn);
                return;
            }
            if (string.IsNullOrEmpty(strCateID))
            {

                base.ShowMsg("请选择课程分类！", MessageType.Warn);
                return;
            }
            //声明实体
            Model.tb_CourseInfo model = new Model.tb_CourseInfo();
            model.Names = strTitle;
            model.Remark = strRemark;
            model.State = RbtEnable.Checked ? TiKu.Common.Constants.Common.ENABLE : TiKu.Common.Constants.Common.DISABLE;
            model.Val = strVal;
            model.CategoryID = Convert.ToInt32(strCateID);
            model.Del = TiKu.Common.Constants.Common.NORMAL;
            int iSort = 0;
            iSort = Int32.TryParse(strOrders, out  iSort) ? iSort : 99;
            model.Orders = iSort;
            //添加
            if (ActionType == TiKu.Common.ActionType.Add)
            {
                DoAdd(model);//添加
                return;
            }
            //修改
            if (ActionType == TiKu.Common.ActionType.Edit)
            {
                DoUpdate(model);//修改
                return;
            }
        }

        /// <summary>
        /// 添加======================================
        /// </summary>
        /// <param name="model"></param>
        private void DoAdd(Model.tb_CourseInfo model)
        {
            if (bll.Add(model, (m) =>
            {
                bll.ClearCache(m.CategoryID);
            }))
            {
                base.ShowMsg("信息保存成功！", MessageType.Success, "/course/index.aspx");
                //记录日志
                TiKu.Common.Logger.AdminLogger.Info(AdminID,
                                                    "添加课程",
                                                    TiKu.Common._Active.EDIT,
                                                    AdminName + "添加课程信息");
            }
        }



        /// <summary>
        /// 修改===================================
        /// </summary>
        /// <param name="model"></param>
        private void DoUpdate(Model.tb_CourseInfo model)
        {
            model.ID = id;
            //修改
            if (bll.Update(model, (m) =>
            {
                bll.ClearCache(m.CategoryID);
            }))
            {
                base.ShowMsg("信息保存成功！", MessageType.Success, "/course/index.aspx");
                if (IsEnableAdminLog)
                {
                    //记录日志
                    TiKu.Common.Logger.AdminLogger.Info(AdminID,
                                                        "修改课程",
                                                        TiKu.Common._Active.EDIT,
                                                        AdminName + "修改专业课程信息");
                }
            }
        }

        /// <summary>
        /// 数据初始化
        /// </summary>
        private void data()
        {
            //声明实体
            Model.tb_CourseInfo model = new Model.tb_CourseInfo();
            model = bll.GetModel(id);
            if (null == model)
            {
                StopRequest("信息不存在，或已被删除！");
                return;
            }
            //信息初始化
            txtTitle.Value = model.Names;
            txtSort.Value = model.Orders.ToString();
            txtVal.Value = model.Val;
            txtRemark.Value = model.Remark;
            DrpCategory.SelectedValue = model.CategoryID.ToString();
            RbtEnable.Checked = (model.State == TiKu.Common.Constants.Common.ENABLE);
            RbnDisbale.Checked = (model.State == TiKu.Common.Constants.Common.DISABLE);
        }
    }
}