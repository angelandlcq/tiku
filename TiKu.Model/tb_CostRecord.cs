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
    //经销商消费记录
    [Serializable()]
    public class tb_CostRecord : EntityBase
    {

        /// <summary>
        /// 构造器
        /// </summary>
        public tb_CostRecord()
        {
            TableName = "tb_CostRecord";
            //主键
            List<string> keys = new List<string>();
            keys.Add("ID");
            PrimaryKeys = keys;
            //字段长度
            StringFieldSize["tb_CostRecord_ID"] = 4;
            StringFieldSize["tb_CostRecord_Amount"] = 8;
            StringFieldSize["tb_CostRecord_AgentID"] = 8;
            StringFieldSize["tb_CostRecord_Note"] = 300;
            StringFieldSize["tb_CostRecord_AddDate"] = 8;
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
        /// Amount
        /// </summary>		
        public decimal Amount
        {
            get { return GetPropertyValue<decimal>("Amount"); }
            set { SetPropertyValue("Amount", value); }
        }
        /// <summary>
        /// AgentID
        /// </summary>		
        public long AgentID
        {
            get { return GetPropertyValue<long>("AgentID"); }
            set { SetPropertyValue("AgentID", value); }
        }
        /// <summary>
        /// Note
        /// </summary>		
        public string Note
        {
            get { return GetPropertyValue<string>("Note"); }
            set { SetPropertyValue("Note", value); }
        }
        /// <summary>
        /// AddDate
        /// </summary>		
        public DateTime AddDate
        {
            get { return GetPropertyValue<DateTime>("AddDate"); }
            set { SetPropertyValue("AddDate", value); }
        }

    }
}

