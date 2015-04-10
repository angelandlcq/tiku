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
    //纠错
    [Serializable()]
    public class tb_Correct : EntityBase
    {

        /// <summary>
        /// 构造器
        /// </summary>
        public tb_Correct()
        {
            TableName = "tb_Correct";
            //主键
            List<string> keys = new List<string>();
            Identity = "ID";
            keys.Add("ID");
            PrimaryKeys = keys;
            //字段长度
            StringFieldSize["tb_Correct_ID"] = 4;
            StringFieldSize["tb_Correct_UserID"] = 8;
            StringFieldSize["tb_Correct_QuestionID"] = 4;
            StringFieldSize["tb_Correct_CrtType"] = 4;
            StringFieldSize["tb_Correct_Note"] = 1000;
            StringFieldSize["tb_Correct_State"] = 4;
            StringFieldSize["tb_Correct_AddDate"] = 8;
            StringFieldSize["tb_Correct_Audit"] = 4;
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
        /// 会员编号
        /// </summary>		
        public long UserID
        {
            get { return GetPropertyValue<long>("UserID"); }
            set { SetPropertyValue("UserID", value); }
        }
        /// <summary>
        /// 题目编号
        /// </summary>		
        public int QuestionID
        {
            get { return GetPropertyValue<int>("QuestionID"); }
            set { SetPropertyValue("QuestionID", value); }
        }
        /// <summary>
        /// 类别
        /// </summary>		
        public int CrtType
        {
            get { return GetPropertyValue<int>("CrtType"); }
            set { SetPropertyValue("CrtType", value); }
        }
        /// <summary>
        /// 说明
        /// </summary>		
        public string Note
        {
            get { return GetPropertyValue<string>("Note"); }
            set { SetPropertyValue("Note", value); }
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
        /// 时间
        /// </summary>		
        public DateTime AddDate
        {
            get { return GetPropertyValue<DateTime>("AddDate"); }
            set { SetPropertyValue("AddDate", value); }
        }
        /// <summary>
        /// 审核人(管理员)
        /// </summary>		
        public int Audit
        {
            get { return GetPropertyValue<int>("Audit"); }
            set { SetPropertyValue("Audit", value); }
        }

    }
}

