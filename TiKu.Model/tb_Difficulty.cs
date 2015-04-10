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
    //难度
    [Serializable()]
    public class tb_Difficulty : EntityBase
    {

        /// <summary>
        /// 构造器
        /// </summary>
        public tb_Difficulty()
        {
            TableName = "tb_Difficulty";
            //主键
            List<string> keys = new List<string>();
            Identity = "ID";
            keys.Add("ID");
            PrimaryKeys = keys;
            //字段长度
            StringFieldSize["tb_Difficulty_ID"] = 4;
            StringFieldSize["tb_Difficulty_QuestionID"] = 4;
            StringFieldSize["tb_Difficulty_Rate"] = 4;
            StringFieldSize["tb_Difficulty_UserID"] = 4;
            StringFieldSize["tb_Difficulty_CreatedOn"] = 8;
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
        /// 题目编号
        /// </summary>		
        public int QuestionID
        {
            get { return GetPropertyValue<int>("QuestionID"); }
            set { SetPropertyValue("QuestionID", value); }
        }
        /// <summary>
        /// 难度指数
        /// </summary>		
        public int Rate
        {
            get { return GetPropertyValue<int>("Rate"); }
            set { SetPropertyValue("Rate", value); }
        }
        /// <summary>
        /// 会员编号
        /// </summary>		
        public int UserID
        {
            get { return GetPropertyValue<int>("UserID"); }
            set { SetPropertyValue("UserID", value); }
        }
        /// <summary>
        /// 创建时间
        /// </summary>		
        public DateTime CreatedOn
        {
            get { return GetPropertyValue<DateTime>("CreatedOn"); }
            set { SetPropertyValue("CreatedOn", value); }
        }

    }
}

