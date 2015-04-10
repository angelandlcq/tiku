using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
/***********************************************************************
 * 
 * 
 * 
 * 说 明：录题信息之选择课程(Admin)
 * 
 * 
 * 
 * **********************************************************************/
namespace TiKu.Admin.q
{
    public partial class course : TiKu.WebUI.Page.AdminBase
    {
        #region 事件
        /// <summary>
        /// 画面初始化
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInit(EventArgs e)
        {
            btnSubmit.Click += new EventHandler(btnSubmit_ServerClick);
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
                    //BLL
                    BLL.tb_CourseCategory bllCate = new BLL.tb_CourseCategory();
                    bllCate.BindCourseCategory(DrpCategory);
                    DrpCategory.Items.RemoveAt(0);
                    //编辑初始化
                    if (base.ActionType == TiKu.Common.ActionType.Edit)
                    {
                        //数据初始化
                        data();
                        return;
                    }
                    //控件初始化
                    int iQtype = TiKu.Common.TKRequest.GetQueryInt("qtype");
                    if (iQtype == TiKu.Common.Constants.QUESTION.QTYPE.MATERIAL)
                    {
                        tbEditor.Visible = true;
                        SetRadioButtonListValue(RbtQType, iQtype.ToString());
                        int iMat = TiKu.Common.TKRequest.GetQueryInt("mat");
                        if (iMat > 0)
                        {
                            Model.tb_Material model = new BLL.tb_Material().GetModel(iMat);
                            if (null == model)
                            {
                                return;
                            }
                            TxtMaterial.Value = model.Context;
                        }
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
        protected void btnSubmit_ServerClick(object sender, EventArgs e)
        {
            #region 录入信息
            string strCate = DrpCategory.SelectedValue.Trim();
            string strCourse = DrpCourse.SelectedValue.Trim();
            string strChapter = DrpChapter.SelectedValue.Trim();
            string strQType = RbtQType.SelectedValue.Trim();
            string strBody = TxtMaterial.Value.Trim();
            #endregion

            #region 业务校验
            if (string.IsNullOrEmpty(strCate))
            {
                base.ShowMsg("请选择课程分类！", MessageType.Warn);
                return;
            }
            if (string.IsNullOrEmpty(strCourse))
            {
                base.ShowMsg("请选择课程！", MessageType.Warn);
                return;
            }
            if (string.IsNullOrEmpty(strChapter))
            {
                base.ShowMsg("请选择章节！", MessageType.Warn);
                return;
            }
            #endregion


            string strCookieInfo = DrpCategory.SelectedItem.Text + " >> " + DrpChapter.SelectedItem.Text.Trim();
            strCookieInfo = strCookieInfo.Replace("┠", string.Empty).Trim();
            strCookieInfo = UrlEncode(strCookieInfo);//url编码
            TiKu.Common.CookieUtil.WriteCookie("__Chapter__", strCookieInfo);
            //添加
            if (base.ActionType == TiKu.Common.ActionType.Add)
            {
                DoAdd();
                return;
            }
            //更新
            if (base.ActionType == TiKu.Common.ActionType.Edit)
            {
                DoUpdate();
                return;
            }

        }

        /// <summary>
        /// 选择改变后发生事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DrpCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            BLL.tb_CourseInfo bll = new BLL.tb_CourseInfo();
            string strCate = DrpCategory.SelectedValue.Trim();
            if (string.IsNullOrEmpty(strCate))
            {
                return;
            }
            try
            {
                int iCat = Convert.ToInt32(strCate);
                bll.BindCourseList(DrpCourse, iCat);
                DrpCourse.Items.RemoveAt(0);
            }
            catch (Exception ex)
            {
                TiKu.Common.LogUtil.Error(ex);
            }

        }

        /// <summary>
        /// 选择课程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DrpCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            BLL.tb_Chapter bll = new BLL.tb_Chapter();
            string strCourseID = DrpCourse.SelectedValue.Trim();
            if (string.IsNullOrEmpty(strCourseID))
            {
                return;
            }
            try
            {
                int iCourseID = Convert.ToInt32(strCourseID);
                bll.BindChapterList(DrpChapter, iCourseID);
                DrpChapter.Items.RemoveAt(0);
            }
            catch (Exception ex)
            {
                TiKu.Common.LogUtil.Error(ex);
            }
        }


        /// <summary>
        /// 选择项改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void RbtQType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strQtype = RbtQType.SelectedValue.Trim();
            if (strQtype == TiKu.Common.Constants.QUESTION.QTYPE.MATERIAL.ToString())
            {
                tbEditor.Visible = true;
            }
            else
            {
                tbEditor.Visible = false;
            }
        }
        #endregion

        #region 方法
        /// <summary>
        /// 编辑模式下，数据初始化
        /// </summary>
        private void data()
        {
            //题目编号
            int iQuestionID = TiKu.Common.TKRequest.GetQueryInt("id");
            //声明实体
            Model.tb_Question model = new Model.tb_Question();
            //BLL
            BLL.tb_Question bll = new BLL.tb_Question();
            model = bll.GetModel(iQuestionID);
            if (null == model)
            {
                base.NotFound();
                return;
            }
            //声明实体
            Model.tb_CourseInfo Course = new Model.tb_CourseInfo();
            Course = new BLL.tb_CourseInfo().GetModel(model.CourseID);
            DrpCategory.SelectedValue = Course.CategoryID.ToString();
            //级联课程
            DrpCategory_SelectedIndexChanged(DrpCategory, null);
            DrpCourse.SelectedValue = model.CourseID.ToString();
            //级联章节
            DrpCourse_SelectedIndexChanged(DrpCourse, null);
            DrpChapter.SelectedValue = model.Chapter;
            //题型
            //编辑模态下，不允许修改题型
            RbtQType.Visible = false;
            LblQtype.Text = bll.ShowQTypeLabelText(model.QType);
            LblQtype.Visible = true;
            btnSubmit.CommandArgument = model.QType.ToString() + "|" + model.MateID;
            if (model.QType - TiKu.Common.Constants.QUESTION.QTYPE.MATERIAL > 0)
            {
                tbEditor.Visible = true;
                int iMat = model.MateID;
                if (iMat > 0)
                {
                    Model.tb_Material mateModel = new BLL.tb_Material().GetModel(iMat);
                    if (null == mateModel)
                    {
                        return;
                    }
                    TxtMaterial.Value = mateModel.Context;
                }
            }
            else
            {
                tbEditor.Visible = false;
            }
        }

        /// <summary>
        /// 添加操作
        /// </summary>
        private void DoAdd()
        {
            //录入信息
            string strCate = DrpCategory.SelectedValue.Trim();
            string strCourse = DrpCourse.SelectedValue.Trim();
            string strChapter = DrpChapter.SelectedValue.Trim();
            string strQType = RbtQType.SelectedValue.Trim();
            string strBody = TxtMaterial.Value.Trim();
            //如果是一题多问
            if (strQType == TiKu.Common.Constants.QUESTION.QTYPE.MATERIAL.ToString())
            {
                if (string.IsNullOrEmpty(strBody))
                {
                    base.ShowMsg("请输入材料信息！", MessageType.Warn);
                    return;
                }
            }
            //材料
            int iMat = TiKu.Common.TKRequest.GetQueryInt("mat");
            //问题编号
            int iQuestionID = TiKu.Common.TKRequest.GetQueryInt("id");
            Server.Transfer(string.Format("~/q/edit.aspx?action=add&id={1}&qtype={2}&course={3}&chapter={4}&mat={5}",
                                             base.ActionType,
                                             iQuestionID,
                                             strQType,
                                             strCourse,
                                             strChapter,
                                             iMat),
                                             true);
        }
        /// <summary>
        /// 修改
        /// </summary>
        private void DoUpdate()
        {
            //录入信息
            string strCate = DrpCategory.SelectedValue.Trim();
            string strCourse = DrpCourse.SelectedValue.Trim();
            string strChapter = DrpChapter.SelectedValue.Trim();
            string strQType = btnSubmit.CommandArgument.Split('|')[0];
            string strBody = TxtMaterial.Value.Trim();
            string strMateID = btnSubmit.CommandArgument.Split('|')[1];
            //
            int iQuestionID = TiKu.Common.TKRequest.GetQueryInt("id");
            Server.Transfer(string.Format("~/q/edit.aspx?action=edit&id={1}&qtype={2}&course={3}&chapter={4}&mat={5}",
                                             base.ActionType,
                                             iQuestionID,
                                             strQType,
                                             strCourse,
                                             strChapter,
                                             strMateID),//................
                                             true);
        }
        #endregion
    }
}