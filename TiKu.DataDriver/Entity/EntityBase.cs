using System;
using System.Collections.Generic;
using System.Data;
using System.Collections;
using System.Linq;
using System.Text;
using TiKu.DataDriver.Event;
/*-=-=-=-=-=-=-=-=-=-=-=-=-=-=--=-=-=-=-=--=-=--=-=--=-=--=-=--=-=--=-=--=-=--=-=--=-=--=-=--=-=--=-
 * 
 * 
 * 说  明：实体抽象基类（base)
 * 作  者：李朝强
 * 修  改：
 * 日  期：2015/01/10
 * 备  注：
 * 
 * 
 * -=-=--=-=--=-=--=-=--=-=--=-=--=-=--=-=--=-=--=-=--=-=--=-=--=-=--=-=--=-=--=-==--=-=--=-=--=-=-*/
namespace TiKu.DataDriver.Entity
{

    /// <summary>
    /// 实体基类
    /// </summary>
    [Serializable]
    public abstract class EntityBase
    {
        #region Base Member
        /// <summary>
        ///字段和值
        /// </summary>
        public Dictionary<string, object> FieldValue { get; protected set; }

        /// <summary>
        ///主键
        /// </summary>
        public List<string> PrimaryKeys { get; protected set; }

        /// <summary>
        /// 标识列
        /// </summary>
        public string Identity { get; protected set; }

        /// <summary>
        /// 获取实体对应的数据库表名
        /// </summary>
        public string TableName { get; protected set; }

        /// <summary>
        /// 字段大小
        /// </summary>
        public Dictionary<string, int> StringFieldSize { get; protected set; }
        #endregion

        #region Event
        /// <summary>
        /// 属性改变事件处理句柄
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void PropertyChangedHandler(object sender, PropertyEventArg e);

        /// <summary>
        /// 属性委托处理句柄
        /// </summary>
        private PropertyChangedHandler _OnPropertyChanged = null;

        /// <summary>
        /// 对象属性改变时发生事件
        /// </summary>
        public event PropertyChangedHandler OnPropertyChanged
        {
            add { _OnPropertyChanged += value; }
            remove { _OnPropertyChanged -= value; }
        }
        #endregion

        #region  构造器
        /// <summary>
        /// 构造器
        /// </summary>
        public EntityBase()
        {
            //初始化数据字典
            FieldValue = new Dictionary<string, object>();
            //字段大小
            StringFieldSize = new Dictionary<string, int>();
        }
        #endregion

        #region 索引器
        /// <summary>
        /// 获取或设置实体属性
        /// </summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        public object this[string name]
        {
            get { return FieldValue[name]; }
            set { FieldValue[name] = value; }
        }
        #endregion

        #region 设置属性值
        /// <summary>
        /// 设置属性值
        /// </summary>
        /// <param name="name">属性名</param>
        /// <param name="value">属性值</param>
        public void SetPropertyValue(string name, object value)
        {
            FieldValue[name] = value;
            //属性改变事件
            if (_OnPropertyChanged != null)
            {
                TiKu.DataDriver.Event.PropertyEventArg e = new PropertyEventArg(name, value);
                _OnPropertyChanged(this, e);
            }
        }
        #endregion

        #region 获取属性值
        /// <summary>
        /// 获取属性值
        /// </summary>
        /// <param name="name">属性名</param>
        /// <returns></returns>
        protected T GetPropertyValue<T>(string name)
        {
            if (!FieldValue.ContainsKey(name) ||
                null == FieldValue[name] ||
                FieldValue[name] == DBNull.Value)
            {
                return default(T);
            }
            return (T)FieldValue[name];
        }
        #endregion

        /// <summary>
        /// 创建实例
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <returns></returns>
        public T CreateInstance<T>()
            where T : EntityBase, new()
        {
            return new T();
        }
    }
}
