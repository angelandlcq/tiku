using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
/*==============================================================================================================
 * 
 * 
 * 
 * 说 明：DbSession类，是对DbConnection、DbTransaction、DbCommand对象的封装，目的在于创建一个新的数据库回话
 * 
 * 
 * =============================================================================================================*/
namespace Tiku.DB
{
    public class DbSession
    {
        /// <summary>
        /// 数据库连接对象
        /// </summary>
        public DbConnection Connection { get; private set; }

        /// <summary>
        /// 数据库事务
        /// </summary>
        public DbTransaction Transaction { get; private set; }

        /// <summary>
        /// 设置Command对象
        /// </summary>
        public DbCommand Command { get; private set; }


        /// <summary>
        /// 构造器
        /// </summary>
        public DbSession()
        {
            Connection = DBHelper.CreateDBConnection();//创建数据库连接对象
        }

        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="command"></param>
        public DbSession(DbCommand command)
            : this()
        {
            Command = command;
            Command.CommandTimeout = 60;
        }

        /// <summary>
        /// 打开回话
        /// </summary>
        public void OpenSession()
        {
            lock (this)
            {
                if (Connection.State != ConnectionState.Open)
                {
                    Connection.Open();//打开数据库连接
                }
                //打开数据库事务
                Transaction = Connection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
                if (null != Command)
                {
                    Command.Transaction = Transaction;
                }
            }
        }

        /// <summary>
        /// 提交回话
        /// </summary>
        public void CommitSession()
        {
            if (null != Transaction)
            {
                Transaction.Commit();
                Transaction.Dispose();
                Close();
            }
        }


        /// <summary>
        /// 关闭回话
        /// </summary>
        public void Close()
        {
            if (null != Connection)
            {
                Connection.Close();
                Connection.Dispose();
            }
        }

        /// <summary>
        /// 回滚
        /// </summary>
        public void RollBack()
        {
            if (null != Transaction)
            {
                Transaction.Rollback();
                Transaction.Dispose();//回滚事务
                Close();
            }
        }

    }
}
