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
	 	//做题记录表0
		[Serializable()]
	public class tb_QuestionState:EntityBase
	{
   	    
   	    /// <summary>
        /// 构造器
        /// </summary>
        public tb_QuestionState()
        {
            TableName = "tb_QuestionState";
            //主键
            List<string> keys = new List<string>();
            keys.Add("ID");
            PrimaryKeys = keys;
            //字段长度
           StringFieldSize["tb_QuestionState_ID"]=4;
StringFieldSize["tb_QuestionState_ChapterID"]=4;
StringFieldSize["tb_QuestionState_QuestionID"]=4;
StringFieldSize["tb_QuestionState_Answer"]=100;
StringFieldSize["tb_QuestionState_UserID"]=4;
StringFieldSize["tb_QuestionState_AddTime"]=8;
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
		/// ChapterID
        /// </summary>		
        public int ChapterID
        {
            get{ return GetPropertyValue<int>("ChapterID"); }
            set{ SetPropertyValue("ChapterID",value); }
        }        
				/// <summary>
		/// QuestionID
        /// </summary>		
        public int QuestionID
        {
            get{ return GetPropertyValue<int>("QuestionID"); }
            set{ SetPropertyValue("QuestionID",value); }
        }        
				/// <summary>
		/// Answer
        /// </summary>		
        public string Answer
        {
            get{ return GetPropertyValue<string>("Answer"); }
            set{ SetPropertyValue("Answer",value); }
        }        
				/// <summary>
		/// UserID
        /// </summary>		
        public int UserID
        {
            get{ return GetPropertyValue<int>("UserID"); }
            set{ SetPropertyValue("UserID",value); }
        }        
				/// <summary>
		/// AddTime
        /// </summary>		
        public DateTime AddTime
        {
            get{ return GetPropertyValue<DateTime>("AddTime"); }
            set{ SetPropertyValue("AddTime",value); }
        }        
		   
	}
}

