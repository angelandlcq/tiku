using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
/*****************************************************************************
 * 
 * className:上传图片（一般处理程序）
 * author:李朝强
 * date:2014/05/30
 * mark:
 * 
 * ***************************************************************************/
namespace TiKu.Admin.tools
{
    /// <summary>
    /// uploader 的摘要说明
    /// </summary>
    public class UpfileTool : IHttpHandler
    {

        /// <summary>
        /// 处理请求
        /// </summary>
        /// <param name="context"></param>
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            if (context.Request.Files.Count > 0)
            {
                string _newfile = string.Empty,
                    error = string.Empty,
                    uploadPath = string.Format("{0}{1}", TiKu.Common.Constants.ADMIN.UPLOAD_PATH, "advertor/");
                long _maxlength = 6 * 1024 * 1024;//6MB
                if (TiKu.Common.UpfileTool.Upload(context.Request.Files[0],
                                              new string[4] { ".jpg", ".png", ".jpeg", ".gif" },
                                              _maxlength,
                                              uploadPath,
                                              ref _newfile,
                                              ref error))
                {

                    //上传成功
                    context.Response.Write("{\"ret\":\"1\",\"msg\":\"上传成功！\",\"filename\":\"" + string.Format("{0}{1}", uploadPath, _newfile) + "\"}");
                }
                else
                {
                    context.Response.Write("{\"ret\":\"0\",\"msg\":\"" + error + "！\"}");
                }
            }
            else
            {
                context.Response.Write("{\"ret\":\"0\",\"msg\":\"请求无效！\"}");
            }
        }

        /// <summary>
        /// 是否可以重用
        /// </summary>
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// 输出
        /// </summary>
        /// <param name="ret">返回码</param>
        /// <param name="msg">消息</param>
        /// <param name="context">请求上下文</param>
        private void Output(int ret, string msg, HttpContext context)
        {
            context.Response.Write("{\"ret\":\"" + ret + "\",\"msg\":\"" + msg + "\"}");
        }
    }
}