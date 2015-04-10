using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
/**************************************************************************
 * 
 * Author:
 * Date:
 * Description:提供实体查询的类
 * Mark:
 * 
 * **********************************************************************/
namespace TiKu.DataDriver.Entity
{
    #region 实体查询
    public class EntityQuery<T>
        where T : EntityBase, new()
    {
        /// <summary>
        /// 当前实例
        /// </summary>
        public static EntityQuery<T> Instance
        {
            get
            {
                return new EntityQuery<T>();
            }
        }

        /// <summary>
        /// 添加一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add(T model)
        {
            System.Data.SqlClient.SqlParameter[] parameters = new System.Data.SqlClient.SqlParameter[model.FieldValue.Keys.Count];
            string strCmdText = SQLBuilder.BuildInsertSQL<T>(model, ref parameters);
            if (!string.IsNullOrEmpty(model.Identity))
            {
                strCmdText += "SELECT @@IDENTITY;";
            }
            object obj = Tiku.DB.DBHelper.ExcuteScalar(strCmdText,
                                                       parameters);
            if (obj == null || obj == DBNull.Value) { return false; }
            if (!string.IsNullOrEmpty(model.Identity))
            {
                model.SetPropertyValue(model.Identity, Convert.ToInt32(obj));
            }
            return true;
        }
        /// <summary>
        /// 事务：添加一条记录
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public int Add(T model, IDbTransaction transaction)
        {
            System.Data.SqlClient.SqlParameter[] parameters = new System.Data.SqlClient.SqlParameter[model.FieldValue.Keys.Count];
            string strCmdText = SQLBuilder.BuildInsertSQL<T>(model, ref parameters);
            if (!string.IsNullOrEmpty(model.Identity))
            {
                strCmdText += "SELECT @@IDENTITY;";
            }
            object obj = Tiku.DB.DBHelper.ExcuteScalarTran(strCmdText, transaction, parameters);
            if (obj == null || obj == DBNull.Value) { return 0; }
            int identiy = Convert.ToInt32(obj);
            if (!string.IsNullOrEmpty(model.Identity))
            {
                model.SetPropertyValue(model.Identity, identiy);
            }
            return identiy;
        }

        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="models">实体列表</param>
        /// <returns></returns>
        public void Add(List<T> models)
        {
            SqlConnection connection = Tiku.DB.DBHelper.CreateDBConnectionAndOpen();
            IDbTransaction tran = null;
            try
            {
                tran = connection.BeginTransaction();
                for (int i = 0; i < models.Count; i++)
                {
                    Add(models[i], tran);
                }
                tran.Commit();
                tran.Dispose();
            }
            catch (Exception ex)
            {
                tran.Rollback();
                connection.Close();
                connection.Dispose();
                throw ex;
            }
            finally
            {
                tran.Dispose();
            }
        }

        /// <summary>
        /// 更新记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(T model)
        {
            System.Data.SqlClient.SqlParameter[] parameters = new System.Data.SqlClient.SqlParameter[model.FieldValue.Keys.Count];
            string strCmdText = SQLBuilder.BuildUpdateSQL<T>(model, ref parameters);
            int iResult = Tiku.DB.DBHelper.ExcuteNonQuery(strCmdText, parameters);
            return (iResult > 0);
        }

        /// <summary>
        /// 事务：更新
        /// </summary>
        /// <param name="model"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public int Update(T model, IDbTransaction transaction)
        {
            System.Data.SqlClient.SqlParameter[] parameters = new System.Data.SqlClient.SqlParameter[model.FieldValue.Keys.Count];
            string strCmdText = SQLBuilder.BuildUpdateSQL<T>(model, ref parameters);
            int iResult = Tiku.DB.DBHelper.ExcuteNonQueryTran(strCmdText,
                                                              transaction,
                                                              parameters);
            return iResult;
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Delete(T model)
        {
            string strCmdText = SQLBuilder.BuildDeleteSQL<T>(model);
            return Tiku.DB.DBHelper.ExcuteNonQuery(strCmdText, model.FieldValue);
        }

        /// <summary>
        /// 根据编号，删除记录
        /// </summary>
        /// <typeparam name="T2"></typeparam>
        /// <param name="id">编号</param>
        /// <returns></returns>
        public int Delete<T2>(T2 id)
        {
            SqlParameter[] parameters = { new SqlParameter("@ID", SqlDbType.Int, 8) };
            parameters[0].Value = id;
            T model = new T();
            string strCmdText = string.Format("DELETE FROM [{0}] WHERE ID=@ID;", model.TableName);
            int iResult = Tiku.DB.DBHelper.ExcuteNonQuery(strCmdText, parameters);
            return iResult;
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <typeparam name="T2"></typeparam>
        /// <param name="ids"></param>
        /// <returns></returns>
        public int Delete<T2>(T2[] ids)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取符合条件的记录数
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        public int GetRowCount(string where,
                               IEnumerable parameters)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="columns">列</param>
        /// <param name="where">条件</param>
        /// <param name="orders">排序</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        public List<T> GetList(int top,
                               string columns,
                               string tableName,
                               string where,
                               string orders,
                               IEnumerable parameters)
        {
            //SQL:
            StringBuilder stbCmdText = new StringBuilder();
            if (top > 0)
            {
                stbCmdText.AppendFormat("SELECT TOP({0})", top);
            }
            else
            {
                stbCmdText.Append("SELECT ");
            }
            stbCmdText.Append(columns);
            stbCmdText.AppendFormat(" FROM {0}", tableName);
            if (!string.IsNullOrEmpty(where))
            {
                if (where.ToLower().TrimStart().StartsWith("and", StringComparison.CurrentCultureIgnoreCase))
                {
                    stbCmdText.Append(" WHERE 1=1 ");
                }
                else
                {
                    stbCmdText.Append(" WHERE ");
                }
                stbCmdText.Append(where);
            }
            if (!string.IsNullOrEmpty(orders))
            {
                stbCmdText.Append(orders);
            }
            //List
            List<T> list = new List<T>();
            using (IDataReader dataReader = Tiku.DB.DBHelper.ExcuteDataReader(stbCmdText.ToString(),
                                                                              parameters))
            {
                while (dataReader.Read())
                {
                    T model = new T();//实体
                    for (int i = 0; i < dataReader.FieldCount; i++)
                    {
                        model.SetPropertyValue(dataReader.GetName(i), dataReader[i]);
                    }
                    list.Add(model);
                }
                dataReader.Close();
            }
            return list;
        }

        /// <summary>
        /// 获取数据集
        /// </summary>
        /// <param name="columns">列</param>
        /// <param name="where">条件</param>
        /// <param name="orders">排序</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        public DataSet GetDataSet(int top,
                                  string columns,
                                  string tableName,
                                  string where,
                                  string orders,
                                  IEnumerable parameters)
        {
            //SQL:
            StringBuilder stbCmdText = new StringBuilder();
            if (top > 0)
            {
                stbCmdText.AppendFormat("SELECT TOP({0})", top);
            }
            else
            {
                stbCmdText.Append("SELECT ");
            }
            stbCmdText.Append((string.IsNullOrEmpty(columns) ? "*" : columns));
            stbCmdText.AppendFormat(" FROM {0}", tableName);
            stbCmdText.Append(" WHERE 1=1 ");
            if (!string.IsNullOrEmpty(where))
            {
                stbCmdText.Append(where);
            }
            if (!string.IsNullOrEmpty(orders))
            {
                stbCmdText.Append(orders);
            }
            DataSet ds = Tiku.DB.DBHelper.Query(stbCmdText.ToString(), parameters);
            return ds;
        }

        /// <summary>
        ///获取实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public T Fill(T model)
        {
            string strCmdText = "SELECT TOP(1) * FROM [" + model.TableName + "] WHERE 1=1 ";
            for (int i = 0; i < model.PrimaryKeys.Count; i++)
            {
                strCmdText += string.Format(" AND {0}=@{0}", model.PrimaryKeys[i]);
            }
            IDataReader dataReader = Tiku.DB.DBHelper.ExcuteDataReader(strCmdText, model.FieldValue);
            if (dataReader.Read())
            {
                //循环设置数据
                for (int c = 0; c < dataReader.FieldCount; c++)
                {
                    model.SetPropertyValue(dataReader.GetName(c), dataReader.GetValue(c));
                }
            }
            dataReader.Close();
            dataReader.Dispose();
            return model;
        }

    }
    #endregion


}
