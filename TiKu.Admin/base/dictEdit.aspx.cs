using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TiKu.Admin._base
{
    public partial class dictEdit : TiKu.WebUI.Page.AdminBase
    {
        /// <summary>
        /// BLL组件
        /// </summary>
        private readonly BLL.tb_Dictionay bll = new BLL.tb_Dictionay();

        /// <summary>
        /// 字典编号
        /// </summary>
        private int id
        {
            get { return TiKu.Common.TKRequest.GetQueryInt("id"); }
        }

        /// <summary>
        /// 获取或设置值
        /// </summary>
        protected Dictionary<string, object> dictValues
        {
            get
            {
                if (null != ViewState["dictValues"]) { return (Dictionary<string, object>)ViewState["dictValues"]; }
                return null;
            }
            set
            {
                ViewState["dictValues"] = value;
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
                    StopRequest("参数无效！");
                    return;
                }
            }
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
                    ///编辑初始化
                    if (ActionType == TiKu.Common.ActionType.Edit
                        && id > 0)
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
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //录入信息
            string strNames = txtNames.Value.Trim();
            string strCode = txtCode.Value.Trim();
            string strDescription = txtDescription.Value.Trim();
            string strKeys = TiKu.Common.TKRequest.GetFormString("key");
            string strVals = TiKu.Common.TKRequest.GetFormString("val");
            //业务校验
            if (string.IsNullOrEmpty(strNames))
            {
                base.ShowMsg("字典名称不能为空！", MessageType.Warn);
                return;
            }
            if (string.IsNullOrEmpty(strCode))
            {
                base.ShowMsg("字典编号不能为空！", MessageType.Warn);
                return;
            }
            //验证调用名是否存在
            if (bll.IsExistsCode(strCode, id))
            {
                base.ShowMsg("调用名称，已经存在！", MessageType.Warn);
                return;
            }
            //声明实体
            Model.tb_Dictionay model = new Model.tb_Dictionay();
            model.Code = strCode;
            model.Names = strNames;
            model.Data = GetDictJsonData();
            model.Description = strDescription;
            if (RbtEnable.Checked)
            {
                model.State = TiKu.Common.Constants.Common.ENABLE;
            }
            if (RbtDisable.Checked)
            {
                model.State = TiKu.Common.Constants.Common.DISABLE;
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
                    DoUpdate(model);
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
        private void DoAdd(Model.tb_Dictionay model)
        {
            if (bll.Add(model))
            {
                base.ShowMsg("信息保存成功！", MessageType.Success, "dict.aspx");
            }
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        private void DoUpdate(Model.tb_Dictionay model)
        {
            model.ID = id;
            if (bll.Update(model))
            {
                base.ShowMsg("信息保存成功！", MessageType.Success, "dict.aspx");
            }
        }

        /// <summary>
        /// 获取字典列表
        /// </summary>
        /// <returns></returns>
        private string GetDictJsonData()
        {
            string strKeys = TiKu.Common.TKRequest.GetFormString("key");
            string strVals = TiKu.Common.TKRequest.GetFormString("val");
            if (string.IsNullOrEmpty(strKeys))
            {
                return string.Empty;
            }
            strKeys = strKeys.Trim(',');
            strVals = strVals.Trim(',');
            string[] strArrayKey = strKeys.Split(',');
            string[] strArrayVal = strVals.Split(',');
            string strData = "{";
            for (int i = 0; i < strArrayKey.Length; i++)
            {
                strData += "\"" + strArrayKey[i] + "\"" + ":\"" + (i >= strArrayVal.Length ? "" : strArrayVal[i]) + "\",";
            }
            strData = strData.Trim(',');
            strData += "}";
            return strData;
        }

        /// <summary>
        /// 数据初始化
        /// </summary>
        private void data()
        {
            //声明实体
            Model.tb_Dictionay model = new Model.tb_Dictionay();
            model = bll.GetModel(id);
            if (null == model)
            {
                StopRequest("信息不存在，或被删除！");
                return;
            }
            txtNames.Value = model.Names;
            txtDescription.Value = model.Description;
            txtCode.Value = model.Code;
            dictValues = TiKu.Common.JsonHelper.MapToObject<Dictionary<string, object>>(model.Data);
            if (model.State == TiKu.Common.Constants.Common.ENABLE)
            {
                RbtEnable.Checked = true;
            }
            if (model.State == TiKu.Common.Constants.Common.DISABLE)
            {
                RbtDisable.Checked = false;
            }
        }
    }
}