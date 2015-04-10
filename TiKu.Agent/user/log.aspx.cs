using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
/*=========================================日志管理=============================================================*/
namespace TiKu.Agent.user
{
    public partial class log : TiKu.WebUI.Page.AgentBase
    {

        /// <summary>
        /// BLL
        /// </summary>
        protected readonly BLL.tb_AgentLog bll = new BLL.tb_AgentLog();

        /// <summary>
        /// 当前页
        /// </summary>
        protected int __CurrentIndex
        {
            get
            {
                int index = TiKu.Common.TKRequest.GetQueryInt("page");
                return (index == 0 ? 1 : index);
            }
        }

        /// <summary>
        /// 分页html
        /// </summary>
        protected string __PagenationHtml = string.Empty;


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
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnQuery_Click(object sender, EventArgs e)
        {
            string strKeywords = txtKeywords.Value.Trim();
            strKeywords = UrlEncode(strKeywords);
            Response.Redirect(string.Format(string.Format("log.aspx?keywords={0}", strKeywords)));
        }


        /// <summary>
        /// 操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void RepList_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {
            int iID = Convert.ToInt32(e.CommandArgument);
            try
            {
                //删除
                if (e.CommandName == "delete")
                {
                    if (bll.Delete(iID) > 0)
                    {
                        base.ShowMsg(":)删除成功！", MessageType.Success);
                        data();
                        base.LogInfo("删除日志", string.Format("代理商{0}删除日志", AgentName));
                    }
                }
            }
            catch (Exception ex)
            {
                TiKu.Common.LogUtil.Error(ex);
            }
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        private void data()
        {
            //条件
            string strWhere = " And AgentID=@AgentID";
            string strKeywords = TiKu.Common.TKRequest.GetQueryString("keywords");
            //参数
            Dictionary<string, object> dictParameters = new Dictionary<string, object>();
            if (!string.IsNullOrEmpty(strKeywords))
            {
                strKeywords = UrlEncode(strKeywords);
                strWhere += " And charIndex(@Keywords,Msg)>0";
                dictParameters["@Keywords"] = strKeywords;
                txtKeywords.Value = strKeywords;

            }

            int iCount = 0,
                start = (__CurrentIndex - 1) * PageSize + 1,
                end = __CurrentIndex * PageSize;

            dictParameters["@AgentID"] = AgentID;
            List<Model.tb_AgentLog> list = bll.GetListPager(start,
                                                              end,
                                                              strWhere,
                                                              null,
                                                              dictParameters,
                                                              out iCount);
            //绑定列表
            RepList.DataSource = list;
            RepList.DataBind();
            //分页html
            __PagenationHtml = base.get_page_list(PageSize,
                                                  iCount,
                                                  __CurrentIndex,
                                                  string.Format("log.aspx?keywords={0}&page={{0}}", strKeywords));
        }
    }
}