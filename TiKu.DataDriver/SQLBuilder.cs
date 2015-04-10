using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*****************************************************************************
 * 
 * 
 * 类 名：SQLBuilder
 * 说 明：SQL生成共同类
 * 作 者：李朝强
 * 
 * 
 * *************************************************************************/
namespace TiKu.DataDriver
{
    public class SQLBuilder
    {
        /// <summary>
        /// 根据迭代类型，生成Insert语句
        /// </summary>
        /// <param name="columns">列</param>
        /// <param name="tablename">表名</param>
        /// <returns></returns>
        public static string BuildInsertSQL(IEnumerable columns, string tablename)
        {
            //SQL:
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat("INSERT INTO {0}", tablename);
            sql.Append("(");

            StringBuilder stbColumns = new StringBuilder();//列
            StringBuilder stbParameters = new StringBuilder();//参数值
            //Hashtable
            if (columns is Hashtable)
            {
                foreach (DictionaryEntry item in columns)
                {
                    //列
                    stbColumns.Append("[" + item.Key.ToString().TrimStart('@') + "]");
                    stbColumns.Append(",");
                    //值
                    stbParameters.Append("@" + item.Key.ToString().TrimStart('@'));
                    stbParameters.Append(",");
                }
            }
            //Dictionary<string,object>
            if (columns is Dictionary<string, object>)
            {
                foreach (KeyValuePair<string, object> item in columns)
                {
                    //列
                    stbColumns.Append("[" + item.Key.ToString().TrimStart('@') + "]");
                    stbColumns.Append(",");
                    //值
                    stbParameters.Append("@" + item.Key.ToString().TrimStart('@'));
                    stbParameters.Append(",");
                }
            }
            //移除最后一个逗号
            stbColumns.Remove(stbColumns.Length - 1, 1);
            stbParameters.Remove(stbParameters.Length - 1, 1);

            sql.Append(stbColumns);
            sql.Append(")");
            //Value
            sql.Append(" VALUES(");
            sql.Append(stbParameters);
            sql.Append(");");
            return sql.ToString();
        }


        /// <summary>
        /// 生成更新SQL
        /// </summary>
        /// <param name="Columns">更新列</param>
        /// <param name="tablename">表名</param>
        /// <returns></returns>
        public static string BuildUpdateSQL(IEnumerable Columns,
                                            IEnumerable Where,
                                            string tablename)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat("UPDATE {0}", tablename);
            sql.Append(" SET ");
            if (Columns is Hashtable)
            {
                foreach (DictionaryEntry item in Columns)
                {
                    sql.AppendFormat("{0}=@{1}", item.Key.ToString().TrimStart('@'), item.Key);
                    sql.Append(",");
                }
            }
            sql.Remove(sql.Length - 1, 1);//移除最后一个逗号
            //条件
            sql.Append(" WHERE 1=1 ");
            if (Columns is Dictionary<string, object>)
            {
                foreach (KeyValuePair<string, object> item in Where)
                {
                    sql.AppendFormat(" AND {0}=@{1}", item.Key.ToString().TrimStart('@'), item.Key);
                }
            }
            return sql.ToString();
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="strColumnInfo"></param>
        /// <param name="strWhere"></param>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public static string BuildUpdateSQL(string strColumnInfo,
                                            string strWhere,
                                            string tbName)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat("UPDATE {0}", tbName);
            sql.Append(" SET ");
            sql.Append(strColumnInfo);
            sql.AppendFormat(" WHERE {0}", strWhere);
            return sql.ToString();
        }

        /// <summary>
        /// 生成删除语句
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="tablename">表名</param>
        /// <returns></returns>
        public static string BuildDeleteSQL(IEnumerable where, string tablename)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat("DELETE FROM {0} WHERE 1=1 ", tablename);
            if (where is Hashtable)
            {
                foreach (DictionaryEntry item in where)
                {
                    sql.AppendFormat(" AND {0}=@{1}", item.Key.ToString().TrimStart('@'), item.Key);
                }
            }
            if (where is Dictionary<string, object>)
            {
                foreach (KeyValuePair<string, object> item in where)
                {
                    sql.AppendFormat(" AND {0}=@{1}", item.Key.TrimStart('@'), item.Key);
                }
            }
            return sql.ToString();
        }

        /// <summary>
        /// 生成删除语句
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        public static string BuildDeleteSQL(string strWhere, string tableName)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat("DELETE FROM [{0}] WHERE {1}",
                             tableName.Trim(']').Trim('['),
                             strWhere);
            return sql.ToString();
        }

        /// <summary>
        /// 根据实体，生成Insert语句
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="model">模型</param>
        /// <returns></returns>
        public static string BuildInsertSQL<T>(T model,
                                              ref System.Data.SqlClient.SqlParameter[] parameters)
        where T : TiKu.DataDriver.Entity.EntityBase
        {
            //SQL:
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat("INSERT INTO {0}", model.TableName);
            sql.Append("(");
            StringBuilder stbColumns = new StringBuilder();//列
            StringBuilder stbParameters = new StringBuilder();//参数值
            //Dictionary<string,object>
            int i = 0;
            foreach (KeyValuePair<string, object> item in model.FieldValue)
            {
                //列
                stbColumns.Append("[" + item.Key.ToString() + "]");
                stbColumns.Append(",");
                //值
                stbParameters.Append("@" + item.Key.ToString());
                stbParameters.Append(",");
                //Parameters
                System.Data.SqlClient.SqlParameter Parameters = new System.Data.SqlClient.SqlParameter("@" + item.Key.ToString(), item.Value);
                if (model.StringFieldSize != null && model.StringFieldSize.ContainsKey(string.Format("{0}_{1}", model.TableName, item.Key)))
                {
                    Parameters.Size = model.StringFieldSize[string.Format("{0}_{1}", model.TableName, item.Key)];
                }
                parameters[i] = Parameters;
                i++;
            }
            //移除最后一个逗号
            stbColumns.Remove(stbColumns.Length - 1, 1);
            stbParameters.Remove(stbParameters.Length - 1, 1);

            sql.Append(stbColumns);
            sql.Append(")");
            //Value
            sql.Append(" VALUES(");
            sql.Append(stbParameters);
            sql.Append(");");
            return sql.ToString();
        }

        /// <summary>
        /// 根据实体，创建更新语句
        /// </summary>
        /// <typeparam name="T">实体类别，必须继承自Model.EntityBase</typeparam>
        /// <param name="model">实体</param>
        /// <returns></returns>
        public static string BuildUpdateSQL<T>(T model,
                                               ref System.Data.SqlClient.SqlParameter[] parameters)
            where T : TiKu.DataDriver.Entity.EntityBase
        {
            StringBuilder stbSQL = new StringBuilder();
            StringBuilder stbWhere = new StringBuilder();
            stbSQL.Append("UPDATE [" + model.TableName.Trim(']').Trim('[') + "] SET ");
            stbWhere.Append(" WHERE 1=1 ");
            //条件
            for (int j = 0; j < model.PrimaryKeys.Count; j++)
            {
                stbWhere.AppendFormat(" And {0}=@{0}", model.PrimaryKeys[j]);
            }
            //列
            int i = 0;
            foreach (KeyValuePair<string, object> ColumInfo in model.FieldValue)
            {
                //参数
                System.Data.SqlClient.SqlParameter parameter = new System.Data.SqlClient.SqlParameter("@" + ColumInfo.Key, ColumInfo.Value);
                parameter.Size = 255;//默认长度
                if (model.StringFieldSize != null && model.StringFieldSize.ContainsKey(string.Format("{0}_{1}", model.TableName, ColumInfo.Key)))
                {
                    parameter.Size = model.StringFieldSize[string.Format("{0}_{1}", model.TableName, ColumInfo.Key)];
                }
                parameters[i] = parameter;
                i++;
                //判断是否是主键
                if (model.PrimaryKeys.Contains(ColumInfo.Key))
                {
                    continue;
                }
                stbSQL.AppendFormat("{0}=@{0},", ColumInfo.Key);
            }
            stbSQL.Remove(stbSQL.Length - 1, 1);
            //条件
            return (stbSQL.ToString() + stbWhere.ToString());
        }

        /// <summary>
        /// 根据实体删除
        /// </summary>
        /// <typeparam name="T">实体类别，必须继承自Model.EntityBase</typeparam>
        /// <param name="model"></param>
        /// <returns>实体</returns>
        public static string BuildDeleteSQL<T>(T model)
            where T : TiKu.DataDriver.Entity.EntityBase
        {
            StringBuilder stbSQL = new StringBuilder();
            stbSQL.AppendFormat("DELETE FROM [{0}]", model.TableName.Trim(']').Trim('['));
            stbSQL.Append(" WHERE 1=1 ");
            for (int i = 0; i < model.PrimaryKeys.Count; i++)
            {
                stbSQL.AppendFormat(" AND {0}=@{1}", model.PrimaryKeys[i], model.PrimaryKeys[i]);
            }
            return stbSQL.ToString();
        }

        #region 私有方法
        /// <summary>
        /// 生成列
        /// </summary>
        /// <param name="columns">列</param>
        /// <returns></returns>
        private static string BuildColumnString(IEnumerable columns)
        {
            StringBuilder stbColumns = new StringBuilder();
            if (columns is Hashtable)
            {
                foreach (DictionaryEntry item in columns)
                {
                    stbColumns.Append(item.Key.ToString().IndexOf(']') >= 0 ? item.Key : "[" + item.Key + "]");
                    stbColumns.Append(",");
                }
            }
            if (columns is Dictionary<string, object>)
            {
                foreach (KeyValuePair<string, object> item in columns)
                {
                    stbColumns.Append(item.Key.ToString().IndexOf(']') >= 0 ? item.Key : "[" + item.Key + "]");
                    stbColumns.Append(",");
                }
            }
            stbColumns.Remove(stbColumns.Length - 1, 1);//移除最后一个逗号
            stbColumns.Replace("@", string.Empty);
            return stbColumns.ToString();
        }
        #endregion
    }
}
