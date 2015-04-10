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
	 	//错题
		[Serializable()]
	public class tb_ErrorQuestion:EntityBase
	{
   	    
   	    /// <summary>
        /// 构造器
        /// </summary>
        public tb_ErrorQuestion()
        {
            TableName = "tb_ErrorQuestion";
            //主键
            List<string> keys = new List<string>();
            keys.Add("ID");
            PrimaryKeys = keys;
            //字段长度
           StringFieldSize["tb_ErrorQuestion_ID"]=4;
StringFieldSize["tb_ErrorQuestion_UserID"]=8;
StringFieldSize["tb_ErrorQuestion_QuestionID"]=4;
StringFieldSize["tb_ErrorQuestion_ChapterID"]=4;
StringFieldSize["tb_ErrorQuestion_ErrorNum"]=4;
StringFieldSize["tb_ErrorQuestion_CreatedOn"]=8;
        }
   	    

   	
      			/// <summary>
		/// ID
        /// </summary>		
        public int ID
        {
            get{ return GetPropertyValue<int>("ID"); }
            set{ SetPropertyValue("ID",value); }
        }        
				/// <summary>
		/// 会员编号
        /// </summary>		
        public long UserID
        {
            get{ return GetPropertyValue<long>("UserID"); }
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
		/// 所属考点
        /// </summary>		
        public int ChapterID
        {
            get{ return GetPropertyValue<int>("ChapterID"); }
            set{ SetPropertyValue("ChapterID",value); }
        }        
				/// <summary>
		/// 错误次数
        /// </summary>		
        public int ErrorNum
        {
            get{ return GetPropertyValue<int>("ErrorNum"); }
            set{ SetPropertyValue("ErrorNum",value); }
        }        
				/// <summary>
		/// 创建时间
        /// </summary>		
        public DateTime CreatedOn
        {
            get{ return GetPropertyValue<DateTime>("CreatedOn"); }
            set{ SetPropertyValue("CreatedOn",value); }
        }        
		   
	}
}

