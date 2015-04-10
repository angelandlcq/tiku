/* 
说 明：题库信息

备 注： 本类由实体类生成工具(Ver 4.1)自动生成,
了解更多请登录http://my.oschina.net/lichaoqiang

日 期：2015-03-26 10:09
*/
using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using TiKu.DataDriver.Entity;
namespace TiKu.Model
{
    //题库信息
    [Serializable()]
    public class tb_Question : EntityBase
    {

        /// <summary>
        /// 构造器
        /// </summary>
        public tb_Question()
        {
            TableName = "tb_Question";
            //主键
            List<string> keys = new List<string>();
            Identity = "ID";
            keys.Add("ID");
            PrimaryKeys = keys;
            //字段长度
            StringFieldSize["tb_Question_ID"] = 10;
            StringFieldSize["tb_Question_Title"] = 100;
            StringFieldSize["tb_Question_QType"] = 4;
            StringFieldSize["tb_Question_ShortTitle"] = 60;
            StringFieldSize["tb_Question_QScore"] = 4;
            StringFieldSize["tb_Question_TrueAnswer"] = 20;
            StringFieldSize["tb_Question_Orders"] = 4;
            StringFieldSize["tb_Question_Analysis"] = 3000;
            StringFieldSize["tb_Question_State"] = 4;
            StringFieldSize["tb_Question_RigthtNum"] = 4;
            StringFieldSize["tb_Question_ErrorNum"] = 4;
            StringFieldSize["tb_Question_AvgDifficulty"] = 4;
            StringFieldSize["tb_Question_FavoriteNum"] = 4;
            StringFieldSize["tb_Question_NoteNum"] = 4;
            StringFieldSize["tb_Question_IsFree"] = 1;
            StringFieldSize["tb_Question_CreatedOn"] = 20;
            StringFieldSize["tb_Question_CreatedBy"] = 4;
            StringFieldSize["tb_Question_ModifyOn"] = 20;
            StringFieldSize["tb_Question_ModifyBy"] = 4;
            StringFieldSize["tb_Question_Del"] = 4;
            StringFieldSize["tb_Question_Options"] = 6000;
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
        /// 题目
        /// </summary>		
        public string Title
        {
            get { return GetPropertyValue<string>("Title"); }
            set { SetPropertyValue("Title", value); }
        }
        /// <summary>
        /// 题型
        /// </summary>		
        public int QType
        {
            get { return GetPropertyValue<int>("QType"); }
            set { SetPropertyValue("QType", value); }
        }

        /// <summary>
        /// 级别
        /// </summary>
        public int QLevel
        {
            get { return GetPropertyValue<int>("QLevel"); }
            set { SetPropertyValue("QLevel", value); }
        }

        /// <summary>
        /// 短标题
        /// </summary>		
        public string ShortTitle
        {
            get { return GetPropertyValue<string>("ShortTitle"); }
            set { SetPropertyValue("ShortTitle", value); }
        }
        /// <summary>
        /// 分值
        /// </summary>		
        public int QScore
        {
            get { return GetPropertyValue<int>("QScore"); }
            set { SetPropertyValue("QScore", value); }
        }
        /// <summary>
        /// 正确答案
        /// </summary>		
        public string TrueAnswer
        {
            get { return GetPropertyValue<string>("TrueAnswer"); }
            set { SetPropertyValue("TrueAnswer", value); }
        }

        /// <summary>
        /// 材料编号
        /// </summary>
        public int MateID
        {
            get { return GetPropertyValue<int>("MateID"); }
            set { SetPropertyValue("MateID", value); }
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
        /// Analysis
        /// </summary>		
        public string Analysis
        {
            get { return GetPropertyValue<string>("Analysis"); }
            set { SetPropertyValue("Analysis", value); }
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
        /// 正确次数
        /// </summary>		
        public int RigthtNum
        {
            get { return GetPropertyValue<int>("RigthtNum"); }
            set { SetPropertyValue("RigthtNum", value); }
        }
        /// <summary>
        /// 错误次数
        /// </summary>		
        public int ErrorNum
        {
            get { return GetPropertyValue<int>("ErrorNum"); }
            set { SetPropertyValue("ErrorNum", value); }

        }


        /// <summary>
        /// 课程编号
        /// </summary>
        public int CourseID
        {
            get { return GetPropertyValue<int>("CourseID"); }
            set { SetPropertyValue("CourseID", value); }
        }

        /// <summary>
        /// 章节考点
        /// </summary>

        public string Chapter
        {
            get { return GetPropertyValue<string>("Chapter"); }
            set { SetPropertyValue("Chapter", value); }
        }

        /// <summary>
        /// 平均难度
        /// </summary>		
        public int AvgDifficulty
        {
            get { return GetPropertyValue<int>("AvgDifficulty"); }
            set { SetPropertyValue("AvgDifficulty", value); }
        }
        /// <summary>
        /// 收藏次数
        /// </summary>		
        public int FavoriteNum
        {
            get { return GetPropertyValue<int>("FavoriteNum"); }
            set { SetPropertyValue("FavoriteNum", value); }
        }
        /// <summary>
        /// 笔记数
        /// </summary>		
        public int NoteNum
        {
            get { return GetPropertyValue<int>("NoteNum"); }
            set { SetPropertyValue("NoteNum", value); }
        }
        /// <summary>
        /// 是否收费
        /// </summary>		
        public bool IsFree
        {
            get { return GetPropertyValue<bool>("IsFree"); }
            set { SetPropertyValue("IsFree", value); }
        }
        /// <summary>
        /// 创建时间
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
        /// 修改时间
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
        /// 删除标示
        /// </summary>		
        public int Del
        {
            get { return GetPropertyValue<int>("Del"); }
            set { SetPropertyValue("Del", value); }
        }

        /// <summary>
        /// 选项
        /// </summary>
        public string Options
        {
            get { return GetPropertyValue<string>("Options"); }
            set { SetPropertyValue("Options", value); }
        }

        /// <summary>
        /// 材料
        /// </summary>
        public tb_Material Material { get; set; }

    }
}