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
	 	//后台管理页面
		[Serializable()]
	public class tb_AdminPage:EntityBase
	{
   	    
   	    /// <summary>
        /// 构造器
        /// </summary>
        public tb_AdminPage()
        {
            TableName = "tb_AdminPage";
            //主键
            List<string> keys = new List<string>();
            Identity="ID";
keys.Add("ID");
            PrimaryKeys = keys;
            //字段长度
           StringFieldSize["tb_AdminPage_ID"]=4;
StringFieldSize["tb_AdminPage_Names"]=20;
StringFieldSize["tb_AdminPage_LinkUrl"]=200;
StringFieldSize["tb_AdminPage_Target"]=12;
StringFieldSize["tb_AdminPage_ImageUrl"]=200;
StringFieldSize["tb_AdminPage_Orders"]=4;
StringFieldSize["tb_AdminPage_Del"]=4;
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
		/// 页面名称
        /// </summary>		
        public string Names
        {
            get{ return GetPropertyValue<string>("Names"); }
            set{ SetPropertyValue("Names",value); }
        }        
				/// <summary>
		/// 链接地址
        /// </summary>		
        public string LinkUrl
        {
            get{ return GetPropertyValue<string>("LinkUrl"); }
            set{ SetPropertyValue("LinkUrl",value); }
        }        
				/// <summary>
		/// 打开窗口方式
        /// </summary>		
        public string Target
        {
            get{ return GetPropertyValue<string>("Target"); }
            set{ SetPropertyValue("Target",value); }
        }        
				/// <summary>
		/// 菜单图标
        /// </summary>		
        public string ImageUrl
        {
            get{ return GetPropertyValue<string>("ImageUrl"); }
            set{ SetPropertyValue("ImageUrl",value); }
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
		/// 删除标示
        /// </summary>		
        public int Del
        {
            get{ return GetPropertyValue<int>("Del"); }
            set{ SetPropertyValue("Del",value); }
        }        
		   
	}
}

