using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using LitJson;
/*****************************************************************************
 * 
 * className:Ajax处理（一般处理程序）
 * author:李朝强
 * date:2014/05/30
 * mark:
 * 
 * ***************************************************************************/
namespace TiKu.Admin.tools
{
    /// <summary>
    /// AjaxSubmit 的摘要说明
    /// </summary>
    public class AjaxSubmit : IHttpHandler
    {

        /// <summary>
        ///处理请求 
        /// </summary>
        /// <param name="context">当前请求上下文</param>
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string action = TiKu.Common.TKRequest.GetString("action");//操作
            try
            {
                switch (action)
                {
                    //验证代理商登录名是否存在
                    case "checkAgentName":
                        checkAgentName(context);
                        break;
                    //获取章节列表
                    case "getChaptersJson":
                        getChaptersJson(context);
                        break;
                    //获取课程列表
                    case "getCourseList":
                        getCourseList(context);
                        break;
                    //课程分类列表
                    case "getCourseCateList":
                        getCourseCateList(context);
                        break;
                }
            }
            catch (Exception ex)
            {
                TiKu.Common.LogUtil.Error(ex);
            }
        }

        /// <summary>
        ///获取章节
        /// </summary>
        /// <param name="context"></param>
        private void getChaptersJson(HttpContext context)
        {
            //课程编号
            string strCourseID = TiKu.Common.TKRequest.GetString("cid");
            if (string.IsNullOrEmpty(strCourseID))
            {
                return;
            }
            //声明BLL组件
            BLL.tb_Chapter bllCourse = new BLL.tb_Chapter();
            List<Model.tb_Chapter> list = new List<Model.tb_Chapter>();
            list = bllCourse.GetList(Convert.ToInt32(strCourseID));
            //转换为json
            StringBuilder stbJson = new StringBuilder();
            stbJson.Append("[");
            for (int i = 0; i < list.Count; i++)
            {
                stbJson.Append("{\"id\":\"" + list[i].ID + "\",\"pId\":\"" + list[i].ParentID + "\",\"name\":\"" + list[i].CptName + "\"}");
                stbJson.Append(",");
            }
            stbJson.Remove(stbJson.Length - 1, 1);//移除后一个,
            stbJson.Append("]");
            context.Response.Write(stbJson);
        }

        /// <summary>
        /// 代理商是否存在
        /// </summary>
        /// <param name="context"></param>
        private void checkAgentName(HttpContext context)
        {
            //BLL组件
            BLL.tb_Agent bll = new BLL.tb_Agent();
            string strAgentName = TiKu.Common.TKRequest.GetFormString("param");
            if (string.IsNullOrEmpty(strAgentName))
            {
                context.Response.Write("{\"status\":\"n\"}");
                return;
            }
            if (bll.CheckAgentName(strAgentName))
            {
                context.Response.Write("{\"status\":\"n\"}");
                return;
            }
            context.Response.Write("{\"status\":\"y\"}");
            context.Response.End();
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
        /// 获取课程列表
        /// </summary>
        /// <param name="context"></param>
        private void getCourseList(HttpContext context)
        {
            //课程分类
            string strCat = TiKu.Common.TKRequest.GetString("cat");
            List<Model.tb_CourseInfo> list = new List<Model.tb_CourseInfo>();
            if (!string.IsNullOrEmpty(strCat))
            {
                int iCat = 0;
                Int32.TryParse(strCat, out iCat);
                list = new BLL.tb_CourseInfo().GetCourseListByCateID(iCat);
            }
            StringBuilder stbJson = new StringBuilder();
            stbJson.Append("[");
            for (int i = 0; i < list.Count; i++)
            {
                stbJson.Append("{");
                stbJson.AppendFormat("\"id\":\"{0}\",\"name\":\"{1}\",\"cat\":\"{2}\"", list[i].ID, list[i].Names, list[i].CategoryID);
                stbJson.Append("},");
            }
            stbJson = stbJson.Remove(stbJson.Length - 1, 1);
            stbJson.Append("]");
            context.Response.Write(stbJson);
        }

        /// <summary>
        /// 获取课程分类列表
        /// </summary>
        /// <param name="context"></param>
        private void getCourseCateList(HttpContext context)
        {
            List<Model.tb_CourseCategory> list = new List<Model.tb_CourseCategory>();
            list = new BLL.tb_CourseCategory().GetCacheList();
            StringBuilder stbJson = new StringBuilder();
            //JSON编辑器
            LitJson.JsonWriter jw = new JsonWriter(stbJson);
            jw.WriteArrayStart();
            for (int i = 0; i < list.Count; i++)
            {
                jw.WriteObjectStart();

                jw.WritePropertyName("ID");
                jw.Write(list[i].ID);

                jw.WritePropertyName("Name");
                jw.Write(list[i].CateName);

                jw.WritePropertyName("ParentID");
                jw.Write(list[i].ParentID);

                jw.WriteObjectEnd();
            }
            jw.WriteArrayEnd();
            //输出
            context.Response.Write(stbJson);
        }

        /// <summary>
        /// 输出请求json
        /// </summary>
        /// <param name="ret">返回码</param>
        /// <param name="message">消息</param>
        /// <param name="context">请求上下文</param>
        private void Output(string ret, string message, HttpContext context)
        {
            context.Response.Write("{\"ret\":\"" + ret + "\",\"msg\":\"" + message + "\"}");
            context.Response.End();
        }
    }
}