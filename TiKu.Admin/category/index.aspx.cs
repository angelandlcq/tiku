using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
/*=================================================================================================
 * 
 * className:Admin题库类别（科目分类）（UI）
 * author:1058736170@qq.com
 * date:2015-03-13 11:04
 * modifyBy:1058736170@qq.com
 * modifyOn:2015-03-13 11:04
 * mark:本程序由代码生成器生成,了解更多,请登录http://my.oschina.net/lichaoqiang
 * 
 * ================================================================================================*/
namespace TiKu.Admin.category
{
    public partial class index : TiKu.WebUI.Page.AdminBase
    {


        #region 成员
        /// <summary>
        /// BLL组件
        /// </summary>
        private readonly BLL.tb_CourseCategory bll = new BLL.tb_CourseCategory();

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
                    bll.BindCourseCategory(DrpCategory);//绑定课程分类
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
            string strKeywords = txtKeywords.Value.Trim();
            string strParentID = DrpCategory.SelectedValue.Trim();
            strKeywords = UrlDecode(strKeywords);
            Response.Redirect(string.Format("index.aspx?keywords={0}&fid={1}", strKeywords, strParentID));
        }

        /// <summary>
        /// 操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void RepList_OnItemCommand(object sender, RepeaterCommandEventArgs e)
        {
            //主键
            int iID = Convert.ToInt32(e.CommandArgument);
            try
            {
                //删除操作
                if (e.CommandName == "delete")
                {
                    if (bll.Delete(iID) > 0)
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
                Response.Redirect(string.Format("edit.aspx?action=edit&id={0}", iID));
            }
        }


        /// <summary>
        /// 绑定数据
        /// </summary>
        private void data()
        {
            //1>条件
            string strWhere = " And Del=0";
            string strKeywords = TiKu.Common.TKRequest.GetQueryString("keywords");
            string strParentCate = TiKu.Common.TKRequest.GetQueryString("fid");

            Dictionary<string, object> dictParameters = new Dictionary<string, object>();
            if (!string.IsNullOrEmpty(strKeywords))
            {
                strKeywords = UrlDecode(strKeywords);
                strWhere += " And charIndex(@keywords,CateName)>0";
                dictParameters["@keywords"] = strKeywords;
                txtKeywords.Value = strKeywords;
            }
            if (!string.IsNullOrEmpty(strParentCate))
            {
                strWhere += " And ParentID=@ParentID";
                dictParameters["@ParentID"] = strParentCate;
                DrpCategory.SelectedValue = strParentCate;
            }
            int iCount = 0,
                start = (__CurrentIndex - 1) * PageSize,
                end = __CurrentIndex * PageSize;
            //2>获取列表
            DataSet ds = bll.GetData(start,
                                   end,
                                   strWhere,
                                   " Order By [Orders] Asc",
                                   dictParameters,
                                   out iCount);
            //3>绑定数据列表
            RepList.DataSource = ds.Tables[0].DefaultView;
            RepList.DataBind();
            //4>分页
            __pagenation = get_page_list(PageSize,
                                       iCount,
                                       __CurrentIndex,
                                       string.Format("index.aspx?keywords={0}&fid={1}&page={{0}}", strKeywords, strParentCate));
        }
    }
}