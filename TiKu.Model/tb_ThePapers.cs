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
	 	//做题试卷
		[Serializable()]
	public class tb_ThePapers:EntityBase
	{
   	    
   	    /// <summary>
        /// 构造器
        /// </summary>
        public tb_ThePapers()
        {
            TableName = "tb_ThePapers";
            //主键
            List<string> keys = new List<string>();
            Identity="ID";
keys.Add("ID");
            PrimaryKeys = keys;
            //字段长度
           StringFieldSize["tb_ThePapers_ID"]=4;
StringFieldSize["tb_ThePapers_UserID"]=8;
StringFieldSize["tb_ThePapers_CapterID"]=4;
StringFieldSize["tb_ThePapers_AnswerQuantity"]=4;
StringFieldSize["tb_ThePapers_Names"]=60;
StringFieldSize["tb_ThePapers_CreatedOn"]=8;
StringFieldSize["tb_ThePapers_TestTime"]=8;
StringFieldSize["tb_ThePapers_Score"]=4;
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
        public int CapterID
        {
            get{ return GetPropertyValue<int>("CapterID"); }
            set{ SetPropertyValue("CapterID",value); }
        }        
				/// <summary>
		/// 答题量
        /// </summary>		
        public int AnswerQuantity
        {
            get{ return GetPropertyValue<int>("AnswerQuantity"); }
            set{ SetPropertyValue("AnswerQuantity",value); }
        }        
				/// <summary>
		/// Names
        /// </summary>		
        public string Names
        {
            get{ return GetPropertyValue<string>("Names"); }
            set{ SetPropertyValue("Names",value); }
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
		/// TestTime
        /// </summary>		
        public DateTime TestTime
        {
            get{ return GetPropertyValue<DateTime>("TestTime"); }
            set{ SetPropertyValue("TestTime",value); }
        }        
				/// <summary>
		/// 总分
        /// </summary>		
        public int Score
        {
            get{ return GetPropertyValue<int>("Score"); }
            set{ SetPropertyValue("Score",value); }
        }        
		   
	}
}

