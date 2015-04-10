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
 * className:经销商(BLL)
 * author:1058736170@qq.com
 * date:2015-03-05 15:23
 * modifyBy:1058736170@qq.com
 * modifyOn:2015-03-05 15:23
 * mark:本程序由代码生成器生成,了解更多,请登录http://my.oschina.net/lichaoqiang
 * 
 * ================================================================================================*/
namespace TiKu.BLL
{
    //经销商
    public partial class tb_Agent
    {
        #region 成员
        /// <summary>
        /// 表名
        /// </summary>
        private readonly string TableName = "tb_Agent";
        #endregion

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(TiKu.Model.tb_Agent model)
        {
            return EntityQuery<TiKu.Model.tb_Agent>.Instance.Add(model);
        }

        /// <summary>
        ///修改
        /// </summary>
        public bool Update(TiKu.Model.tb_Agent model)
        {
            return EntityQuery<TiKu.Model.tb_Agent>.Instance.Update(model);
        }

        /// <summary>
        ///删除
        /// </summary>
        public int Delete(TiKu.Model.tb_Agent model)
        {
            return EntityQuery<TiKu.Model.tb_Agent>.Instance.Delete(model);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ID">编号</param>
        /// <returns></returns>
        public int Delete(int ID)
        {
            SqlParameter[] parameter = { 
                                       new SqlParameter("@ID",SqlDbType.Int,-1)
                                       };
            parameter[0].Value = ID;
            return TiKu.DataDriver.AdoHelper.Delete(TableName, " And ID=@ID", parameter);
        }

        /// <summary>
        /// 业务删除
        /// </summary>
        /// <param name="ID">编号</param>
        /// <param name="AdminID">管理员编号</param>
        /// <returns></returns>
        public bool DoDelete(int ID, int AdminID)
        {
            //是否启用逻辑删除
            Model.tb_Agent model = new Model.tb_Agent();
            model.ID = ID;
            if (BLL.tb_WebSet.WebSiteInfo.IsEnableDelete > 0)
            {
                model.Del = TiKu.Common.Constants.Common.DELETE;
                model.ModifyBy = AdminID;
                model.ModifyOn = DateTime.Now;
                return Update(model);
            }
            return Delete(model) > 0;
        }

        /// <summary>
        /// 获取单个实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public TiKu.Model.tb_Agent GetModel(int ID)
        {
            TiKu.Model.tb_Agent model = new TiKu.Model.tb_Agent();
            model.ID = ID;
            EntityQuery<TiKu.Model.tb_Agent>.Instance.Fill(model);
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
        public List<TiKu.Model.tb_Agent> GetList(int top,
            string where,
            string orders,
            IEnumerable parameters)
        {
            List<TiKu.Model.tb_Agent> list = TiKu.DataDriver.Entity.EntityQuery<TiKu.Model.tb_Agent>.Instance.GetList(top,
                                                                               "ID,AgentName,AgentPwd,ShowName,State,RegisterTime,RegisterIP,LogNum,Contact,Mobile,Tel,QQ,Email,Del,Address,Amount,Url,TaoBaoUrl,AliAcount",
                                                                               "tb_Agent",
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
        public List<TiKu.Model.tb_Agent> GetListPager(int startIndex,
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
            stbCmdText.AppendFormat("SELECT Row_Number() over(order by ID desc) as Row,ID,AgentName,AgentPwd,ShowName,State,RegisterTime,RegisterIP,LogNum,Contact,Mobile,Tel,QQ,Email,Del,Address,Amount,Url,TaoBaoUrl,AliAcount FROM [{0}] WHERE 1=1 ", TableName);
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
            List<TiKu.Model.tb_Agent> list = new List<TiKu.Model.tb_Agent>();
            string strCmdText = stbCmdText + ";" + stbCmdCount;
            using (IDataReader dataReader = TiKu.DataDriver.AdoHelper.ExcuteDataReader(strCmdText, parameters))
            {
                while (dataReader.Read())
                {
                    TiKu.Model.tb_Agent model = new TiKu.Model.tb_Agent();
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
            stbCmdText.AppendFormat("SELECT Row_Number() over(order by ID desc) as Row,ID,AgentName,AgentPwd,ShowName,State,RegisterTime,RegisterIP,LogNum,Contact,Mobile,Tel,QQ,Email,Del,Address,Amount,Url,TaoBaoUrl,AliAcount FROM [{0}] WHERE 1=1 ", TableName);
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
        /// 验证代理商登陆名是否存在
        /// </summary>
        /// <param name="AgentName">代理商名称</param>
        /// <returns></returns>
        public bool CheckAgentName(string AgentName)
        {
            SqlParameter[] parameters = { 
                                        new SqlParameter("@AgentName",SqlDbType.VarChar,30)
                                        };
            parameters[0].Value = AgentName;
            int iCount = Count(" And AgentName=@AgentName", parameters);
            return (iCount > 0);
        }

        /// <summary>
        /// 根据状态，显示状态文本
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public string ShowStateLabelText(object state)
        {
            if (null == state || state == DBNull.Value) { return "待审核"; }
            int iState = Convert.ToInt32(state);
            if (iState == TiKu.Common.Constants.Common.AUDITING)
            {
                return "待审核";
            }
            if (iState == TiKu.Common.Constants.Common.POST)
            {
                return "审核通过";
            }
            if (iState == TiKu.Common.Constants.Common.LOCK)
            {
                return "已冻结";
            }
            return "待审核";
        }

        /// <summary>
        /// 修改状态
        /// </summary>
        /// <param name="IDs">编号，多个用,分割</param>
        /// <param name="state">状态</param>
        /// <returns></returns>
        public bool SaveAgentState(string IDs, int State, int AdminID)
        {
            IDs = IDs.Trim(',');
            SqlParameter[] parameters = { 
                                        new SqlParameter("@State",SqlDbType.Int),
                                        new SqlParameter("@ModifyBy",SqlDbType.Int)
                                        };
            parameters[0].Value = State;
            parameters[1].Value = AdminID;
            string strCmdText = "UPDATE [" + TableName + "] SET State=@State,ModifyOn=GETDATE(),ModifyBy=@ModifyBy WHERE ID IN(" + IDs + ");";
            int iRowEffect = TiKu.DataDriver.AdoHelper.ExucteNonQuery(strCmdText, parameters);
            return (iRowEffect > 0);
        }

        /// <summary>
        /// 验证代理商登陆
        /// </summary>
        /// <param name="AgentName">登录名</param>
        /// <param name="Password">密码</param>
        /// <param name="ReturnUrl">登陆成功后，跳转地址</param>
        /// <returns></returns>
        public bool CheckAgentLogin(string AgentName,
                                    string AgentPwd,
                                    ref string error,
                                    string ReturnUrl)
        {
            //参数化
            SqlParameter[] paramters = {
                                       new SqlParameter("@AgentName",SqlDbType.VarChar,60),
                                       new SqlParameter("@AgentPwd",SqlDbType.VarChar,32)
                                       };
            paramters[0].Value = AgentName;
            paramters[1].Value = AgentPwd;
            //获取列表
            List<Model.tb_Agent> list = GetList(1,
                                              " And Del=0 And AgentName=@AgentName And AgentPwd=@AgentPwd ",
                                              null,
                                              paramters);
            if (list.Count == 0)
            {
                error = "用户名或密码错误！";
                return false;
            }
            //实体信息
            Model.tb_Agent model = list[0];
            if (model.State == TiKu.Common.Constants.AGENT.STATE.AUDITING)
            {
                error = "账号正在审核中...";
                return false;
            }
            if (model.State == TiKu.Common.Constants.AGENT.STATE.LOCK)
            {
                error = "账号被锁定，请联系客服！";
                return false;
            }
            //登陆成功
            if (model.State == TiKu.Common.Constants.AGENT.STATE.POST)
            {
                //1>更新登陆信息
                Model.tb_Agent agent = new Model.tb_Agent();
                agent.ID = model.ID;
                agent.LastTime = DateTime.Now;
                Update(agent);
                //2>写入登陆信息
                object obj = new
                {
                    ID = model.ID,
                    AgentName = model.AgentName,
                    AgentPwd = model.AgentPwd
                };
                string strLoginedInfo = System.Web.HttpUtility.UrlEncode(TiKu.Common.JsonHelper.ToJson(obj));
                //加密Cookie
                strLoginedInfo = TiKu.Common.DES.Encode(strLoginedInfo, TiKu.Common.Constants.Encrypt.DES.ENCRYPT_KEY);

                TiKu.Common.CookieUtil.WriteCookie(TiKu.Common.Constants.AGENT.AGENT_SESSION_ID,
                                                    strLoginedInfo,
                                                    System.Web.Security.FormsAuthentication.Timeout,
                                                    true,
                                                    BLL.tb_WebSet.WebSiteInfo.Domain);
                //3>写入登陆日志
                TiKu.Common.Logger.AgentLogger.Info(model.ID,
                                                    "登陆",
                                                    string.Format("代理商{0}成功登陆系统！", AgentName));
                //4>跳转至请求页
                System.Web.HttpContext.Current.Response.Redirect(ReturnUrl);
                return true;
            }
            return false;
        }

        /// <summary>
        /// 验证代理商登陆状态
        /// </summary>
        /// <returns></returns>
        public bool CheckLoginState()
        {
            if (System.Web.HttpContext.Current.Request.Cookies[TiKu.Common.Constants.AGENT.AGENT_SESSION_ID] != null)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 获取代理商登陆的信息
        /// </summary>
        /// <returns></returns>
        public static Model.tb_Agent GetAgentLoginedInfo()
        {
            string strCookieVal = TiKu.Common.CookieUtil.GetCookieValue(TiKu.Common.Constants.AGENT.AGENT_SESSION_ID);
            if (string.IsNullOrEmpty(strCookieVal))
            {
                System.Web.HttpContext.Current.Response.Write("<script type=\"text/javascript\">alert(\"登陆超时，请重新登陆！\");top.location.href=\"/login.aspx\";</script>");
                System.Web.HttpContext.Current.Response.End();
                return null;
            }
            Model.tb_Agent model = null;
            try
            {
                strCookieVal = System.Web.HttpUtility.UrlDecode(TiKu.Common.DES.Decode(strCookieVal, TiKu.Common.Constants.Encrypt.DES.ENCRYPT_KEY));
                model = TiKu.Common.JsonHelper.MapToObject<Model.tb_Agent>(strCookieVal);
            }
            catch
            {
                System.Web.HttpContext.Current.Response.Write("<script type=\"text/javascript\">alert(\"登陆超时，请重新登陆！\");top.location.href=\"/login.aspx\";</script>");
                System.Web.HttpContext.Current.Response.End();
            }
            return model;
        }

        /// <summary>
        /// 退出系统登录
        /// </summary>
        /// <returns></returns>
        public void ExitSystem(Action _callBack)
        {
            System.Web.HttpCookie cookie = System.Web.HttpContext.Current.Request.Cookies[TiKu.Common.Constants.AGENT.AGENT_SESSION_ID];
            if (null == cookie)
            {
                return;
            }
            cookie.Expires = DateTime.Now.AddMonths(-1);
            System.Web.HttpContext.Current.Response.AppendCookie(cookie);
            if (_callBack != null)
            {
                _callBack();
            }
        }

        /// <summary>
        /// 通过用户名和密码获取代理商信息
        /// </summary>
        /// <param name="AgentName">代理商登陆名</param>
        /// <param name="AgentPwd">登陆密码</param>
        /// <returns></returns>
        public Model.tb_Agent GetAgentInfoByNameAndPwd(string AgentName, string AgentPwd)
        {
            SqlParameter[] parameters = { 
                                        new SqlParameter("@AgentName",SqlDbType.VarChar,60),
                                        new SqlParameter("@AgentPwd",SqlDbType.VarChar,32)
                                        };
            parameters[0].Value = AgentName;
            parameters[1].Value = AgentPwd;
            Model.tb_Agent model = null;
            //获取列表
            List<Model.tb_Agent> list = GetList(1,
                                                " And AgentName=@AgentName And AgentPwd=@AgentPwd",
                                                null,
                                                parameters);
            model = list.Count > 0 ? list[0] : null;
            return model;
        }


    }
}