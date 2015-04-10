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
	 	//用户问题反馈
		[Serializable()]
	public class tb_Feedback:EntityBase
	{
   	    
   	    /// <summary>
        /// 构造器
        /// </summary>
        public tb_Feedback()
        {
            TableName = "tb_Feedback";
            //主键
            List<string> keys = new List<string>();
            Identity="ID";
keys.Add("ID");
            PrimaryKeys = keys;
            //字段长度
           StringFieldSize["tb_Feedback_ID"]=4;
StringFieldSize["tb_Feedback_UserID"]=8;
StringFieldSize["tb_Feedback_Contents"]=1000;
StringFieldSize["tb_Feedback_AddDate"]=8;
StringFieldSize["tb_Feedback_State"]=4;
StringFieldSize["tb_Feedback_Audit"]=4;
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
        public long UserID
        {
            get{ return GetPropertyValue<long>("UserID"); }
            set{ SetPropertyValue("UserID",value); }
        }        
				/// <summary>
		/// 反馈内容
        /// </summary>		
        public string Contents
        {
            get{ return GetPropertyValue<string>("Contents"); }
            set{ SetPropertyValue("Contents",value); }
        }        
				/// <summary>
		/// 添加日期
        /// </summary>		
        public DateTime AddDate
        {
            get{ return GetPropertyValue<DateTime>("AddDate"); }
            set{ SetPropertyValue("AddDate",value); }
        }        
				/// <summary>
		/// 状态
        /// </summary>		
        public int State
        {
            get{ return GetPropertyValue<int>("State"); }
            set{ SetPropertyValue("State",value); }
        }        
				/// <summary>
		/// 审核人
        /// </summary>		
        public int Audit
        {
            get{ return GetPropertyValue<int>("Audit"); }
            set{ SetPropertyValue("Audit",value); }
        }        
		   
	}
}

