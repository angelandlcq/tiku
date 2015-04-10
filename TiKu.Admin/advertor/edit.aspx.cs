using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
/*=================================================================================================
 * 
 * className:广告信息
 * author:beisha
 * date:
 * modifyBy:
 * modifyOn:
 * mark:
 * 
 * ================================================================================================*/
namespace TiKu.Admin.advertor
{
    public partial class edit : TiKu.WebUI.Page.AdminBase
    {

        #region 成员
        /// <summary>
        /// BLL
        /// </summary>
        private readonly BLL.tb_Advertor bll = new BLL.tb_Advertor();

        /// <summary>
        /// 参数：编号
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
            if (!IsPostBack)
            {
                try
                {
                    if (ActionType == TiKu.Common.ActionType.Edit)
                    {
                        if (id <= 0)
                        {
                            NotFound();
                            return;
                        }
                        EditInit();//编辑初始化
                    }
                    //绑定广告位列表
                    new BLL.tb_AdvertorPlace().BindAdpDropDownList(DrpAplace, null);
                }
                catch (Exception ex)
                {
                    base.ShowMsg(ex.Message, MessageType.Error);
                    TiKu.Common.LogUtil.Error(ex);
                }
            }
        }

        #region 提交按钮单击事件
        /// <summary>
        /// 提交按钮单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_ServerClick(object sender, EventArgs e)
        {
            try
            {
                //输入
                string strAdText = txtAdText.Value.Trim();
                string strImageUrl = HidImageUrl.Value.Trim();
                string strAdp = DrpAplace.SelectedValue.Trim();
                string strUrl = txtUrl.Value.Trim();
                string strOrders = txtSort.Value.Trim();
                //业务校验
                if (string.IsNullOrEmpty(strUrl))
                {
                    base.ShowMsg("广告链接不能为空！", MessageType.Warn);
                    return;
                }
                if (string.IsNullOrEmpty(strAdp))
                {
                    base.ShowMsg("请选择所属广告位！", MessageType.Warn);
                    return;
                }
                int iOrders = 0;
                iOrders = Int32.TryParse(strOrders, out iOrders) ? iOrders : 99;
                //声明实体
                Model.tb_Advertor model = new Model.tb_Advertor();
                model.AdText = strAdText;
                model.APID = Convert.ToInt32(strAdp);
                model.AdUrl = strUrl;
                model.ImageUrl = strImageUrl;
                if (radEnable.Checked)
                {
                    model.State = TiKu.Common.Constants.Common.ENABLE;
                }
                if (radDisable.Checked)
                {
                    model.State = TiKu.Common.Constants.Common.DISABLE;
                }
                //添加
                if (ActionType == TiKu.Common.ActionType.Add)
                {
                    //添加
                    DoAdd(model);
                }
                //修改
                if (ActionType == TiKu.Common.ActionType.Edit)
                {
                    //修改
                    DoUpdate(model);
                }

            }
            catch (Exception ex)
            {
                base.ShowMsg(ex.Message, MessageType.Error);
                TiKu.Common.LogUtil.Error(ex);
            }
        }
        #endregion

        #region 添加====================================
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        private void DoAdd(Model.tb_Advertor model)
        {
            model.AddTime = DateTime.Now;
            if (bll.Add(model))
            {
                base.ShowMsg("广告发布成功！", MessageType.Success, "list.aspx");
                //日志
                if (IsEnableAdminLog)
                {
                    TiKu.Common.Logger.AdminLogger.Info(AdminID,
                                                        "发布广告",
                                                        TiKu.Common._Active.ADD,
                                                        "发布广告");
                }
            }
        }

        #endregion

        #region 修改====================================
        /// <summary>
        /// 修改
        /// </summary>
        private void DoUpdate(Model.tb_Advertor model)
        {
            model.ID = id;
            if (bll.Update(model))
            {
                base.ShowMsg("信息保存成功！", MessageType.Success, "list.aspx");
                //日志
                if (IsEnableAdminLog)
                {
                    TiKu.Common.Logger.AdminLogger.Info(AdminID,
                                                        "修改广告信息",
                                                        TiKu.Common._Active.ADD,
                                                        "修改广告信息");
                }
            }
        }
        #endregion

        #region 编辑初始化
        /// <summary>
        /// 编辑初始化
        /// </summary>
        private void EditInit()
        {
            Model.tb_Advertor model = bll.GetModel(id);
            if (null == model)
            {
                StopRequest("参数无效，或信息不存在！");
                return;
            }
            txtAdText.Value = model.AdText;
            txtSort.Value = model.Orders.ToString();
            txtUrl.Value = model.AdUrl;
            DrpAplace.SelectedValue = model.APID.ToString();
            HidImageUrl.Value = model.ImageUrl;
            if (model.State == TiKu.Common.Constants.Common.ENABLE)
            {
                radDisable.Checked = false;
            }
        }
        #endregion
    }
}