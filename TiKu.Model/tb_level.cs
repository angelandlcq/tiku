/* 
 本类由实体类生成工具(Ver 4.1)自动生成
 http://www.oschina.net/lichaoqiang/
 2015-2-27 13:42:25
*/
using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using TiKu.DataDriver.Entity;
namespace TiKu.Model
{
    //推荐，每周精选等板块
    [Serializable()]
    public class tb_level : EntityBase
    {

        /// <summary>
        /// 构造器
        /// </summary>
        public tb_level()
        {
            TableName = "tb_level";
            //主键
            List<string> keys = new List<string>();
            keys.Add("ID");
            PrimaryKeys = keys;
            Identity = "ID";
            //字段长度
            StringFieldSize["tb_level_ID"] = 8;
            StringFieldSize["tb_level_Names"] = 60;
            StringFieldSize["tb_level_TableName"] = 30;
            StringFieldSize["tb_level_Orders"] = 4;
            StringFieldSize["tb_level_IsRecommand"] = 4;
            StringFieldSize["tb_level_State"] = 4;
            StringFieldSize["tb_level_Del"] = 4;
        }



        /// <summary>
        /// ID
        /// </summary>		
        public int ID
        {
            get { return GetPropertyValue<int>("ID"); }
            set { SetPropertyValue("ID", value); }
        }
        /// <summary>
        /// Names
        /// </summary>		
        public string Names
        {
            get { return GetPropertyValue<string>("Names"); }
            set { SetPropertyValue("Names", value); }
        }
        /// <summary>
        /// TableName
        /// </summary>		
        public string ForTableName
        {
            get { return GetPropertyValue<string>("TableName"); }
            set { SetPropertyValue("TableName", value); }
        }

        /// <summary>
        /// 值
        /// </summary>
        public string Val
        {
            get { return GetPropertyValue<string>("Val"); }
            set { SetPropertyValue("Val", value); }
        }

        /// <summary>
        /// Orders
        /// </summary>		
        public int Orders
        {
            get { return GetPropertyValue<int>("Orders"); }
            set { SetPropertyValue("Orders", value); }
        }
        /// <summary>
        /// IsRecommand
        /// </summary>		
        public int IsRecommand
        {
            get { return GetPropertyValue<int>("IsRecommand"); }
            set { SetPropertyValue("IsRecommand", value); }
        }
        /// <summary>
        /// State
        /// </summary>		
        public int State
        {
            get { return GetPropertyValue<int>("State"); }
            set { SetPropertyValue("State", value); }
        }
        /// <summary>
        /// Del
        /// </summary>		
        public int Del
        {
            get { return GetPropertyValue<int>("Del"); }
            set { SetPropertyValue("Del", value); }
        }

    }
}

