using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
/*=================================================================================================
 * 
 * className:角色管理
 * author:beisha
 * date:
 * modifyBy:
 * modifyOn:
 * mark:
 * 
 * ================================================================================================*/
namespace TiKu.Admin.role
{
    public partial class list : TiKu.WebUI.Page.AdminBase
    {
        #region 成员
        /// <summary>
        /// BLL组件
        /// </summary>
        private readonly BLL.tb_AdminRole bll = new BLL.tb_AdminRole();

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
            try
            {
                //删除
                if (e.CommandName == "delete")
                {
                    if (bll.DoDel(Convert.ToInt32(strID)))
                    {
                        base.ShowMsg("删除成功！", MessageType.Success);
                        data();
                        if (IsEnableAdminLog)
                        {
                            //日志
                            TiKu.Common.Logger.AdminLogger.Info(AdminID,
                                                                "删除角色",
                                                                TiKu.Common._Active.DELETE,
                                                                "删除角色");
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                base.ShowMsg(ex.Message, MessageType.Error);
                TiKu.Common.LogUtil.Error(ex);
            }
            //修改
            if (e.CommandName == "edit")
            {
                Response.Redirect(string.Format("edit.aspx?action={0}&id={1}", TiKu.Common.ActionType.Edit, strID));
            }
        }

        /// <summary>
        /// 数据初始化
        /// </summary>
        private void data()
        {
            int iCount = 0,
                start = (__CurrentIndex - 1) * PageSize + 1,
                end = __CurrentIndex * PageSize;
            //获取列表
            DataSet ds = bll.GetData(start,
                                     end,
                                   " And Del=0",
                                   null,
                                   null,
                                   out iCount);
            RepList.DataSource = ds.Tables[0].DefaultView;
            RepList.DataBind();
            //分页内容
            __pagenation = get_page_list(PageSize,
                                       iCount,
                                       __CurrentIndex,
                                       "");
        }
    }
}