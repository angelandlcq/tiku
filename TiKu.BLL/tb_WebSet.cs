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
 * className:网站设置信息
 * author:beisha
 * date:
 * modifyBy:
 * modifyOn:
 * mark:
 * 
 * ================================================================================================*/
namespace TiKu.BLL
{
    //设置
    public partial class tb_WebSet
    {

        /// <summary>
        /// 表名
        /// </summary>
        private readonly string TableName = "tb_WebSet";

        /// <summary>
        /// 获取网站基本信息
        /// </summary>
        /// <returns></returns>
        public static TiKu.Model.tb_WebSet WebSiteInfo
        {
            get { return new BLL.tb_WebSet().GetWebSiteInfo(); }
        }
        /// <summary>
        /// 获取根域名
        /// </summary>
        public static string Domain
        {
            get
            {
                string strDomain = WebSiteInfo.Domain;
                if (string.IsNullOrEmpty(strDomain))
                {
                    strDomain = System.Web.HttpContext.Current.Request.Url.DnsSafeHost;
                }
                strDomain = strDomain.ToLower().Replace("www.", string.Empty);
                return strDomain;
            }
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(TiKu.Model.tb_WebSet model)
        {
            return EntityQuery<TiKu.Model.tb_WebSet>.Instance.Add(model);
        }

        /// <summary>
        ///修改
        /// </summary>
        public bool Update(TiKu.Model.tb_WebSet model)
        {
            if (EntityQuery<TiKu.Model.tb_WebSet>.Instance.Update(model))
            {
                //移除缓存
                TiKu.Common.CacheHelper.RemoveCache(TiKu.Common.Constants.CACHE_KEY.WEBSITESET_CACHE_KEY);
                return true;
            }
            return false;
        }

        /// <summary>
        ///删除
        /// </summary>
        public int Delete(TiKu.Model.tb_WebSet model)
        {
            return EntityQuery<TiKu.Model.tb_WebSet>.Instance.Delete(model);
        }

        /// <summary>
        /// 获取网站实体信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public TiKu.Model.tb_WebSet GetWebSiteInfo()
        {
            if (TiKu.Common.CacheHelper.IsExistsCahce(TiKu.Common.Constants.CACHE_KEY.WEBSITESET_CACHE_KEY))
            {
                return TiKu.Common.CacheHelper.GetCacheValue<TiKu.Model.tb_WebSet>(TiKu.Common.Constants.CACHE_KEY.WEBSITESET_CACHE_KEY);
            }
            TiKu.Model.tb_WebSet model = GetList(1,
                                                "ID=1",
                                                null,
                                                null)[0];
            TiKu.Common.CacheHelper.SaveAlway(TiKu.Common.Constants.CACHE_KEY.WEBSITESET_CACHE_KEY, model);
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
        public List<TiKu.Model.tb_WebSet> GetList(int top,
            string where,
            string orders,
            IEnumerable parameters)
        {
            List<TiKu.Model.tb_WebSet> list = TiKu.DataDriver.Entity.EntityQuery<TiKu.Model.tb_WebSet>.Instance.GetList(top,
                                                                               "ID,WebName,ICP,IsEnableAdminLog,IsEnableUserLog,Company,IsEnableAgentLog,WebState,IsEnableDelete,Logo,Domain,Smtp,SmtpPort,EmaiAccount,EmailPwd",
                                                                               "tb_WebSet",
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



    }
}