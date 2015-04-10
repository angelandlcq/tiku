using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/**************************************************************************
 * 
 * Author:lichaoqiang@sina.cn
 * Date:
 * Description:json数据操作类
 * Mark:
 * 
 * **********************************************************************/
namespace TiKu.Common
{
    public class JsonHelper
    {

        /// <summary>
        /// 把对象序列号成json字符串
        /// </summary>
        /// <param name="data">对象</param>
        /// <returns></returns>
        public static string ToJson(object data)
        {
            return LitJson.JsonMapper.ToJson(data);
        }

        /// <summary>
        /// 根据json字符串，反序列化为对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static T MapToObject<T>(string json)
        {
            return LitJson.JsonMapper.ToObject<T>(json);
        }
    }
}
