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
	 	//地区
		[Serializable()]
	public class tb_Area:EntityBase
	{
   	    
   	    /// <summary>
        /// 构造器
        /// </summary>
        public tb_Area()
        {
            TableName = "tb_Area";
            //主键
            List<string> keys = new List<string>();
            Identity="ID";
keys.Add("ID");
            PrimaryKeys = keys;
            //字段长度
           StringFieldSize["tb_Area_ID"]=4;
StringFieldSize["tb_Area_AreaCode"]=20;
StringFieldSize["tb_Area_AreaName"]=20;
StringFieldSize["tb_Area_Orders"]=4;
StringFieldSize["tb_Area_State"]=4;
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
		/// 地区编号
        /// </summary>		
        public string AreaCode
        {
            get{ return GetPropertyValue<string>("AreaCode"); }
            set{ SetPropertyValue("AreaCode",value); }
        }        
				/// <summary>
		/// 地区名称
        /// </summary>		
        public string AreaName
        {
            get{ return GetPropertyValue<string>("AreaName"); }
            set{ SetPropertyValue("AreaName",value); }
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
		/// 状态
        /// </summary>		
        public int State
        {
            get{ return GetPropertyValue<int>("State"); }
            set{ SetPropertyValue("State",value); }
        }        
		   
	}
}

