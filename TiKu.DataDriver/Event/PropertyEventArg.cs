using System;
using System.Collections.Generic;
using System.Data;
using System.Collections;
using System.Linq;
using System.Text;
/*-=-=-=-=-=-=-=-=-=-=-=-=-=-=--=-=-=-=-=--=-=--=-=--=-=--=-=--=-=--=-=--=-=--=-=--=-=--=-=--=-=--=-
 * 
 * 
 * 说  明：属性改变事件参数
 * 作  者：李朝强
 * 修  改：
 * 日  期：2015/01/10
 * 备  注：
 * 
 * 
 * -=-=--=-=--=-=--=-=--=-=--=-=--=-=--=-=--=-=--=-=--=-=--=-=--=-=--=-=--=-=--=-==--=-=--=-=--=-=-*/
namespace TiKu.DataDriver.Event
{
    public class PropertyEventArg : EventArgs
    {
        /// <summary>
        /// 获取或设置属性名
        /// </summary>
        public string PropertyName { get; set; }

        /// <summary>
        /// 获取或设置属性值
        /// </summary>
        public object PropertyValue { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="PropertyName">属性名</param>
        /// <param name="PropertyValue">属性值</param>
        public PropertyEventArg(string __PropertyName, object __PropertyValue)
        {
            PropertyName = __PropertyName;
            PropertyValue = __PropertyValue;
        }
    }
}
