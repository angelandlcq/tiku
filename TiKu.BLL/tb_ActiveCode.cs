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
 * className:激活码生成表(BLL)
 * author:1058736170@qq.com
 * date:2015-03-05 15:23
 * modifyBy:1058736170@qq.com
 * modifyOn:2015-03-05 15:23
 * mark:本程序由代码生成器生成,了解更多,请登录http://my.oschina.net/lichaoqiang
 * 
 * ================================================================================================*/
namespace TiKu.BLL
{
    //激活码生成表
    public partial class tb_ActiveCode
    {
        #region 成员
        /// <summary>
        /// 表名
        /// </summary>
        private readonly string TableName = "tb_ActiveCode";
        #endregion

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(TiKu.Model.tb_ActiveCode model)
        {
            return EntityQuery<TiKu.Model.tb_ActiveCode>.Instance.Add(model);
        }

        /// <summary>
        ///修改
        /// </summary>
        public bool Update(TiKu.Model.tb_ActiveCode model)
        {
            return EntityQuery<TiKu.Model.tb_ActiveCode>.Instance.Update(model);
        }

        /// <summary>
        ///删除
        /// </summary>
        public int Delete(TiKu.Model.tb_ActiveCode model)
        {
            return EntityQuery<TiKu.Model.tb_ActiveCode>.Instance.Delete(model);
        }

        /// <summary>
        /// 获取单个实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public TiKu.Model.tb_ActiveCode GetModel(int ID)
        {
            TiKu.Model.tb_ActiveCode model = new TiKu.Model.tb_ActiveCode();
            model.ID = ID;
            EntityQuery<TiKu.Model.tb_ActiveCode>.Instance.Fill(model);
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
        public List<TiKu.Model.tb_ActiveCode> GetList(int top,
            string where,
            string orders,
            IEnumerable parameters)
        {
            List<TiKu.Model.tb_ActiveCode> list = TiKu.DataDriver.Entity.EntityQuery<TiKu.Model.tb_ActiveCode>.Instance.GetList(top,
                                                                               "ID,Code,TableName,State,UserID,CourseID,CreatedBy,CreatedOn",
                                                                               "tb_ActiveCode",
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
        public List<TiKu.Model.tb_ActiveCode> GetListPager(int startIndex,
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
            stbCmdText.AppendFormat("SELECT Row_Number() over(order by ID desc) as Row,ID,Code,TableName,State,UserID,CourseID,CreatedBy,CreatedOn FROM [{0}] WHERE 1=1 ", TableName);
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
            List<TiKu.Model.tb_ActiveCode> list = new List<TiKu.Model.tb_ActiveCode>();
            string strCmdText = stbCmdText + ";" + stbCmdCount;
            using (IDataReader dataReader = TiKu.DataDriver.AdoHelper.ExcuteDataReader(strCmdText, parameters))
            {
                while (dataReader.Read())
                {
                    TiKu.Model.tb_ActiveCode model = new TiKu.Model.tb_ActiveCode();
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
            stbCmdText.AppendFormat("SELECT Row_Number() over(order by ID desc) as Row,ID,Code,TableName,State,UserID,CourseID,CreatedBy,CreatedOn FROM [{0}] WHERE 1=1 ", TableName);
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
        /// 创建一个新的激活码:30位
        /// </summary>
        /// <returns></returns>
        public string CreateActiveCode()
        {
            string[] strArray = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            Random rand = new Random();
            byte[] byGuid = Guid.NewGuid().ToByteArray();
            long _time = DateTime.Now.ToFileTimeUtc();
            string strGuid = Convert.ToBase64String(byGuid);
            strGuid = strGuid.Replace("+", strArray[rand.Next(strArray.Length)]).Replace("=", strArray[rand.Next(strArray.Length)]).Replace("/", strArray[rand.Next(strArray.Length)]);
            strGuid += _time.ToString().Substring(_time.ToString().Length - 6);
            //随机打乱
            char[] _charArray = strGuid.ToCharArray();
            char _temp;
            int _t = 0;
            for (int i = 0; i < _charArray.Length; i++)
            {
                _t = rand.Next(_charArray.Length);
                _temp = _charArray[i];
                _charArray[i] = _charArray[_t];
                _charArray[_t] = _temp;
            }
            strGuid = string.Join(string.Empty, _charArray).ToUpper();
            //添加分隔符
            for (int j = 0; j < 2; j++)
            {
                strGuid = strGuid.Insert((j + 1) * 10 + j, "-");
            }
            return strGuid;
        }

    }


}