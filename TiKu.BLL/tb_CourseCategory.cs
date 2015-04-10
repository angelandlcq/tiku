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
 * className:题库类别（科目分类）(BLL)
 * author:1058736170@qq.com
 * date:2015-03-13 11:01
 * modifyBy:1058736170@qq.com
 * modifyOn:2015-03-13 11:01
 * mark:本程序由代码生成器生成,了解更多,请登录http://my.oschina.net/lichaoqiang
 * 
 * ================================================================================================*/
namespace TiKu.BLL
{
    //题库类别（科目分类）
    public partial class tb_CourseCategory
    {
        #region 成员
        /// <summary>
        /// 表名
        /// </summary>
        private readonly string TableName = "tb_CourseCategory";
        #endregion

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(TiKu.Model.tb_CourseCategory model)
        {
            if (EntityQuery<TiKu.Model.tb_CourseCategory>.Instance.Add(model))
            {
                //清除缓存
                TiKu.Common.CacheHelper.RemoveCache(TiKu.Common.Constants.CACHE_KEY._CACHE_COURSE_CATEGORY_KEY);
                return true;
            }
            return false;
        }

        /// <summary>
        ///修改
        /// </summary>
        public bool Update(TiKu.Model.tb_CourseCategory model)
        {
            if (EntityQuery<TiKu.Model.tb_CourseCategory>.Instance.Update(model))
            {
                //清除缓存
                TiKu.Common.CacheHelper.RemoveCache(TiKu.Common.Constants.CACHE_KEY._CACHE_COURSE_CATEGORY_KEY);
                return true;
            }
            return false;
        }

        /// <summary>
        ///删除
        /// </summary>
        public int Delete(TiKu.Model.tb_CourseCategory model)
        {
            return EntityQuery<TiKu.Model.tb_CourseCategory>.Instance.Delete(model);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ID">编号</param>
        /// <returns></returns>
        public int Delete(int ID)
        {
            SqlParameter[] parameters = {
                                            new SqlParameter("@ID",SqlDbType.Int,8)
                                        };
            parameters[0].Value = ID;
            return TiKu.DataDriver.AdoHelper.Delete(TableName, " And ID=@ID", parameters);
        }

        /// <summary>
        /// 判断分类名称是否存在
        /// </summary>
        /// <param name="CateName"></param>
        /// <returns></returns>
        public bool IsExistsName(string CateName)
        {
            SqlParameter[] parameters = { 
                                        new SqlParameter("@CateName",SqlDbType.VarChar,100)
                                        };
            int iCount = Count(" And CateName=@CateName", parameters);
            return (iCount > 0);
        }

        /// <summary>
        /// 获取单个实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public TiKu.Model.tb_CourseCategory GetModel(int ID)
        {
            TiKu.Model.tb_CourseCategory model = new TiKu.Model.tb_CourseCategory();
            model.ID = ID;
            EntityQuery<TiKu.Model.tb_CourseCategory>.Instance.Fill(model);
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
        public List<TiKu.Model.tb_CourseCategory> GetList(int top,
            string where,
            string orders,
            IEnumerable parameters)
        {
            List<TiKu.Model.tb_CourseCategory> list = TiKu.DataDriver.Entity.EntityQuery<TiKu.Model.tb_CourseCategory>.Instance.GetList(top,
                                                                               "ID,CateName,ParentID,Orders,CreatedBy,CreatedOn,ModifyBy,ModifyOn,Remark,Val,Deep,Del",
                                                                               "tb_CourseCategory",
                                                                               where,
                                                                               orders,
                                                                               parameters);
            return list;
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
        /// 分页：获取列表
        /// </summary>
        /// <param name="startIndex">开始索引</param>
        /// <param name="endIndex">截止索引</param>
        /// <param name="where">条件</param>
        /// <param name="orders">排序</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        public List<TiKu.Model.tb_CourseCategory> GetListPager(int startIndex,
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
            stbCmdText.AppendFormat("SELECT Row_Number() over(order by ID desc) as Row,ID,CateName,ParentID,Orders,CreatedBy,CreatedOn,ModifyBy,ModifyOn,Remark,Del FROM [{0}] WHERE 1=1 ", TableName);
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
            List<TiKu.Model.tb_CourseCategory> list = new List<TiKu.Model.tb_CourseCategory>();
            string strCmdText = stbCmdText + ";" + stbCmdCount;
            using (IDataReader dataReader = TiKu.DataDriver.AdoHelper.ExcuteDataReader(strCmdText, parameters))
            {
                while (dataReader.Read())
                {
                    TiKu.Model.tb_CourseCategory model = new TiKu.Model.tb_CourseCategory();
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
            stbCmdText.AppendFormat("SELECT Row_Number() over(order by ID desc) as Row,ID,CateName,ParentID,Orders,CreatedBy,CreatedOn,ModifyBy,ModifyOn,Remark,Del FROM [{0}] WHERE 1=1 ", TableName);
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

        /// <summary>
        /// 绑定列表
        /// </summary>
        /// <param name="drp"></param>
        public void BindCourseCategory(DropDownList drp)
        {
            List<Model.tb_CourseCategory> list = null;
            list = GetCacheList();//获取数据列表
            string strPad = string.Empty;
            AddItem(drp,
                    list,
                    0,
                    strPad);
            drp.DataBind();
            drp.Items.Insert(0, new ListItem("--请选择所属分类--", string.Empty));
        }



        /// <summary>
        /// 获取缓存列表
        /// </summary>
        public List<Model.tb_CourseCategory> GetCacheList()
        {
            List<Model.tb_CourseCategory> list = null;
            if (TiKu.Common.CacheHelper.IsExistsCahce(TiKu.Common.Constants.CACHE_KEY._CACHE_COURSE_CATEGORY_KEY))
            {
                list = TiKu.Common.CacheHelper.GetCacheValue<List<Model.tb_CourseCategory>>(TiKu.Common.Constants.CACHE_KEY._CACHE_COURSE_CATEGORY_KEY);
            }
            else
            {
                list = GetList(0,
                             " And Del=0",
                             " Order By [Orders] Asc",
                             null);
                //缓存对象
                TiKu.Common.CacheHelper.SaveCache(TiKu.Common.Constants.CACHE_KEY._CACHE_COURSE_CATEGORY_KEY, list);
            }
            return list;
        }

        /// <summary>
        /// 私有方法：递归添加课程分类
        /// </summary>
        /// <param name="drp"></param>
        /// <param name="list"></param>
        /// <param name="parentID"></param>
        private void AddItem(DropDownList drp,
                             List<Model.tb_CourseCategory> list,
                             int parent,
                             string strPad)
        {
            List<Model.tb_CourseCategory> listTop = list.FindAll(m => { return (m.ParentID == parent); });
            for (int i = 0; i < listTop.Count; i++)
            {
                ListItem item = new ListItem(System.Web.HttpUtility.HtmlDecode(strPad + "┠&nbsp;") + listTop[i].CateName, listTop[i].ID.ToString());
                item.Attributes["deep"] = listTop[i].Deep.ToString();
                drp.Items.Add(item);
                //递归
                AddItem(drp,
                        list,
                        listTop[i].ID,
                        strPad + "&nbsp;&nbsp;");
            }


        }

    }
}