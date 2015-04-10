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
    //管理员角色
    public partial class tb_AdminRole
    {
        #region 成员
        /// <summary>
        /// 表名
        /// </summary>
        private readonly string TableName = "tb_AdminRole";
        #endregion

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(TiKu.Model.tb_AdminRole model)
        {
            return EntityQuery<TiKu.Model.tb_AdminRole>.Instance.Add(model);
        }

        /// <summary>
        ///修改
        /// </summary>
        public bool Update(TiKu.Model.tb_AdminRole model)
        {
            return EntityQuery<TiKu.Model.tb_AdminRole>.Instance.Update(model);
        }

        /// <summary>
        ///删除
        /// </summary>
        public int Delete(TiKu.Model.tb_AdminRole model)
        {
            return EntityQuery<TiKu.Model.tb_AdminRole>.Instance.Delete(model);
        }

        /// <summary>
        /// 业务删除
        /// </summary>
        /// <param name="ID">编号</param>
        /// <param name="ActionID">操作者编号</param>
        /// <returns></returns>
        public bool DoDel(int ID)
        {
            Model.tb_AdminRole model = new Model.tb_AdminRole();
            model.ID = ID;
            //启用逻辑删除
            if (BLL.tb_WebSet.WebSiteInfo.IsEnableDelete > 0)
            {
                model.Del = TiKu.Common.Constants.Common.DELETE;
                return Update(model);
            }
            //物理删除
            return Delete(model) > 0;
        }

        /// <summary>
        /// 获取单个实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public TiKu.Model.tb_AdminRole GetModel(int ID)
        {
            TiKu.Model.tb_AdminRole model = new TiKu.Model.tb_AdminRole();
            model.ID = ID;
            EntityQuery<TiKu.Model.tb_AdminRole>.Instance.Fill(model);
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
        public List<TiKu.Model.tb_AdminRole> GetList(int top,
            string where,
            string orders,
            IEnumerable parameters)
        {
            List<TiKu.Model.tb_AdminRole> list = TiKu.DataDriver.Entity.EntityQuery<TiKu.Model.tb_AdminRole>.Instance.GetList(top,
                                                                               "ID,RoleName,RoleValue,Orders,State,Del,CreatedOn,CreatedBy",
                                                                               "tb_AdminRole",
                                                                               where,
                                                                               orders,
                                                                               parameters);
            return list;
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="top">记录数</param>
        /// <param name="where">条件</param>
        /// <param name="orders">排序</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        public DataSet GetData(int top,
                               string where,
                               string orders,
                               IEnumerable parameters)
        {
            string strCmdText = string.Format("SELECT TOP() FROM [{0}] WHERE 1=1 ", TableName);
            if (!string.IsNullOrEmpty(where))
            {
                strCmdText += where;
            }
            if (!string.IsNullOrEmpty(orders))
            {
                strCmdText += " " + orders;
            }
            DataSet ds = TiKu.DataDriver.AdoHelper.Query(strCmdText, parameters);
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
        public List<TiKu.Model.tb_AdminRole> GetListPager(int startIndex,
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
            stbCmdText.AppendFormat("SELECT Row_Number() over(order by ID desc) as Row,ID,RoleName,RoleValue,Orders,State,Del,CreatedOn,CreatedBy FROM [{0}] WHERE 1=1 ", TableName);
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
            List<TiKu.Model.tb_AdminRole> list = new List<TiKu.Model.tb_AdminRole>();
            string strCmdText = stbCmdText + ";" + stbCmdCount;
            using (IDataReader dataReader = TiKu.DataDriver.AdoHelper.ExcuteDataReader(strCmdText, parameters))
            {
                while (dataReader.Read())
                {
                    TiKu.Model.tb_AdminRole model = new TiKu.Model.tb_AdminRole();
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
            stbCmdText.AppendFormat("SELECT Row_Number() over(order by ID desc) as Row,ID,RoleName,RoleValue,Orders,State,Del,CreatedOn,CreatedBy FROM [{0}] WHERE 1=1 ", TableName);
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
        /// 绑定角色列表
        /// </summary>
        /// <param name="drp"></param>
        /// <param name="_default"></param>
        public void BindRoleDropDownList(DropDownList drp)
        {
            List<TiKu.Model.tb_AdminRole> list = null;
            //检测缓存是否存在
            if (TiKu.Common.CacheHelper.IsExistsCahce(TiKu.Common.Constants.CACHE_KEY._CACHE_ADMIN_ROLE))
            {
                list = TiKu.Common.CacheHelper.GetCacheValue<List<TiKu.Model.tb_AdminRole>>(TiKu.Common.Constants.CACHE_KEY._CACHE_ADMIN_ROLE);
            }
            else
            {
                list = TiKu.DataDriver.Entity.EntityQuery<TiKu.Model.tb_AdminRole>.Instance.GetList(0,
                                                                                   "ID,RoleName",
                                                                                   TableName,
                                                                                   " And Del=0 And State=1",
                                                                                   " Order By [Orders] Asc",
                                                                                    null);
                //缓存对象
                TiKu.Common.CacheHelper.SaveCache(TiKu.Common.Constants.CACHE_KEY._CACHE_ADMIN_ROLE, list);
            }
            drp.DataTextField = "RoleName";
            drp.DataValueField = "ID";
            drp.DataSource = list;
            drp.DataBind();
            drp.Items.Insert(0, new ListItem("--请选择角色--", ""));
        }

    }
}