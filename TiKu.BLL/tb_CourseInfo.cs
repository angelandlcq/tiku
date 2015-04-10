#region using directiry
using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System.Collections;
using TiKu.DataDriver.Entity;
using System.Web.UI.WebControls;
#endregion
/*=================================================================================================
 * 
 * className:专业科目(BLL)
 * author:1058736170@qq.com
 * date:2015-03-05 15:23
 * modifyBy:1058736170@qq.com
 * modifyOn:2015-03-05 15:23
 * mark:本程序由代码生成器生成,了解更多,请登录http://my.oschina.net/lichaoqiang
 * 
 * ================================================================================================*/
namespace TiKu.BLL
{
    //专业科目
    public partial class tb_CourseInfo
    {
        #region 成员
        /// <summary>
        /// 表名
        /// </summary>
        private readonly string TableName = "tb_CourseInfo";
        #endregion

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(TiKu.Model.tb_CourseInfo model, Action<Model.tb_CourseInfo> success)
        {
            if (EntityQuery<TiKu.Model.tb_CourseInfo>.Instance.Add(model))
            {
                if (null != success) { success(model); }
                return true;
            }
            return false;
        }

        /// <summary>
        ///修改
        /// </summary>
        public bool Update(TiKu.Model.tb_CourseInfo model, Action<Model.tb_CourseInfo> success)
        {
            if (EntityQuery<TiKu.Model.tb_CourseInfo>.Instance.Update(model))
            {
                if (null != success)
                {
                    success(model);
                }
                return true;
            }
            return false;
        }

        /// <summary>
        ///删除
        /// </summary>
        public int Delete(TiKu.Model.tb_CourseInfo model)
        {
            return EntityQuery<TiKu.Model.tb_CourseInfo>.Instance.Delete(model);
        }

        /// <summary>
        /// 执行删除操作
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public bool DoDel(int ID, int CateID, Action<Int32> success)
        {
            bool isSuccess = false;
            Model.tb_CourseInfo model = new Model.tb_CourseInfo();
            model.ID = ID;
            //逻辑删除
            if (tb_WebSet.WebSiteInfo.IsEnableDelete > 0)
            {
                model.Del = TiKu.Common.Constants.Common.DELETE;
                isSuccess = (EntityQuery<TiKu.Model.tb_CourseInfo>.Instance.Update(model));
            }
            //物理删除
            else
            {
                isSuccess = Delete(model) > 0;
            }
            //清除缓存
            if (isSuccess && null != success) { success(CateID); }
            return isSuccess;
        }



        /// <summary>
        /// 获取单个实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public TiKu.Model.tb_CourseInfo GetModel(int ID)
        {
            TiKu.Model.tb_CourseInfo model = new TiKu.Model.tb_CourseInfo();
            EntityQuery<TiKu.Model.tb_CourseInfo>.Instance.Fill(model);
            return model;
        }

        /// <summary>
        /// 获取实体列表
        /// </summary>
        /// <param name="top"></param>
        /// <param name="where"></param>
        /// <param name="orders"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public List<TiKu.Model.tb_CourseInfo> GetList(int top,
            string where,
            string orders,
            IEnumerable parameters)
        {
            List<TiKu.Model.tb_CourseInfo> list = TiKu.DataDriver.Entity.EntityQuery<TiKu.Model.tb_CourseInfo>.Instance.GetList(top,
                                                                               "ID,Names,CategoryID,Orders,Del,State",
                                                                               "tb_CourseInfo",
                                                                               where,
                                                                               orders,
                                                                               parameters);
            return list;
        }

        /// <summary>
        /// 根据分类编号，获取课程信息
        /// </summary>
        /// <param name="CateID">课程分类编号</param>
        /// <returns></returns>
        public List<TiKu.Model.tb_CourseInfo> GetCourseListByCateID(int CateID)
        {
            string strCacheKey = "__CACHE_COURSE_" + CateID;//缓存Key
            //是否从缓存中提取数据
            if (TiKu.Common.CacheHelper.IsExistsCahce(strCacheKey))
            {
                return TiKu.Common.CacheHelper.GetCacheValue<List<Model.tb_CourseInfo>>(strCacheKey);
            }
            SqlParameter[] parameters = {
                                        new SqlParameter("@CategoryID",SqlDbType.Int)
                                        };
            parameters[0].Value = CateID;

            List<TiKu.Model.tb_CourseInfo> list = TiKu.DataDriver.Entity.EntityQuery<TiKu.Model.tb_CourseInfo>.Instance.GetList(0,
                                                                            "ID,Names",
                                                                            "tb_CourseInfo",
                                                                            " And Del=0 And State=1 And CategoryID=@CategoryID",
                                                                            " Order By [Orders] Asc",
                                                                            parameters);
            TiKu.Common.CacheHelper.SaveCache(strCacheKey, list);//缓存数据
            return list;
        }

        /// <summary>
        /// 绑定课程分类
        /// </summary>
        /// <param name="drpCourse"></param>
        public void BindCourseList(DropDownList drpCourse, int iCateID)
        {
            List<Model.tb_CourseInfo> list = GetCourseListByCateID(iCateID);
            drpCourse.DataTextField = "Names";
            drpCourse.DataValueField = "ID";
            drpCourse.DataSource = list;
            drpCourse.DataBind();
            drpCourse.Items.Insert(0, new ListItem("--请选择专业课程--", ""));
        }

        /// <summary>
        /// 获取符合条件的记录数
        /// </summary>
        /// <param name="where"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public int Count(string where, IEnumerable parameters)
        {
            return TiKu.DataDriver.AdoHelper.Count(where, TableName, parameters);
        }

        /// <summary>
        /// 移除缓存
        /// </summary>
        /// <param name="iCateID"></param>
        public void ClearCache(int iCateID)
        {
            TiKu.Common.CacheHelper.RemoveCache("__CACHE_COURSE_" + iCateID);
        }

        /// <summary>
        /// 分页：获取列表
        /// </summary>
        /// <param name="startIndex">开始索引</param>
        /// <param name="endIndex">截止索引</param>
        /// <param name="where">条件</param>
        /// <param name="orders">排序</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        public List<TiKu.Model.tb_CourseInfo> GetListPager(int startIndex,
                                                    int endIndex,
                                                    string where,
                                                    string orders,
                                                    IEnumerable parameters,
                                                    out int iRowCount)
        {
            iRowCount = 0;
            StringBuilder stbCmdText = new StringBuilder();
            StringBuilder stbCmdCount = new StringBuilder();
            stbCmdCount.AppendFormat("SELECT COUNT(1) AS Total FROM [{0}] WHERE 1=1 ", TableName);
            stbCmdText.Append("SELECT * FROM (");
            stbCmdText.AppendFormat("SELECT Row_Number() over(order by ID desc) as Row,ID,Names,CategoryID,Orders,Del,State FROM [{0}] WHERE 1=1 ", TableName);
            if (!string.IsNullOrEmpty(where))
            {
                stbCmdText.Append(where);
                stbCmdCount.Append(where);
            }
            stbCmdText.Append(") as T");
            stbCmdText.AppendFormat(" WHERE Row Between {0} And {1}", startIndex, endIndex);
            if (!string.IsNullOrEmpty(orders))
            {
                stbCmdText.Append(orders);
            }
            List<TiKu.Model.tb_CourseInfo> list = new List<TiKu.Model.tb_CourseInfo>();
            string strCmdText = stbCmdText + ";" + stbCmdCount;
            using (IDataReader dataReader = TiKu.DataDriver.AdoHelper.ExcuteDataReader(strCmdText, parameters))
            {
                while (dataReader.Read())
                {
                    TiKu.Model.tb_CourseInfo model = new TiKu.Model.tb_CourseInfo();
                    for (int i = 1; i < dataReader.FieldCount; i++)
                    {
                        model.SetPropertyValue(dataReader.GetName(i), dataReader.GetValue(i));
                    }
                    list.Add(model);
                }
                if (dataReader.NextResult() && dataReader.Read())
                {
                    iRowCount = Convert.ToInt32(dataReader["Total"]);
                }
            }
            return list;
        }

        /// <summary>
        /// 显示状态
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public string ShowStateLabel(object state)
        {
            if (null == state)
            {
                return "缺省";
            }
            int iState = Convert.ToInt32(state);
            if (iState == TiKu.Common.Constants.Common.ENABLE)
            {
                return "启用";
            }
            if (iState == TiKu.Common.Constants.Common.DISABLE)
            {
                return "禁用";
            }
            return "禁用";
        }

        /// <summary>
        /// 分页：获取数据列表
        /// </summary>
        /// <param name="startIndex">开始索引</param>
        /// <param name="endIndex">截止索引</param>
        /// <param name="where">条件</param>
        /// <param name="orders">排序</param>
        /// <param name="parameters">参数</param>
        /// <param name="iRowCount">输出参数：记录数</param>
        /// <returns></returns>
        public DataSet GetData(int startIndex,
                                int endIndex,
                                string where,
                                string orders,
                                IEnumerable parameters,
                                out int iRowCount)
        {
            iRowCount = 0;
            StringBuilder stbCmdText = new StringBuilder();
            StringBuilder stbCmdCount = new StringBuilder();
            stbCmdCount.AppendFormat("SELECT @Count=COUNT(1) FROM [{0}] WHERE 1=1 ", TableName);
            stbCmdText.Append("SELECT * FROM (");
            stbCmdText.AppendFormat(@"SELECT Row_Number() over(order by a.ID desc) as Row,a.ID,Names,b.CateName,CategoryID,a.Orders,a.Del,a.State FROM [{0}] a Left join [tb_CourseCategory] b
            ON a.CategoryID=b.ID
            WHERE 1=1 ", TableName);
            if (!string.IsNullOrEmpty(where))
            {
                stbCmdText.Append(where);
                stbCmdCount.Append(where);
            }
            stbCmdText.Append(") as T");
            stbCmdText.AppendFormat(" WHERE Row Between {0} And {1}", startIndex, endIndex);
            if (!string.IsNullOrEmpty(orders))
            {
                stbCmdText.Append(orders);
            }
            string strCmdText = stbCmdText + ";" + stbCmdCount;
            Dictionary<string, object> dictOutput = new Dictionary<string, object>();
            dictOutput["@Count"] = 0;
            DataSet ds = TiKu.DataDriver.AdoHelper.Query(strCmdText, parameters, ref dictOutput);
            iRowCount = Convert.ToInt32(dictOutput["@Count"]);
            return ds;
        }

    }
}