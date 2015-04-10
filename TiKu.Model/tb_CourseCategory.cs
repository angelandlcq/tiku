/* 
说 明：题库类别（科目分类）

备 注： 本类由实体类生成工具(Ver 4.1)自动生成,
了解更多请登录http://my.oschina.net/lichaoqiang

日 期：2015-03-13 10:59
*/
using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using TiKu.DataDriver.Entity;
namespace TiKu.Model
{
    //题库类别（科目分类）
    [Serializable()]
    public class tb_CourseCategory : EntityBase
    {

        /// <summary>
        /// 构造器
        /// </summary>
        public tb_CourseCategory()
        {
            TableName = "tb_CourseCategory";
            //主键
            List<string> keys = new List<string>();
            keys.Add("ID");
            Identity = "ID";
            PrimaryKeys = keys;
            //字段长度
            StringFieldSize["tb_CourseCategory_ID"] = 8;
            StringFieldSize["tb_CourseCategory_CateName"] = 60;
            StringFieldSize["tb_CourseCategory_ParentID"] = 8;
            StringFieldSize["tb_CourseCategory_Orders"] = 8;
            StringFieldSize["tb_CourseCategory_CreatedBy"] = 4;
            StringFieldSize["tb_CourseCategory_ModifyBy"] = 4;
            StringFieldSize["tb_CourseCategory_Del"] = 4;
            StringFieldSize["tb_CourseCategory_Remark"] = 1000;
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
        /// 分类名称
        /// </summary>		
        public string CateName
        {
            get { return GetPropertyValue<string>("CateName"); }
            set { SetPropertyValue("CateName", value); }
        }
        /// <summary>
        /// 父级分类
        /// </summary>		
        public int ParentID
        {
            get { return GetPropertyValue<int>("ParentID"); }
            set { SetPropertyValue("ParentID", value); }
        }
        /// <summary>
        /// 排序字段
        /// </summary>		
        public int Orders
        {
            get { return GetPropertyValue<int>("Orders"); }
            set { SetPropertyValue("Orders", value); }
        }

        /// <summary>
        /// 值：调用
        /// </summary>
        public string Val
        {
            get { return GetPropertyValue<string>("Val"); }
            set { SetPropertyValue("Val", value); }
        }

        /// <summary>
        /// 深度
        /// </summary>
        public int Deep
        {
            get { return GetPropertyValue<Int32>("Deep"); }
            set { SetPropertyValue("Deep", value); }
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
        /// 更新者
        /// </summary>		
        public int ModifyBy
        {
            get { return GetPropertyValue<int>("ModifyBy"); }
            set { SetPropertyValue("ModifyBy", value); }
        }
        /// <summary>
        /// 更新日期
        /// </summary>		
        public DateTime ModifyOn
        {
            get { return GetPropertyValue<DateTime>("ModifyOn"); }
            set { SetPropertyValue("ModifyOn", value); }
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
        /// 删除标示
        /// </summary>		
        public int Del
        {
            get { return GetPropertyValue<int>("Del"); }
            set { SetPropertyValue("Del", value); }
        }

    }
}