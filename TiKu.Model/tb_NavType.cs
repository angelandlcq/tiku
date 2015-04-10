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
	 	//管理员权限
		[Serializable()]
	public class tb_NavType:EntityBase
	{
   	    
   	    /// <summary>
        /// 构造器
        /// </summary>
        public tb_NavType()
        {
            TableName = "tb_NavType";
            //主键
            List<string> keys = new List<string>();
            Identity="ID";
keys.Add("ID");
            PrimaryKeys = keys;
            //字段长度
           StringFieldSize["tb_NavType_ID"]=4;
StringFieldSize["tb_NavType_Names"]=30;
StringFieldSize["tb_NavType_ParentID"]=4;
StringFieldSize["tb_NavType_Orders"]=4;
StringFieldSize["tb_NavType_Enable"]=1;
StringFieldSize["tb_NavType_Del"]=4;
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
		/// 导航名称
        /// </summary>		
        public string Names
        {
            get{ return GetPropertyValue<string>("Names"); }
            set{ SetPropertyValue("Names",value); }
        }        
				/// <summary>
		/// 父级导航
        /// </summary>		
        public int ParentID
        {
            get{ return GetPropertyValue<int>("ParentID"); }
            set{ SetPropertyValue("ParentID",value); }
        }        
				/// <summary>
		/// 排序
        /// </summary>		
        public int Orders
        {
            get{ return GetPropertyValue<int>("Orders"); }
            set{ SetPropertyValue("Orders",value); }
        }        
				/// <summary>
		/// 是否启用
        /// </summary>		
        public bool Enable
        {
            get{ return GetPropertyValue<bool>("Enable"); }
            set{ SetPropertyValue("Enable",value); }
        }        
				/// <summary>
		/// 删除标示
        /// </summary>		
        public int Del
        {
            get{ return GetPropertyValue<int>("Del"); }
            set{ SetPropertyValue("Del",value); }
        }        
		   
	}
}

