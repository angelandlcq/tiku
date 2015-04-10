using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
/*=================================================================================================
 * 
 * className:Admin广告位信息（UI）
 * author:1058736170@qq.com
 * date:2015-03-05 14:02
 * modifyBy:1058736170@qq.com
 * modifyOn:2015-03-05 14:02
 * mark:本程序由代码生成器生成,了解更多,请登录http://my.oschina.net/lichaoqiang
 * 
 * ================================================================================================*/
namespace TiKu.Admin.advertor
{
    public partial class place_edit : TiKu.WebUI.Page.AdminBase
    {


        #region 成员
        /// <summary>
        /// BLL组件
        /// </summary>
        private readonly BLL.tb_AdvertorPlace bll = new BLL.tb_AdvertorPlace();

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
                if (ActionType == TiKu.Common.ActionType.Edit)
                {
                    if (id <= 0)
                    {
                        NotFound();
                        return;
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
            //输入
            string strAdpName = txtAdpName.Value.Trim();
            string strRemark = txtRemark.Value.Trim();
            string strOrders = txtSort.Value.Trim();
            //校验
            if (string.IsNullOrEmpty(strAdpName))
            {
                base.ShowMsg("广告位名称不能为空！", MessageType.Warn);
                return;
            }
            //实体
            Model.tb_AdvertorPlace model = new Model.tb_AdvertorPlace();
            model.APName = strAdpName;
            model.APDescription = strRemark;
            model.Del = TiKu.Common.Constants.Common.NORMAL;
            int iOrders = 0;
            iOrders = Int32.TryParse(strOrders, out iOrders) ? iOrders : 99;
            model.Orders = iOrders;
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
                //添加
                if (ActionType == TiKu.Common.ActionType.Add)
                {
                    DoAdd(model);
                }
                //更新
                if (ActionType == TiKu.Common.ActionType.Edit)
                {
                    model.ID = id;
                    DoUpdate(model);
                }
            }
            catch (Exception ex)
            {
                base.ShowMsg(ex.Message, MessageType.Error);
                TiKu.Common.LogUtil.Error(ex);
            }
        }

        #region 添加
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        private void DoAdd(Model.tb_AdvertorPlace model)
        {
            //添加成功
            if (bll.Add(model))
            {
                base.ShowMsg("信息保存成功！", MessageType.Success);
                //清除广告位的缓存
                TiKu.Common.CacheHelper.RemoveCache(TiKu.Common.Constants.CACHE_KEY._CACHE_ADVERTOR_PALCE_KEY);
                //日志
                if (IsEnableAdminLog)
                {
                    TiKu.Common.Logger.AdminLogger.Info(AdminID,
                                                        "添加广告位",
                                                        TiKu.Common._Active.ADD,
                                                        "添加广告位信息！");
                }
            }
        }
        #endregion

        #region 修改
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        private void DoUpdate(Model.tb_AdvertorPlace model)
        {
            //更新
            if (bll.Update(model))
            {
                base.ShowMsg("信息保存成功！", MessageType.Success);
                //日志
                if (IsEnableAdminLog)
                {
                    TiKu.Common.Logger.AdminLogger.Info(AdminID,
                                                        "添加广告位",
                                                        TiKu.Common._Active.ADD,
                                                        "添加广告位信息！");
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
            //获取实体信息
            Model.tb_AdvertorPlace model = bll.GetModel(id);
            if (null == model)
            {
                return;
            }
            txtAdpName.Value = model.APName;
            txtRemark.Value = model.APDescription;
            txtSort.Value = model.Orders.ToString();
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
        #endregion

    }
}