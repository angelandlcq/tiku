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
    //管理员角色
    [Serializable()]
    public class tb_AdminRole : EntityBase
    {

        /// <summary>
        /// 构造器
        /// </summary>
        public tb_AdminRole()
        {
            TableName = "tb_AdminRole";
            //主键
            List<string> keys = new List<string>();
            keys.Add("ID");
            PrimaryKeys = keys;
            Identity = "ID";
            //字段长度
            StringFieldSize["tb_AdminRole_ID"] = 4;
            StringFieldSize["tb_AdminRole_RoleName"] = 60;
            StringFieldSize["tb_AdminRole_RoleValue"] = 4;
            StringFieldSize["tb_AdminRole_Orders"] = 4;
            StringFieldSize["tb_AdminRole_State"] = 4;
            StringFieldSize["tb_AdminRole_Del"] = 4;
            StringFieldSize["tb_AdminRole_CreatedOn"] = 8;
            StringFieldSize["tb_AdminRole_CreatedBy"] = 4;
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
        /// RoleName
        /// </summary>		
        public string RoleName
        {
            get { return GetPropertyValue<string>("RoleName"); }
            set { SetPropertyValue("RoleName", value); }
        }
        /// <summary>
        /// RoleValue
        /// </summary>		
        public int RoleValue
        {
            get { return GetPropertyValue<int>("RoleValue"); }
            set { SetPropertyValue("RoleValue", value); }
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
        /// <summary>
        /// CreatedOn
        /// </summary>		
        public DateTime CreatedOn
        {
            get { return GetPropertyValue<DateTime>("CreatedOn"); }
            set { SetPropertyValue("CreatedOn", value); }
        }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            get { return GetPropertyValue<string>("Remark"); }
            set { SetPropertyValue("Remark", value); }
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

