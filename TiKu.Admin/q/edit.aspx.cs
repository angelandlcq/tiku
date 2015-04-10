using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
/*************************************************************************************
 * 
 * 
 * 说 明：添加/修改试题信息
 * 
 * ***********************************************************************************/
namespace TiKu.Admin.q
{
    public partial class edit : TiKu.WebUI.Page.AdminBase
    {

        /// <summary>
        /// 选项
        /// </summary>
        protected string Options { get; set; }

        /// <summary>
        /// BLL
        /// </summary>
        private readonly BLL.tb_Question bll = new BLL.tb_Question();

        /// <summary>
        /// 画面初始化
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInit(EventArgs e)
        {
            btnDoSubmit.ServerClick += new EventHandler(btnDoSubmit_ServerClick);
            base.OnInit(e);
        }
        #region 画面载入初始化
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
                    Options = "[]";
                    //初始化控件
                    initControl();
                    //修改
                    if (base.ActionType == TiKu.Common.ActionType.Edit)
                    {
                        //数据初始化
                        data();
                    }
                }
                catch (Exception ex)
                {
                    TiKu.Common.LogUtil.Error(ex);
                }
            }
        }
        #endregion

        #region 提交按钮单击事件
        /// <summary>
        /// 提交按钮单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDoSubmit_ServerClick(object sender, EventArgs e)
        {
            #region 录入信息
            //0>父窗口传递的试题相关参数
            int iQType = TiKu.Common.TKRequest.GetQueryInt("qtype");
            string strCourse = TiKu.Common.TKRequest.GetQueryString("course"),
                   strMat = TiKu.Common.TKRequest.GetQueryString("mat");//材料
            string strTitle = txtTitle.Value.Trim();//题目
            string strAnswer = string.Empty;//答案
            string strSort = txtSort.Value.Trim();//排序
            string strScore = txtScore.Value.Trim();//分值
            string strLevel = DrpLevel.SelectedValue.Trim();//级别
            string strAnalyze = txtAnalyze.Value.Trim();//解析
            string strChapter = TiKu.Common.TKRequest.GetQueryString("chapter");//章节考点
            string[] strOptions = TiKu.Common.TKRequest.GetFormArray("items");//选项
            //1>材料分析 一题多问
            if (iQType - TiKu.Common.Constants.QUESTION.QTYPE.MATERIAL >= 0)
            {
                //一题多问，题型
                string strMaterialQtype = RbtQtype.SelectedValue.Trim();
                if (base.ActionType == TiKu.Common.ActionType.Edit)
                {
                    //编辑模式下，不能修改题型
                    strMaterialQtype = iQType.ToString();
                }
                //单选、多选
                if (strMaterialQtype == TiKu.Common.Constants.QUESTION.QTYPE.MATERIAL_SINGLE_SELECTION.ToString() ||
                    strMaterialQtype == TiKu.Common.Constants.QUESTION.QTYPE.MATERIAL_MULTI_SELECTION.ToString())
                {
                    strAnswer = txtAnswer.Value.Trim();
                }
                //判断
                if (strMaterialQtype == TiKu.Common.Constants.QUESTION.QTYPE.MATERIAL_JUDGE.ToString())
                {
                    strAnswer = RbtAnswer.SelectedValue.Trim();
                }
                //简答
                if (strMaterialQtype == TiKu.Common.Constants.QUESTION.QTYPE.MATERIAL_SHORT_ANSWER.ToString())
                {
                    strAnswer = txtAnswer.Value.Trim();
                }
                iQType = Convert.ToInt32(strMaterialQtype);

            }
            //单选、多选、判断、简答
            else
            {
                //单选、多选
                if (iQType == TiKu.Common.Constants.QUESTION.QTYPE.SINGLE_SELECTION ||
                    iQType == TiKu.Common.Constants.QUESTION.QTYPE.MULTI_SELECTION)
                {
                    strAnswer = txtAnswer.Value.Trim();
                }
                //判断
                if (iQType == TiKu.Common.Constants.QUESTION.QTYPE.JUDGE)
                {
                    strAnswer = RbtAnswer.SelectedValue.Trim();
                }
                //简答
                if (iQType == TiKu.Common.Constants.QUESTION.QTYPE.SHORT_ANSWER)
                {
                    strAnswer = txtAnswer.Value.Trim();
                }
            }
            #endregion

            #region 业务校验
            if (iQType <= 0)
            {
                base.ShowMsg("题型参数无效！", MessageType.Warn);
                return;
            }
            if (string.IsNullOrEmpty(strTitle))
            {
                base.ShowMsg("题目不能为空！", MessageType.Warn);
                return;
            }
            if (string.IsNullOrEmpty(strAnswer))
            {
                base.ShowMsg("答案不能为空！", MessageType.Warn);
                return;
            }
            if (string.IsNullOrEmpty(strLevel))
            {
                base.ShowMsg("试题级别！", MessageType.Warn);
                return;
            }
            #endregion

            //声明实体
            Model.tb_Question model = new Model.tb_Question();
            model.Analysis = strAnalyze;
            model.Title = strTitle;
            model.TrueAnswer = strAnswer;
            model.QType = iQType;
            model.QLevel = Convert.ToInt32(strLevel);
            model.Chapter = strChapter;
            int iScore = 0;
            Int32.TryParse(strScore, out iScore);
            model.QScore = iScore;
            int iSort = 0;
            iSort = Int32.TryParse(strSort, out iSort) ? iSort : 999;
            model.Orders = iSort;
            model.IsFree = false;
            model.ModifyBy = AdminID;
            model.ModifyOn = DateTime.Now;
            model.State = Convert.ToInt32(RbtState.SelectedValue.Trim());
            model.CourseID = Convert.ToInt32(strCourse);
            if (strOptions != null && strOptions.Length > 0)
            {
                //选项
                model.Options = TiKu.Common.JsonHelper.ToJson(strOptions);
            }
            try
            {
                //添加
                if (ActionType == TiKu.Common.ActionType.Add)
                {
                    model.NoteNum = 0;
                    model.CreatedBy = AdminID;
                    model.CreatedOn = DateTime.Now;
                    model.Del = TiKu.Common.Constants.Common.NORMAL;
                    model.AvgDifficulty = 0;
                    model.ErrorNum = 0;
                    model.FavoriteNum = 0;
                    model.RigthtNum = 0;
                    DoAdd(model);
                    return;
                }
                //修改
                if (ActionType == TiKu.Common.ActionType.Edit)
                {
                    DoUpdate(model);
                }
            }
            catch (Exception ex)
            {
                TiKu.Common.LogUtil.Error(ex);
            }
        }
        #endregion


        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model">实体</param>
        private void DoAdd(Model.tb_Question model)
        {
            int iQtype = TiKu.Common.TKRequest.GetQueryInt("qtype");
            int iMat = TiKu.Common.TKRequest.GetQueryInt("mat");
            string strChapter = TiKu.Common.TKRequest.GetQueryString("chapter");
            if (iMat == 0 && (iQtype - TiKu.Common.Constants.QUESTION.QTYPE.MATERIAL >= 0))
            {
                string strMaterial = Request.Form["Material"];
                //一题多问
                BLL.tb_Material bllMaterial = new BLL.tb_Material();
                Model.tb_Material Material = new Model.tb_Material();
                Material.Context = strMaterial;
                Material.CreatedBy = AdminID;
                Material.CreatedOn = DateTime.Now;
                Material.ModifyBy = AdminID;
                Material.ModifyOn = DateTime.Now;
                model.Material = Material;
            }
            model.MateID = iMat;
            //添加题库信息
            if (bll.DoAdd(model) > 0)
            {
                if (null != model.Material) { iMat = model.Material.ID; }
                string strCourse = TiKu.Common.TKRequest.GetQueryString("course");
                //2>录入成功，跳转至提示页
                string url = Request.Url.ToString();
                url = string.Format("done.aspx?action=add&qtype={0}&course={1}&chapter={2}&mat={3}",
                                    TiKu.Common.TKRequest.GetQueryString("qtype"),
                                    strCourse,
                                    strChapter,
                                    iMat);
                //跳转至信息保存成功页！
                Server.Transfer(url, true);
            }

        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model"></param>
        private void DoUpdate(Model.tb_Question model)
        {
            int iMat = TiKu.Common.TKRequest.GetQueryInt("mat");
            int iQtype = TiKu.Common.TKRequest.GetQueryInt("qtype");
            //案例分析，一题多问
            if (iMat > 0 && (iQtype - TiKu.Common.Constants.QUESTION.QTYPE.MATERIAL) >= 0)
            {
                string strMaterial = Request.Form["Material"];
                //一题多问
                BLL.tb_Material bllMaterial = new BLL.tb_Material();
                Model.tb_Material Material = new Model.tb_Material();
                Material.Context = strMaterial;
                Material.ModifyBy = AdminID;
                Material.ModifyOn = DateTime.Now;
                Material.ID = iMat;
                model.Material = Material;
            }
            model.ID = TiKu.Common.TKRequest.GetQueryInt("id");
            if (bll.Update(model))
            {
                string strCourse = TiKu.Common.TKRequest.GetQueryString("course"),
                       strMat = TiKu.Common.TKRequest.GetQueryString("mat");//材料
                //2>录入成功，跳转至提示页
                Server.Transfer(string.Format("done.aspx?action=edit&qtype={0}&course={1}&mat={2}",
                                              TiKu.Common.TKRequest.GetQueryString("qtype"),
                                              strCourse,
                                               strMat),
                                  true);
            }
        }

        /// <summary>
        /// 初始化
        /// </summary>
        private void initControl()
        {
            //判断是否是一题多问的题型
            int iQtype = TiKu.Common.TKRequest.GetQueryInt("qtype");
            //如果是判断题
            if (iQtype == TiKu.Common.Constants.QUESTION.QTYPE.JUDGE)
            {
                RbtAnswer.Visible = true;
                txtAnswer.Visible = false;
            }
            else
            {
                RbtAnswer.Visible = false;
                txtAnswer.Visible = true;
            }
            if (iQtype == TiKu.Common.Constants.QUESTION.QTYPE.SINGLE_SELECTION ||
                iQtype == TiKu.Common.Constants.QUESTION.QTYPE.MULTI_SELECTION)
            {
                pnlOptions.Visible = true;
            }
            else
            {
                pnlOptions.Visible = false;
            }
            //一题多问
            if (iQtype - TiKu.Common.Constants.QUESTION.QTYPE.MATERIAL >= 0)
            {
                PnlQtype.Visible = true;
                RbtQtype_SelectedIndexChanged(RbtQtype, null);
                PnlMateContainer.Visible = true;
                //材料信息
                string strFormMat = PreviousPage.Request.Form["TxtMaterial"];
                PnlMat.InnerHtml = strFormMat;
                Material.Value = strFormMat;
            }
            else
            {
                PnlQtype.Visible = false;
                PnlMateContainer.Visible = false;
            }
            //绑定试题级别
            BLL.tb_level bllLevel = new BLL.tb_level();
            bllLevel.BindDropDownList(DrpLevel, "tb_Question");

        }

        /// <summary>
        /// 题型选项改变后发生事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void RbtQtype_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strQtype = RbtQtype.SelectedValue.Trim();
            //单选多选
            if (strQtype == TiKu.Common.Constants.QUESTION.QTYPE.MATERIAL_MULTI_SELECTION.ToString() ||
                strQtype == TiKu.Common.Constants.QUESTION.QTYPE.MATERIAL_SINGLE_SELECTION.ToString())
            {
                pnlOptions.Visible = true;
            }
            else
            {
                pnlOptions.Visible = false;
            }
            //判断
            if (strQtype == TiKu.Common.Constants.QUESTION.QTYPE.MATERIAL_JUDGE.ToString())
            {
                RbtAnswer.Visible = true;
                txtAnswer.Visible = false;
            }
            else
            {
                RbtAnswer.Visible = false;
                txtAnswer.Visible = true;
            }
        }


        /// <summary>
        /// 绑定数据
        /// </summary>
        private void data()
        {
            //题目编号
            int iQuestionID = TiKu.Common.TKRequest.GetQueryInt("id");
            Model.tb_Question quesionModel = new Model.tb_Question();
            quesionModel = bll.GetModel(iQuestionID);
            if (null == quesionModel) { return; }
            txtTitle.Value = quesionModel.Title;
            txtSort.Value = quesionModel.Orders.ToString();
            txtScore.Value = quesionModel.QScore.ToString();
            txtAnswer.Value = quesionModel.TrueAnswer;
            txtAnalyze.Value = quesionModel.Analysis;
            RbtQtype.Visible = false;
            LblQtype.Visible = true;
            LblQtype.Text = bll.ShowQTypeLabelText(quesionModel.QType);
            RbtState.SelectedValue = quesionModel.State.ToString();
            DrpLevel.SelectedValue = quesionModel.QLevel.ToString();
            Options = quesionModel.Options;
            //判断题
            if (quesionModel.QType == TiKu.Common.Constants.QUESTION.QTYPE.JUDGE ||
                quesionModel.QType == TiKu.Common.Constants.QUESTION.QTYPE.MATERIAL_JUDGE)
            {
                RbtAnswer.Visible = true;
                SetRadioButtonListValue(RbtAnswer, quesionModel.TrueAnswer);
            }

        }
    }
}