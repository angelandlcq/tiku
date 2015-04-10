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
	 	//订单基本信息表
		[Serializable()]
	public class tb_Order:EntityBase
	{
   	    
   	    /// <summary>
        /// 构造器
        /// </summary>
        public tb_Order()
        {
            TableName = "tb_Order";
            //主键
            List<string> keys = new List<string>();
            Identity="ID";
keys.Add("ID");
            PrimaryKeys = keys;
            //字段长度
           StringFieldSize["tb_Order_ID"]=4;
StringFieldSize["tb_Order_OrderNO"]=32;
StringFieldSize["tb_Order_Amount"]=8;
StringFieldSize["tb_Order_TenderType"]=15;
StringFieldSize["tb_Order_AddTime"]=8;
StringFieldSize["tb_Order_State"]=4;
StringFieldSize["tb_Order_UserID"]=8;
StringFieldSize["tb_Order_Remark"]=200;
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
		/// 订单号
        /// </summary>		
        public string OrderNO
        {
            get{ return GetPropertyValue<string>("OrderNO"); }
            set{ SetPropertyValue("OrderNO",value); }
        }        
				/// <summary>
		/// 交易金额
        /// </summary>		
        public decimal Amount
        {
            get{ return GetPropertyValue<decimal>("Amount"); }
            set{ SetPropertyValue("Amount",value); }
        }        
				/// <summary>
		/// 支付方式
        /// </summary>		
        public string TenderType
        {
            get{ return GetPropertyValue<string>("TenderType"); }
            set{ SetPropertyValue("TenderType",value); }
        }        
				/// <summary>
		/// 交易时间
        /// </summary>		
        public DateTime AddTime
        {
            get{ return GetPropertyValue<DateTime>("AddTime"); }
            set{ SetPropertyValue("AddTime",value); }
        }        
				/// <summary>
		/// 订单状态
        /// </summary>		
        public int State
        {
            get{ return GetPropertyValue<int>("State"); }
            set{ SetPropertyValue("State",value); }
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
		/// Remark
        /// </summary>		
        public string Remark
        {
            get{ return GetPropertyValue<string>("Remark"); }
            set{ SetPropertyValue("Remark",value); }
        }        
		   
	}
}

