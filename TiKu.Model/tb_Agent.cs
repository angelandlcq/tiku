/* 
说 明：经销商

备 注： 本类由实体类生成工具(Ver 4.1)自动生成,
了解更多请登录http://my.oschina.net/lichaoqiang

日 期：2015-03-07 10:36
*/
using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using TiKu.DataDriver.Entity;
namespace TiKu.Model
{
    //经销商
    [Serializable()]
    public class tb_Agent : EntityBase
    {

        /// <summary>
        /// 构造器
        /// </summary>
        public tb_Agent()
        {
            TableName = "tb_Agent";
            //主键
            List<string> keys = new List<string>();
            Identity = "ID";
            keys.Add("ID");
            PrimaryKeys = keys;
            //字段长度
            StringFieldSize["tb_Agent_AgentName"] = 30;
            StringFieldSize["tb_Agent_AgentPwd"] = 32;
            StringFieldSize["tb_Agent_ShowName"] = 60;
            StringFieldSize["tb_Agent_State"] = 4;
            StringFieldSize["tb_Agent_RegisterIP"] = 20;
            StringFieldSize["tb_Agent_Contact"] = 20;
            StringFieldSize["tb_Agent_Mobile"] = 15;
            StringFieldSize["tb_Agent_Tel"] = 20;
            StringFieldSize["tb_Agent_QQ"] = 20;
            StringFieldSize["tb_Agent_Email"] = 100;
            StringFieldSize["tb_Agent_Address"] = 200;
            StringFieldSize["tb_Agent_Amount"] = 8;
            StringFieldSize["tb_Agent_Url"] = 200;
            StringFieldSize["tb_Agent_TaoBaoUrl"] = 200;
            StringFieldSize["tb_Agent_AliAcount"] = 30;
            StringFieldSize["tb_Agent_CreatedBy"] = 4;
            StringFieldSize["tb_Agent_ModifyBy"] = 4;
            StringFieldSize["tb_Agent_Del"] = 4;
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
        /// 登录名
        /// </summary>		
        public string AgentName
        {
            get { return GetPropertyValue<string>("AgentName"); }
            set { SetPropertyValue("AgentName", value); }
        }
        /// <summary>
        /// 登录密码
        /// </summary>		
        public string AgentPwd
        {
            get { return GetPropertyValue<string>("AgentPwd"); }
            set { SetPropertyValue("AgentPwd", value); }
        }
        /// <summary>
        /// 显示名称
        /// </summary>		
        public string ShowName
        {
            get { return GetPropertyValue<string>("ShowName"); }
            set { SetPropertyValue("ShowName", value); }
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
        /// 注册日期
        /// </summary>		
        public DateTime RegisterTime
        {
            get { return GetPropertyValue<DateTime>("RegisterTime"); }
            set { SetPropertyValue("RegisterTime", value); }
        }
        /// <summary>
        /// 注册IP
        /// </summary>		
        public string RegisterIP
        {
            get { return GetPropertyValue<string>("RegisterIP"); }
            set { SetPropertyValue("RegisterIP", value); }
        }
        /// <summary>
        /// 登录次数
        /// </summary>		
        public int LogNum
        {
            get { return GetPropertyValue<int>("LogNum"); }
            set { SetPropertyValue("LogNum", value); }
        }
        /// <summary>
        /// Contact
        /// </summary>		
        public string Contact
        {
            get { return GetPropertyValue<string>("Contact"); }
            set { SetPropertyValue("Contact", value); }
        }
        /// <summary>
        /// 手机号
        /// </summary>		
        public string Mobile
        {
            get { return GetPropertyValue<string>("Mobile"); }
            set { SetPropertyValue("Mobile", value); }
        }
        /// <summary>
        /// Tel
        /// </summary>		
        public string Tel
        {
            get { return GetPropertyValue<string>("Tel"); }
            set { SetPropertyValue("Tel", value); }
        }
        /// <summary>
        /// QQ
        /// </summary>		
        public string QQ
        {
            get { return GetPropertyValue<string>("QQ"); }
            set { SetPropertyValue("QQ", value); }
        }
        /// <summary>
        /// 邮箱
        /// </summary>		
        public string Email
        {
            get { return GetPropertyValue<string>("Email"); }
            set { SetPropertyValue("Email", value); }
        }
        /// <summary>
        /// 地址
        /// </summary>		
        public string Address
        {
            get { return GetPropertyValue<string>("Address"); }
            set { SetPropertyValue("Address", value); }
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
        /// Url
        /// </summary>		
        public string Url
        {
            get { return GetPropertyValue<string>("Url"); }
            set { SetPropertyValue("Url", value); }
        }
        /// <summary>
        /// TaoBaoUrl
        /// </summary>		
        public string TaoBaoUrl
        {
            get { return GetPropertyValue<string>("TaoBaoUrl"); }
            set { SetPropertyValue("TaoBaoUrl", value); }
        }
        /// <summary>
        /// AliAcount
        /// </summary>		
        public string AliAcount
        {
            get { return GetPropertyValue<string>("AliAcount"); }
            set { SetPropertyValue("AliAcount", value); }
        }
        /// <summary>
        /// LastTime
        /// </summary>		
        public DateTime LastTime
        {
            get { return GetPropertyValue<DateTime>("LastTime"); }
            set { SetPropertyValue("LastTime", value); }
        }
        /// <summary>
        /// 创建者编号
        /// </summary>		
        public int CreatedBy
        {
            get { return GetPropertyValue<int>("CreatedBy"); }
            set { SetPropertyValue("CreatedBy", value); }
        }
        /// <summary>
        /// 创建日期
        /// </summary>		
        public DateTime CreatedOn
        {
            get { return GetPropertyValue<DateTime>("CreatedOn"); }
            set { SetPropertyValue("CreatedOn", value); }
        }
        /// <summary>
        /// 修改者编号
        /// </summary>		
        public int ModifyBy
        {
            get { return GetPropertyValue<int>("ModifyBy"); }
            set { SetPropertyValue("ModifyBy", value); }
        }
        /// <summary>
        /// 修改日期
        /// </summary>		
        public DateTime ModifyOn
        {
            get { return GetPropertyValue<DateTime>("ModifyOn"); }
            set { SetPropertyValue("ModifyOn", value); }
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