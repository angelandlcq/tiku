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
    //广告信息表
    [Serializable()]
    public class tb_Advertor : EntityBase
    {

        /// <summary>
        /// 构造器
        /// </summary>
        public tb_Advertor()
        {
            TableName = "tb_Advertor";
            //主键
            List<string> keys = new List<string>();
            keys.Add("ID");
            Identity = "ID";
            PrimaryKeys = keys;
            //字段长度
            StringFieldSize["tb_Advertor_ID"] = -1;
            StringFieldSize["tb_Advertor_APID"] = 4;
            StringFieldSize["tb_Advertor_AdText"] = 100;
            StringFieldSize["tb_Advertor_AdUrl"] = 200;
            StringFieldSize["tb_Advertor_Orders"] = 4;
            StringFieldSize["tb_Advertor_ImageUrl"] = 200;
            StringFieldSize["tb_Advertor_State"] = 4;
            StringFieldSize["tb_Advertor_AddTime"] = 8;
            StringFieldSize["tb_Advertor_CreatedBy"] = 4;
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
        /// APID
        /// </summary>		
        public int APID
        {
            get { return GetPropertyValue<int>("APID"); }
            set { SetPropertyValue("APID", value); }
        }
        /// <summary>
        /// AdText
        /// </summary>		
        public string AdText
        {
            get { return GetPropertyValue<string>("AdText"); }
            set { SetPropertyValue("AdText", value); }
        }
        /// <summary>
        /// AdUrl
        /// </summary>		
        public string AdUrl
        {
            get { return GetPropertyValue<string>("AdUrl"); }
            set { SetPropertyValue("AdUrl", value); }
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
        /// ImageUrl
        /// </summary>		
        public string ImageUrl
        {
            get { return GetPropertyValue<string>("ImageUrl"); }
            set { SetPropertyValue("ImageUrl", value); }
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
        /// AddTime
        /// </summary>		
        public DateTime AddTime
        {
            get { return GetPropertyValue<DateTime>("AddTime"); }
            set { SetPropertyValue("AddTime", value); }
        }
        /// <summary>
        /// CreatedBy
        /// </summary>		
        public int CreatedBy
        {
            get { return GetPropertyValue<int>("CreatedBy"); }
            set { SetPropertyValue("CreatedBy", value); }
        }

    }
}

