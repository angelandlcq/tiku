using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
/*=================================================================================================
 * 
 * className:Admin代理商管理（UI）
 * author:1058736170@qq.com
 * date:2015-03-07 10:16
 * modifyBy:1058736170@qq.com
 * modifyOn:2015-03-07 10:16
 * mark:本程序由代码生成器生成,了解更多,请登录http://my.oschina.net/lichaoqiang
 * 
 * ================================================================================================*/
namespace TiKu.Admin.Agent
{
    public partial class list : TiKu.WebUI.Page.AdminBase
    {
        #region 成员
        /// <summary>
        /// BLL组件
        /// </summary>
        protected readonly BLL.tb_Agent bll = new BLL.tb_Agent();

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
        #endregion

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
            btnQuery.ServerClick += new EventHandler(btnQuery_ServerClick);
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
                    //绑定数据
                    data();
                }
                catch (Exception ex)
                {
                    TiKu.Common.LogUtil.Error(ex);
                }
            }
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnQuery_ServerClick(object sender, EventArgs e)
        {
            string strState = DrpState.SelectedValue.Trim(),
                   strAgentName = txtAgentName.Value.Trim();
            strAgentName = base.UrlEncode(strAgentName);//url编码
            Response.Redirect(string.Format("list.aspx?state={0}&name={1}", strState, strAgentName));
        }


        /// <summary>
        /// 操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void RepList_OnItemCommand(object sender, RepeaterCommandEventArgs e)
        {
            //主键
            string strID = e.CommandArgument.ToString();
            try
            {
                //删除操作
                if (e.CommandName == "delete")
                {
                    if (bll.DoDelete(Convert.ToInt32(strID), AdminID))
                    {
                        base.ShowMsg("删除成功！", MessageType.Success);
                        data();
                        //管理员日志
                        if (IsEnableAdminLog)
                        {
                            //记录日志
                            TiKu.Common.Logger.AdminLogger.Info(AdminID,
                                                                "删除代理商",
                                                                TiKu.Common._Active.DELETE,
                                                                "删除代理商信息");
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
                Response.Redirect(string.Format("edit.aspx?id={0}", strID));
            }
        }


        /// <summary>
        /// 绑定数据
        /// </summary>
        private void data()
        {
            //1>条件
            string strWhere = "";
            string strState = TiKu.Common.TKRequest.GetQueryString("state"),
                   strAgentName = TiKu.Common.TKRequest.GetQueryString("name");
            Dictionary<string, object> dictParameter = new Dictionary<string, object>();
            if (!string.IsNullOrEmpty(strState))
            {
                strWhere = " And State=@State";
                dictParameter.Add("@State", strState);
                DrpState.SelectedValue = strState;
            }
            if (!string.IsNullOrEmpty(strAgentName))
            {
                strAgentName = HttpUtility.UrlDecode(strAgentName);
                strWhere += " And charIndex(@AgentName,AgentName)>0";
                dictParameter.Add("@AgentName", strAgentName);
                txtAgentName.Value = strAgentName;
            }
            int iCount = 0,
                start = (__CurrentIndex - 1) * PageSize,
                end = __CurrentIndex * PageSize;
            //2>获取列表
            DataSet ds = bll.GetData(start,
                                   end,
                                   strWhere,
                                   null,
                                   dictParameter,
                                   out iCount);
            //3>绑定数据列表
            RepList.DataSource = ds.Tables[0].DefaultView;
            RepList.DataBind();
            //4>分页
            __pagenation = get_page_list(PageSize,
                                       iCount,
                                       __CurrentIndex,
                                       string.Format("list.aspx?state={0}&name={1}&page={{0}}", strState, strAgentName));
        }

        /// <summary>
        /// 审核/冻结/解冻 操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAudit_Click(object sender, EventArgs e)
        {

            string strCheckedIDs = TiKu.Common.TKRequest.GetFormString("chkID");
            if (string.IsNullOrEmpty(strCheckedIDs))
            {
                base.ShowMsg("请选择你要操作的信息！", MessageType.Warn);
                return;
            }
            string strCommand = (sender as Button).CommandName;//操作
            int strArg = Convert.ToInt32((sender as Button).CommandArgument);//参数状态
            try
            {
                //批量操作
                if (bll.SaveAgentState(strCheckedIDs,
                                       strArg,
                                       AdminID))
                {
                    base.ShowMsg(":)操作成功！", MessageType.Success);
                    data();
                    //日志
                    if (IsEnableAdminLog)
                    {
                        TiKu.Common.Logger.AdminLogger.Info(AdminID,
                                                            "批量修改代理商",
                                                            TiKu.Common._Active.EDIT,
                                                            string.Format("管理员{0}批量修改代理商状态", AdminName));
                    }
                }
            }
            catch (Exception ex)
            {
                TiKu.Common.LogUtil.Error(ex);
            }

        }
    }
}