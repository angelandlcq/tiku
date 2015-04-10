using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
/******************************************************************************
 * 
 * 
 * 说 明：选择课程分类
 * 
 * *****************************************************************************/
namespace TiKu.Admin.question
{
    public partial class course : System.Web.UI.Page
    {

        /// <summary>
        /// 画面载入事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        /// <summary>
        /// 获取课程分类
        /// </summary>
        /// <returns></returns>
        protected List<Model.tb_CourseCategory> GetCourseCategory()
        {
            BLL.tb_CourseCategory bll = new BLL.tb_CourseCategory();
            List<Model.tb_CourseCategory> list = bll.GetCacheList();
            return list;
        }
    }
}