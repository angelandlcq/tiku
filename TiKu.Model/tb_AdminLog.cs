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
    //管理员日志
    [Serializable()]
    public class tb_AdminLog : EntityBase
    {

        /// <summary>
        /// 构造器
        /// </summary>
        public tb_AdminLog()
        {
            TableName = "tb_AdminLog";
            //主键
            List<string> keys = new List<string>();
            Identity = "ID";
            keys.Add("ID");
            PrimaryKeys = keys;
            //字段长度
            StringFieldSize["tb_AdminLog_ID"] = 4;
            StringFieldSize["tb_AdminLog_ActionType"] = 2;
            StringFieldSize["tb_AdminLog_AdminID"] = 4;
            StringFieldSize["tb_AdminLog_Event"] = 30;
            StringFieldSize["tb_AdminLog_ActionLevel"] = 10;
            StringFieldSize["tb_AdminLog_CreatedOn"] = 8;
            StringFieldSize["tb_AdminLog_IP"] = 20;
            StringFieldSize["tb_AdminLog_Msg"] = 300;
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
        /// 操作类别
        /// </summary>		
        public string ActionType
        {
            get { return GetPropertyValue<string>("ActionType"); }
            set { SetPropertyValue("ActionType", value); }
        }
        /// <summary>
        /// AdminID
        /// </summary>		
        public int AdminID
        {
            get { return GetPropertyValue<int>("AdminID"); }
            set { SetPropertyValue("AdminID", value); }
        }
        /// <summary>
        /// 事件
        /// </summary>		
        public string Event
        {
            get { return GetPropertyValue<string>("Event"); }
            set { SetPropertyValue("Event", value); }
        }
        /// <summary>
        /// 日志级别
        /// </summary>		
        public string ActionLevel
        {
            get { return GetPropertyValue<string>("ActionLevel"); }
            set { SetPropertyValue("ActionLevel", value); }
        }
        /// <summary>
        /// 时间
        /// </summary>		
        public DateTime CreatedOn
        {
            get { return GetPropertyValue<DateTime>("CreatedOn"); }
            set { SetPropertyValue("CreatedOn", value); }
        }
        /// <summary>
        /// ip
        /// </summary>		
        public string IP
        {
            get { return GetPropertyValue<string>("IP"); }
            set { SetPropertyValue("IP", value); }
        }
        /// <summary>
        /// 日志信息
        /// </summary>		
        public string Msg
        {
            get { return GetPropertyValue<string>("Msg"); }
            set { SetPropertyValue("Msg", value); }
        }

        /// <summary>
        /// 角色
        /// </summary>
        public Model.tb_AdminRole Role
        {
            get;
            set;
        }
    }
}