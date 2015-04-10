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
 * className:推荐，每周精选等板块(BLL)
 * author:1058736170@qq.com
 * date:2015-03-05 15:23
 * modifyBy:1058736170@qq.com
 * modifyOn:2015-03-05 15:23
 * mark:本程序由代码生成器生成,了解更多,请登录http://my.oschina.net/lichaoqiang
 * 
 * ================================================================================================*/
namespace TiKu.BLL
{
    //推荐，每周精选等板块
    public partial class tb_level
    {
        #region 成员
        /// <summary>
        /// 表名
        /// </summary>
        public readonly string TableName = "tb_level";
        #endregion

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(TiKu.Model.tb_level model)
        {
            return EntityQuery<TiKu.Model.tb_level>.Instance.Add(model);
        }

        /// <summary>
        ///修改
        /// </summary>
        public bool Update(TiKu.Model.tb_level model)
        {
            return EntityQuery<TiKu.Model.tb_level>.Instance.Update(model);
        }

        /// <summary>
        ///删除
        /// </summary>
        public int Delete(TiKu.Model.tb_level model)
        {
            return EntityQuery<TiKu.Model.tb_level>.Instance.Delete(model);
        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public bool DelDel(int ID)
        {
            SqlParameter[] parameters = { 
                                        new SqlParameter("@ID",SqlDbType.Int)
                                        };
            parameters[0].Value = ID;
            string strCmdText = "";
            if (BLL.tb_WebSet.WebSiteInfo.IsEnableDelete > 0)
            {
                strCmdText = string.Format("UPDATE [0] SET Del={1} WHERE ID=@ID;", TableName, TiKu.Common.Constants.Common.DELETE);
            }
            else
            {
                strCmdText = string.Format("DELETE FROM [0] WHERE ID=@ID;", TableName);
            }
            //执行删除
            int iRowEffect = TiKu.DataDriver.AdoHelper.ExucteNonQuery(strCmdText, parameters);
            return (iRowEffect > 0);
        }

        /// <summary>
        /// 获取单个实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public TiKu.Model.tb_level GetModel(int ID)
        {
            TiKu.Model.tb_level model = new TiKu.Model.tb_level();
            model.ID = ID;
            EntityQuery<TiKu.Model.tb_level>.Instance.Fill(model);
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
        public List<TiKu.Model.tb_level> GetList(int top,
            string where,
            string orders,
            IEnumerable parameters)
        {
            List<TiKu.Model.tb_level> list = TiKu.DataDriver.Entity.EntityQuery<TiKu.Model.tb_level>.Instance.GetList(top,
                                                                               "ID,Names,TableName,Orders,IsRecommand,State,Del",
                                                                               "tb_level",
                                                                               where,
                                                                               orders,
                                                                               parameters);
            return list;
        }


        /// <summary>
        /// 【缓存】根据表名，获取级别列表
        /// </summary>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public List<TiKu.Model.tb_level> GetCacheLevels(string tbName)
        {
            List<TiKu.Model.tb_level> list = null;
            string strCacheKey = "_CACHE_LEVEL_" + tbName;
            //验证缓存是否存在，如果存在，从缓存中提取数据
            if (TiKu.Common.CacheHelper.IsExistsCahce(strCacheKey))
            {
                list = TiKu.Common.CacheHelper.GetCacheValue<List<Model.tb_level>>(strCacheKey);
            }
            else
            {
                SqlParameter[] parameters = { 
                                            new SqlParameter("@TableName",SqlDbType.VarChar,30)
                                            };
                parameters[0].Value = tbName;
                list = TiKu.DataDriver.Entity.EntityQuery<TiKu.Model.tb_level>.Instance.GetList(0,
                                                                               "ID,Names,Val,Orders",
                                                                               "tb_level",
                                                                               " And State=1 And Del=0 And TableName=@TableName",
                                                                               " ORDER BY [Orders] Asc",
                                                                               parameters);
                //缓存数据
                TiKu.Common.CacheHelper.SaveCache(strCacheKey, list);
            }
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
        public List<TiKu.Model.tb_level> GetListPager(int startIndex,
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
            stbCmdText.AppendFormat("SELECT Row_Number() over(order by ID desc) as Row,ID,Names,TableName,Orders,IsRecommand,State,Del FROM [{0}] WHERE 1=1 ", TableName);
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
            List<TiKu.Model.tb_level> list = new List<TiKu.Model.tb_level>();
            string strCmdText = stbCmdText + ";" + stbCmdCount;
            using (IDataReader dataReader = TiKu.DataDriver.AdoHelper.ExcuteDataReader(strCmdText, parameters))
            {
                while (dataReader.Read())
                {
                    TiKu.Model.tb_level model = new TiKu.Model.tb_level();
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
            stbCmdText.AppendFormat("SELECT Row_Number() over(order by ID desc) as Row,ID,Names,TableName,Val,Orders,IsRecommand,State,Del FROM [{0}] WHERE 1=1 ", TableName);
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
        /// 显示状态文本
        /// </summary>
        /// <param name="state">状态</param>
        /// <returns></returns>
        public string ShowStateLabelText(object state)
        {
            if (null == state || state == DBNull.Value) { return "--"; }
            int iState = Convert.ToInt32(state);
            if (iState == TiKu.Common.Constants.Common.ENABLE) { return "启用"; }
            if (iState == TiKu.Common.Constants.Common.DISABLE) { return "禁用"; }
            return "--";
        }

        /// <summary>
        /// 验证级别值是否存在
        /// </summary>
        /// <param name="Val">级别值（必须唯一）</param>
        /// <param name="ID">编号</param>
        /// <returns></returns>
        public bool IsExistVal(string Val, int ID)
        {
            SqlParameter[] parameters = { 
                                        new SqlParameter("@Val",SqlDbType.VarChar,30),
                                        new SqlParameter("@ID",SqlDbType.Int)
                                        };
            parameters[0].Value = Val;
            parameters[1].Value = ID;
            int iCount = Count(" And Val=@Val And ID<>@ID", parameters);
            return (iCount > 0);
        }

        /// <summary>
        /// 绑定级别
        /// </summary>
        /// <param name="drp">控件</param>
        /// <param name="tbName">表名</param>
        public void BindDropDownList(DropDownList drp, string tbName)
        {
            List<Model.tb_level> list = GetCacheLevels(tbName);
            drp.DataSource = list;
            drp.DataTextField = "Names";
            drp.DataValueField = "Val";
            drp.DataBind();
            drp.Items.Insert(0, new ListItem("--请选择级别--", string.Empty));
        }

    }
}