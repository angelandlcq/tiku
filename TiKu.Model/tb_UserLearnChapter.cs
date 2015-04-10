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
	 	//已学习章节
		[Serializable()]
	public class tb_UserLearnChapter:EntityBase
	{
   	    
   	    /// <summary>
        /// 构造器
        /// </summary>
        public tb_UserLearnChapter()
        {
            TableName = "tb_UserLearnChapter";
            //主键
            List<string> keys = new List<string>();
            Identity="ID";
keys.Add("ID");
            PrimaryKeys = keys;
            //字段长度
           StringFieldSize["tb_UserLearnChapter_ID"]=4;
StringFieldSize["tb_UserLearnChapter_UserID"]=8;
StringFieldSize["tb_UserLearnChapter_ChapterID"]=4;
StringFieldSize["tb_UserLearnChapter_AddTime"]=8;
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
		/// 用户编号
        /// </summary>		
        public long UserID
        {
            get{ return GetPropertyValue<long>("UserID"); }
            set{ SetPropertyValue("UserID",value); }
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
		/// 时间
        /// </summary>		
        public DateTime AddTime
        {
            get{ return GetPropertyValue<DateTime>("AddTime"); }
            set{ SetPropertyValue("AddTime",value); }
        }        
		   
	}
}

