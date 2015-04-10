using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/*=================================================================
 * 
 * 
 * 说 明：自定义异常类
 * 作 者：李朝强
 * 
 * =============================================================*/
namespace TiKu.Common
{
    public class TiKuException : Exception
    {

        /// <summary>
        /// 构造
        /// </summary>
        public TiKuException()
        {

        }

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="message">消息</param>
        public TiKuException(object message)
        {
            //记录地址
            TiKu.Common.LogUtil.Error(message, this);
        }

    }
}
