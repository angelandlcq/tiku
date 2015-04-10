using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/*****************************************************************************
 * 
 * className:提供缓存应用的的公共类
 * author:李朝强
 * date:2015/03/3
 * mark:
 * 
 * ***************************************************************************/
namespace TiKu.Common
{
    public class CacheHelper
    {
        #region 成员
        /// <summary>
        /// 默认过期时间(30分钟)
        /// </summary>
        private static DateTime Expire
        {
            get
            {
                return DateTime.Now.AddMinutes(30);
            }
        }
        #endregion

        #region 保存缓存对象
        /// <summary>
        /// 保存缓存对象
        /// </summary>
        /// <param name="name">缓存名</param>
        /// <param name="value">值</param>
        public static void SaveCache(string name, object value)
        {
            if (System.Web.HttpRuntime.Cache[name] != null)
            {
                System.Web.HttpRuntime.Cache[name] = value;
                return;
            }
            System.Web.HttpRuntime.Cache.Insert(name,
                                                value,
                                                null,
                                                Expire,
                                                System.Web.Caching.Cache.NoSlidingExpiration);
        }
        /// <summary>
        /// 缓存数据，
        /// </summary>
        /// <param name="name">缓存Name</param>
        /// <param name="value">缓存数据</param>
        /// <param name="dependency">依赖（可空)</param>
        public static void SaveCache(string name,
                                     object value,
                                      System.Web.Caching.CacheDependency dependency)
        {
            if (System.Web.HttpRuntime.Cache[name] != null)
            {
                System.Web.HttpRuntime.Cache[name] = value;
                return;
            }
            System.Web.HttpRuntime.Cache.Insert(name,
                                                value,
                                                dependency,
                                                Expire,
                                                System.Web.Caching.Cache.NoSlidingExpiration);
        }
        /// <summary>
        /// 缓存对象
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="dependency"></param>
        /// <param name="expires"></param>
        public static void SaveCache(string name,
                                     object value,
                                     System.Web.Caching.CacheDependency dependency,
                                     TimeSpan expires)
        {
            if (System.Web.HttpRuntime.Cache[name] != null)
            {
                System.Web.HttpRuntime.Cache[name] = value;
                return;
            }
            System.Web.HttpRuntime.Cache.Insert(name,
                                                value,
                                                dependency,
                                                DateTime.Now.Add(expires),
                                                System.Web.Caching.Cache.NoSlidingExpiration);
        }
        #endregion

        #region 获取缓存值
        /// <summary>
        ///  获取缓存值
        /// </summary>
        /// <typeparam name="T">返回类型</typeparam>
        /// <param name="name">缓存key</param>
        /// <returns>返回指定类型的值</returns>
        public static T GetCacheValue<T>(string name)
        {
            if (System.Web.HttpRuntime.Cache[name] == null)
            {
                return default(T);
            }
            return (T)System.Web.HttpRuntime.Cache[name];
        }
        #endregion

        #region 检查缓存对象是否存在
        /// <summary>
        /// 检查缓存对象是否存在
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool IsExistsCahce(string name)
        {
            return (System.Web.HttpRuntime.Cache[name] != null);
        }
        #endregion

        #region 长驻缓存
        /// <summary>
        ///长驻缓存
        /// </summary>
        /// <param name="name">缓存名</param>
        /// <param name="value">缓存对象</param>
        public static void SaveAlway(string name, object value)
        {
            System.Web.HttpRuntime.Cache[name] = value;
        }
        #endregion

        #region 从缓存中移除指定的对象
        /// <summary>
        /// 从缓存中移除
        /// </summary>
        /// <param name="name"></param>
        public static void RemoveCache(string name)
        {
            if (IsExistsCahce(name))
            {
                System.Web.HttpRuntime.Cache.Remove(name);
            }
        }
        #endregion

        #region 清除所有缓存
        /// <summary>
        /// 清除所有缓存
        /// </summary>
        public static void Clear()
        {
            //循环删除
            System.Collections.IDictionaryEnumerator iEnumerator = System.Web.HttpRuntime.Cache.GetEnumerator();
            while (iEnumerator.MoveNext())
            {
                System.Web.HttpRuntime.Cache.Remove(iEnumerator.Key.ToString());
            }
        }
        #endregion
    }
}
