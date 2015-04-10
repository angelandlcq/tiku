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
	 	//消费记录
		[Serializable()]
	public class tb_UserBalance:EntityBase
	{
   	    
   	    /// <summary>
        /// 构造器
        /// </summary>
        public tb_UserBalance()
        {
            TableName = "tb_UserBalance";
            //主键
            List<string> keys = new List<string>();
            keys.Add("ID");
            PrimaryKeys = keys;
            //字段长度
           StringFieldSize["tb_UserBalance_ID"]=4;
StringFieldSize["tb_UserBalance_UserID"]=8;
StringFieldSize["tb_UserBalance_Amount"]=8;
StringFieldSize["tb_UserBalance_Note"]=200;
StringFieldSize["tb_UserBalance_Balance"]=8;
StringFieldSize["tb_UserBalance_AddTime"]=8;
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
		/// UserID
        /// </summary>		
        public long UserID
        {
            get{ return GetPropertyValue<long>("UserID"); }
            set{ SetPropertyValue("UserID",value); }
        }        
				/// <summary>
		/// Amount
        /// </summary>		
        public decimal Amount
        {
            get{ return GetPropertyValue<decimal>("Amount"); }
            set{ SetPropertyValue("Amount",value); }
        }        
				/// <summary>
		/// Note
        /// </summary>		
        public string Note
        {
            get{ return GetPropertyValue<string>("Note"); }
            set{ SetPropertyValue("Note",value); }
        }        
				/// <summary>
		/// Balance
        /// </summary>		
        public decimal Balance
        {
            get{ return GetPropertyValue<decimal>("Balance"); }
            set{ SetPropertyValue("Balance",value); }
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

