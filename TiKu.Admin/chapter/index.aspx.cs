using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
/*=================================================================================================
 * 
 * className:Admin章节（UI）
 * author:1058736170@qq.com
 * date:2015-03-23 14:09
 * modifyBy:1058736170@qq.com
 * modifyOn:2015-03-23 14:09
 * mark:本程序由代码生成器生成,了解更多,请登录http://my.oschina.net/lichaoqiang
 * 
 * ================================================================================================*/
namespace TiKu.Admin.chapter
{
    public partial class index : TiKu.WebUI.Page.AdminBase
    {
        #region 成员
        /// <summary>
        /// BLL组件
        /// </summary>
        protected readonly BLL.tb_Chapter bll = new BLL.tb_Chapter();

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
            btnQuery.ServerClick += new EventHandler(btnQuery_Click);
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
        /// 查询按钮单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnQuery_Click(object sender, EventArgs e)
        {
            string strState = DrpState.SelectedValue.Trim();
            string strKeywords = txtKeywords.Value.Trim();
            strKeywords = UrlEncode(strKeywords);
            Response.Redirect(string.Format("index.aspx?state={0}&keywords={1}", strState, strKeywords));
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
                    if (bll.Delete(Convert.ToInt32(strID)) > 0)
                    {
                        base.ShowMsg("删除成功！", MessageType.Success);
                        data();
                        //管理员日志
                        if (IsEnableAdminLog)
                        {
                            //记录日志
                            TiKu.Common.Logger.AdminLogger.Info(AdminID,
                                                                "删除",
                                                                TiKu.Common._Active.DELETE,
                                                                "删除信息");
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
                Response.Redirect(string.Format("edit.aspx?action=edit&id={0}", strID));
            }
        }


        /// <summary>
        /// 绑定数据
        /// </summary>
        private void data()
        {
            //1>条件
            string strWhere = "";
            string strKeywords = TiKu.Common.TKRequest.GetQueryString("keywords");
            string strState = TiKu.Common.TKRequest.GetQueryString("state");
            //参数
            Dictionary<string, object> dictWhere = new Dictionary<string, object>();
            if (!string.IsNullOrEmpty(strKeywords))
            {
                strKeywords = UrlDecode(strKeywords);
                strWhere = " And charIndex(@Keywords,CptName)>0";
                dictWhere["@Keywords"] = strKeywords;
                txtKeywords.Value = strKeywords;
            }
            if (!string.IsNullOrEmpty(strState))
            {
                strWhere = " And State=@State";
                dictWhere["@State"] = strState;
                DrpState.SelectedValue = strState;
            }


            int iCount = 0,
                start = (__CurrentIndex - 1) * PageSize,
                end = __CurrentIndex * PageSize;
            //2>获取列表
            DataSet ds = bll.GetData(start,
                                     end,
                                     strWhere,
                                     null,
                                    dictWhere,
                                    out iCount);
            //3>绑定数据列表
            RepList.DataSource = ds.Tables[0].DefaultView;
            RepList.DataBind();
            //4>分页
            __pagenation = get_page_list(PageSize,
                                       iCount,
                                       __CurrentIndex,
                                       string.Format("index.aspx?state={0}&keywords={1}&page={{0}}",
                                                      strState,
                                                      strKeywords));
        }
    }
}