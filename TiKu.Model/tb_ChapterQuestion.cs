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
	 	//章节考点关系表
		[Serializable()]
	public class tb_ChapterQuestion:EntityBase
	{
   	    
   	    /// <summary>
        /// 构造器
        /// </summary>
        public tb_ChapterQuestion()
        {
            TableName = "tb_ChapterQuestion";
            //主键
            List<string> keys = new List<string>();
            keys.Add("ID");
            PrimaryKeys = keys;
            //字段长度
           StringFieldSize["tb_ChapterQuestion_ID"]=4;
StringFieldSize["tb_ChapterQuestion_ChapterID"]=4;
StringFieldSize["tb_ChapterQuestion_QuestionID"]=4;
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
		/// 章节编号
        /// </summary>		
        public int ChapterID
        {
            get{ return GetPropertyValue<int>("ChapterID"); }
            set{ SetPropertyValue("ChapterID",value); }
        }        
				/// <summary>
		/// 题目编号
        /// </summary>		
        public int QuestionID
        {
            get{ return GetPropertyValue<int>("QuestionID"); }
            set{ SetPropertyValue("QuestionID",value); }
        }        
		   
	}
}

