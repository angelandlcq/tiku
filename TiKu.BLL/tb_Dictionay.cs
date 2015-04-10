#region using directiry
using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System.Collections;
using TiKu.DataDriver.Entity;
#endregion
/*=================================================================================================
 * 
 * className:tb_Dictionay(BLL)
 * author:1058736170@qq.com
 * date:2015-03-24 16:08
 * modifyBy:1058736170@qq.com
 * modifyOn:2015-03-24 16:08
 * mark:本程序由代码生成器生成,了解更多,请登录http://my.oschina.net/lichaoqiang
 * 
 * ================================================================================================*/
namespace TiKu.BLL
{
    //tb_Dictionay
    public partial class tb_Dictionay
    {
        #region 成员
        /// <summary>
        /// 表名
        /// </summary>
        private readonly string TableName = "tb_Dictionay";
        #endregion

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(TiKu.Model.tb_Dictionay model)
        {
            return EntityQuery<TiKu.Model.tb_Dictionay>.Instance.Add(model);
        }

        /// <summary>
        ///修改
        /// </summary>
        public bool Update(TiKu.Model.tb_Dictionay model)
        {
            return EntityQuery<TiKu.Model.tb_Dictionay>.Instance.Update(model);
        }

        /// <summary>
        ///删除
        /// </summary>
        public int Delete(TiKu.Model.tb_Dictionay model)
        {
            return EntityQuery<TiKu.Model.tb_Dictionay>.Instance.Delete(model);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ID">编号</param>
        /// <returns></returns>
        public bool Delete(int ID)
        {
            SqlParameter[] paramters = { 
                                       new SqlParameter("@ID",SqlDbType.Int)
                                       };
            paramters[0].Value = ID;
            return TiKu.DataDriver.AdoHelper.Delete(TableName, " And ID=@ID", paramters) > 0;
        }

        /// <summary>
        /// 获取单个实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public TiKu.Model.tb_Dictionay GetModel(int ID)
        {
            TiKu.Model.tb_Dictionay model = new TiKu.Model.tb_Dictionay();
            model.ID = ID;
            EntityQuery<TiKu.Model.tb_Dictionay>.Instance.Fill(model);
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
        public List<TiKu.Model.tb_Dictionay> GetList(int top,
            string where,
            string orders,
            IEnumerable parameters)
        {
            List<TiKu.Model.tb_Dictionay> list = TiKu.DataDriver.Entity.EntityQuery<TiKu.Model.tb_Dictionay>.Instance.GetList(top,
                                                                               "ID,Names,Data,Code,State,Description",
                                                                               "tb_Dictionay",
                                                                               where,
                                                                               orders,
                                                                               parameters);
            return list;
        }

        /// <summary>
        /// 根据调用别名，获取字典信息
        /// </summary>
        /// <param name="Code">调用名称</param>
        /// <returns></returns>
        public Model.tb_Dictionay GetDataByCode(string Code, bool isCache)
        {
            if (isCache)
            {
                //从缓存中提取数据
                if (TiKu.Common.CacheHelper.IsExistsCahce(Code))
                {
                    return TiKu.Common.CacheHelper.GetCacheValue<Model.tb_Dictionay>(Code);
                }
            }
            SqlParameter[] parameters = { 
                                        new SqlParameter("@Code",SqlDbType.VarChar,30)
                                        };
            parameters[0].Value = Code;
            List<TiKu.Model.tb_Dictionay> list = TiKu.DataDriver.Entity.EntityQuery<TiKu.Model.tb_Dictionay>.Instance.GetList(1,
                                                                            "ID,Names,Data",
                                                                            "tb_Dictionay",
                                                                            " And State=1 And Code=@Code",
                                                                            null,
                                                                            parameters);
            if (list.Count == 0) { return null; }
            //是否缓存对象
            if (isCache)
            {
                TiKu.Common.CacheHelper.SaveCache(Code, list[0]);
            }
            return list[0];
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
        /// 调用名是否存在
        /// </summary>
        /// <param name="Code">调用名</param>
        /// <returns></returns>
        public bool IsExistsCode(string Code, int ID)
        {
            SqlParameter[] parameter = { 
                                      new SqlParameter("@Code",SqlDbType.VarChar,30),
                                      new SqlParameter("@ID",SqlDbType.Int)
                                       };
            parameter[0].Value = Code;
            parameter[1].Value = ID;
            int iCount = Count(" And Code=@Code And ID<>@ID", parameter);
            return (iCount > 0);
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
        public List<TiKu.Model.tb_Dictionay> GetListPager(int startIndex,
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
            stbCmdText.AppendFormat("SELECT Row_Number() over(order by ID desc) as Row,ID,Names,Data,Code,State,Description FROM [{0}] WHERE 1=1 ", TableName);
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
            List<TiKu.Model.tb_Dictionay> list = new List<TiKu.Model.tb_Dictionay>();
            string strCmdText = stbCmdText + ";" + stbCmdCount;
            using (IDataReader dataReader = TiKu.DataDriver.AdoHelper.ExcuteDataReader(strCmdText, parameters))
            {
                while (dataReader.Read())
                {
                    TiKu.Model.tb_Dictionay model = new TiKu.Model.tb_Dictionay();
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
            stbCmdText.AppendFormat("SELECT Row_Number() over(order by ID desc) as Row,ID,Names,Data,Code,State,Description FROM [{0}] WHERE 1=1 ", TableName);
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