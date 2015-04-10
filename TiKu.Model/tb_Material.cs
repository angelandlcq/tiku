/* 
说 明：阅读简答信息表

备 注： 本类由实体类生成工具(Ver 4.1)自动生成,
了解更多请登录http://my.oschina.net/lichaoqiang

日 期：2015-04-02 18:58
*/
using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using TiKu.DataDriver.Entity;
namespace TiKu.Model
{
    //阅读简答信息表
    [Serializable()]
    public class tb_Material : EntityBase
    {

        /// <summary>
        /// 构造器
        /// </summary>
        public tb_Material()
        {
            TableName = "tb_Material";
            //主键
            List<string> keys = new List<string>();
            Identity = "ID";
            keys.Add("ID");
            PrimaryKeys = keys;
            //字段长度
            StringFieldSize["tb_Material_ID"] = 8;
            StringFieldSize["tb_Material_Context"] = -1;
            StringFieldSize["tb_Material_CreatedOn"] = 8;
            StringFieldSize["tb_Material_CreatedBy"] = 4;
            StringFieldSize["tb_Material_ModifyOn"] = 8;
            StringFieldSize["tb_Material_ModifyBy"] = 4;
        }



        /// <summary>
        /// 编号
        /// </summary>		
        public int ID
        {
            get { return GetPropertyValue<int>("ID"); }
            set { SetPropertyValue("ID", value); }
        }
        /// <summary>
        /// 阅读内容
        /// </summary>		
        public string Context
        {
            get { return GetPropertyValue<string>("Context"); }
            set { SetPropertyValue("Context", value); }
        }
        /// <summary>
        /// 创建时间
        /// </summary>		
        public DateTime CreatedOn
        {
            get { return GetPropertyValue<DateTime>("CreatedOn"); }
            set { SetPropertyValue("CreatedOn", value); }
        }
        /// <summary>
        /// CreatedBy
        /// </summary>		
        public int CreatedBy
        {
            get { return GetPropertyValue<int>("CreatedBy"); }
            set { SetPropertyValue("CreatedBy", value); }
        }
        /// <summary>
        /// ModifyOn
        /// </summary>		
        public DateTime ModifyOn
        {
            get { return GetPropertyValue<DateTime>("ModifyOn"); }
            set { SetPropertyValue("ModifyOn", value); }
        }
        /// <summary>
        /// ModifyBy
        /// </summary>		
        public int ModifyBy
        {
            get { return GetPropertyValue<int>("ModifyBy"); }
            set { SetPropertyValue("ModifyBy", value); }
        }

    }
}

