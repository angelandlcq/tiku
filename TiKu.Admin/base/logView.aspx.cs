using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TiKu.Admin._base
{
    public partial class logView : System.Web.UI.Page
    {
        /// <summary>
        /// 文件名
        /// </summary>
        private string FileName
        {
            get { return TiKu.Common.TKRequest.GetQueryString("name"); }
        }
        /// <summary>
        /// 画面初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!(IsPostBack))
            {
                if (string.IsNullOrEmpty(FileName))
                {
                    return;
                }
                try
                {
                    string filename = "/Log/Error/" + HttpUtility.UrlDecode(FileName);
                    filename = TiKu.Common.Util.GetPath(filename);
                    if (System.IO.File.Exists(filename) == false) { return; }
                    //多线程读取文件，共享锁
                    FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    StreamReader sr = new StreamReader(fs, System.Text.Encoding.Default);
                    txtBody.Value = sr.ReadToEnd();

                    sr.Close();
                    sr.Dispose();
                    fs.Close();
                    fs.Dispose();

                }
                catch { }
            }
        }
    }
}