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
    //经销商日志
    [Serializable()]
    public class tb_AgentLog : EntityBase
    {

        /// <summary>
        /// 构造器
        /// </summary>
        public tb_AgentLog()
        {
            TableName = "tb_AgentLog";
            //主键
            List<string> keys = new List<string>();
            Identity = "ID";
            keys.Add("ID");
            PrimaryKeys = keys;
            //字段长度
            StringFieldSize["tb_AgentLog_ID"] = 4;
            StringFieldSize["tb_AgentLog_Action"] = 10;
            StringFieldSize["tb_AgentLog_AgentID"] = 4;
            StringFieldSize["tb_AgentLog_Level"] = 10;
            StringFieldSize["tb_AgentLog_Msg"] = 300;
            StringFieldSize["tb_AgentLog_AddDate"] = 8;
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
        /// 操作
        /// </summary>		
        public string Action
        {
            get { return GetPropertyValue<string>("Action"); }
            set { SetPropertyValue("Action", value); }
        }
        /// <summary>
        /// 经销商编号
        /// </summary>		
        public int AgentID
        {
            get { return GetPropertyValue<int>("AgentID"); }
            set { SetPropertyValue("AgentID", value); }
        }
        /// <summary>
        /// 日志级别
        /// </summary>		
        public string Level
        {
            get { return GetPropertyValue<string>("Level"); }
            set { SetPropertyValue("Level", value); }
        }
        /// <summary>
        /// 日志消息
        /// </summary>		
        public string Msg
        {
            get { return GetPropertyValue<string>("Msg"); }
            set { SetPropertyValue("Msg", value); }
        }
        /// <summary>
        /// 创建日期
        /// </summary>		
        public DateTime AddDate
        {
            get { return GetPropertyValue<DateTime>("AddDate"); }
            set { SetPropertyValue("AddDate", value); }
        }

        /// <summary>
        /// IP
        /// </summary>
        public string IP
        {
            get { return GetPropertyValue<string>("IP"); }
            set { SetPropertyValue("IP", value); }
        }
    }
}

