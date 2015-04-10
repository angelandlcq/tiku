using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
/*=================================================================================================
 * 
 * className:Admin管理员管理
 * author:beisha
 * date:
 * modifyBy:
 * modifyOn:
 * mark:
 * 
 * ================================================================================================*/
namespace TiKu.Admin.admin
{
    public partial class list : TiKu.WebUI.Page.AdminBase
    {

        /// <summary>
        /// BLL组件
        /// </summary>
        private readonly BLL.tb_Admin bll = new BLL.tb_Admin();

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
                //绑定数据
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
            //删除操作
            if (e.CommandName == "delete")
            {
                try
                {
                    int iAdminID = Convert.ToInt32(strID);//AdminID
                    if (iAdminID == AdminID)
                    {
                        base.ShowMsg("非法操作！", MessageType.Warn);
                        return;
                    }
                    if (bll.DoDel(iAdminID, AdminID))
                    {
                        base.ShowMsg("删除成功！", MessageType.Success);
                        data();
                        //是否启用日志
                        if (IsEnableAdminLog)
                        {
                            //记录日志
                            TiKu.Common.Logger.AdminLogger.Info(AdminID,
                                                                "删除管理员",
                                                                TiKu.Common._Active.DELETE,
                                                                AdminName + "删除了管理员！");
                        }
                    }
                    else
                    {
                        base.ShowMsg("删除时发生异常，请稍后再试!", MessageType.Error);
                    }
                }
                catch (Exception ex)
                {
                    base.ShowMsg(ex.Message, MessageType.Error);
                    TiKu.Common.LogUtil.Error(ex);
                }
            }
            //修改
            if (e.CommandName == "edit")
            {
                Response.Redirect(string.Format("edit.aspx?id={0}", strID));
            }
        }

        #region 绑定
        /// <summary>
        /// 绑定数据
        /// </summary>
        private void data()
        {
            List<Model.tb_Admin> list = new List<Model.tb_Admin>();
            int iCount = 0,
                start = (__CurrentIndex - 1) * PageSize + 1,
                end = __CurrentIndex * PageSize;
            //获取列表
            list = bll.GetListPager(start,
                                    end,
                                    " And a.Del=0",
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
                                            "");
        }
        #endregion
    }
}