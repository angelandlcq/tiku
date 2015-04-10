using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
/*=================================================================================================
 * 
 * className:Admin日志
 * author:beisha
 * date:
 * modifyBy:
 * modifyOn:
 * mark:
 * 
 * ================================================================================================*/
namespace TiKu.Admin.admin
{
    public partial class log : TiKu.WebUI.Page.AdminBase
    {


        #region 成员
        /// <summary>
        /// BLL组件
        /// </summary>
        private readonly BLL.tb_AdminLog bll = new BLL.tb_AdminLog();

        /// <summary>
        /// 当前页
        /// </summary>
        private int __CurrentIndex
        {
            get
            {
                int index = TiKu.Common.TKRequest.GetQueryInt("page");
                index = index <= 0 ? 1 : index;
                return index;
            }
        }
        /// <summary>
        /// 分页
        /// </summary>
        protected string __pagenation = string.Empty;
        #endregion

        /// <summary>
        /// 画面初始化
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInit(EventArgs e)
        {
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
                data();
            }
        }


        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDel_Click(object sender, EventArgs e)
        {
            string strIDs = TiKu.Common.TKRequest.GetFormString("chkID");
            if (string.IsNullOrEmpty(strIDs))
            {
                base.ShowMsg("请选择你要删除的信息！", MessageType.Warn);
                return;
            }
            //批量删除
            if (bll.Delete(strIDs) > 0)
            {
                base.ShowMsg("信息删除成功！", MessageType.Success);
                //记录日志
                if (IsEnableAdminLog)
                {
                    TiKu.Common.Logger.AdminLogger.Info(AdminID,
                                                        "批量删除日志",
                                                        TiKu.Common._Active.DELETE,
                                                        "批量删除日志!");
                }
                data();
            }
        }

        /// <summary>
        /// 操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void RepList_OnItemCommand(object sender, RepeaterCommandEventArgs e)
        {
            string strID = e.CommandArgument.ToString();
            try
            {
                //删除操作
                if (e.CommandName == "delete")
                {
                    if (bll.Delete(Convert.ToInt32(strID)) > 0)
                    {
                        base.ShowMsg(":)删除成功！", MessageType.Success);
                        data();
                    }
                }
            }
            catch (Exception ex)
            {
                base.ShowMsg(ex.Message, MessageType.Error);
                TiKu.Common.LogUtil.Error(ex);
            }
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        private void data()
        {
            //列表
            List<Model.tb_AdminLog> list = new List<Model.tb_AdminLog>();
            int iCount = 0,
                start = (__CurrentIndex - 1) * PageSize + 1,
                end = __CurrentIndex * PageSize;
            //参数
            Dictionary<string, object> dictParamters = new Dictionary<string, object>();
            list = bll.GetListPager(start,
                                  end,
                                  "",
                                  null,
                                  null,
                                  out iCount);
            //绑定列表
            RepList.DataSource = list;
            RepList.DataBind();
            //分页
            __pagenation = base.get_page_list(PageSize,
                                            iCount,
                                            __CurrentIndex,
                                            "log.aspx?page={0}");

        }
    }
}