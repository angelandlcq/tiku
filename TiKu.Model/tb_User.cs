/* 
说 明：会员信息

备 注： 本类由实体类生成工具(Ver 4.1)自动生成,
了解更多请登录http://my.oschina.net/lichaoqiang

日 期：2015-03-09 09:36
*/
using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using TiKu.DataDriver.Entity;
namespace TiKu.Model
{
    //会员信息
    [Serializable()]
    public class tb_User : EntityBase
    {

        /// <summary>
        /// 构造器
        /// </summary>
        public tb_User()
        {
            TableName = "tb_User";
            //主键
            List<string> keys = new List<string>();
            Identity = "ID";
            keys.Add("ID");
            PrimaryKeys = keys;
            //字段长度
            StringFieldSize["tb_User_ID"] = 8;
            StringFieldSize["tb_User_UserName"] = 60;
            StringFieldSize["tb_User_NickName"] = 30;
            StringFieldSize["tb_User_UserPwd"] = 32;
            StringFieldSize["tb_User_PwdSalt"] = 4;
            StringFieldSize["tb_User_Mobile"] = 15;
            StringFieldSize["tb_User_Email"] = 60;
            StringFieldSize["tb_User_State"] = 4;
            StringFieldSize["tb_User_Del"] = 4;
            StringFieldSize["tb_User_RegisterTime"] = 8;
            StringFieldSize["tb_User_RegisterIP"] = 15;
        }



        /// <summary>
        /// 会员编号
        /// </summary>		
        public long ID
        {
            get { return GetPropertyValue<long>("ID"); }
            set { SetPropertyValue("ID", value); }
        }
        /// <summary>
        /// 会员名称
        /// </summary>		
        public string UserName
        {
            get { return GetPropertyValue<string>("UserName"); }
            set { SetPropertyValue("UserName", value); }
        }
        /// <summary>
        /// 显示名称
        /// </summary>		
        public string NickName
        {
            get { return GetPropertyValue<string>("NickName"); }
            set { SetPropertyValue("NickName", value); }
        }
        /// <summary>
        /// 登录密码
        /// </summary>		
        public string UserPwd
        {
            get { return GetPropertyValue<string>("UserPwd"); }
            set { SetPropertyValue("UserPwd", value); }
        }
        /// <summary>
        /// 登录随机数
        /// </summary>		
        public int PwdSalt
        {
            get { return GetPropertyValue<int>("PwdSalt"); }
            set { SetPropertyValue("PwdSalt", value); }
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
        /// 邮箱
        /// </summary>		
        public string Email
        {
            get { return GetPropertyValue<string>("Email"); }
            set { SetPropertyValue("Email", value); }
        }
        /// <summary>
        /// 用户状态
        /// </summary>		
        public int State
        {
            get { return GetPropertyValue<int>("State"); }
            set { SetPropertyValue("State", value); }
        }
        /// <summary>
        /// 删除标示
        /// </summary>		
        public int Del
        {
            get { return GetPropertyValue<int>("Del"); }
            set { SetPropertyValue("Del", value); }
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

    }
}