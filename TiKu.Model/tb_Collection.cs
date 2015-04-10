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
	 	//会员收藏
		[Serializable()]
	public class tb_Collection:EntityBase
	{
   	    
   	    /// <summary>
        /// 构造器
        /// </summary>
        public tb_Collection()
        {
            TableName = "tb_Collection";
            //主键
            List<string> keys = new List<string>();
            Identity="ID";
keys.Add("ID");
            PrimaryKeys = keys;
            //字段长度
           StringFieldSize["tb_Collection_ID"]=9;
StringFieldSize["tb_Collection_UserID"]=8;
StringFieldSize["tb_Collection_QuestionID"]=4;
        }
   	    

   	
      			/// <summary>
		/// 编号
        /// </summary>		
        public decimal ID
        {
            get{ return GetPropertyValue<decimal>("ID"); }
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
		   
	}
}

