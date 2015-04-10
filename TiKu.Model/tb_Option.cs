/* 
说 明：问题选项表

备 注： 本类由实体类生成工具(Ver 4.1)自动生成,
了解更多请登录http://my.oschina.net/lichaoqiang

日 期：2015-04-02 15:16
*/
using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using TiKu.DataDriver.Entity;
namespace TiKu.Model
{
    //问题选项表
    [Serializable()]
    public class tb_Option : EntityBase
    {

        /// <summary>
        /// 构造器
        /// </summary>
        public tb_Option()
        {
            TableName = "tb_Option";
            //主键
            List<string> keys = new List<string>();
            Identity = "ID";
            keys.Add("ID");
            PrimaryKeys = keys;
            //字段长度
            StringFieldSize["tb_Option_ID"] = 8;
            StringFieldSize["tb_Option_QuestionID"] = 4;
            StringFieldSize["tb_Option_Option"] = 2000;
        }



        /// <summary>
        /// 编号（主键）
        /// </summary>		
        public int ID
        {
            get { return GetPropertyValue<int>("ID"); }
            set { SetPropertyValue("ID", value); }
        }
        /// <summary>
        /// 问题编号
        /// </summary>		
        public int QuestionID
        {
            get { return GetPropertyValue<int>("QuestionID"); }
            set { SetPropertyValue("QuestionID", value); }
        }
        /// <summary>
        /// 选项
        /// </summary>		
        public string Option
        {
            get { return GetPropertyValue<string>("Option"); }
            set { SetPropertyValue("Option", value); }
        }


    }
}