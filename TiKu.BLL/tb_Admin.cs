#region using directiry
using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Collections;
using TiKu.DataDriver.Entity;
using System.Net;
#endregion
/*=================================================================================================
 * 
 * className:管理员（BLL)
 * author:beisha
 * date:
 * modifyBy:
 * modifyOn:
 * mark:
 * 
 * ================================================================================================*/
namespace TiKu.BLL
{
    //Admin管理员
    public partial class tb_Admin
    {

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(TiKu.Model.tb_Admin model)
        {
            return EntityQuery<TiKu.Model.tb_Admin>.Instance.Add(model);
        }

        /// <summary>
        ///修改
        /// </summary>
        public bool Update(TiKu.Model.tb_Admin model)
        {
            return EntityQuery<TiKu.Model.tb_Admin>.Instance.Update(model);
        }

        /// <summary>
        ///删除
        /// </summary>
        public int Delete(TiKu.Model.tb_Admin model)
        {
            return EntityQuery<TiKu.Model.tb_Admin>.Instance.Delete(model);
        }

        /// <summary>
        /// 业务删除
        /// </summary>
        /// <param name="ID">要删除的ID</param>
        /// <param name="ActionID">操作者编号</param>
        /// <returns></returns>
        public bool DoDel(int ID, int ActionID)
        {
            //验证是否启用逻辑删除功能
            if (BLL.tb_WebSet.WebSiteInfo.IsEnableDelete > 0)
            {
                //声明实体
                Model.tb_Admin model = new Model.tb_Admin();
                model.ID = ID;
                model.Del = TiKu.Common.Constants.Common.DELETE;
                model.ModifyBy = ActionID;
                model.ModifyOn = DateTime.Now;
                return Update(model);
            }
            //物理删除
            return EntityQuery<TiKu.Model.tb_Admin>.Instance.Delete<int>(ID) > 0;
        }

        /// <summary>
        /// 获取单个实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public TiKu.Model.tb_Admin GetModel(int ID)
        {
            TiKu.Model.tb_Admin model = new TiKu.Model.tb_Admin();
            model.ID = ID;
            EntityQuery<TiKu.Model.tb_Admin>.Instance.Fill(model);
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
        public List<TiKu.Model.tb_Admin> GetList(int top,
            string where,
            string orders,
            IEnumerable parameters)
        {
            List<TiKu.Model.tb_Admin> list = TiKu.DataDriver.Entity.EntityQuery<TiKu.Model.tb_Admin>.Instance.GetList(top,
                                                                               "ID,AdminName,AdminPwd,TrueName,RoleID,State,CreatedOn,CreatedBy,ModifyOn,ModifyBy,LastTime,Del",
                                                                               "tb_Admin",
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
            return TiKu.DataDriver.AdoHelper.Count(where, "tb_Admin", parameters);
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
        public List<Model.tb_Admin> GetListPager(int startIndex,
                                                    int endIndex,
                                                    string where,
                                                    string orders,
                                                    IEnumerable parameters,
                                                    out int iRowCount)
        {
            iRowCount = 0;
            StringBuilder stbCmdText = new StringBuilder();
            StringBuilder stbCmdCount = new StringBuilder();
            stbCmdCount.Append("SELECT COUNT(1) AS Total FROM [tb_Admin] a left join [tb_AdminRole] r On a.RoleID=r.ID  WHERE 1=1 ");
            stbCmdText.Append("SELECT * FROM (");
            stbCmdText.Append("SELECT Row_Number() over(order by a.ID desc) as Row,a.ID,r.RoleName,AdminName,AdminPwd,TrueName,RoleID,a.State,a.CreatedOn,a.CreatedBy,a.ModifyOn,a.ModifyBy FROM [tb_Admin] a left join [tb_AdminRole] r On a.RoleID=r.ID WHERE 1=1 ");
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
            List<Model.tb_Admin> list = new List<Model.tb_Admin>();
            string strCmdText = stbCmdText + ";" + stbCmdCount;
            using (IDataReader dataReader = TiKu.DataDriver.AdoHelper.ExcuteDataReader(strCmdText, parameters))
            {
                while (dataReader.Read())
                {
                    Model.tb_Admin model = new Model.tb_Admin();
                    for (int i = 1; i < dataReader.FieldCount; i++)
                    {
                        model.SetPropertyValue(dataReader.GetName(i), dataReader.GetValue(i));
                    }
                    model.Role = new Model.tb_AdminRole();
                    model.Role.RoleName = dataReader["RoleName"].ToString();
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
        /// 管理员登陆
        /// </summary>
        /// <param name="strAdminName">管理员</param>
        /// <param name="strAdminPwd">密码</param>
        /// <param name="isRemeber">是否记住密码</param>
        /// <param name="error">输出：错误信息</param>
        /// <returns></returns>
        public bool CheckAdminSignIn(string strAdminName,
                                     string strAdminPwd,
                                     bool isRemeber,
                                     string defaultUrl,
                                     ref string error)
        {
            //Model
            TiKu.Model.tb_Admin model = new Model.tb_Admin();
            SqlParameter[] parameters = 
            {
                new SqlParameter("@AdminName",SqlDbType.VarChar,30),
                new SqlParameter("@AdminPwd",SqlDbType.VarChar,32)
            };
            //MD5加密
            strAdminPwd = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(strAdminPwd, "md5");
            parameters[0].Value = strAdminName;
            parameters[1].Value = strAdminPwd;
            List<TiKu.Model.tb_Admin> list = GetList(1,
                                                     "AdminName=@AdminName And AdminPwd=@AdminPwd",
                                                     null,
                                                     parameters);
            //2>验证登陆》》》》》》》》》》》》》》》》》》》》》》
            if (list.Count > 0)
            {
                model = list.FirstOrDefault();
                if (model.Del == TiKu.Common.Constants.Common.DELETE)
                {
                    error = "账号不存在或登陆名和密码错误！";
                    return false;
                }
                //2.1>账号锁定
                if (model.State == TiKu.Common.Constants.ADMIN.STATE.LOCK)
                {
                    error = "账号已锁定，请联系管理员！";
                    return false;
                }
                //2.2>未启用
                if (model.State == TiKu.Common.Constants.ADMIN.STATE.UNENABLE)
                {
                    error = "账号不存在或未启用！";
                    return false;
                }
                //2.3>登陆成功
                if (model.State == TiKu.Common.Constants.ADMIN.STATE.ACTIVE)
                {
                    //2.3.1>写入登陆信息(Cookie)
                    object objCookie = new
                    {
                        AdminName = strAdminName,
                        AdminPwd = strAdminPwd,
                        LastTime = model.LastTime,
                        ID = model.ID
                    };
                    string strJson = System.Web.HttpUtility.UrlEncode(TiKu.Common.JsonHelper.ToJson(objCookie));
                    strJson = TiKu.Common.DES.Encode(strJson, TiKu.Common.Constants.Encrypt.DES.ENCRYPT_KEY);
                    TimeSpan expire = isRemeber ? new TimeSpan(15, 0, 0, 0) : new TimeSpan(7, 0, 0, 0);
                    TiKu.Common.CookieUtil.WriteCookie(TiKu.Common.Constants.ADMIN.COOKIE.COOKIE_SESSION,
                                                       strJson,
                                                       expire,
                                                       true,
                                                       tb_WebSet.Domain);
                    //2.3.1>记录登登录日志
                    TiKu.Common.Logger.AdminLogger.Info(model.ID,
                                                        "登录",
                                                        "Q",
                                                        strAdminName + "管理员登陆成功！");
                    //2.3.2>更新最后登录日期
                    Model.tb_Admin admin = new Model.tb_Admin();
                    admin.ID = model.ID;
                    admin.LastTime = DateTime.Now;
                    Update(admin);

                    System.Web.HttpContext.Current.Response.Redirect(defaultUrl);//跳转至指定页
                    return true;
                }
            }
            else
            {
                error = "登陆名或密码错误！";
                return false;
            }
            return false;
        }

        /// <summary>
        /// 根据用户名或密码获取管理员信息
        /// </summary>
        /// <param name="AdminName"></param>
        /// <param name="AdminPwd"></param>
        /// <returns></returns>
        public Model.tb_Admin GetAdminInfoByNameAndPwd(string AdminName, string AdminPwd)
        {
            string strCmdText = @"SELECT Top(1) [ID],[AdminName],[TrueName]  FROM [tb_Admin] WHERE [AdminName]=@AdminName And [AdminPwd]=@AdminPwd;";
            SqlParameter[] parameters = { 
                                       new SqlParameter("@AdminName",SqlDbType.VarChar,60),
                                       new SqlParameter("@AdminPwd",SqlDbType.VarChar,32),
                                        };
            parameters[0].Value = AdminName;
            parameters[1].Value = AdminPwd;
            Model.tb_Admin model = null;
            using (IDataReader dataReader = TiKu.DataDriver.AdoHelper.ExcuteDataReader(strCmdText, parameters))
            {
                if (dataReader.Read())
                {
                    model = new Model.tb_Admin();
                    model.ID = Convert.ToInt32(dataReader["ID"]);
                    model.AdminName = dataReader["AdminName"].ToString();
                    model.TrueName = dataReader["TrueName"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        ///验证用户是否登录
        /// </summary>
        public bool CheckIsLogin()
        {
            //验证是否登录
            if (TiKu.Common.CookieUtil.IsExistsCookie(TiKu.Common.Constants.ADMIN.COOKIE.COOKIE_SESSION))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 检查用户名是否存在
        /// </summary>
        /// <param name="strAdminName">登录名</param>
        /// <returns></returns>
        public bool CheckIsExistsAdminName(string strAdminName)
        {
            SqlParameter[] parameters = { 
                                        new SqlParameter("@AdminName",SqlDbType.VarChar,60)
                                        };
            parameters[0].Value = strAdminName;
            int iCount = TiKu.DataDriver.AdoHelper.Count(" And  AdminName=@AdminName ",
                                              "tb_Admin",
                                              parameters);
            return (iCount > 0);
        }

        /// <summary>
        /// 退出系统
        /// </summary>
        public void ExitSystem(Action _callBack)
        {
            System.Web.HttpCookie cookie = System.Web.HttpContext.Current.Request.Cookies[TiKu.Common.Constants.ADMIN.COOKIE.COOKIE_SESSION];
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

    }
}