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
    //广告位信息表
    [Serializable()]
    public class tb_AdvertorPlace : EntityBase
    {

        /// <summary>
        /// 构造器
        /// </summary>
        public tb_AdvertorPlace()
        {
            TableName = "tb_AdvertorPlace";
            //主键
            List<string> keys = new List<string>();
            keys.Add("ID");
            PrimaryKeys = keys;
            Identity = "ID";
            //字段长度
            StringFieldSize["tb_AdvertorPlace_ID"] = 4;
            StringFieldSize["tb_AdvertorPlace_APName"] = 100;
            StringFieldSize["tb_AdvertorPlace_Orders"] = 4;
            StringFieldSize["tb_AdvertorPlace_State"] = 4;
            StringFieldSize["tb_AdvertorPlace_APDescription"] = 600;
            StringFieldSize["tb_AdvertorPlace_Del"] = 4;
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
        /// 广告位名称
        /// </summary>		
        public string APName
        {
            get { return GetPropertyValue<string>("APName"); }
            set { SetPropertyValue("APName", value); }
        }
        /// <summary>
        /// 排序
        /// </summary>		
        public int Orders
        {
            get { return GetPropertyValue<int>("Orders"); }
            set { SetPropertyValue("Orders", value); }
        }
        /// <summary>
        /// 状态
        /// </summary>		
        public int State
        {
            get { return GetPropertyValue<int>("State"); }
            set { SetPropertyValue("State", value); }
        }
        /// <summary>
        /// 描述
        /// </summary>		
        public string APDescription
        {
            get { return GetPropertyValue<string>("APDescription"); }
            set { SetPropertyValue("APDescription", value); }
        }
        /// <summary>
        /// 删除标示
        /// </summary>		
        public int Del
        {
            get { return GetPropertyValue<int>("Del"); }
            set { SetPropertyValue("Del", value); }
        }

    }
}

