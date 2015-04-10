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
    //Admin管理员
    [Serializable()]
    public class tb_Admin : EntityBase
    {

        /// <summary>
        /// 构造器
        /// </summary>
        public tb_Admin()
        {
            TableName = "tb_Admin";
            //主键
            List<string> keys = new List<string>();
            Identity = "ID";
            keys.Add("ID");
            PrimaryKeys = keys;
            //字段长度
            StringFieldSize["tb_Admin_ID"] = 4;
            StringFieldSize["tb_Admin_AdminName"] = 60;
            StringFieldSize["tb_Admin_AdminPwd"] = 32;
            StringFieldSize["tb_Admin_TrueName"] = 15;
            StringFieldSize["tb_Admin_RoleID"] = 4;
            StringFieldSize["tb_Admin_State"] = 4;
            StringFieldSize["tb_Admin_CreatedOn"] = 8;
            StringFieldSize["tb_Admin_CreatedBy"] = 4;
            StringFieldSize["tb_Admin_ModifyOn"] = 8;
            StringFieldSize["tb_Admin_ModifyBy"] = 4;
            StringFieldSize["tb_Admin_Del"] = 1;
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
        public string AdminName
        {
            get { return GetPropertyValue<string>("AdminName"); }
            set { SetPropertyValue("AdminName", value); }
        }
        /// <summary>
        /// 密码
        /// </summary>		
        public string AdminPwd
        {
            get { return GetPropertyValue<string>("AdminPwd"); }
            set { SetPropertyValue("AdminPwd", value); }
        }
        /// <summary>
        /// 真实姓名
        /// </summary>		
        public string TrueName
        {
            get { return GetPropertyValue<string>("TrueName"); }
            set { SetPropertyValue("TrueName", value); }
        }
        /// <summary>
        /// 角色
        /// </summary>		
        public int RoleID
        {
            get { return GetPropertyValue<int>("RoleID"); }
            set { SetPropertyValue("RoleID", value); }
        }

        /// <summary>
        /// 角色信息
        /// </summary>
        public Model.tb_AdminRole Role { get; set; }

        /// <summary>
        /// 状态
        /// </summary>		
        public int State
        {
            get { return GetPropertyValue<int>("State"); }
            set { SetPropertyValue("State", value); }
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
        /// 创建人
        /// </summary>		
        public int CreatedBy
        {
            get { return GetPropertyValue<int>("CreatedBy"); }
            set { SetPropertyValue("CreatedBy", value); }
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
        /// 修改人
        /// </summary>		
        public int ModifyBy
        {
            get { return GetPropertyValue<int>("ModifyBy"); }
            set { SetPropertyValue("ModifyBy", value); }
        }

        /// <summary>
        /// 最后一次登陆时间
        /// </summary>
        public DateTime LastTime
        {
            get { return GetPropertyValue<DateTime>("LastTime"); }
            set { SetPropertyValue("LastTime", value); }
        }

        /// <summary>
        /// 删除标示
        /// </summary>		
        public int Del
        {
            get { return GetPropertyValue<Int32>("Del"); }
            set { SetPropertyValue("Del", value); }
        }


    }
}

