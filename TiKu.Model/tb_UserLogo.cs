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
	 	//会员日志
		[Serializable()]
	public class tb_UserLogo:EntityBase
	{
   	    
   	    /// <summary>
        /// 构造器
        /// </summary>
        public tb_UserLogo()
        {
            TableName = "tb_UserLogo";
            //主键
            List<string> keys = new List<string>();
            keys.Add("ID");
            PrimaryKeys = keys;
            //字段长度
           StringFieldSize["tb_UserLogo_ID"]=4;
StringFieldSize["tb_UserLogo_UserID"]=8;
StringFieldSize["tb_UserLogo_ActionTyp"]=4;
StringFieldSize["tb_UserLogo_TableName"]=30;
StringFieldSize["tb_UserLogo_Level"]=10;
StringFieldSize["tb_UserLogo_Msg"]=300;
StringFieldSize["tb_UserLogo_Event"]=10;
StringFieldSize["tb_UserLogo_AddTime"]=8;
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
		/// ActionTyp
        /// </summary>		
        public int ActionTyp
        {
            get{ return GetPropertyValue<int>("ActionTyp"); }
            set{ SetPropertyValue("ActionTyp",value); }
        }        
				/// <summary>
		/// TableName
        /// </summary>		
        public string TableName
        {
            get{ return GetPropertyValue<string>("TableName"); }
            set{ SetPropertyValue("TableName",value); }
        }        
				/// <summary>
		/// Level
        /// </summary>		
        public string Level
        {
            get{ return GetPropertyValue<string>("Level"); }
            set{ SetPropertyValue("Level",value); }
        }        
				/// <summary>
		/// Msg
        /// </summary>		
        public string Msg
        {
            get{ return GetPropertyValue<string>("Msg"); }
            set{ SetPropertyValue("Msg",value); }
        }        
				/// <summary>
		/// Event
        /// </summary>		
        public string Event
        {
            get{ return GetPropertyValue<string>("Event"); }
            set{ SetPropertyValue("Event",value); }
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

