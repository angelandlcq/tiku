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
namespace TiKu.Model{
	 	//做题笔记
		[Serializable()]
	public class tb_Note:EntityBase
	{
   	    
   	    /// <summary>
        /// 构造器
        /// </summary>
        public tb_Note()
        {
            TableName = "tb_Note";
            //主键
            List<string> keys = new List<string>();
            Identity="ID";
keys.Add("ID");
            PrimaryKeys = keys;
            //字段长度
           StringFieldSize["tb_Note_ID"]=4;
StringFieldSize["tb_Note_UserID"]=4;
StringFieldSize["tb_Note_QuestionID"]=4;
StringFieldSize["tb_Note_Note"]=1000;
StringFieldSize["tb_Note_CreatedOn"]=8;
StringFieldSize["tb_Note_IsOpen"]=1;
        }
   	    

   	
      			/// <summary>
		/// 编号
        /// </summary>		
        public int ID
        {
            get{ return GetPropertyValue<int>("ID"); }
            set{ SetPropertyValue("ID",value); }
        }        
				/// <summary>
		/// 会员编号
        /// </summary>		
        public int UserID
        {
            get{ return GetPropertyValue<int>("UserID"); }
            set{ SetPropertyValue("UserID",value); }
        }        
				/// <summary>
		/// 题目编号
        /// </summary>		
        public int QuestionID
        {
            get{ return GetPropertyValue<int>("QuestionID"); }
            set{ SetPropertyValue("QuestionID",value); }
        }        
				/// <summary>
		/// 笔记内容
        /// </summary>		
        public string Note
        {
            get{ return GetPropertyValue<string>("Note"); }
            set{ SetPropertyValue("Note",value); }
        }        
				/// <summary>
		/// 添加日期
        /// </summary>		
        public DateTime CreatedOn
        {
            get{ return GetPropertyValue<DateTime>("CreatedOn"); }
            set{ SetPropertyValue("CreatedOn",value); }
        }        
				/// <summary>
		/// 是否公开
        /// </summary>		
        public bool IsOpen
        {
            get{ return GetPropertyValue<bool>("IsOpen"); }
            set{ SetPropertyValue("IsOpen",value); }
        }        
		   
	}
}

