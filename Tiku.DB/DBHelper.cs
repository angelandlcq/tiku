using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
/***********************************************************************
 * 
 * 
 * 
 * 说 明：数据库操作类
 * 
 * 作 者：李朝强(http://my.oschina.net/lichaoqiang)
 * 
 * 
 * *******************************************************************/
namespace Tiku.DB
{
    public class DBHelper
    {

        #region　member
        /// <summary>
        /// 配置文件Key
        /// </summary>
        public const string DBCONNECTION_APPSETTING_KEY = "TiKuDBConnection";

        /// <summary>
        /// 获取链接超时时间
        /// </summary>
        public static int Timeout
        {
            get
            {
                string strTimeOut = System.Configuration.ConfigurationManager.AppSettings["DbTimeOut"];
                if (!string.IsNullOrEmpty(strTimeOut))
                {
                    return Convert.ToInt32(strTimeOut);
                }
                return 3000;
            }
        }
        /// <summary>
        /// 获取数据连接字符串
        /// </summary>
        public static string DbConnectionString
        {
            get
            {
                //加密处理
                return System.Configuration.ConfigurationManager.ConnectionStrings[DBCONNECTION_APPSETTING_KEY].ConnectionString;
            }
        }
        #endregion

        #region 提供Connection、Command对象的操作方法
        /// <summary>
        /// 创建DB链接
        /// </summary>
        /// <param name="connectionName">配置文件链接名称</param>
        /// <returns></returns>
        public static SqlConnection CreateDBConnection(string connectionName = "TiKuDBConnection")
        {
            //数据库连接字符串
            string strConnectString = System.Configuration.ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
            SqlConnection conn = new SqlConnection(strConnectString);
            return conn;
        }
        /// <summary>
        /// 创建并打开数据库链接
        /// </summary>
        /// <param name="connectionName"></param>
        /// <returns></returns>
        public static SqlConnection CreateDBConnectionAndOpen(string connectionName = "TiKuDBConnection")
        {
            SqlConnection connection = CreateDBConnection(connectionName);
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            return connection;
        }

        /// <summary>
        /// 创建Command对象
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="cmdText"></param>
        /// <returns></returns>
        public static IDbCommand CreateDBCommand(SqlConnection connection,
                                                 string cmdText,
                                                 SqlParameter[] parameters)
        {
            IDbCommand command = new SqlCommand(cmdText, connection);
            for (int i = 0; parameters != null && i < parameters.Length; i++)
            {
                command.Parameters.Add(parameters[i]);
            }
            command.CommandTimeout = Timeout;
            return command;
        }

        /// <summary>
        /// 创建Command对象
        /// </summary>
        /// <param name="connection">数据库连接对象</param>
        /// <param name="cmdText">要执行的SQL</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        public static IDbCommand CreateDBCommand(IDbConnection connection,
                                                 string cmdText,
                                                 IEnumerable parameters)
        {
            IDbCommand command = new SqlCommand(cmdText);
            command.Connection = connection;
            if (null != parameters)
            {
                if (parameters is Hashtable)
                {
                    foreach (DictionaryEntry item in parameters)
                    {
                        SqlParameter parameter = new SqlParameter(item.Key.ToString(), item.Value);
                        command.Parameters.Add(parameter);
                    }
                }
                else if (parameters is Dictionary<string, object>)
                {
                    foreach (KeyValuePair<string, object> item in parameters)
                    {
                        SqlParameter parameter = new SqlParameter(item.Key, item.Value);
                        command.Parameters.Add(parameter);
                    }
                }
                else if (parameters is SqlParameter[])
                {
                    foreach (SqlParameter item in parameters)
                    {
                        command.Parameters.Add(item);
                    }
                }
            }
            command.CommandTimeout = Timeout;
            return command;
        }

        /// <summary>
        /// 关闭数据库连接
        /// </summary>
        /// <param name="connection"></param>
        public static void CloseDataBase(IDbConnection connection)
        {
            if (null == connection) { return; }
            connection.Close();
            connection.Dispose();
        }
        /// <summary>
        /// 关闭读取器
        /// </summary>
        /// <param name="dataReader"></param>
        public static void CloseDataReader(IDataReader dataReader)
        {
            if (null == dataReader) { return; }
            dataReader.Close();
            dataReader.Dispose();
        }
        #endregion

        #region 执行更新、添加、删除操作
        /// <summary>
        ///事务：执行SQL
        /// </summary>
        /// <param name="cmdText">SQL</param>
        /// <param name="parameters">参数</param>
        /// <param name="tran">事务对象</param>
        public static int ExcuteNonQueryTran(string cmdText,
                                             SqlConnection connection,
                                             SqlTransaction tran,
                                             IEnumerable parameters)
        {
            //创建Command对象
            IDbCommand command = DBHelper.CreateDBCommand(connection,
                                                          cmdText,
                                                          parameters);
            command.Transaction = tran;
            //执行Command对象
            int iResult = command.ExecuteNonQuery();
            command.Dispose();
            return iResult;
        }

        /// <summary>
        /// 执行事务
        /// </summary>
        /// <param name="command">Command对象</param>
        /// <param name="tran">事务</param>
        /// <returns></returns>
        public static int ExcuteNonQueryTran(IDbCommand command,
                                             IDbTransaction tran)
        {
            int iResult = 0;
            command.Transaction = tran;
            iResult = command.ExecuteNonQuery();
            return iResult;
        }

        /// <summary>
        /// 事务：执行SQL，返回受影响的记录数
        /// </summary>
        /// <param name="cmdText">SQL</param>
        /// <param name="tran">事务对象</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        public static int ExcuteNonQueryTran(string cmdText,
                                             IDbTransaction tran,
                                             IEnumerable parameters)
        {
            IDbCommand command = DBHelper.CreateDBCommand(tran.Connection,
                                                          cmdText,
                                                          parameters);
            command.Transaction = tran;
            int iResult = command.ExecuteNonQuery();
            return iResult;
        }

        /// <summary>
        /// 事务：执行SQL，返回首行首列
        /// </summary>
        /// <param name="cmdTex">SQL</param>
        /// <param name="tran">事务</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        public static object ExcuteScalarTran(string cmdText,
                                             IDbTransaction tran,
                                             IEnumerable parameters)
        {
            IDbCommand command = DBHelper.CreateDBCommand(tran.Connection,
                                                          cmdText,
                                                          parameters);
            command.Transaction = tran;
            object obj = command.ExecuteScalar();
            return obj;
        }

        /// <summary>
        /// 执行SQL语句，返回受影响的记录数
        /// </summary>
        /// <param name="cmdText">要执行的SQL</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        public static int ExcuteNonQuery(string cmdText,
                                         IEnumerable parameters,
                                         string connectionName = null)
        {
            int iResult = 0;
            connectionName = connectionName ?? DBCONNECTION_APPSETTING_KEY;
            //创建链接
            SqlConnection connection = CreateDBConnection(connectionName);
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                IDbCommand command = CreateDBCommand(connection, cmdText, parameters);
                iResult = command.ExecuteNonQuery();
                command.Dispose();
            }
            catch (SqlException ex) { throw ex; }
            catch (Exception ex) { throw ex; }
            finally
            {
                CloseDataBase(connection);//关闭连接
            }
            return iResult;
        }
        #endregion

        #region 查询
        /// <summary>
        /// 指针：读取数据
        /// </summary>
        /// <param name="cmdText">SQL脚本</param>
        /// <param name="parameters">参数，支持：hashtable dictionary<string,object> sqlparameter[]</param>
        /// <param name="connectionName"></param>
        /// <returns></returns>
        public static IDataReader ExcuteDataReader(string cmdText,
                                                   IEnumerable parameters,
                                                   string connectionName = null)
        {
            connectionName = connectionName ?? DBCONNECTION_APPSETTING_KEY;
            //创建Connection对象
            SqlConnection connect = CreateDBConnection(connectionName);
            IDataReader dataReader = null;
            try
            {
                //创建Command对象
                IDbCommand command = CreateDBCommand(connect, cmdText, parameters);
                command.CommandType = CommandType.Text;
                if (connect.State != ConnectionState.Open)
                {
                    connect.Open();
                }
                //执行SQL
                dataReader = command.ExecuteReader();
            }
            catch { throw; }
            finally { CloseDataReader(dataReader); }
            return dataReader;
        }


        /// <summary>
        /// 获取首行首列
        /// </summary>
        /// <param name="cmdText">要执行的SQL</param>
        /// <param name="parameters">参数</param>
        /// <param name="connectionName">数据库连接key</param>
        /// <returns></returns>
        public static object GetSingleValue(string cmdText,
                                            SqlParameter[] parameters,
                                            string connectionName = null)
        {
            object obj = null;
            connectionName = connectionName ?? DBCONNECTION_APPSETTING_KEY;
            SqlConnection connection = CreateDBConnection(connectionName);
            try
            {
                //打开数据库链接
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                IDbCommand command = CreateDBCommand(connection, cmdText, parameters);
                obj = command.ExecuteScalar();
                command.Parameters.Clear();
                command.Dispose();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseDataBase(connection);//关闭数据库连接
            }
            return obj;
        }

        /// <summary>
        ///  获取首行首列
        /// </summary>
        /// <param name="cmdText">要执行的SQL</param>
        /// <param name="parameters">参数</param>
        /// <param name="connnectionName">连接名称</param>
        /// <returns></returns>
        public static object GetSingleValue(string cmdText,
                                            IEnumerable parameters,
                                            string connnectionName = null)
        {
            connnectionName = connnectionName ?? DBCONNECTION_APPSETTING_KEY;
            SqlParameter[] arrParameters = ToSqlParametersCollection(parameters);
            return GetSingleValue(cmdText, arrParameters, connnectionName);
        }

        /// <summary>
        /// 事务：获取首行首列
        /// </summary>
        /// <param name="cmdText">要执行SQL</param>
        /// <param name="parameters">参数</param>
        /// <param name="connection">连接对象</param>
        /// <param name="tran">事务</param>
        /// <returns></returns>
        public static object ExcuteScalar(string cmdText,
                                          SqlParameter[] parameters,
                                          SqlConnection connection,
                                          SqlTransaction tran)
        {
            object obj = null;
            //打开数据库链接
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            IDbCommand command = CreateDBCommand(connection,
                                                 cmdText,
                                                 parameters);
            command.Transaction = tran;
            obj = command.ExecuteScalar();
            command.Dispose();
            return obj;
        }



        /// <summary>
        /// 返回首航首列
        /// </summary>
        /// <param name="cmdText">SQL</param>
        /// <param name="parameter">参数</param>
        /// <returns></returns>
        public static object ExcuteScalar(string cmdText,
                                          IEnumerable parameter)
        {
            object obj = null;
            SqlConnection connection = null;
            try
            {
                connection = CreateDBConnectionAndOpen(DBCONNECTION_APPSETTING_KEY);
                IDbCommand command = CreateDBCommand(connection,
                                                   cmdText,
                                                   parameter);
                obj = command.ExecuteScalar();
                command.Parameters.Clear();
                command.Dispose();
            }
            catch (SqlException ex) { throw ex; }
            catch (Exception ex) { throw ex; }
            finally
            {
                CloseDataBase(connection);//关闭数据库连接
            }
            return obj;
        }

        /// <summary>
        /// 事务：获取首行首列
        /// </summary>
        /// <param name="cmdText">要执行的SQL</param>
        /// <param name="parameters">参数</param>
        /// <param name="connection">连接对象</param>
        /// <param name="tran">事务</param>
        /// <returns></returns>
        public static object ExcuteScalar(string cmdText,
                                          IEnumerable parameters,
                                          SqlConnection connection,
                                          SqlTransaction tran)
        {
            SqlParameter[] arrSqlparameters = ToSqlParametersCollection(parameters);
            return ExcuteScalar(cmdText,
                           arrSqlparameters,
                           connection,
                           tran);
        }

        /// <summary>
        /// 事务：获取记录数
        /// </summary>
        /// <param name="cmdText">执行的SQL</param>
        /// <param name="parameters">参数</param>
        /// <param name="connection">连接对象</param>
        /// <param name="tran">事务</param>
        /// <returns></returns>
        public static int Count(string where,
                                string tbName,
                                IEnumerable parameters,
                                IDbConnection connection,
                                IDbTransaction tran)
        {
            string strCmdText = "SELECT COUNT(1) FROM " + tbName + " WHERE " + where;
            IDbCommand command = CreateDBCommand(connection,
                                                 strCmdText,
                                                 parameters);
            command.Transaction = tran;
            object obj = command.ExecuteScalar();
            return Convert.ToInt32(obj);
        }

        /// <summary>
        /// 获取记录数
        /// </summary>
        /// <param name="where">条件不带Where</param>
        /// <param name="tbName">表名</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        public static int Count(string where,
                                string tbName,
                                IEnumerable parameters,
                                string connectionKey = null)
        {
            connectionKey = connectionKey ?? DBCONNECTION_APPSETTING_KEY;
            string strCmdText = "SELECT COUNT(1) FROM " + tbName + " WHERE 1=1 ";
            if (!string.IsNullOrEmpty(where))
            {
                strCmdText += where;
            }
            object obj = null;
            SqlConnection connection = null;
            try
            {
                connection = CreateDBConnectionAndOpen(connectionKey);

                IDbCommand command = CreateDBCommand(connection,
                                                     strCmdText,
                                                     parameters);
                obj = command.ExecuteScalar();
                command.Parameters.Clear();
                command.Dispose();

            }
            catch (SqlException ex)
            {
                Debug.Assert(false, ex.Message);
                throw ex;
            }
            catch (Exception ex)
            {
                Debug.Assert(false, ex.Message);
                throw ex;
            }
            finally
            {
                CloseDataBase(connection);
            }
            return Convert.ToInt32(obj);
        }

        /// <summary>
        /// 执行查询，返回DataSet
        /// </summary>
        /// <param name="cmdText">脚本</param>
        /// <param name="parameters">参数,hashtable或Dictionary<string,object></param>
        /// <param name="connectionName">数据库连接名称</param>
        /// <returns></returns>
        public static DataSet Query(string cmdText,
                                    IEnumerable parameters,
                                    string connectionName = "TiKuDBConnection")
        {
            SqlParameter[] arrSqlParameters = ToSqlParametersCollection(parameters);
            DataSet ds = new DataSet();
            SqlConnection connection = CreateDBConnection(connectionName);
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlCommand command = new SqlCommand(cmdText, connection);
                if (parameters != null && arrSqlParameters.Length > 0)
                {
                    command.Parameters.AddRange(arrSqlParameters);
                }
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(ds, "ds");
                command.Dispose();
                adapter.Dispose();
            }
            catch (SqlException ex) { throw ex; }
            catch (Exception ex) { throw ex; }
            finally
            {
                CloseDataBase(connection);
            }
            return ds;
        }
        /// <summary>
        /// 执行SQL，返回数据集，输出参数
        /// </summary>
        /// <param name="strCmdText"></param>
        /// <param name="parameter"></param>
        /// <param name="output"></param>
        /// <returns></returns>
        public static DataSet Query(string cmdText,
                                    IEnumerable parameters,
                                    ref Dictionary<string, object> output)
        {
            SqlParameter[] arrSqlParameters = ToSqlParametersCollection(parameters);
            DataSet ds = new DataSet();
            SqlConnection connection = CreateDBConnection(DBCONNECTION_APPSETTING_KEY);

            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlCommand command = new SqlCommand(cmdText, connection);
                if (parameters != null && arrSqlParameters.Length > 0)
                {
                    command.Parameters.AddRange(arrSqlParameters);
                }
                //输出参数
                Dictionary<string, object>.Enumerator Enumerator = output.GetEnumerator();
                while (Enumerator.MoveNext())
                {
                    SqlParameter parameter = new SqlParameter(Enumerator.Current.Key, Enumerator.Current.Value);
                    parameter.Direction = ParameterDirection.Output;
                    command.Parameters.Add(parameter);
                }

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(ds, "ds");
                command.Dispose();
                adapter.Dispose();
                Dictionary<string, object> dictOut = new Dictionary<string, object>();
                foreach (string key in output.Keys)
                {
                    dictOut[key] = command.Parameters[key].Value;
                }
                output = dictOut;
            }
            catch (SqlException ex) { throw ex; }
            catch (Exception ex) { throw ex; }
            finally
            {
                CloseDataBase(connection);
            }

            return ds;
        }
        #endregion

        #region 存储过程
        /// <summary>
        /// 执行过程，返回受影响的记录数
        /// </summary>
        /// <param name="procedureName">过程名</param>
        /// <param name="parameters">参数</param>
        /// <param name="connectionName">链接名</param>
        /// <returns></returns>
        public static int ExcuteNonQueryPro(string procedureName,
                                            IEnumerable parameters,
                                            string connectionName)
        {
            int iResult = 0;
            SqlConnection connection = null;
            IDbCommand command = null;
            try
            {
                //创建并打开数据库链接
                connection = CreateDBConnectionAndOpen(connectionName);
                command = CreateDBCommand(connection,
                                          procedureName,
                                          parameters);
                command.CommandType = CommandType.StoredProcedure;
                //执行
                iResult = command.ExecuteNonQuery();
            }
            catch (SqlException ex) { throw ex; }
            catch (Exception ex) { throw ex; }
            finally
            {
                command.Dispose();
                connection.Close();
                connection.Dispose();
            }
            return iResult;
        }
        /// <summary>
        /// 过程：事务执行增删改
        /// </summary>
        /// <param name="procedureName">过程名</param>
        /// <param name="parameters">参数</param>
        /// <param name="connection">链接对象</param>
        /// <param name="tran">事务</param>
        /// <returns></returns>
        public static int ExcuteNonQueryProTran(string procedureName,
                                                IEnumerable parameters,
                                                SqlConnection connection,
                                                SqlTransaction tran)
        {
            int iResult = 0;
            IDbCommand command = null;
            try
            {
                command = CreateDBCommand(connection, procedureName, parameters);
                command.CommandType = CommandType.StoredProcedure;
                iResult = command.ExecuteNonQuery();
            }
            catch (SqlException ex) { throw ex; }
            catch (Exception ex) { throw ex; }
            return iResult;
        }

        /// <summary>
        /// 过程：执行过程，返回DataSet对象
        /// </summary>
        /// <param name="procedureName">过程名</param>
        /// <param name="parameters">参数</param>
        /// <param name="connectionName">连接名</param>
        /// <returns></returns>
        public static DataSet ExcuteDataSetPro(string procedureName,
                                               IEnumerable parameters,
                                               string connectionName,
                                               string tablename = "0")
        {
            DataSet ds = null;
            SqlConnection connection = null;
            try
            {
                //创建数据库链接
                connection = CreateDBConnectionAndOpen(connectionName);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(procedureName, connection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                //添加参数
                dataAdapter.SelectCommand.Parameters.AddRange(ToSqlParametersCollection(parameters));
                ds = new DataSet();
                dataAdapter.Fill(ds, tablename);
                dataAdapter.Dispose();
            }
            catch (SqlException ex) { throw ex; }
            catch (Exception ex) { throw ex; }
            finally
            {
                CloseDataBase(connection);
            }
            return ds;
        }

        /// <summary>
        /// 过程：读取器
        /// </summary>
        /// <param name="procedureName">过程名</param>
        /// <param name="parameters">参数</param>
        /// <param name="connectionName">链接名</param>
        /// <returns></returns>
        public static IDataReader ExcuteDataReaderPro(string procedureName,
                                                      IEnumerable parameters,
                                                      SqlConnection connection)
        {
            //创建Command对象
            IDbCommand command = CreateDBCommand(connection,
                                                 procedureName,
                                                 parameters);
            command.CommandType = CommandType.StoredProcedure;
            IDataReader dataReader = command.ExecuteReader();
            return dataReader;
        }


        /// <summary>
        /// 导入数据
        /// </summary>
        /// <param name="connectionName">链接名</param>
        /// <param name="data">数据源</param>
        /// <param name="dtTarget">目标</param>
        /// <param name="DestinationTableName">目标（表名）</param>
        /// <returns></returns>
        public static void Import(string connectionName,
                                 DataTable data,
                                 DataTable dtTarget,
                                 string DestinationTableName)
        {
            SqlConnection connection = CreateDBConnectionAndOpen(connectionName);
            //开始事务
            SqlTransaction tran = connection.BeginTransaction();
            SqlBulkCopy blk = new SqlBulkCopy(connection, SqlBulkCopyOptions.Default, tran);
            try
            {
                blk.BatchSize = 1;
                blk.BulkCopyTimeout = Timeout;
                blk.DestinationTableName = DestinationTableName;
                //按照顺序进行映射
                for (int i = 0; i < dtTarget.Columns.Count; i++)
                {
                    //映射
                    blk.ColumnMappings.Add(dtTarget.Columns[i].ColumnName, data.Columns[i].ColumnName);
                }
                blk.WriteToServer(data);
                tran.Commit();//提交事务
            }
            catch (SqlException ex) { tran.Rollback(); throw ex; }
            catch (Exception ex) { tran.Rollback(); throw ex; }
            finally
            {
                blk.Close();
                tran.Dispose();
                CloseDataBase(connection);
            }
        }


        /// <summary>
        /// 更新数据集
        /// </summary>
        /// <param name="strCmdText">查询语句</param>
        /// <param name="ds">数据集</param>
        /// <returns></returns>
        public static int UpdateDataSet(string strCmdText,
                                        DataSet ds,
                                        Action<DataSet> action)
        {
            SqlConnection connection = CreateDBConnection();
            int iResult = 0;
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlDataAdapter adapter = new SqlDataAdapter(strCmdText, connection);
                SqlCommandBuilder cmd = new SqlCommandBuilder(adapter);
                cmd.DataAdapter = adapter;
                adapter.Fill(ds);
                action(ds);//添加数据
                iResult = adapter.Update(ds);
                adapter.Dispose();
            }
            catch (SqlException ex) { throw ex; }
            catch (Exception ex) { throw ex; }
            finally
            {
                CloseDataBase(connection);
            }
            return iResult;
        }
        #endregion

        #region 私有成员
        /// <summary>
        /// 把Hashtable转换为SqlParameter[]
        /// </summary>
        /// <param name="hashParameters">参数：目前支持的类型有SqlParameter、Hashtable、Dictionary<string,object></param>
        /// <returns></returns>
        private static SqlParameter[] ToSqlParametersCollection(IEnumerable Parameters)
        {
            List<SqlParameter> listParameters = new List<SqlParameter>();
            if (Parameters is Hashtable)
            {
                foreach (DictionaryEntry item in Parameters)
                {
                    listParameters.Add(new SqlParameter(item.Key.ToString(), item.Value));
                }
                return listParameters.ToArray();
            }
            if (Parameters is Dictionary<string, object>)
            {
                foreach (KeyValuePair<string, object> item in Parameters)
                {
                    listParameters.Add(new SqlParameter(item.Key, item.Value));
                }
                return listParameters.ToArray();
            }
            return listParameters.ToArray();
        }
        #endregion
    }
}
