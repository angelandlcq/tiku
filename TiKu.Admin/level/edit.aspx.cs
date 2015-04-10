using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
/********************************************************************
 * 
 * 
 * 
 * 
 * 说 明：级别信息管理
 * 
 * 
 * 
 * *****************************************************************/
namespace TiKu.Admin.level
{
    public partial class edit : TiKu.WebUI.Page.AdminBase
    {

        /// <summary>
        /// BLL组件
        /// </summary>
        private readonly BLL.tb_level bll = new BLL.tb_level();

        /// <summary>
        /// 获取参数编号id
        /// </summary>
        private int id { get { return TiKu.Common.TKRequest.GetQueryInt("id"); } }

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
                    StopRequest("参数无效！");
                    return;
                }
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
                try
                {
                    //绑定表名
                    new BLL.tb_provider().BindDropDownList(DrpTableName);
                    //编辑模态下，数据初始化
                    if (ActionType == TiKu.Common.ActionType.Edit && id > 0)
                    {
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
        /// 提交按钮单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_ServerClick(object sender, EventArgs e)
        {
            //录入信息
            string strNames = txtNames.Value.Trim();
            string strVal = txtVal.Value.Trim();
            string strSort = txtSort.Value.Trim();
            string strTableName = DrpTableName.SelectedValue.Trim();
            //业务校验
            if (string.IsNullOrEmpty(strNames))
            {
                base.ShowMsg("级别名称不能为空！", MessageType.Warn);
                return;
            }
            if (string.IsNullOrEmpty(strVal))
            {
                base.ShowMsg("级别值不能为空！", MessageType.Warn);
                return;
            }
            if (string.IsNullOrEmpty(strTableName))
            {
                base.ShowMsg("请选择表名！", MessageType.Warn);
                return;
            }
            if (bll.IsExistVal(strVal, id))
            {
                base.ShowMsg("级别值已经存在！", MessageType.Warn);
                return;
            }
            //声明实体
            Model.tb_level model = new Model.tb_level();
            model.Del = TiKu.Common.Constants.Common.NORMAL;
            model.Names = strNames;
            model.Val = strVal;
            int iSort = 0;
            iSort = Int32.TryParse(strSort, out iSort) ? iSort : 99;
            model.Orders = iSort;
            model.ForTableName = strTableName;
            if (RbtEnable.Checked)
            {
                model.State = TiKu.Common.Constants.Common.ENABLE;
            }
            if (RbtDisable.Checked)
            {
                model.State = TiKu.Common.Constants.Common.DISABLE;
            }
            //添加
            if (ActionType == TiKu.Common.ActionType.Add)
            {
                DoAdd(model);
                return;
            }
            //修改
            if (ActionType == TiKu.Common.ActionType.Edit)
            {
                DoUpdate(model);
            }
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        private void DoAdd(Model.tb_level model)
        {
            if (bll.Add(model))
            {
                base.ShowMsg("信息保存成功！", MessageType.Success, "index.aspx");
                base.AdminLog("添加级别",
                              TiKu.Common._Active.ADD,
                              string.Format("管理员{0}添加级别", AdminName));
            }
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model"></param>
        private void DoUpdate(Model.tb_level model)
        {
            model.ID = id;
            if (bll.Update(model))
            {
                base.ShowMsg("信息保存成功！", MessageType.Success, "index.aspx");
                base.AdminLog("修改级别",
                              TiKu.Common._Active.ADD,
                              string.Format("管理员{0}修改级别", AdminName));
            }
        }

        /// <summary>
        /// 数据
        /// </summary>
        private void data()
        {
            //声明实体
            Model.tb_level model = null;
            model = bll.GetModel(id);
            if (null == model)
            {
                StopRequest("信息不存在，或已被删除！");
                return;
            }
            txtNames.Value = model.Names;
            txtSort.Value = model.Orders.ToString();
            txtVal.Value = model.Val.ToString();
            DrpTableName.SelectedValue = model.TableName;
            if (TiKu.Common.Constants.Common.ENABLE == model.State)
            {
                RbtEnable.Checked = true;
            }
            else
            {
                RbtDisable.Checked = true;
            }
        }
    }
}