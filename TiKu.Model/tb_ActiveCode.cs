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
	 	//激活码生成表
		[Serializable()]
	public class tb_ActiveCode:EntityBase
	{
   	    
   	    /// <summary>
        /// 构造器
        /// </summary>
        public tb_ActiveCode()
        {
            TableName = "tb_ActiveCode";
            //主键
            List<string> keys = new List<string>();
            keys.Add("ID");
            PrimaryKeys = keys;
            //字段长度
           StringFieldSize["tb_ActiveCode_ID"]=4;
StringFieldSize["tb_ActiveCode_Code"]=30;
StringFieldSize["tb_ActiveCode_TableName"]=30;
StringFieldSize["tb_ActiveCode_State"]=4;
StringFieldSize["tb_ActiveCode_UserID"]=4;
StringFieldSize["tb_ActiveCode_CourseID"]=4;
StringFieldSize["tb_ActiveCode_CreatedBy"]=4;
StringFieldSize["tb_ActiveCode_CreatedOn"]=8;
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
		/// 激活码
        /// </summary>		
        public string Code
        {
            get{ return GetPropertyValue<string>("Code"); }
            set{ SetPropertyValue("Code",value); }
        }        
				/// <summary>
		/// 表名
        /// </summary>		
        public string TableName
        {
            get{ return GetPropertyValue<string>("TableName"); }
            set{ SetPropertyValue("TableName",value); }
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
		/// UserID
        /// </summary>		
        public int UserID
        {
            get{ return GetPropertyValue<int>("UserID"); }
            set{ SetPropertyValue("UserID",value); }
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
		/// 创建编号
        /// </summary>		
        public int CreatedBy
        {
            get{ return GetPropertyValue<int>("CreatedBy"); }
            set{ SetPropertyValue("CreatedBy",value); }
        }        
				/// <summary>
		/// 创建日期
        /// </summary>		
        public DateTime CreatedOn
        {
            get{ return GetPropertyValue<DateTime>("CreatedOn"); }
            set{ SetPropertyValue("CreatedOn",value); }
        }        
		   
	}
}

