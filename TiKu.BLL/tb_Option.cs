﻿#region using directiry
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
 * className:问题选项表(BLL)
 * author:1058736170@qq.com
 * date:2015-04-02 15:16
 * modifyBy:1058736170@qq.com
 * modifyOn:2015-04-02 15:16
 * mark:本程序由代码生成器生成,了解更多,请登录http://my.oschina.net/lichaoqiang
 * 
 * ================================================================================================*/
namespace TiKu.BLL
{
    //问题选项表
    public partial class tb_Option
    {
        #region 成员
        /// <summary>
        /// 表名
        /// </summary>
        private readonly string TableName = "tb_Option";
        #endregion

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(TiKu.Model.tb_Option model)
        {
            return EntityQuery<TiKu.Model.tb_Option>.Instance.Add(model);
        }

        /// <summary>
        ///修改
        /// </summary>
        public bool Update(TiKu.Model.tb_Option model)
        {
            return EntityQuery<TiKu.Model.tb_Option>.Instance.Update(model);
        }

        /// <summary>
        ///删除
        /// </summary>
        public int Delete(TiKu.Model.tb_Option model)
        {
            return EntityQuery<TiKu.Model.tb_Option>.Instance.Delete(model);
        }

        /// <summary>
        /// 获取单个实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public TiKu.Model.tb_Option GetModel(int ID)
        {
            TiKu.Model.tb_Option model = new TiKu.Model.tb_Option();
            model.ID = ID;
            EntityQuery<TiKu.Model.tb_Option>.Instance.Fill(model);
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
        public List<TiKu.Model.tb_Option> GetList(int top,
            string where,
            string orders,
            IEnumerable parameters)
        {
            List<TiKu.Model.tb_Option> list = TiKu.DataDriver.Entity.EntityQuery<TiKu.Model.tb_Option>.Instance.GetList(top,
                                                                               "ID,QuestionID,OptionA,OptionB,OptionC,OptionD,OptionE,OptionF,OptionG",
                                                                               "tb_Option",
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
        public List<TiKu.Model.tb_Option> GetListPager(int startIndex,
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
            stbCmdText.AppendFormat("SELECT Row_Number() over(order by ID desc) as Row,ID,QuestionID,OptionA,OptionB,OptionC,OptionD,OptionE,OptionF,OptionG FROM [{0}] WHERE 1=1 ", TableName);
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
            List<TiKu.Model.tb_Option> list = new List<TiKu.Model.tb_Option>();
            string strCmdText = stbCmdText + ";" + stbCmdCount;
            using (IDataReader dataReader = TiKu.DataDriver.AdoHelper.ExcuteDataReader(strCmdText, parameters))
            {
                while (dataReader.Read())
                {
                    TiKu.Model.tb_Option model = new TiKu.Model.tb_Option();
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
            stbCmdText.AppendFormat("SELECT Row_Number() over(order by ID desc) as Row,ID,QuestionID,OptionA,OptionB,OptionC,OptionD,OptionE,OptionF,OptionG FROM [{0}] WHERE 1=1 ", TableName);
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