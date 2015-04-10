/* 
说 明：tb_SEO

备 注： 本类由实体类生成工具(Ver 4.1)自动生成,
了解更多请登录http://my.oschina.net/lichaoqiang

日 期：2015-03-07 16:21
*/
using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using TiKu.DataDriver.Entity;
namespace TiKu.Model
{
    //tb_SEO
    [Serializable()]
    public class tb_SEO : EntityBase
    {

        /// <summary>
        /// 构造器
        /// </summary>
        public tb_SEO()
        {
            TableName = "tb_SEO";
            //主键
            List<string> keys = new List<string>();
            Identity = "ID";
            keys.Add("ID");
            PrimaryKeys = keys;
            //字段长度
            StringFieldSize["tb_SEO_ID"] = 4;
            StringFieldSize["tb_SEO_CallName"] = 20;
            StringFieldSize["tb_SEO_Title"] = 80;
            StringFieldSize["tb_SEO_keywords"] = 50;
            StringFieldSize["tb_SEO_Description"] = 300;
            StringFieldSize["tb_SEO_Orders"] = 4;
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
        /// 调用别名
        /// </summary>		
        public string CallName
        {
            get { return GetPropertyValue<string>("CallName"); }
            set { SetPropertyValue("CallName", value); }
        }
        /// <summary>
        /// Title
        /// </summary>		
        public string Title
        {
            get { return GetPropertyValue<string>("Title"); }
            set { SetPropertyValue("Title", value); }
        }
        /// <summary>
        /// 关键词
        /// </summary>		
        public string keywords
        {
            get { return GetPropertyValue<string>("keywords"); }
            set { SetPropertyValue("keywords", value); }
        }
        /// <summary>
        /// Description
        /// </summary>		
        public string Description
        {
            get { return GetPropertyValue<string>("Description"); }
            set { SetPropertyValue("Description", value); }
        }
        /// <summary>
        /// 排序
        /// </summary>		
        public int Orders
        {
            get { return GetPropertyValue<int>("Orders"); }
            set { SetPropertyValue("Orders", value); }
        }

    }
}