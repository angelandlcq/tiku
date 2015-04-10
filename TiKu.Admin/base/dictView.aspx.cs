using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TiKu.Admin._base
{
    public partial class dictView : TiKu.WebUI.Page.AdminBase
    {

        /// <summary>
        /// 编号
        /// </summary>
        protected int id { get { return TiKu.Common.TKRequest.GetQueryInt("id"); } }

        /// <summary>
        /// 数据
        /// </summary>
        protected Dictionary<string, object> dictData
        {
            get;
            set;
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
                if (id <= 0)
                {
                    StopRequest("参数无效！");
                    return;
                }
                //根据编号，获取实体
                Model.tb_Dictionay model = new BLL.tb_Dictionay().GetModel(id);
                if (null == model)
                {
                    StopRequest("信息不存在，或已被删除！");
                    return;
                }
                if (string.IsNullOrEmpty(model.Data))
                {
                    dictData = new Dictionary<string, object>();
                    return;
                }
                dictData = TiKu.Common.JsonHelper.MapToObject<Dictionary<string, object>>(model.Data);
            }
        }
    }
}