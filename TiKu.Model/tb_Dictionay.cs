/* 
说 明：tb_Dictionay

备 注： 本类由实体类生成工具(Ver 4.1)自动生成,
了解更多请登录http://my.oschina.net/lichaoqiang

日 期：2015-03-24 16:08
*/
using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using TiKu.DataDriver.Entity;
namespace TiKu.Model
{
    //tb_Dictionay
    [Serializable()]
    public class tb_Dictionay : EntityBase
    {

        /// <summary>
        /// 构造器
        /// </summary>
        public tb_Dictionay()
        {
            TableName = "tb_Dictionay";
            //主键
            List<string> keys = new List<string>();
            Identity = "ID";
            keys.Add("ID");
            PrimaryKeys = keys;
            //字段长度
            StringFieldSize["tb_Dictionay_ID"] = 8;
            StringFieldSize["tb_Dictionay_Names"] = 60;
            StringFieldSize["tb_Dictionay_Data"] = 600;
            StringFieldSize["tb_Dictionay_Code"] = 30;
            StringFieldSize["tb_Dictionay_State"] = 4;
            StringFieldSize["tb_Dictionay_Description"] = 600;
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
        /// 字典名称
        /// </summary>		
        public string Names
        {
            get { return GetPropertyValue<string>("Names"); }
            set { SetPropertyValue("Names", value); }
        }
        /// <summary>
        /// 字典值
        /// </summary>		
        public string Data
        {
            get { return GetPropertyValue<string>("Data"); }
            set { SetPropertyValue("Data", value); }
        }
        /// <summary>
        /// 编号
        /// </summary>		
        public string Code
        {
            get { return GetPropertyValue<string>("Code"); }
            set { SetPropertyValue("Code", value); }
        }
        /// <summary>
        /// 是否启用
        /// </summary>		
        public int State
        {
            get { return GetPropertyValue<int>("State"); }
            set { SetPropertyValue("State", value); }
        }
        /// <summary>
        /// 描述
        /// </summary>		
        public string Description
        {
            get { return GetPropertyValue<string>("Description"); }
            set { SetPropertyValue("Description", value); }
        }

    }
}

