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
 * className:题库信息(BLL)
 * author:1058736170@qq.com
 * date:2015-03-26 10:10
 * modifyBy:1058736170@qq.com
 * modifyOn:2015-03-26 10:10
 * mark:本程序由代码生成器生成,了解更多,请登录http://my.oschina.net/lichaoqiang
 * 
 * ================================================================================================*/
namespace TiKu.BLL
{
    //题库信息
    public partial class tb_Question
    {
        #region 成员
        /// <summary>
        /// 表名
        /// </summary>
        private readonly string TableName = "tb_Question";
        #endregion

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(TiKu.Model.tb_Question model)
        {
            return EntityQuery<TiKu.Model.tb_Question>.Instance.Add(model);
        }


        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns></returns>
        public int DoAdd(TiKu.Model.tb_Question model)
        {
            IDbTransaction tran = TiKu.DataDriver.AdoHelper.BeginSingleTran();
            int iResult = 0;
            try
            {
                //1>添加材料
                if (null != model.Material)
                {
                    int iMate = EntityQuery<Model.tb_Material>.Instance.Add(model.Material, tran);
                    model.Material.ID = iMate;
                    model.MateID = iMate;
                }
                //2>添加问题
                iResult = EntityQuery<Model.tb_Question>.Instance.Add(model, tran);
                //提交数据库事务
                tran.Commit();
            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw new Exception("添加题目信息时出错！", ex);
            }
            finally
            {
                tran.Dispose();
            }
            return iResult;
        }

        /// <summary>
        ///修改
        /// </summary>
        public bool Update(TiKu.Model.tb_Question model)
        {
            IDbTransaction tran = TiKu.DataDriver.AdoHelper.BeginSingleTran();
            int iResult = 0;
            try
            {
                //1>添加材料
                if (null != model.Material)
                {
                    iResult = EntityQuery<Model.tb_Material>.Instance.Update(model.Material, tran);
                }
                //2>修改试题信息
                iResult += EntityQuery<Model.tb_Question>.Instance.Update(model, tran);
                tran.Commit();
            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw new Exception("添加题目信息时出错！", ex);
            }
            finally
            {
                tran.Dispose();
            }
            return EntityQuery<TiKu.Model.tb_Question>.Instance.Update(model);
        }

        /// <summary>
        ///删除
        /// </summary>
        public int Delete(TiKu.Model.tb_Question model)
        {
            return EntityQuery<TiKu.Model.tb_Question>.Instance.Delete(model);
        }

        /// <summary>
        /// 根据编号，删除问题信息
        /// </summary>
        /// <param name="ID">编号</param>
        /// <param name="ID">管理员编号</param>
        /// <returns></returns>
        public bool DoDel(int ID, int AdminID)
        {
            string strCmdText = "";
            SqlParameter[] parameters = { 
                                        new SqlParameter("@ID",SqlDbType.Int),
                                        new SqlParameter("@AdminID",SqlDbType.Int)
                                        };
            parameters[0].Value = ID;
            parameters[1].Value = AdminID;
            //启用逻辑删除
            if (BLL.tb_WebSet.WebSiteInfo.IsEnableDelete > 0)
            {
                strCmdText = string.Format("UPDATE [{0}] SET Del=1,ModifyBy=@AdminID,ModifyOn=GETDATE() WHERE ID=@ID;", TableName);
            }
            else
            {
                strCmdText = string.Format("DELETE FROM [{0}] WHERE ID=@ID;", TableName);
            }
            int iRowEffect = TiKu.DataDriver.AdoHelper.ExucteNonQuery(strCmdText, parameters);
            return (iRowEffect > 0);
        }

        /// <summary>
        /// 获取单个实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public TiKu.Model.tb_Question GetModel(int ID)
        {
            TiKu.Model.tb_Question model = new TiKu.Model.tb_Question();
            model.ID = ID;
            EntityQuery<TiKu.Model.tb_Question>.Instance.Fill(model);
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
        public List<TiKu.Model.tb_Question> GetList(int top,
            string where,
            string orders,
            IEnumerable parameters)
        {
            List<TiKu.Model.tb_Question> list = TiKu.DataDriver.Entity.EntityQuery<TiKu.Model.tb_Question>.Instance.GetList(top,
                                                                               "ID,RigthtNum,ErrorNum,AvgDifficulty,FavoriteNum,NoteNum,IsFree,CreatedOn,CreatedBy,ModifyOn,ModifyBy,Title,Del,QType,ShortTitle,QScore,TrueAnswer,Orders,Analysis,State",
                                                                               "tb_Question",
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
        public List<TiKu.Model.tb_Question> GetListPager(int startIndex,
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
            stbCmdText.AppendFormat("SELECT Row_Number() over(order by ID desc) as Row,ID,RigthtNum,ErrorNum,AvgDifficulty,FavoriteNum,NoteNum,IsFree,CreatedOn,CreatedBy,ModifyOn,ModifyBy,Title,Del,QType,ShortTitle,QScore,TrueAnswer,Orders,Analysis,State FROM [{0}] WHERE 1=1 ", TableName);
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
            List<TiKu.Model.tb_Question> list = new List<TiKu.Model.tb_Question>();
            string strCmdText = stbCmdText + ";" + stbCmdCount;
            using (IDataReader dataReader = TiKu.DataDriver.AdoHelper.ExcuteDataReader(strCmdText, parameters))
            {
                while (dataReader.Read())
                {
                    TiKu.Model.tb_Question model = new TiKu.Model.tb_Question();
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
            stbCmdText.AppendFormat("SELECT Row_Number() over(order by ID desc) as Row,ID,RigthtNum,ErrorNum,AvgDifficulty,FavoriteNum,NoteNum,IsFree,CreatedOn,CreatedBy,ModifyOn,ModifyBy,Title,Del,QType,ShortTitle,QScore,TrueAnswer,Orders,Analysis,State FROM [{0}] WHERE 1=1 ", TableName);
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
        /// 显示题型文本
        /// </summary>
        /// <param name="qtype">题型</param>
        /// <returns></returns>
        public string ShowQTypeLabelText(object qtype)
        {
            if (null == qtype) { return "--"; }
            int iQtype = Convert.ToInt32(qtype);

            //1、单选题
            if (iQtype == TiKu.Common.Constants.QUESTION.QTYPE.SINGLE_SELECTION)
            {
                return "单选题";
            }
            //2、多选题
            if (iQtype == TiKu.Common.Constants.QUESTION.QTYPE.MULTI_SELECTION)
            {
                return "多选题";
            }
            //3、判断
            if (iQtype == TiKu.Common.Constants.QUESTION.QTYPE.JUDGE)
            {
                return "判断题";
            }
            //4、简答题
            if (iQtype == TiKu.Common.Constants.QUESTION.QTYPE.SHORT_ANSWER)
            {
                return "简答题";
            }
            //一题多问
            if (iQtype == TiKu.Common.Constants.QUESTION.QTYPE.MATERIAL_SINGLE_SELECTION)
            {
                return "单选题";
            }
            if (iQtype == TiKu.Common.Constants.QUESTION.QTYPE.MATERIAL_MULTI_SELECTION)
            {
                return "多选题";
            }
            if (iQtype == TiKu.Common.Constants.QUESTION.QTYPE.MATERIAL_SHORT_ANSWER)
            {
                return "简答题";
            }
            if (iQtype == TiKu.Common.Constants.QUESTION.QTYPE.MATERIAL_JUDGE)
            {
                return "判断题";
            }
            return "--";
        }

        /// <summary>
        /// 显示状态文本
        /// </summary>
        /// <param name="state">状态</param>
        /// <returns></returns>
        public string ShowStateLabelText(object state)
        {
            if (null == state) { return "--"; }
            if (state.ToString() == "1") { return "启用"; }
            if (state.ToString() == "0") { return "禁用"; }
            return "--";
        }

    }
}