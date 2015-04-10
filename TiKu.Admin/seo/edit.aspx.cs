using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
/*=================================================================================================
 * 
 * className:SEO（UI）
 * author:1058736170@qq.com
 * date:2015-03-07 16:26
 * modifyBy:1058736170@qq.com
 * modifyOn:2015-03-07 16:26
 * mark:本程序由代码生成器生成,了解更多,请登录http://my.oschina.net/lichaoqiang
 * 
 * ================================================================================================*/
namespace TiKu.Admin.seo
{
    public partial class edit : TiKu.WebUI.Page.AdminBase
    {

        /// <summary>
        /// BLL组件
        /// </summary>
        private readonly BLL.tb_SEO bll = new BLL.tb_SEO();

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
            btnSubmit.ServerClick += new EventHandler(btnSubmit_Click);
            base.OnInit(e);
        }

        /// <summary>
        /// 画面载入时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    data();
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
            string strVal = txtCallName.Value.Trim();
            string strKeywords = txtKeywords.Value.Trim();
            string strDescription = txtDescription.Value.Trim();
            string strOrders = txtSort.Value.Trim();
            //业务校验
            if (string.IsNullOrEmpty(strTitle))
            {
                base.ShowMsg("标题名称不能为空！", MessageType.Warn);
                return;
            }
            if (string.IsNullOrEmpty(strVal))
            {
                base.ShowMsg("调用别名不能为空！", MessageType.Warn);
                return;
            }
            if (string.IsNullOrEmpty(strKeywords))
            {
                base.ShowMsg("关键词不能为空！", MessageType.Warn);
                return;
            }
            if (string.IsNullOrEmpty(strDescription))
            {
                base.ShowMsg("描述不能为空！", MessageType.Warn);
                return;

            }
            int iSort = 0;
            iSort = Int32.TryParse(strOrders, out iSort) ? iSort : 99;
            //声明实体
            Model.tb_SEO model = new Model.tb_SEO();
            model.Title = strTitle;
            model.Description = strDescription;
            model.keywords = strKeywords;
            model.Orders = iSort;
            //添加
            if (ActionType == TiKu.Common.ActionType.Add)
            {
                model.CallName = strVal;
                //添加
                DoAdd(model);
                return;
            }
            //修改
            if (ActionType == TiKu.Common.ActionType.Edit)
            {
                DoUpdate(model);
                return;
            }
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        private void DoAdd(Model.tb_SEO model)
        {
            if (bll.Add(model))
            {
                base.ShowMsg("信息保存成功！", MessageType.Success, "list.aspx");
                //日志
                if (IsEnableAdminLog)
                {
                    TiKu.Common.Logger.AdminLogger.Info(AdminID,
                                                        "添加SEO信息",
                                                        TiKu.Common._Active.ADD,
                                                        "添加SEO信息");
                }
            }
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model"></param>
        private void DoUpdate(Model.tb_SEO model)
        {
            model.ID = id;
            if (bll.Update(model))
            {
                base.ShowMsg("信息保存成功！", MessageType.Success, "list.aspx");
                //日志
                if (IsEnableAdminLog)
                {
                    TiKu.Common.Logger.AdminLogger.Info(AdminID,
                                                        "修改SEO信息",
                                                        TiKu.Common._Active.ADD,
                                                        "修改SEO信息");
                }
            }
        }

        /// <summary>
        /// 编辑初始化
        /// </summary>
        private void data()
        {
            Model.tb_SEO model = bll.GetModel(id);
            if (null == model)
            {
                NotFound();
                return;
            }
            txtCallName.Value = model.CallName;
            txtCallName.Attributes["readonly"] = "readonly";
            txtTitle.Value = model.Title;
            txtKeywords.Value = model.keywords;
            txtDescription.Value = model.Description;
        }
    }
}