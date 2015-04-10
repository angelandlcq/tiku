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
	 	//已做试题
		[Serializable()]
	public class tb_DoneQuestion:EntityBase
	{
   	    
   	    /// <summary>
        /// 构造器
        /// </summary>
        public tb_DoneQuestion()
        {
            TableName = "tb_DoneQuestion";
            //主键
            List<string> keys = new List<string>();
            keys.Add("ID");
            PrimaryKeys = keys;
            //字段长度
           StringFieldSize["tb_DoneQuestion_ID"]=4;
StringFieldSize["tb_DoneQuestion_TestID"]=4;
StringFieldSize["tb_DoneQuestion_UserID"]=4;
StringFieldSize["tb_DoneQuestion_Answer"]=1000;
StringFieldSize["tb_DoneQuestion_AddDate"]=8;
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
		/// 试卷编号
        /// </summary>		
        public int TestID
        {
            get{ return GetPropertyValue<int>("TestID"); }
            set{ SetPropertyValue("TestID",value); }
        }        
				/// <summary>
		/// 用户编号
        /// </summary>		
        public int UserID
        {
            get{ return GetPropertyValue<int>("UserID"); }
            set{ SetPropertyValue("UserID",value); }
        }        
				/// <summary>
		/// 答案
        /// </summary>		
        public string Answer
        {
            get{ return GetPropertyValue<string>("Answer"); }
            set{ SetPropertyValue("Answer",value); }
        }        
				/// <summary>
		/// 日期
        /// </summary>		
        public DateTime AddDate
        {
            get{ return GetPropertyValue<DateTime>("AddDate"); }
            set{ SetPropertyValue("AddDate",value); }
        }        
		   
	}
}

