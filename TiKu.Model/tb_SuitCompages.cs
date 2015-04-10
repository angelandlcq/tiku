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
	 	//套装组合
		[Serializable()]
	public class tb_SuitCompages:EntityBase
	{
   	    
   	    /// <summary>
        /// 构造器
        /// </summary>
        public tb_SuitCompages()
        {
            TableName = "tb_SuitCompages";
            //主键
            List<string> keys = new List<string>();
            Identity="ID";
keys.Add("ID");
            PrimaryKeys = keys;
            //字段长度
           StringFieldSize["tb_SuitCompages_ID"]=4;
StringFieldSize["tb_SuitCompages_CourseID"]=4;
StringFieldSize["tb_SuitCompages_LimitedChapter"]=4;
StringFieldSize["tb_SuitCompages_CreatedOn"]=8;
StringFieldSize["tb_SuitCompages_CreatedBy"]=4;
StringFieldSize["tb_SuitCompages_State"]=4;
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
		/// 课程编号
        /// </summary>		
        public int CourseID
        {
            get{ return GetPropertyValue<int>("CourseID"); }
            set{ SetPropertyValue("CourseID",value); }
        }        
				/// <summary>
		/// 最多章节数
        /// </summary>		
        public int LimitedChapter
        {
            get{ return GetPropertyValue<int>("LimitedChapter"); }
            set{ SetPropertyValue("LimitedChapter",value); }
        }        
				/// <summary>
		/// 创建时间
        /// </summary>		
        public DateTime CreatedOn
        {
            get{ return GetPropertyValue<DateTime>("CreatedOn"); }
            set{ SetPropertyValue("CreatedOn",value); }
        }        
				/// <summary>
		/// 创建人
        /// </summary>		
        public int CreatedBy
        {
            get{ return GetPropertyValue<int>("CreatedBy"); }
            set{ SetPropertyValue("CreatedBy",value); }
        }        
				/// <summary>
		/// 状态
        /// </summary>		
        public int State
        {
            get{ return GetPropertyValue<int>("State"); }
            set{ SetPropertyValue("State",value); }
        }        
		   
	}
}

