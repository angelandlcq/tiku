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
    //设置
    [Serializable()]
    public class tb_WebSet : EntityBase
    {

        /// <summary>
        /// 构造器
        /// </summary>
        public tb_WebSet()
        {
            TableName = "tb_WebSet";
            //主键
            List<string> keys = new List<string>();
            keys.Add("ID");
            PrimaryKeys = keys;
            //字段长度
            StringFieldSize["tb_WebSet_WebName"] = 60;
            StringFieldSize["tb_WebSet_ICP"] = 30;
            StringFieldSize["tb_WebSet_IsEnableAdminLog"] = 4;
            StringFieldSize["tb_WebSet_IsEnableUserLog"] = 4;
            StringFieldSize["tb_WebSet_IsEnableAgentLog"] = 4;
            StringFieldSize["tb_WebSet_WebState"] = 4;
            StringFieldSize["tb_WebSet_IsEnableDelete"] = 4;
            StringFieldSize["tb_WebSet_Logo"] = 200;
            StringFieldSize["tb_WebSet_Domain"] = 60;
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
        /// WebName
        /// </summary>		
        public string WebName
        {
            get { return GetPropertyValue<string>("WebName"); }
            set { SetPropertyValue("WebName", value); }
        }
        /// <summary>
        /// ICP
        /// </summary>		
        public string ICP
        {
            get { return GetPropertyValue<string>("ICP"); }
            set { SetPropertyValue("ICP", value); }
        }
        /// <summary>
        /// IsEnableAdminLog
        /// </summary>		
        public int IsEnableAdminLog
        {
            get { return GetPropertyValue<int>("IsEnableAdminLog"); }
            set { SetPropertyValue("IsEnableAdminLog", value); }
        }
        /// <summary>
        /// IsEnableUserLogo
        /// </summary>		
        public int IsEnableUserLog
        {
            get { return GetPropertyValue<int>("IsEnableUserLog"); }
            set { SetPropertyValue("IsEnableUserLog", value); }
        }
        /// <summary>
        /// IsEnableAgentLog
        /// </summary>		
        public int IsEnableAgentLog
        {
            get { return GetPropertyValue<int>("IsEnableAgentLog"); }
            set { SetPropertyValue("IsEnableAgentLog", value); }
        }
        /// <summary>
        /// WebState
        /// </summary>		
        public int WebState
        {
            get { return GetPropertyValue<int>("WebState"); }
            set { SetPropertyValue("WebState", value); }
        }
        /// <summary>
        /// IsEnableDelete
        /// </summary>		
        public int IsEnableDelete
        {
            get { return GetPropertyValue<int>("IsEnableDelete"); }
            set { SetPropertyValue("IsEnableDelete", value); }
        }
        /// <summary>
        /// Logo
        /// </summary>		
        public string Logo
        {
            get { return GetPropertyValue<string>("Logo"); }
            set { SetPropertyValue("Logo", value); }
        }
        /// <summary>
        /// Domain
        /// </summary>		
        public string Domain
        {
            get { return GetPropertyValue<string>("Domain"); }
            set { SetPropertyValue("Domain", value); }
        }

        /// <summary>
        /// 企业名称
        /// </summary>
        public string Company
        {
            get { return GetPropertyValue<string>("Company"); }
            set { SetPropertyValue("Company", value); }
        }

        /// <summary>
        /// Smtp
        /// </summary>
        public string Smtp
        {
            get { return GetPropertyValue<string>("Smtp"); }
            set { SetPropertyValue("Smtp", value); }
        }
        /// <summary>
        /// 端口
        /// </summary>
        public int SmtpPort
        {
            get { return GetPropertyValue<int>("SmtpPort"); }
            set { SetPropertyValue("SmtpPort", value); }
        }

        /// <summary>
        /// 邮箱账号
        /// </summary>
        public string EmaiAccount
        {
            get { return GetPropertyValue<string>("EmaiAccount"); }
            set { SetPropertyValue("EmaiAccount", value); }
        }

        /// <summary>
        /// 邮箱密码
        /// </summary>
        public string EmailPwd
        {
            get { return GetPropertyValue<string>("EmailPwd"); }
            set { SetPropertyValue("EmailPwd", value); }
        }
    }
}

