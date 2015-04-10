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
    //经销商充值记录
    [Serializable()]
    public class tb_AgentRecharge : EntityBase
    {

        /// <summary>
        /// 构造器
        /// </summary>
        public tb_AgentRecharge()
        {
            TableName = "tb_AgentRecharge";
            //主键
            List<string> keys = new List<string>();
            keys.Add("ID");
            Identity = "ID";
            PrimaryKeys = keys;
            //字段长度
            StringFieldSize["tb_AgentRecharge_ID"] = 4;
            StringFieldSize["tb_AgentRecharge_AgentID"] = 4;
            StringFieldSize["tb_AgentRecharge_Amount"] = 8;
            StringFieldSize["tb_AgentRecharge_Balance"] = 8;
            StringFieldSize["tb_AgentRecharge_note"] = 300;
            StringFieldSize["tb_AgentRecharge_AddTime"] = 8;
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
        /// AgentID
        /// </summary>		
        public int AgentID
        {
            get { return GetPropertyValue<int>("AgentID"); }
            set { SetPropertyValue("AgentID", value); }
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
        /// Balance
        /// </summary>		
        public decimal Balance
        {
            get { return GetPropertyValue<decimal>("Balance"); }
            set { SetPropertyValue("Balance", value); }
        }
        /// <summary>
        /// note
        /// </summary>		
        public string note
        {
            get { return GetPropertyValue<string>("note"); }
            set { SetPropertyValue("note", value); }
        }
        /// <summary>
        /// AddTime
        /// </summary>		
        public DateTime AddTime
        {
            get { return GetPropertyValue<DateTime>("AddTime"); }
            set { SetPropertyValue("AddTime", value); }
        }

    }
}

