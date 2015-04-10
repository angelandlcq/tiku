using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
/****************************************************************************
 * 
 * 
 * 说 明：提供公用的方法
 * 
 * 
 * **************************************************************************/
namespace TiKu.BLL
{
    public class tb_provider
    {
        /// <summary>
        /// 获取DataBase表列表
        /// </summary>
        /// <returns></returns>
        public List<string> GetTableList()
        {
            List<string> listTable = new List<string>();
            //从缓存中提取数据
            if (TiKu.Common.CacheHelper.IsExistsCahce(TiKu.Common.Constants.CACHE_KEY._CACHE_DATABASE_TABLES_KEY))
            {
                return TiKu.Common.CacheHelper.GetCacheValue<List<string>>(TiKu.Common.Constants.CACHE_KEY._CACHE_DATABASE_TABLES_KEY);
            }
            string strCmdText = "SELECT [NAME] FROM SYS.OBJECTS WHERE TYPE='U';";
            listTable = TiKu.DataDriver.AdoHelper.ToList<string>(strCmdText,
                                                      null,
                                                      (data) =>
                                                      {
                                                          return data["NAME"].ToString();
                                                      });
            //缓存数据
            TiKu.Common.CacheHelper.SaveCache(TiKu.Common.Constants.CACHE_KEY._CACHE_DATABASE_TABLES_KEY, listTable);
            return listTable;
        }

        /// <summary>
        /// 绑定下拉列表
        /// </summary>
        /// <param name="drp">控件：DropDownList</param>
        public void BindDropDownList(DropDownList drp)
        {
            List<string> list = GetTableList();
            for (int i = 0; i < list.Count; i++)
            {
                drp.Items.Add(new ListItem(list[i], list[i]));
            }
            drp.Items.Insert(0, new ListItem("--请选择表名--", string.Empty));
        }
    }
}
