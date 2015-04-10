/* 
说 明：章节

备 注： 本类由实体类生成工具(Ver 4.1)自动生成,
了解更多请登录http://my.oschina.net/lichaoqiang

日 期：2015-03-23 16:00
*/
using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using TiKu.DataDriver.Entity;
namespace TiKu.Model
{
    //章节
    [Serializable()]
    public class tb_Chapter : EntityBase
    {

        /// <summary>
        /// 构造器
        /// </summary>
        public tb_Chapter()
        {
            TableName = "tb_Chapter";
            //主键
            List<string> keys = new List<string>();
            keys.Add("ID");
            Identity = "ID";
            PrimaryKeys = keys;
            //字段长度
            StringFieldSize["tb_Chapter_ID"] = 8;
            StringFieldSize["tb_Chapter_CptName"] = 100;
            StringFieldSize["tb_Chapter_ParentID"] = 8;
            StringFieldSize["tb_Chapter_ParentPath"] = 200;
            StringFieldSize["tb_Chapter_Quantity"] = 8;
            StringFieldSize["tb_Chapter_NoteNum"] = 8;
            StringFieldSize["tb_Chapter_Collection"] = 8;
            StringFieldSize["tb_Chapter_Orders"] = 8;
            StringFieldSize["tb_Chapter_DirCode"] = 15;
            StringFieldSize["tb_Chapter_IsExam"] = 1;
            StringFieldSize["tb_Chapter_State"] = 10;
            StringFieldSize["tb_Chapter_CreatedBy"] = 4;
            StringFieldSize["tb_Chapter_CreatedOn"] = 8;
            StringFieldSize["tb_Chapter_ModifyBy"] = 4;
            StringFieldSize["tb_Chapter_ModifyOn"] = 8;
            StringFieldSize["tb_Chapter_Del"] = 4;
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
        /// 章节名称
        /// </summary>		
        public string CptName
        {
            get { return GetPropertyValue<string>("CptName"); }
            set { SetPropertyValue("CptName", value); }

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
        /// 父级节点
        /// </summary>		
        public int ParentID
        {
            get { return GetPropertyValue<int>("ParentID"); }
            set { SetPropertyValue("ParentID", value); }
        }
        /// <summary>
        /// 节点路径
        /// </summary>		
        public string ParentPath
        {
            get { return GetPropertyValue<string>("ParentPath"); }
            set { SetPropertyValue("ParentPath", value); }
        }
        /// <summary>
        /// 总题量
        /// </summary>		
        public int Quantity
        {
            get { return GetPropertyValue<int>("Quantity"); }
            set { SetPropertyValue("Quantity", value); }
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
        /// 收藏量
        /// </summary>		
        public int Collection
        {
            get { return GetPropertyValue<int>("Collection"); }
            set { SetPropertyValue("Collection", value); }
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
        /// 目录编号
        /// </summary>		
        public string DirCode
        {
            get { return GetPropertyValue<string>("DirCode"); }
            set { SetPropertyValue("DirCode", value); }
        }
        /// <summary>
        /// 是否是真题
        /// </summary>		
        public bool IsExam
        {
            get { return GetPropertyValue<bool>("IsExam"); }
            set { SetPropertyValue("IsExam", value); }
        }
        /// <summary>
        /// 状态
        /// </summary>		
        public string State
        {
            get { return GetPropertyValue<string>("State"); }
            set { SetPropertyValue("State", value); }
        }
        /// <summary>
        /// 创建者
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
        /// 修改者
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