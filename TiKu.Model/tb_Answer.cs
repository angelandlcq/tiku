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
    //答案信息
    [Serializable()]
    [Obsolete("答案信息，已经抛弃，请使用tb_Option对象")]
    public class tb_Answer : EntityBase
    {

        /// <summary>
        /// 构造器
        /// </summary>
        public tb_Answer()
        {
            TableName = "tb_Answer";
            //主键
            List<string> keys = new List<string>();
            Identity = "ID";
            keys.Add("ID");
            PrimaryKeys = keys;
            //字段长度
            StringFieldSize["tb_Answer_ID"] = 4;
            StringFieldSize["tb_Answer_Code"] = 10;
            StringFieldSize["tb_Answer_QuestionID"] = 4;
            StringFieldSize["tb_Answer_State"] = 4;
            StringFieldSize["tb_Answer_Answer"] = 300;
            StringFieldSize["tb_Answer_Orders"] = 4;
            StringFieldSize["tb_Answer_CreatedBy"] = 4;
            StringFieldSize["tb_Answer_CreatedOn"] = 8;
            StringFieldSize["tb_Answer_ModifyBy"] = 4;
            StringFieldSize["tb_Answer_ModifyOn"] = 8;
            StringFieldSize["tb_Answer_Del"] = 4;
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
        /// 序号
        /// </summary>		
        public string Code
        {
            get { return GetPropertyValue<string>("Code"); }
            set { SetPropertyValue("Code", value); }
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
        /// 状态
        /// </summary>		
        public int State
        {
            get { return GetPropertyValue<int>("State"); }
            set { SetPropertyValue("State", value); }
        }
        /// <summary>
        /// 答案内容
        /// </summary>		
        public string Answer
        {
            get { return GetPropertyValue<string>("Answer"); }
            set { SetPropertyValue("Answer", value); }
        }
        /// <summary>
        /// 排序
        /// </summary>		
        public int Orders
        {
            get { return GetPropertyValue<int>("Orders"); }
            set { SetPropertyValue("Orders", value); }
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
        /// 创建日期
        /// </summary>		
        public DateTime CreatedOn
        {
            get { return GetPropertyValue<DateTime>("CreatedOn"); }
            set { SetPropertyValue("CreatedOn", value); }
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
        /// 修改时间
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

