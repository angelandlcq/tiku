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
 * className:
 * author:beisha
 * date:
 * modifyBy:
 * modifyOn:
 * mark:
 * 
 * ================================================================================================*/
namespace TiKu.BLL
{
    //管理员日志
    public partial class tb_AdminLog
    {

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(TiKu.Model.tb_AdminLog model)
        {
            return EntityQuery<TiKu.Model.tb_AdminLog>.Instance.Add(model);
        }

        /// <summary>
        ///修改
        /// </summary>
        public bool Update(TiKu.Model.tb_AdminLog model)
        {
            return EntityQuery<TiKu.Model.tb_AdminLog>.Instance.Update(model);
        }

        /// <summary>
        ///删除
        /// </summary>
        public int Delete(TiKu.Model.tb_AdminLog model)
        {
            return EntityQuery<TiKu.Model.tb_AdminLog>.Instance.Delete(model);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public int Delete(int ID)
        {
            string strCmdText = "DELETE FROM [tb_AdminLog] WHERE ID=@ID";
            Hashtable htParameter = new Hashtable();
            htParameter.Add("@ID", ID);
            int iRowEffect = TiKu.DataDriver.AdoHelper.ExucteNonQuery(strCmdText, htParameter);
            return iRowEffect;
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="strIDs">多个用,分割</param>
        /// <returns></returns>
        public int Delete(string strIDs)
        {
            strIDs = strIDs.Trim(',');//去除首尾,号
            string strCmdText = "DELETE FROM [tb_AdminLog] WHERE ID IN(" + strIDs + ");";
            int iRowEffect = TiKu.DataDriver.AdoHelper.ExucteNonQuery(strCmdText, null);
            return iRowEffect;
        }

        /// <summary>
        /// 获取单个实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public TiKu.Model.tb_AdminLog GetModel(int ID)
        {
            TiKu.Model.tb_AdminLog model = new TiKu.Model.tb_AdminLog();
            model.ID = ID;
            EntityQuery<TiKu.Model.tb_AdminLog>.Instance.Fill(model);
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
        public List<TiKu.Model.tb_AdminLog> GetList(int top,
            string where,
            string orders,
            IEnumerable parameters)
        {
            List<TiKu.Model.tb_AdminLog> list = TiKu.DataDriver.Entity.EntityQuery<TiKu.Model.tb_AdminLog>.Instance.GetList(top,
                                                                               "ID,ActionType,AdminID,Event,ActionLevel,CreatedOn,IP,Msg",
                                                                               "tb_AdminLog",
                                                                               where,
                                                                               orders,
                                                                               parameters);
            return list;
        }

        public DataSet GetListData(int top,
                               string where,
                               string orders,
                               IEnumerable parameters)
        {
            DataSet ds = TiKu.DataDriver.Entity.EntityQuery<Model.tb_AdminLog>.Instance.GetDataSet(top,
                                                                                         "*",
                                                                                         "tb_AdminLog",
                                                                                         null,
                                                                                         null,
                                                                                         null);
            return ds;
        }

        /// <summary>
        /// 获取符合条件的记录数
        /// </summary>
        /// <param name="where"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public int Count(string where, IEnumerable parameters)
        {
            return TiKu.DataDriver.AdoHelper.Count(where, "tb_AdminLog", parameters);
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
        public List<Model.tb_AdminLog> GetListPager(int startIndex,
                                                    int endIndex,
                                                    string where,
                                                    string orders,
                                                    IEnumerable parameters,
                                                    out int iRowCount)
        {
            iRowCount = 0;
            StringBuilder stbCmdText = new StringBuilder();
            StringBuilder stbCmdCount = new StringBuilder();
            stbCmdCount.Append("SELECT COUNT(1) AS Total FROM [tb_AdminLog] WHERE 1=1 ");
            stbCmdText.Append("SELECT * FROM (");
            stbCmdText.Append("SELECT Row_Number() over(order by ID desc) as Row,ID,ActionType,AdminID,Event,ActionLevel,CreatedOn,IP,Msg FROM [tb_AdminLog] WHERE 1=1 ");
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
            List<Model.tb_AdminLog> list = new List<Model.tb_AdminLog>();
            string strCmdText = stbCmdText + ";" + stbCmdCount;
            using (IDataReader dataReader = TiKu.DataDriver.AdoHelper.ExcuteDataReader(strCmdText, parameters))
            {
                while (dataReader.Read())
                {
                    Model.tb_AdminLog model = new Model.tb_AdminLog();
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


    }
}