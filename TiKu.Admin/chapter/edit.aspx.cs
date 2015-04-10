using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
/*==============================================================================
 * 
 * 
 * 说 明：章节考点信息
 * 
 * ============================================================================*/
namespace TiKu.Admin.chapter
{
    public partial class edit : TiKu.WebUI.Page.AdminBase
    {

        /// <summary>
        /// BLL
        /// </summary>
        private readonly BLL.tb_Chapter bll = new BLL.tb_Chapter();

        /// <summary>
        /// 获取章节编号
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
                try
                {
                    //绑定课程分类
                    new BLL.tb_CourseCategory().BindCourseCategory(DrpCategory);
                    if (ActionType == TiKu.Common.ActionType.Edit)
                    {
                        if (id <= 0)
                        {
                            StopRequest("信息不存在，或已被删除！");
                            return;
                        }
                        //绑定数据列表
                        data();
                    }
                }
                catch (Exception ex)
                {
                    TiKu.Common.LogUtil.Error(ex);
                }
            }
        }

        /// <summary>
        /// 查询按钮单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //信息录入
            string strName = txtTitle.Value.Trim();
            string strChapterNO = txtChaperNO.Value.Trim();
            string strCourseID = DrpCourse.SelectedValue.Trim();
            string strCourseCate = DrpCategory.SelectedValue.Trim();
            string strChapter = DrpChapter.SelectedValue.Trim();
            string strOrders = txtSort.Value.Trim();
            string strQuantity = txtQuantity.Value.Trim();
            string strCollectionNum = txtCollection.Value.Trim();
            string strParentPath = string.Empty;
            //业务校验
            if (string.IsNullOrEmpty(strName))
            {
                base.ShowMsg("请输入章节名称！", MessageType.Warn);
                return;
            }
            if (string.IsNullOrEmpty(strCourseCate))
            {
                base.ShowMsg("请选择课程分类！", MessageType.Warn);
                return;
            }
            if (string.IsNullOrEmpty(strCourseID))
            {
                base.ShowMsg("请选择课程分类！", MessageType.Warn);
                return;
            }
            if (!string.IsNullOrEmpty(strChapter))
            {
                strParentPath = DrpChapter.SelectedItem.Attributes["ParentPath"] + "," + strChapter;
            }
            //声明实体
            Model.tb_Chapter model = new Model.tb_Chapter();
            model.CreatedBy = AdminID;
            model.CreatedOn = DateTime.Now;
            model.Del = TiKu.Common.Constants.Common.NORMAL;
            model.CptName = strName;
            model.CourseID = Convert.ToInt32(strCourseID);
            model.ModifyBy = AdminID;
            model.ModifyOn = DateTime.Now;
            model.NoteNum = 0;
            int iOrders = 0;
            iOrders = Int32.TryParse(strOrders, out iOrders) ? iOrders : 99;
            model.Orders = iOrders;
            int iChapter = 0;
            Int32.TryParse(strChapter, out iChapter);
            model.ParentID = iChapter;
            model.DirCode = strChapterNO;
            int iCollection = 0;
            Int32.TryParse(strCollectionNum, out iCollection);
            model.Collection = iCollection;

            model.ParentPath = strParentPath;
            int iQuantity = 0;
            Int32.TryParse(strQuantity, out iQuantity);
            model.Quantity = iQuantity;
            if (RbtEnable.Checked)
            {
                model.State = TiKu.Common.Constants.Common.ENABLE.ToString();
            }
            if (RbtDisable.Checked)
            {
                model.State = TiKu.Common.Constants.Common.DISABLE.ToString();
            }
            try
            {
                //添加
                if (ActionType == TiKu.Common.ActionType.Add)
                {
                    DoAdd(model);
                    return;
                }
                //修改
                if (ActionType == TiKu.Common.ActionType.Edit)
                {
                    DoUpate(model);
                }
            }
            catch (Exception ex)
            {
                TiKu.Common.LogUtil.Error(ex);
            }
        }

        /// <summary>
        /// 选择分类
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DrpCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string strCate = DrpCategory.SelectedValue.Trim();
                if (!string.IsNullOrEmpty(strCate))
                {
                    new BLL.tb_CourseInfo().BindCourseList(DrpCourse, Convert.ToInt32(strCate));
                }
            }
            catch (Exception ex)
            {
                TiKu.Common.LogUtil.Error(ex);
            }
        }

        /// <summary>
        /// 课程选项改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DrpCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string strCourseID = DrpCourse.SelectedValue.Trim();
                if (!string.IsNullOrEmpty(strCourseID))
                {
                    bll.BindChapterList(DrpChapter, Convert.ToInt32(strCourseID));
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
        private void DoAdd(Model.tb_Chapter model)
        {
            if (bll.Add(model))
            {
                base.ShowMsg("信息保存成功！", MessageType.Success, "index.aspx");
                if (IsEnableAdminLog)
                {
                    TiKu.Common.Logger.AdminLogger.Info(AdminID,
                                                        "修改章节",
                                                        TiKu.Common._Active.EDIT,
                                                        string.Format("管理员{0}修改章节信息！", AdminName));
                }
            }
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        private void DoUpate(Model.tb_Chapter model)
        {
            model.ID = id;
            if (bll.Update(model))
            {
                base.ShowMsg("信息保存成功！", MessageType.Success, "index.aspx");
                //日志
                if (IsEnableAdminLog)
                {
                    TiKu.Common.Logger.AdminLogger.Info(AdminID,
                                                        "修改章节",
                                                        TiKu.Common._Active.EDIT,
                                                        string.Format("管理员{0}修改章节信息！", AdminName));
                }
            }
        }

        /// <summary>
        /// 编辑初始化
        /// </summary>
        private void data()
        {
            //声明实体
            Model.tb_Chapter model = new Model.tb_Chapter();
            model = bll.GetModel(id);
            if (null == model)
            {
                base.StopRequest("参数无效！");
                return;
            }
            txtCollection.Value = model.Collection.ToString();
            txtQuantity.Value = model.Quantity.ToString();
            txtRemark.Value = "";
            txtSort.Value = model.Orders.ToString();
            txtTitle.Value = model.CptName;
            txtChaperNO.Value = model.DirCode;
            //根据课程编号，获取章节编号
            bll.BindChapterList(DrpChapter, model.CourseID);
            //课程
            BLL.tb_CourseInfo bllCourse = new BLL.tb_CourseInfo();
            int iCateID = bllCourse.GetModel(model.CourseID).CategoryID;
            //课程分类
            DrpCategory.SelectedValue = iCateID.ToString();
            //课程
            bllCourse.BindCourseList(DrpCourse, iCateID);
            DrpCourse.SelectedValue = model.CourseID.ToString();
            DrpChapter.SelectedValue = model.ParentID.ToString();

            if (model.State == TiKu.Common.Constants.Common.ENABLE.ToString())
            {
                RbtEnable.Checked = true;
            }
            if (model.State == TiKu.Common.Constants.Common.DISABLE.ToString())
            {
                RbtDisable.Checked = true;
            }
        }

    }
}