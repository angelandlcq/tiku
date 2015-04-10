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
    //专业科目
    [Serializable()]
    public class tb_CourseInfo : EntityBase
    {

        /// <summary>
        /// 构造器
        /// </summary>
        public tb_CourseInfo()
        {
            TableName = "tb_CourseInfo";
            //主键
            List<string> keys = new List<string>();
            PrimaryKeys = keys;
            Identity = "ID";
            //字段长度
            StringFieldSize["tb_CourseInfo_ID"] = 4;
            StringFieldSize["tb_CourseInfo_Names"] = 60;
            StringFieldSize["tb_CourseInfo_CategoryID"] = 4;
            StringFieldSize["tb_CourseInfo_Orders"] = 4;
            StringFieldSize["tb_CourseInfo_Del"] = 4;
            StringFieldSize["tb_CourseInfo_State"] = 4;
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
        /// CategoryID
        /// </summary>		
        public int CategoryID
        {
            get { return GetPropertyValue<int>("CategoryID"); }
            set { SetPropertyValue("CategoryID", value); }
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
        /// Del
        /// </summary>		
        public int Del
        {
            get { return GetPropertyValue<int>("Del"); }
            set { SetPropertyValue("Del", value); }
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
        /// 值，调用别名
        /// </summary>
        public string Val
        {
            get { return GetPropertyValue<string>("Val"); }
            set { SetPropertyValue("Val", value); }
        }

        /// <summary>
        /// 备注说明
        /// </summary>
        public string Remark
        {
            get { return GetPropertyValue<string>("Remark"); }
            set { SetPropertyValue("Remark", value); }
        }

    }
}

