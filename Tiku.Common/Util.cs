using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Web;
using System.Text.RegularExpressions;
using System.Web.UI;

namespace TiKu.Common
{
    public class Util
    {
        /// <summary>
        /// 字符串如果操过指定长度则将超出的部分用指定字符串代替
        /// </summary>
        /// <param name="p_SrcString">要检查的字符串</param>
        /// <param name="p_Length">指定长度</param>
        /// <param name="p_TailString">用于替换的字符串</param>
        /// <returns>截取后的字符串</returns>
        public static string GetSubString(string p_SrcString, int p_Length, string p_TailString)
        {
            return GetSubString(p_SrcString, 0, p_Length, p_TailString);
        }

        /// <summary>
        /// 取指定长度的字符串
        /// </summary>
        /// <param name="p_SrcString">要检查的字符串</param>
        /// <param name="p_StartIndex">起始位置</param>
        /// <param name="p_Length">指定长度</param>
        /// <param name="p_TailString">用于替换的字符串</param>
        /// <returns>截取后的字符串</returns>
        public static string GetSubString(string p_SrcString, int p_StartIndex, int p_Length, string p_TailString)
        {
            string myResult = p_SrcString;

            Byte[] bComments = Encoding.UTF8.GetBytes(p_SrcString);
            foreach (char c in Encoding.UTF8.GetChars(bComments))
            {    //当是日文或韩文时(注:中文的范围:\u4e00 - \u9fa5, 日文在\u0800 - \u4e00, 韩文为\xAC00-\xD7A3)
                if ((c > '\u0800' && c < '\u4e00') || (c > '\xAC00' && c < '\xD7A3'))
                {
                    //if (System.Text.RegularExpressions.Regex.IsMatch(p_SrcString, "[\u0800-\u4e00]+") || System.Text.RegularExpressions.Regex.IsMatch(p_SrcString, "[\xAC00-\xD7A3]+"))
                    //当截取的起始位置超出字段串长度时
                    if (p_StartIndex >= p_SrcString.Length)
                        return "";
                    else
                        return p_SrcString.Substring(p_StartIndex,
                                                       ((p_Length + p_StartIndex) > p_SrcString.Length) ? (p_SrcString.Length - p_StartIndex) : p_Length);
                }
            }

            if (p_Length >= 0)
            {
                byte[] bsSrcString = Encoding.Default.GetBytes(p_SrcString);

                //当字符串长度大于起始位置
                if (bsSrcString.Length > p_StartIndex)
                {
                    int p_EndIndex = bsSrcString.Length;

                    //当要截取的长度在字符串的有效长度范围内
                    if (bsSrcString.Length > (p_StartIndex + p_Length))
                    {
                        p_EndIndex = p_Length + p_StartIndex;
                    }
                    else
                    {   //当不在有效范围内时,只取到字符串的结尾

                        p_Length = bsSrcString.Length - p_StartIndex;
                        p_TailString = "";
                    }

                    int nRealLength = p_Length;
                    int[] anResultFlag = new int[p_Length];
                    byte[] bsResult = null;

                    int nFlag = 0;
                    for (int i = p_StartIndex; i < p_EndIndex; i++)
                    {
                        if (bsSrcString[i] > 127)
                        {
                            nFlag++;
                            if (nFlag == 3)
                                nFlag = 1;
                        }
                        else
                            nFlag = 0;

                        anResultFlag[i] = nFlag;
                    }

                    if ((bsSrcString[p_EndIndex - 1] > 127) && (anResultFlag[p_Length - 1] == 1))
                        nRealLength = p_Length + 1;

                    bsResult = new byte[nRealLength];

                    Array.Copy(bsSrcString, p_StartIndex, bsResult, 0, nRealLength);

                    myResult = Encoding.Default.GetString(bsResult);
                    myResult = myResult + p_TailString;
                }
            }

            return myResult;
        }


        #region Json特符字符过滤，参见http://www.json.org/
        /// <summary>
        /// Json特符字符过滤，参见http://www.json.org/
        /// </summary>
        /// <param name="sourceStr">要过滤的源字符串</param>
        /// <returns>返回过滤的字符串</returns>
        public static string JsonCharFilter(string sourceStr)
        {
            sourceStr = sourceStr.Replace("\\", "\\\\");
            sourceStr = sourceStr.Replace("\b", "\\\b");
            sourceStr = sourceStr.Replace("\t", "\\\t");
            sourceStr = sourceStr.Replace("\n", "\\\n");
            sourceStr = sourceStr.Replace("\n", "\\\n");
            sourceStr = sourceStr.Replace("\f", "\\\f");
            sourceStr = sourceStr.Replace("\r", "\\\r");
            return sourceStr.Replace("\"", "\\\"");
        }
        #endregion

        #region Private Methods
        private static string[] browerNames = { "MSIE", "Firefox", "Opera", "Netscape", "Safari", "Lynx", "Konqueror", "Mozilla" };
        //private const string[] osNames = { "Win", "Mac", "Linux", "FreeBSD", "SunOS", "OS/2", "AIX", "Bot", "Crawl", "Spider" };

        /// <summary>
        /// 获得浏览器信息
        /// </summary>
        /// <returns></returns>
        public static string GetClientBrower()
        {
            string agent = HttpContext.Current.Request.ServerVariables["HTTP_USER_AGENT"];
            if (!string.IsNullOrEmpty(agent))
            {
                foreach (string name in browerNames)
                {
                    if (agent.Contains(name))
                        return name;
                }
            }
            return "Other";
        }

        /// <summary>
        /// 获得操作系统信息
        /// </summary>
        /// <returns></returns>
        public static string GetClientOS()
        {
            string os = string.Empty;
            string agent = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_USER_AGENT"];
            if (agent == null)
                return "Other";

            if (agent.IndexOf("Win") > -1)
                os = "Windows";
            else if (agent.IndexOf("Mac") > -1)
                os = "Mac";
            else if (agent.IndexOf("Linux") > -1)
                os = "Linux";
            else if (agent.IndexOf("FreeBSD") > -1)
                os = "FreeBSD";
            else if (agent.IndexOf("SunOS") > -1)
                os = "SunOS";
            else if (agent.IndexOf("OS/2") > -1)
                os = "OS/2";
            else if (agent.IndexOf("AIX") > -1)
                os = "AIX";
            else if (System.Text.RegularExpressions.Regex.IsMatch(agent, @"(Bot|Crawl|Spider)"))
                os = "Spiders";
            else
                os = "Other";
            return os;
        }
        #endregion

        #region 判断当前客户端请求是否为IE
        /// <summary>
        /// 判断当前客户端请求是否为IE
        /// </summary>
        /// <returns></returns>
        public static bool IsIE()
        {
            return HttpContext.Current.Request.ServerVariables["HTTP_USER_AGENT"].IndexOf("MSIE") >= 0;
        }
        #endregion

        #region 过滤HTML中的不安全标签
        /// <summary>
        /// 过滤HTML中的不安全标签
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string RemoveUnsafeHtml(string content)
        {
            content = Regex.Replace(content, @"(\<|\s+)o([a-z]+\s?=)", "$1$2", RegexOptions.IgnoreCase);
            content = Regex.Replace(content, @"(script|frame|form|meta|behavior|style|link)([\s|:|>])+", "$1.$2", RegexOptions.IgnoreCase);
            return content;
        }
        #endregion

        #region Html编码、解码
        /// <summary>
        /// (一)html编码
        /// </summary>
        /// <param name="strHtml"></param>
        /// <returns></returns>
        public static string HtmlEncode(string strHtml)
        {
            //1>将输入字符串编码,策略：" 默认禁止，显式允许”
            strHtml = Regex.Replace(strHtml, @"<html[^>]*?>.*?</html>", "", RegexOptions.IgnoreCase);
            strHtml = Regex.Replace(strHtml, @"<html[^>]*?/>", "", RegexOptions.IgnoreCase);
            strHtml = Regex.Replace(strHtml, @"<body[^>]*?>.*?</body>", "", RegexOptions.IgnoreCase);
            strHtml = Regex.Replace(strHtml, @"<body[^>]*?/>", "", RegexOptions.IgnoreCase);
            strHtml = Regex.Replace(strHtml, @"<meta[^>]*?>.*?</meta>", "", RegexOptions.IgnoreCase);
            strHtml = Regex.Replace(strHtml, @"<meta[^>]*?/>", "", RegexOptions.IgnoreCase);
            strHtml = Regex.Replace(strHtml, @"<frame[^>]*?>.*?</frame>", "", RegexOptions.IgnoreCase);
            strHtml = Regex.Replace(strHtml, @"<frame[^>]*?/>", "", RegexOptions.IgnoreCase);
            strHtml = Regex.Replace(strHtml, @"<frameset[^>]*?>.*?</frameset>", "", RegexOptions.IgnoreCase);
            strHtml = Regex.Replace(strHtml, @"<frameset[^>]*?/>", "", RegexOptions.IgnoreCase);
            //(<iframe[^>]*?>.*?</iframe>)|(<iframe[^>]*?>)
            strHtml = Regex.Replace(strHtml, @"(<iframe[^>]*?>.*?</iframe>)|(<iframe[^>]*?>)", "", RegexOptions.IgnoreCase);
            strHtml = Regex.Replace(strHtml, @"<iframe[^>]*?/>", "", RegexOptions.IgnoreCase);
            strHtml = Regex.Replace(strHtml, @"<layer[^>]*?>.*?</layer>", "", RegexOptions.IgnoreCase);
            strHtml = Regex.Replace(strHtml, @"<layer[^>]*?/>", "", RegexOptions.IgnoreCase);
            strHtml = Regex.Replace(strHtml, @"<ilayer[^>]*?>.*?</ilayer>", "", RegexOptions.IgnoreCase);
            strHtml = Regex.Replace(strHtml, @"<ilayer[^>]*?/>", "", RegexOptions.IgnoreCase);
            strHtml = Regex.Replace(strHtml, @"<applet[^>]*?>.*?</applet>", "", RegexOptions.IgnoreCase);
            strHtml = Regex.Replace(strHtml, @"<applet[^>]*?/>", "", RegexOptions.IgnoreCase);
            strHtml = Regex.Replace(strHtml, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
            strHtml = Regex.Replace(strHtml, @"<script[^>]*?/>", "", RegexOptions.IgnoreCase);
            //2>以下慎重允许-flash
            strHtml = Regex.Replace(strHtml, @"<embed[^>]*?>.*?</embed>", "", RegexOptions.IgnoreCase);
            strHtml = Regex.Replace(strHtml, @"<embed[^>]*?/>", "", RegexOptions.IgnoreCase);
            strHtml = Regex.Replace(strHtml, @"<object[^>]*?>.*?</object>", "", RegexOptions.IgnoreCase);
            strHtml = Regex.Replace(strHtml, @"<object[^>]*?/>", "", RegexOptions.IgnoreCase);
            //3>Link style
            strHtml = Regex.Replace(strHtml, @"<link[^>]*?>.*?(</link>)?", "", RegexOptions.IgnoreCase);
            strHtml = Regex.Replace(strHtml, @"<link[^>]*?/>", "", RegexOptions.IgnoreCase);
            strHtml = Regex.Replace(strHtml, @"<style[^>]*?>.*?(</style>)?", "", RegexOptions.IgnoreCase);
            strHtml = Regex.Replace(strHtml, @"<style[^>]*?/>", "", RegexOptions.IgnoreCase);
            //img
            //str = Regex.Replace(str, @"<img[^>]*?>.*?</img>", "",
            //RegexOptions.IgnoreCase);
            //str = Regex.Replace(str, @"<img[^>]*?/>", "",
            //RegexOptions.IgnoreCase);
            //4>hyperLink (<a[^>]*?>.*?)|(</a>)+
            strHtml = Regex.Replace(strHtml, @"(<a[^>]*?>|</a>)", "", RegexOptions.IgnoreCase);//<a[^>]*?>.*?</a>
            strHtml = Regex.Replace(strHtml, @"<a[^>]*?/>", "", RegexOptions.IgnoreCase);
            //5>form-elements
            strHtml = Regex.Replace(strHtml, @"<form[^>]*?>.*?</form>", "", RegexOptions.IgnoreCase);
            strHtml = Regex.Replace(strHtml, @"<form[^>]*?/>", "", RegexOptions.IgnoreCase);
            strHtml = Regex.Replace(strHtml, @"<input[^>]*?>.*?</input>", "", RegexOptions.IgnoreCase);
            strHtml = Regex.Replace(strHtml, @"<input[^>]*?/>", "", RegexOptions.IgnoreCase);
            strHtml = Regex.Replace(strHtml, @"<textarea[^>]*?>.*?</textarea>", "", RegexOptions.IgnoreCase);
            strHtml = Regex.Replace(strHtml, @"<textarea[^>]*?/>", "", RegexOptions.IgnoreCase);
            strHtml = Regex.Replace(strHtml, @"<select[^>]*?>.*?</select>", "", RegexOptions.IgnoreCase);
            strHtml = Regex.Replace(strHtml, @"<select[^>]*?/>", "", RegexOptions.IgnoreCase);
            return HttpUtility.HtmlEncode(strHtml);
        }
        /// <summary>
        /// (二)Html解码
        /// </summary>
        /// <param name="strHtml"></param>
        /// <returns></returns>
        public static string HtmlDecode(string strHtml)
        {
            return HttpUtility.HtmlDecode(strHtml);
        }
        #endregion

        #region 格式化字节数字符串
        /// <summary>
        /// 格式化字节数字符串
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string FormatBytesStr(long bytes)
        {
            if (bytes > 1073741824)
                return ((double)(bytes / 1073741824)).ToString("0") + "GB";

            if (bytes > 1048576)
                return ((double)(bytes / 1048576)).ToString("0") + "MB";

            if (bytes > 1024)
                return ((double)(bytes / 1024)).ToString("0") + "KB";

            return bytes.ToString() + "Bytes";
        }
        #endregion

        #region 获得伪静态页码显示链接
        /// <summary>
        /// 获得伪静态页码显示链接
        /// </summary>
        /// <param name="curPage">当前页数</param>
        /// <param name="countPage">总页数</param>
        /// <param name="url">超级链接地址</param>
        /// <param name="extendPage">周边页码显示个数上限</param>
        /// <param name="forumrewrite">当前版块是否使用URL重写</param>
        /// <returns>页码html</returns>
        public static string GetStaticPageNumbers(int curPage, int countPage, string url, string expname, int extendPage, int forumrewrite)
        {
            int startPage = 1;
            int endPage = 1;

            string t1 = "<a href=\"" + url + "-1" + expname + "\">&laquo;</a>";
            string t2 = "<a href=\"" + url + "-" + countPage + expname + "\">&raquo;</a>";

            if (forumrewrite == 1)
            {
                t1 = "<a href=\"" + url + "/1/list" + expname + "\">&laquo;</a>";
                t2 = "<a href=\"" + url + "/" + countPage + "/list" + expname + "\">&raquo;</a>";
            }

            if (forumrewrite == 2)
            {
                t1 = "<a href=\"" + url + "/\">&laquo;</a>";
                t2 = "<a href=\"" + url + "/" + countPage + "/\">&raquo;</a>";
            }

            if (countPage < 1) countPage = 1;
            if (extendPage < 3) extendPage = 2;

            if (countPage > extendPage)
            {
                if (curPage - (extendPage / 2) > 0)
                {
                    if (curPage + (extendPage / 2) < countPage)
                    {
                        startPage = curPage - (extendPage / 2);
                        endPage = startPage + extendPage - 1;
                    }
                    else
                    {
                        endPage = countPage;
                        startPage = endPage - extendPage + 1;
                        t2 = "";
                    }
                }
                else
                {
                    endPage = extendPage;
                    t1 = "";
                }
            }
            else
            {
                startPage = 1;
                endPage = countPage;
                t1 = "";
                t2 = "";
            }

            StringBuilder s = new StringBuilder("");

            s.Append(t1);
            for (int i = startPage; i <= endPage; i++)
            {
                if (i == curPage)
                {
                    s.Append("<span>");
                    s.Append(i);
                    s.Append("</span>");
                }
                else
                {
                    s.Append("<a href=\"");
                    if (forumrewrite == 1)
                    {
                        s.Append(url);
                        if (i != 1)
                        {
                            s.Append("/");
                            s.Append(i);
                        }
                        s.Append("/list");
                        s.Append(expname);
                    }
                    else if (forumrewrite == 2)
                    {
                        s.Append(url);
                        s.Append("/");
                        if (i != 1)
                        {
                            s.Append(i);
                            s.Append("/");
                        }
                    }
                    else
                    {
                        s.Append(url);
                        if (i != 1)
                        {
                            s.Append("-");
                            s.Append(i);
                        }
                        s.Append(expname);
                    }
                    s.Append("\">");
                    s.Append(i);
                    s.Append("</a>");
                }
            }
            s.Append(t2);

            return s.ToString();
        }
        #endregion

        #region 转换为静态html
        /// <summary>
        /// 转换为静态html
        /// </summary>
        public static void transHtml(string path, string outpath)
        {
            Page page = new Page();
            StringWriter writer = new StringWriter();
            page.Server.Execute(path, writer);
            FileStream fs;
            if (File.Exists(page.Server.MapPath("") + "\\" + outpath))
            {
                File.Delete(page.Server.MapPath("") + "\\" + outpath);
                fs = File.Create(page.Server.MapPath("") + "\\" + outpath);
            }
            else
            {
                fs = File.Create(page.Server.MapPath("") + "\\" + outpath);
            }
            byte[] bt = Encoding.Default.GetBytes(writer.ToString());
            fs.Write(bt, 0, bt.Length);
            fs.Close();
        }
        public static void transfHtml(string path, string outpath, HttpContext context)
        {
            StringWriter writer = new StringWriter();
            context.Server.Execute(path, writer);
            FileStream fs;
            if (File.Exists(context.Server.MapPath("") + "\\" + outpath))
            {
                File.Delete(context.Server.MapPath("") + "\\" + outpath);
                fs = File.Create(context.Server.MapPath("") + "\\" + outpath);
            }
            else
            {
                fs = File.Create(context.Server.MapPath("") + "\\" + outpath);
            }
            byte[] bt = Encoding.Default.GetBytes(writer.ToString());
            fs.Write(bt, 0, bt.Length);
            fs.Close();
        }
        #endregion

        #region  获得当前页面客户端的IP
        /// <summary>
        /// 获得当前页面客户端的IP
        /// </summary>
        /// <returns>当前页面客户端的IP</returns>
        public static string GetIP()
        {
            string result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            if (string.IsNullOrEmpty(result))
                result = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (string.IsNullOrEmpty(result))
                result = HttpContext.Current.Request.UserHostAddress;

            if (string.IsNullOrEmpty(result) || !Util.IsIP(result))
                return "127.0.0.1";

            return result;
        }
        #endregion

        #region  检测是否有危险的可能用于链接的字符串
        /// <summary>
        /// 检测是否有危险的可能用于链接的字符串
        /// </summary>
        /// <param name="str">要判断字符串</param>
        /// <returns>判断结果</returns>
        public static bool IsSafeUserInfoString(string str)
        {
            return !Regex.IsMatch(str, @"^\s*$|^c:\\con\\con$|[%,\*" + "\"" + @"\s\t\<\>\&]|游客|^Guest");
        }
        #endregion

        #region 检测是否有Sql危险字符
        /// <summary>
        /// 检测是否有Sql危险字符
        /// </summary>
        /// <param name="str">要判断字符串</param>
        /// <returns>判断结果</returns>
        public static bool IsSafeSqlString(string str)
        {
            return !Regex.IsMatch(str, @"[-|;|,|\/|\(|\)|\[|\]|\}|\{|%|@|\*|!|\']");
        }
        #endregion

        #region 检测是否是正确的Url
        /// <summary>
        /// 检测是否是正确的Url
        /// </summary>
        /// <param name="strUrl">要验证的Url</param>
        /// <returns>判断结果</returns>
        public static bool IsURL(string strUrl)
        {
            return Regex.IsMatch(strUrl, @"^(http|https)\://([a-zA-Z0-9\.\-]+(\:[a-zA-Z0-9\.&%\$\-]+)*@)*((25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9])\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[0-9])|localhost|([a-zA-Z0-9\-]+\.)*[a-zA-Z0-9\-]+\.(com|edu|gov|int|mil|net|org|biz|arpa|info|name|pro|aero|coop|museum|[a-zA-Z]{1,10}))(\:[0-9]+)*(/($|[a-zA-Z0-9\.\,\?\'\\\+&%\$#\=~_\-]+))*$");
        }
        #endregion

        #region  删除字符串尾部的回车/换行/空格
        /// <summary>
        /// 删除字符串尾部的回车/换行/空格
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string RTrim(string str)
        {
            for (int i = str.Length; i >= 0; i--)
            {
                if (str[i].Equals(" ") || str[i].Equals("\r") || str[i].Equals("\n"))
                {
                    str.Remove(i, 1);
                }
            }
            return str;
        }
        #endregion

        #region 返回字符串真实长度, 1个汉字长度为2
        /// <summary>
        /// 返回字符串真实长度, 1个汉字长度为2
        /// </summary>
        /// <returns>字符长度</returns>
        public static int GetStringLength(string str)
        {
            return Encoding.Default.GetBytes(str).Length;
        }
        #endregion

        #region  是否为ip
        /// <summary>
        /// 是否为ip
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static bool IsIP(string ip)
        {
            return Regex.IsMatch(ip, @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$");
        }
        #endregion

        #region  检测是否有危险的可能用于链接的字符串


        /// <summary>  
        ///  判断是否有非法字符
        /// </summary>  
        /// <param name="strString"></param>  
        /// <returns>返回TRUE表示有非法字符，返回FALSE表示没有非法字符。</returns>  
        public static bool CheckBadString(string strString)
        {
            bool outValue = false;
            if (strString != null && strString.Length > 0)
            {
                string[] bidStrlist = new string[27];
                bidStrlist[0] = "'";
                bidStrlist[1] = ";";
                bidStrlist[2] = ":";
                bidStrlist[3] = "%";
                bidStrlist[4] = "@";
                bidStrlist[5] = "&";
                bidStrlist[6] = "#";
                bidStrlist[7] = "\"";
                bidStrlist[8] = "net user";
                bidStrlist[9] = "exec";
                bidStrlist[10] = "net localgroup";
                bidStrlist[11] = "select";
                bidStrlist[12] = "asc";
                bidStrlist[13] = "char";
                bidStrlist[14] = "mid";
                bidStrlist[15] = "insert";
                bidStrlist[19] = "order";
                bidStrlist[20] = "exec";
                bidStrlist[21] = "delete";
                bidStrlist[22] = "drop";
                bidStrlist[23] = "truncate";
                bidStrlist[24] = "xp_cmdshell";
                bidStrlist[25] = "<";
                bidStrlist[26] = ">";
                string tempStr = strString.ToLower();
                for (int i = 0; i < bidStrlist.Length; i++)
                {
                    if (tempStr.IndexOf(bidStrlist[i]) != -1)
                    {
                        outValue = true;
                        break;
                    }
                }
            }
            return outValue;
        }
        #endregion

        #region 检测输入是否安全
        /// <summary>
        ///检测输入是否安全
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsSafe(string input)
        {
            string patter = "update|delete|backup|truncate|drop|eval|select|execcommand|(['%=]+)";
            return !System.Text.RegularExpressions.Regex.IsMatch(input, patter, System.Text.RegularExpressions.RegexOptions.Multiline | System.Text.RegularExpressions.RegexOptions.IgnoreCase);
        }
        #endregion

        #region 分割字符串
        /// <summary>
        /// 分割字符串
        /// </summary>
        /// <param name="input"></param>
        /// <param name="_char"></param>
        /// <returns></returns>
        public static string[] SplitString(string input, params char[] _char)
        {
            if (string.IsNullOrEmpty(input)) { return null; }
            input = input.Trim(_char);
            return input.Split(_char);
        }
        #endregion

        #region 获取文件物理路径
        /// <summary>
        /// 获取文件物理路径
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string GetPath(string path)
        {
            if (HttpContext.Current != null)
            {
                return HttpContext.Current.Server.MapPath(path);
            }
            else //非web程序引用
            {
                path = path.Replace("/", "\\");
                if (path.StartsWith("\\"))
                {
                    path = path.Substring(path.IndexOf('\\', 1)).TrimStart('\\');
                }
                return System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path);
            }
        }
        #endregion

        #region textarea转义\r\n
        /// <summary>
        /// textarea编码
        /// </summary>
        /// <param name="input">输入</param>
        /// <returns></returns>
        public static string TextareaEncode(string input)
        {
            input = input.Replace(@"\r\n", "<br/>");
            input = input.Replace(@"\n", "<br/>");
            return input;
        }
        /// <summary>
        /// textarea解码
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string TextareaDecode(string input)
        {
            input = input.Replace("<br/>", @"\r\n");
            return input;
        }
        #endregion

        #region 视图状态系列化、反序列化
        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="data">数据</param>
        /// <returns></returns>
        public static string SerializeViewState(object data)
        {
            LosFormatter lf = new LosFormatter(true, "#+=ACBD!=-EF08%5@10$2.5&4");
            TextWriter tw = new StringWriter();
            lf.Serialize(tw, data);
            tw.Close();
            tw.Dispose();
            return tw.ToString();
        }
        #endregion
    }
}
