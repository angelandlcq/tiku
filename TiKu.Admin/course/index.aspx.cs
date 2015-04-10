using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
/*=================================================================================================
 * 
 * className:Admin专业科目（UI）
 * author:1058736170@qq.com
 * date:2015-03-23 10:48
 * modifyBy:1058736170@qq.com
 * modifyOn:2015-03-23 10:48
 * mark:本程序由代码生成器生成,了解更多,请登录http://my.oschina.net/lichaoqiang
 * 
 * ================================================================================================*/
namespace TiKu.Admin.course
{
    public partial class index : TiKu.WebUI.Page.AdminBase
    {
        #region 成员
        /// <summary>
        /// BLL组件
        /// </summary>
        protected readonly BLL.tb_CourseInfo bll = new BLL.tb_CourseInfo();

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
                    new BLL.tb_CourseCategory().BindCourseCategory(DrpCategory);//绑定课程分类
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
            string strCate = DrpCategory.SelectedValue.Trim();
            strKeywords = UrlEncode(strKeywords);
            Response.Redirect(string.Format("index.aspx?keywords={0}&cat={1}", strKeywords, strCate));
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
            int iID = Convert.ToInt32(strID.Split('|')[0]),
                iCateID = Convert.ToInt32(strID.Split('|')[1]);
            try
            {
                //删除操作
                if (e.CommandName == "delete")
                {
                    if (bll.DoDel(iID, iCateID, (m) =>
                    {
                        bll.ClearCache(m);//清除该分类的缓存数据
                    }))
                    {
                        base.ShowMsg("删除成功！", MessageType.Success);
                        data();
                        //日志
                        if (IsEnableAdminLog)
                        {
                            TiKu.Common.Logger.AdminLogger.Info(AdminID,
                                                                "删除课程信息",
                                                                TiKu.Common._Active.ADD,
                                                                string.Format("{0}删除课程信息", AdminName));
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
            string strWhere = "";
            string strKeywords = TiKu.Common.TKRequest.GetQueryString("keywords");
            string strCate = TiKu.Common.TKRequest.GetQueryString("cat");
            Dictionary<string, object> dictWhere = new Dictionary<string, object>();
            if (!string.IsNullOrEmpty(strKeywords))
            {
                strKeywords = UrlDecode(strKeywords);
                strWhere = " And CharIndex(@Keywords,Names)>0";
                dictWhere["@Keywords"] = strKeywords;
                txtKeywords.Value = strKeywords;
            }
            if (!string.IsNullOrEmpty(strCate))
            {
                strWhere += " And CategoryID=@CategoryID";
                dictWhere["@CategoryID"] = strCate;
                DrpCategory.SelectedValue = strCate;
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
                                       "index.aspx?page={0}");
        }
    }
}