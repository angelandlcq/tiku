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
 * className:章节(BLL)
 * author:1058736170@qq.com
 * date:2015-03-23 14:10
 * modifyBy:1058736170@qq.com
 * modifyOn:2015-03-23 14:10
 * mark:本程序由代码生成器生成,了解更多,请登录http://my.oschina.net/lichaoqiang
 * 
 * ================================================================================================*/
namespace TiKu.BLL
{
    //章节
    public partial class tb_Chapter
    {
        #region 成员
        /// <summary>
        /// 表名
        /// </summary>
        private readonly string TableName = "tb_Chapter";
        #endregion

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(TiKu.Model.tb_Chapter model)
        {
            return EntityQuery<TiKu.Model.tb_Chapter>.Instance.Add(model);
        }

        /// <summary>
        ///修改
        /// </summary>
        public bool Update(TiKu.Model.tb_Chapter model)
        {
            return EntityQuery<TiKu.Model.tb_Chapter>.Instance.Update(model);
        }

        /// <summary>
        ///删除
        /// </summary>
        public int Delete(TiKu.Model.tb_Chapter model)
        {
            return EntityQuery<TiKu.Model.tb_Chapter>.Instance.Delete(model);
        }

        /// <summary>
        /// 获取单个实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public TiKu.Model.tb_Chapter GetModel(int ID)
        {
            TiKu.Model.tb_Chapter model = new TiKu.Model.tb_Chapter();
            model.ID = ID;
            EntityQuery<TiKu.Model.tb_Chapter>.Instance.Fill(model);
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
        public List<TiKu.Model.tb_Chapter> GetList(int top,
            string where,
            string orders,
            IEnumerable parameters)
        {
            List<TiKu.Model.tb_Chapter> list = TiKu.DataDriver.Entity.EntityQuery<TiKu.Model.tb_Chapter>.Instance.GetList(top,
                                                                               "ID,DirCode,IsExam,State,CreatedBy,CreatedOn,ModifyBy,ModifyOn,Del,CptName,CourseID,ParentID,ParentPath,Quantity,NoteNum,Collection,Orders",
                                                                               "tb_Chapter",
                                                                               where,
                                                                               orders,
                                                                               parameters);
            return list;
        }

        /// <summary>
        /// 根据课程编号，获取章节列表
        /// </summary>
        /// <param name="CourseID">课程编号</param>
        /// <returns></returns>
        public List<TiKu.Model.tb_Chapter> GetList(int CourseID)
        {
            SqlParameter[] parameters = null;
            string strWhere = "And Del=0 And State=1";
            if (CourseID > 0)
            {
                strWhere += " And CourseID=@CourseID";
                parameters = new SqlParameter[1] { new SqlParameter("@CourseID", SqlDbType.Int) };
                parameters[0].Value = CourseID;
            }

            List<Model.tb_Chapter> list = new List<Model.tb_Chapter>();
            list = TiKu.DataDriver.Entity.EntityQuery<TiKu.Model.tb_Chapter>.Instance.GetList(0,
                                                                               "ID,CptName,ParentID",
                                                                               "tb_Chapter",
                                                                               strWhere,
                                                                               " Order By Orders Asc,[ModifyOn] desc",
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
        /// 删除
        /// </summary>
        /// <param name="ID">编号</param>
        /// <returns></returns>
        public int Delete(int ID)
        {
            SqlParameter[] parameters = { new SqlParameter("@ID", SqlDbType.Int) };
            parameters[0].Value = ID;
            return TiKu.DataDriver.AdoHelper.Delete(TableName, " And ID=@ID", parameters);
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
        public List<TiKu.Model.tb_Chapter> GetListPager(int startIndex,
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
            stbCmdText.AppendFormat("SELECT Row_Number() over(order by ID desc) as Row,ID,DirCode,IsExam,State,CreatedBy,CreatedOn,ModifyBy,ModifyOn,Del,CptName,CourseID,ParentID,ParentPath,Quantity,NoteNum,Collection,Orders FROM [{0}] WHERE 1=1 ", TableName);
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
            List<TiKu.Model.tb_Chapter> list = new List<TiKu.Model.tb_Chapter>();
            string strCmdText = stbCmdText + ";" + stbCmdCount;
            using (IDataReader dataReader = TiKu.DataDriver.AdoHelper.ExcuteDataReader(strCmdText, parameters))
            {
                while (dataReader.Read())
                {
                    TiKu.Model.tb_Chapter model = new TiKu.Model.tb_Chapter();
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
            stbCmdText.AppendFormat("SELECT Row_Number() over(order by ID desc) as Row,ID,DirCode,IsExam,State,CreatedBy,CreatedOn,ModifyBy,ModifyOn,Del,CptName,CourseID,ParentID,ParentPath,Quantity,NoteNum,Collection,Orders FROM [{0}] WHERE 1=1 ", TableName);
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
        /// 显示状态文本
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public string ShowStateLabelText(object state)
        {
            if (null == state) { return "缺省"; }
            int iState = Convert.ToInt32(state);
            if (iState == TiKu.Common.Constants.Common.ENABLE)
            {
                return "启用";
            }
            if (iState == TiKu.Common.Constants.Common.DISABLE)
            {
                return "禁用";
            }
            return "禁用";
        }

        #region 绑定章节考点
        /// <summary>
        /// /绑定章节列表
        /// </summary>
        /// <param name="drpChapter">控件：DropDownList</param>
        /// <param name="iCourseID">课程编号</param>
        public void BindChapterList(DropDownList drpChapter, int iCourseID)
        {
            drpChapter.Items.Clear();
            //获取信息列表
            List<Model.tb_Chapter> list = GetList(iCourseID);
            //递归，添加章节项
            AddChildrenItem(drpChapter,
                            list,
                            0,
                            string.Empty);
            drpChapter.Items.Insert(0, new ListItem("--请选择章节考点--", string.Empty));

        }

        /// <summary>
        /// 递归添加
        /// </summary>
        /// <param name="drpChapter">DropDownList</param>
        /// <param name="items"></param>
        private void AddChildrenItem(DropDownList drpChapter,
                                     List<Model.tb_Chapter> list,
                                     int parentID,
                                     string strPad)
        {
            //根据ParenID获取列表项
            List<Model.tb_Chapter> source = list.FindAll(m => { return m.ParentID == parentID; });
            for (int i = 0; i < source.Count; i++)
            {
                //项
                ListItem item = new ListItem();
                item.Text = System.Web.HttpUtility.HtmlDecode(strPad + "┠" + source[i].CptName);
                item.Value = source[i].ID.ToString();
                item.Attributes["title"] = source[i].CptName;
                drpChapter.Items.Add(item);
                //递归调用
                AddChildrenItem(drpChapter,
                                list,
                                source[i].ID,
                                strPad + "&nbsp;&nbsp;");
            }
        }
        #endregion


    }
}