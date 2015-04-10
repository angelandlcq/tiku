using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
/**********************************************************************
 * 
 * 
 * 说 明：系统日志
 * 
 * *******************************************************************/
namespace TiKu.Admin._base
{
    public partial class systemLog : System.Web.UI.Page
    {

        /// <summary>
        /// 日志目录
        /// </summary>
        private static readonly string LogPath = "/Log/";

        /// <summary>
        /// 画面载入事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //绑定数据列表
                data();
            }
        }

        /// <summary>
        /// 获取日志列表
        /// </summary>
        protected void data()
        {
            List<FileInfo> list = new List<FileInfo>();
            list = GetLogList();
            lblSize.Text = TiKu.Common.Util.FormatBytesStr(list.Sum((m) => { return m.Length; }));
            //绑定列表
            RepList.DataSource = list;
            RepList.DataBind();
        }

        /// <summary>
        /// 获取日志文件列表
        /// </summary>
        /// <returns></returns>
        private List<FileInfo> GetLogList()
        {
            string strPath = TiKu.Common.Util.GetPath("/Log/Error/");//日志路径
            string strCacheKey = "__CACHE_ERROR_LOG";
            DirectoryInfo dir = new DirectoryInfo(strPath);
            List<FileInfo> list = null;
            //缓存
            if (TiKu.Common.CacheHelper.IsExistsCahce(strCacheKey))
            {
                //从缓存中提取数据
                list = TiKu.Common.CacheHelper.GetCacheValue<List<FileInfo>>(strCacheKey);
            }
            else
            {
                //获取日志目录下的日志文件集合
                FileInfo[] files = dir.GetFiles();
                list = files.ToList<FileInfo>();
                if (files.Length <= 100)
                {
                    //创建缓存依赖
                    System.Web.Caching.CacheDependency dependency = new System.Web.Caching.CacheDependency(strPath);
                    //缓存起对象
                    TiKu.Common.CacheHelper.SaveCache(strCacheKey,
                                                      list,
                                                      dependency,
                                                      new TimeSpan(2, 0, 0));//缓存2Hours
                }
            }
            list = list.OrderByDescending((f) => { return f.LastWriteTime; }).ToList();
            return list;
        }

        /// <summary>
        /// 操作
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void RepList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            //删除
            if (e.CommandName == "delete")
            {
                try
                {
                    string filename = LogPath + "/Error/" + e.CommandArgument;
                    filename = TiKu.Common.Util.GetPath(filename);
                    if (File.Exists(filename))
                    {
                        File.Delete(filename);
                        TiKu.Common.CacheHelper.RemoveCache("__CACHE_ERROR_LOG");
                        data();
                    }
                }
                catch { }
            }
        }

        /// <summary>
        /// 清空过期日志
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                //获取日志文件列表
                List<FileInfo> list = GetLogList();

                //循环删除
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].CreationTime <= DateTime.Now.AddDays(-1))
                    {
                        list[i].Delete();
                    }
                }
                TiKu.Common.CacheHelper.RemoveCache("__CACHE_ERROR_LOG");
                data();
            }
            catch { }
        }
    }
}