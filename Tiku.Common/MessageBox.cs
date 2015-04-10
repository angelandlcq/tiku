using System;
using System.Collections.Generic;
#if CSHARP4 
 using System.Linq;
#endif
using System.Text;
using System.Web.UI;
/*****************************************************************************
 * 
 * className:提供画面基本的信息提示
 * author:李朝强
 * date:2014/05/30
 * mark:
 * 
 * ***************************************************************************/
#region 消息类型
/// <summary>
/// 消息类型
/// </summary>
public enum MessageType
{
    //1>成功消息
    Success,
    //2>错误消息
    Error,
    //3>询问
    Question,
    //4>警告
    Warn,
    //5>通知
    Info,
    //6>系统错误
    SystemError
}
#endregion
namespace TiKu.Common
{



    public class MessageBox
    {

        /// <summary>
        /// 弹出消息
        /// </summary>
        /// <param name="ctrl"></param>
        /// <param name="message"></param>
        /// <param name="type"></param>
        public static void ShowMsg(System.Web.UI.Page page, string message, MessageType type)
        {
            ShowMsg(message, string.Empty, page, type);

        }

        /// <summary>
        /// 弹出消息
        /// </summary>
        /// <param name="ctrl"></param>
        /// <param name="message"></param>
        /// <param name="type"></param>
        public static void ShowMsg(string message,
                                   string url,
                                   System.Web.UI.Page page,
                                   MessageType type)
        {
            string strJsShow = "window.ShowMsg('系统提示',\"" + message + "\",\"" + url + "\",\"{0}\");";
            switch (type)
            {
                //1>成功消息
                case MessageType.Success:
                    strJsShow = string.Format(strJsShow, "success");
                    break;
                //2>通知消息
                case MessageType.Info:
                    strJsShow = string.Format(strJsShow, "alert");
                    break;
                //3>警告
                case MessageType.Warn:
                    strJsShow = string.Format(strJsShow, "confirm");
                    TiKu.Common.LogUtil.Info(message);//记录到日志
                    break;
                //4>询问
                case MessageType.Question:
                    strJsShow = string.Format(strJsShow, "prompt");
                    break;
                //6>错误
                case MessageType.Error:
                    strJsShow = string.Format(strJsShow, "alert");
                    break;
                //5>系统错误
                case MessageType.SystemError:
                    strJsShow = string.Format(strJsShow, "error");
                    break;
            }
            //向客户端发送脚本
            page.ClientScript.RegisterStartupScript(page.GetType(),
                                                    "_system_show_msg",
                                                     strJsShow,
                                                     true);

        }

        /// <summary>
        /// 提示框
        /// </summary>
        /// <param name="message"></param>
        /// <param name="type"></param>
        public static void Tip(string message, MessageType type)
        {
            string strJsShow = "lhgdialog.tips(\"" + message + "\",3,\"{0}\");";
            switch (type)
            {
                //1>成功消息
                case MessageType.Success:
                    strJsShow = string.Format(strJsShow, "success");
                    break;
                //2>通知消息
                case MessageType.Info:
                    strJsShow = string.Format(strJsShow, "alert");
                    break;
                //3>警告
                case MessageType.Warn:
                    strJsShow = string.Format(strJsShow, "confirm");
                    break;
                //4>询问
                case MessageType.Question:
                    strJsShow = string.Format(strJsShow, "prompt");
                    break;
                //5>系统错误
                case MessageType.SystemError:
                    strJsShow = string.Format(strJsShow, "error");
                    break;
            }
        }

        /// <summary>
        /// alert方式弹出消息
        /// </summary>
        /// <param name="ctrl"></param>
        /// <param name="message"></param>
        public static void Alert(System.Web.UI.Page page, string message)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(),
                                                    "_system_show_msg",
                                                    string.Format("alert(\"{0}\");", message),
                                                    true);
        }

    }
}
