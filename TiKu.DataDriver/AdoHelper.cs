using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using Tiku.DB;
using System.Data.SqlClient;
/***********************************************************************
 * 
 * 
 * 
 * 说 明：ADO操作辅助类
 * 
 * 作 者：李朝强(http://my.oschina.net/lichaoqiang)
 * 
 * 
 * *******************************************************************/
namespace TiKu.DataDriver
{
    public class AdoHelper
    {

        /// <summary>
        /// 数据库回话
        /// </summary>
        private static DbSession __DbSessionShareObj = null;

        /// <summary>
        /// 打开数据库回话
        /// </summary>
        public static void OpenSession()
        {
            __DbSessionShareObj = __DbSessionShareObj ?? new DbSession();
            lock (__DbSessionShareObj)
            {
                __DbSessionShareObj.OpenSession();//打开数据库回话
            }
        }

        /// <summary>
        /// 提交回话
        /// </summary>
        public static void CommitSession()
        {
            lock (__DbSessionShareObj)
            {
                __DbSessionShareObj.CommitSession();
            }
        }


        /// <summary>
        /// 执行SQL，
        /// </summary>
        /// <param name="cmdText">SQL</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        public static IDataReader ExcuteDataReader(string cmdText,
                                                  IEnumerable parameters)
        {
            return Tiku.DB.DBHelper.ExcuteDataReader(cmdText, parameters);
        }

        /// <summary>
        /// 获取记录数
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="tableName">表名</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        public static int Count(string where, string tableName, IEnumerable parameters)
        {
            return Tiku.DB.DBHelper.Count(where, tableName, parameters);
        }

        /// <summary>
        /// 执行SQL，返回数据集
        /// </summary>
        /// <param name="strCmdText">SQL</param>
        /// <param name="parameters">参数（Hashtable、Dictionary、SqlParameter）</param>
        /// <returns></returns>
        public static DataSet Query(string strCmdText,
                                    IEnumerable parameters)
        {
            return Tiku.DB.DBHelper.Query(strCmdText, parameters);
        }

        /// <summary>
        /// 执行SQL，返回数据集
        /// </summary>
        /// <param name="strCmdText">SQL</param>
        /// <param name="parameters">参数</param>
        /// <param name="output">输出参数</param>
        /// <returns></returns>
        public static DataSet Query(string strCmdText,
                                    IEnumerable parameters,
                                    ref Dictionary<string, object> output)
        {
            return Tiku.DB.DBHelper.Query(strCmdText,
                                     parameters,
                                     ref output);
        }

        /// <summary>
        /// 执行SQL，返回受影响的记录数
        /// </summary>
        /// <param name="strCmdText">SQL</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        public static int ExucteNonQuery(string strCmdText, IEnumerable parameters)
        {
            return Tiku.DB.DBHelper.ExcuteNonQuery(strCmdText, parameters);
        }

        /// <summary>
        /// 根据条件，删除某张表中的信息
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="where">条件(必选)</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        public static int Delete(string tableName,
                                 string where,
                                 IEnumerable parameters)
        {
            string strCmdText = string.Format("DELETE FROM [{0}] WHERE 1=1 ", tableName);
            strCmdText += where;
            int iRowEffect = Tiku.DB.DBHelper.ExcuteNonQuery(strCmdText, parameters);
            return iRowEffect;
        }

        /// <summary>
        /// 更新数据集
        /// </summary>
        /// <param name="cmdText">脚本</param>
        /// <param name="ds">数据集</param>
        /// <returns></returns>
        public static int UpdateDataSet(string cmdText,
                                        DataSet ds,
                                        Action<DataSet> action)
        {
            return Tiku.DB.DBHelper.UpdateDataSet(cmdText,
                                                 ds,
                                                 action);
        }

        /// <summary>
        /// 查询：返回实体列表
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="cmdText">SQL语句</param>
        /// <param name="parameters">参数</param>
        /// <param name="fSet">实体初始化委托</param>
        /// <returns></returns>
        public static List<T> Query<T>(string cmdText,
                                       IEnumerable parameters,
                                       Func<IDataReader, T> fSet)
            where T : new()
        {
            IDataReader dataReader = null;
            List<T> list = new List<T>();

            dataReader = Tiku.DB.DBHelper.ExcuteDataReader(cmdText, parameters);
            while (dataReader.Read())
            {
                T model = fSet(dataReader);
                list.Add(model);
            }
            try { }
            finally
            {
                Tiku.DB.DBHelper.CloseDataReader(dataReader);//释放资源
            }
            return list;
        }

        /// <summary>
        /// 返回列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cmdText"></param>
        /// <param name="parameters"></param>
        /// <param name="fset"></param>
        /// <returns></returns>
        public static List<T> ToList<T>(string cmdText,
                                        IEnumerable parameters,
                                        Func<IDataReader, T> fSet)
        {
            IDataReader dataReader = null;
            List<T> list = new List<T>();

            dataReader = Tiku.DB.DBHelper.ExcuteDataReader(cmdText, parameters);
            while (dataReader.Read())
            {
                T model = fSet(dataReader);
                list.Add(model);
            }
            try { }
            finally
            {
                Tiku.DB.DBHelper.CloseDataReader(dataReader);//释放资源
            }
            return list;
        }

        /// <summary>
        /// 打开一个数据库事务
        /// </summary>
        /// <returns></returns>
        public static IDbTransaction BeginSingleTran()
        {
            SqlConnection connecion = DBHelper.CreateDBConnectionAndOpen();
            SqlTransaction tran = connecion.BeginTransaction();
            return tran;
        }

        /// <summary>
        /// 执行事务：
        /// </summary>
        /// <param name="strCmdTex">SQL</param>
        /// <param name="transaction">关联事务</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        public static int ExcueNonQueryTran(string strCmdTex,
                                           IDbTransaction transaction,
                                           IEnumerable parameters)
        {
            int iResult = Tiku.DB.DBHelper.ExcuteNonQueryTran(strCmdTex,
                                                 transaction,
                                                 parameters);
            return iResult;
        }

        /// <summary>
        /// 事务：执行SQL，返回首行首列
        /// </summary>
        /// <param name="strCmdTex">SQL</param>
        /// <param name="transaction">事务</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        public static object ExcuteScalar(string strCmdTex,
                                          IDbTransaction transaction,
                                          IEnumerable parameters)
        {
            object obj = Tiku.DB.DBHelper.ExcuteScalarTran(strCmdTex,
                                                          transaction,
                                                          parameters);
            return obj;
        }
    }
}
