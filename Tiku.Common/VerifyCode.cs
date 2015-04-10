using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Drawing.Imaging;
/**********************************************************
 
 
 
 * 
 * 说明：验证码
 * 
 * 
 * 
 
 
 **********************************************************/
namespace TiKu.Common
{
    public class VerifyCode : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        /// <summary>
        /// 回话键
        /// </summary>
        public const string VERIFY_CODE = "VERIFY_CODE";

        #region 成员
        /// <summary>
        /// 是否可以重用
        /// </summary>
        public bool IsReusable
        {
            get { return false; }
        }
        /// <summary>
        /// 响应客户端请求
        /// </summary>
        protected HttpResponse Response
        {
            get { return HttpContext.Current.Response; }
        }
        #endregion

        #region 处理请求
        /// <summary>
        /// 处理请求
        /// </summary>
        /// <param name="context"></param>
        public void ProcessRequest(HttpContext context)
        {
            //验证码类别
            string strType = TiKu.Common.TKRequest.GetQueryString("type").ToLower();
            switch (strType)
            {
                //中文验证码
                case "zh":
                    CreateVerifyImage();
                    break;
                //算数
                case "math":
                    CreateMathImage();
                    break;
                //字母数字
                default:
                    string strRand = CreateValidateNumber(6);
                    TiKu.Common.SessionHelper.SaveToSession(VerifyCode.VERIFY_CODE, strRand);
                    CreateValidateGraphic(context, strRand);
                    break;
            }
        }
        #endregion

        #region 中文验证码
        /// <summary>
        /// 创建验证码图片
        /// </summary>
        protected void CreateVerifyImage()
        {
            CreateImage(CreatValidateCode());
        }

        /// <summary>
        /// 创建验证码
        /// </summary>
        /// <returns></returns>
        private string CreatValidateCode()
        {
            System.Text.Encoding gb = Encoding.GetEncoding("gb2312");
            string[] storecode = new String[16] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "a", "b", "c", "d", "e", "f" };
            Random rnd = new Random();
            object[] codes = new object[4];
            for (int i = 0; i < 4; i++)
            {
                int rcode1 = rnd.Next(11, 14);
                string str_rcode1 = storecode[rcode1].Trim();
                rnd = new Random(rcode1 * unchecked((int)DateTime.Now.Ticks) + i);
                int rcode2;
                if (rcode1 == 13)
                {
                    rcode2 = rnd.Next(0, 7);
                }
                else
                {
                    rcode2 = rnd.Next(0, 16);
                }
                string str_rcode2 = storecode[rcode2].Trim();
                rnd = new Random(rcode2 * unchecked((int)DateTime.Now.Ticks) + i);
                int rcode3 = rnd.Next(10, 16);
                string str_rcode3 = storecode[rcode3].Trim();
                rnd = new Random(rcode3 * unchecked((int)DateTime.Now.Ticks) + i);
                int rcode4;
                if (rcode3 == 10)
                {
                    rcode4 = rnd.Next(1, 16);
                }
                else if (rcode3 == 15)
                {
                    rcode4 = rnd.Next(0, 15);
                }
                else
                {
                    rcode4 = rnd.Next(0, 16);
                }
                string str_rcode4 = storecode[rcode4].Trim();
                byte byte1 = Convert.ToByte(str_rcode1 + str_rcode2, 16);
                byte byte2 = Convert.ToByte(str_rcode3 + str_rcode4, 16);
                byte[] storebytes = new byte[] { byte1, byte2 };
                codes.SetValue(storebytes, i);

            }

            object[] showbytes = codes;
            string strcode1 = gb.GetString((byte[])Convert.ChangeType(showbytes[0], typeof(byte[])));
            string strcode2 = gb.GetString((byte[])Convert.ChangeType(showbytes[1], typeof(byte[])));
            string strcode3 = gb.GetString((byte[])Convert.ChangeType(showbytes[2], typeof(byte[])));
            string strcode4 = gb.GetString((byte[])Convert.ChangeType(showbytes[3], typeof(byte[])));
            string checkValidateCode = strcode1 + strcode2 + strcode3 + strcode4;
            //保存回话
            HttpContext.Current.Session[VERIFY_CODE] = checkValidateCode;
            return checkValidateCode;
        }
        /// <summary>
        /// 绘制图片
        /// </summary>
        /// <param name="checkValidateCode"></param>
        private void CreateImage(string checkValidateCode)
        {
            if (checkValidateCode == null || checkValidateCode.Trim() == String.Empty)
                return;

            System.Drawing.Bitmap image = new System.Drawing.Bitmap((int)Math.Ceiling((checkValidateCode.Length * 45.0)), 80);
            System.Drawing.Graphics g = Graphics.FromImage(image);

            try
            {
                Random random = new Random();
                g.Clear(Color.White);
                for (int i = 0; i < 150; i++)
                {
                    int x1 = random.Next(image.Width);
                    int x2 = random.Next(image.Width);
                    int y1 = random.Next(image.Height);
                    int y2 = random.Next(image.Height);

                    g.DrawLine(new Pen(Color.Silver), x1, y1, x2, y2);
                }

                string[] pickfonts = { "Verdana", "Microsoft Sans Serif", "Comic Sans MS", "Arial", "宋体" };
                Color[] pickcolors = { Color.Black, Color.Red, Color.DarkBlue, Color.Green, Color.Orange, Color.Brown, Color.DarkCyan, Color.Purple };
                for (int i = 0; i < checkValidateCode.Length; i++)
                {
                    int pickindex = random.Next(7);
                    int fontindex = random.Next(4);

                    Font font_f = new System.Drawing.Font(pickfonts[fontindex], 30, System.Drawing.FontStyle.Bold);
                    Brush solid_b = new System.Drawing.SolidBrush(pickcolors[pickindex]);
                    int j = 30;
                    if ((i + 1) % 2 == 0)
                    {
                        j = 2;
                    }
                    g.DrawString(checkValidateCode.Substring(i, 1), font_f, solid_b, 3 + (i * 40), j);
                }

                for (int i = 0; i < 1000; i++)
                {
                    int x = random.Next(image.Width);
                    int y = random.Next(image.Height);

                    image.SetPixel(x, y, Color.FromArgb(random.Next()));
                }
                g.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);

                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                Response.ClearContent();
                Response.ContentType = "image/Bmp";
                Response.BinaryWrite(ms.ToArray());
            }
            finally
            {
                g.Dispose();
                image.Dispose();
            }
        }
        #endregion

        #region 算数验证码
        /// <summary>
        /// 生成算数验证码
        /// </summary>
        protected void CreateMathImage()
        {
            string strRandomCode = VerifyCodeInit();
            CreateImg(strRandomCode);
        }

        /// <summary>
        /// 验证码初始化
        /// </summary>
        private string VerifyCodeInit()
        {
            Random rand = new Random();
            string[] chu = new string[4];
            chu[0] = "+";
            chu[1] = "-";
            chu[2] = "*";
            chu[3] = "/";
            int randnum1 = rand.Next(10); //除数
            int randnum2 = rand.Next(10);//被除数

            int num3 = rand.Next(4);//定义算数方式0加法1减法2乘法3除法
            if (num3 == 3)
            {
                while (randnum2 == 0)
                {
                    randnum1 = rand.Next(10);
                    randnum2 = rand.Next(10);
                }
            }
            if (randnum1 == 0)
            {
                randnum1 = rand.Next(10);
                randnum2 = rand.Next(10);
            }
            string opera = chu[num3].ToString();
            int result = -1;
            switch (opera)
            {
                case "+":
                    result = randnum1 + randnum2;
                    break;
                case "-":
                    result = randnum1 - randnum2;
                    break;
                case "*":
                    result = randnum1 * randnum2;
                    break;
                case "/":
                    result = randnum1 / randnum2;
                    break;
            }
            //保存至回话
            HttpContext.Current.Session[VERIFY_CODE] = result;
            string ret = randnum1 + opera + randnum2 + "=" + "?";
            return ret;

        }
        /// <summary>
        /// 创建随机码图片
        /// </summary>
        /// <param name="randomcode">随机码</param>
        private void CreateImg(string randomcode)
        {
            int randAngle = 30; //随机转动角度
            int mapwidth = (int)(randomcode.Length * 32);
            Bitmap map = new Bitmap(mapwidth, 28);//创建图片背景
            Graphics graph = Graphics.FromImage(map);
            graph.Clear(Color.AliceBlue);//清除画面，填充背景
            graph.DrawRectangle(new Pen(Color.Black, 0), 0, 0, map.Width - 1, map.Height - 1);//画一个边框
            //graph.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;//模式

            Random rand = new Random();
            //背景噪点生成
            Pen blackPen = new Pen(Color.LightGray, 0);
            for (int i = 0; i < 50; i++)
            {
                int x = rand.Next(0, map.Width);
                int y = rand.Next(0, map.Height);
                graph.DrawRectangle(blackPen, x, y, 1, 1);
            }

            //验证码旋转，防止机器识别
            char[] chars = randomcode.ToCharArray();//拆散字符串成单字符数组
            //文字距中
            StringFormat format = new StringFormat(StringFormatFlags.NoClip);
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;
            //定义颜色
            Color[] c = { Color.Black, Color.Red, Color.DarkBlue, Color.Green, Color.Orange, Color.Brown, Color.DarkCyan, Color.Purple };
            //定义字体 
            string[] font = { "Verdana", "Microsoft Sans Serif", "Comic Sans MS", "Arial", "宋体" };
            for (int i = 0; i < chars.Length; i++)
            {
                int cindex = rand.Next(7);
                int findex = rand.Next(5);
                Font f = new System.Drawing.Font(font[findex], 13, System.Drawing.FontStyle.Bold);//字体样式(参数2为字体大小)
                Brush b = new System.Drawing.SolidBrush(c[cindex]);
                Point dot = new Point(23, 16);
                //graph.DrawString(dot.X.ToString(),fontstyle,new SolidBrush(Color.Black),10,150);//测试X坐标显示间距的
                float angle = rand.Next(-randAngle, randAngle);//转动的度数
                graph.TranslateTransform(dot.X, dot.Y);//移动光标到指定位置
                graph.RotateTransform(angle);
                graph.DrawString(chars[i].ToString(), f, b, 1, 1, format);
                //graph.DrawString(chars[i].ToString(),fontstyle,new SolidBrush(Color.Blue),1,1,format);
                graph.RotateTransform(-angle);//转回去
                graph.TranslateTransform(2, -dot.Y);//移动光标到指定位置
            }
            //graph.DrawString(randomcode,fontstyle,new SolidBrush(Color.Blue),2,2); //标准随机码

            //生成图片
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            map.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            Response.ClearContent();
            Response.ContentType = "image/gif";
            Response.BinaryWrite(ms.ToArray());
            graph.Dispose();
            map.Dispose();
        }
        #endregion

        #region   生成验证码
        /// <summary>
        /// 生成验证码
        /// </summary>
        /// <param name="length">指定验证码的长度</param>
        /// <returns></returns>
        public string CreateValidateNumber(int length)
        {
            int[] randMembers = new int[length];
            int[] validateNums = new int[length];
            string validateNumberStr = "";
            //生成起始序列值
            int seekSeek = unchecked((int)DateTime.Now.Ticks);
            Random seekRand = new Random(seekSeek);
            int beginSeek = (int)seekRand.Next(0, Int32.MaxValue - length * 10000);
            int[] seeks = new int[length];
            for (int i = 0; i < length; i++)
            {
                beginSeek += 10000;
                seeks[i] = beginSeek;
            }
            //生成随机数字
            for (int i = 0; i < length; i++)
            {
                Random rand = new Random(seeks[i]);
                int pownum = 1 * (int)Math.Pow(10, length);
                randMembers[i] = rand.Next(pownum, Int32.MaxValue);
            }
            //抽取随机数字
            for (int i = 0; i < length; i++)
            {
                string numStr = randMembers[i].ToString();
                int numLength = numStr.Length;
                Random rand = new Random();
                int numPosition = rand.Next(0, numLength - 1);
                validateNums[i] = Int32.Parse(numStr.Substring(numPosition, 1));
            }
            //生成验证码
            for (int i = 0; i < length; i++)
            {
                validateNumberStr += validateNums[i].ToString();
            }
            return validateNumberStr;
        }
        /// <summary>
        /// 创建验证码的图片
        /// </summary>
        /// <param name="containsPage">要输出到的page对象</param>
        /// <param name="validateNum">验证码</param>
        public void CreateValidateGraphic(HttpContext containsPage, string validateNum)
        {
            System.Drawing.Bitmap image = new Bitmap((int)Math.Ceiling(validateNum.Length * 12.5), 22);
            System.Drawing.Graphics g = Graphics.FromImage(image);
            try
            {
                //生成随机生成器
                Random random = new Random();
                //清空图片背景色
                g.Clear(Color.White);
                //画图片的干扰线
                for (int i = 0; i < 25; i++)
                {
                    int x1 = random.Next(image.Width);
                    int x2 = random.Next(image.Width);
                    int y1 = random.Next(image.Height);
                    int y2 = random.Next(image.Height);
                    g.DrawLine(new Pen(Color.Silver), x1, y1, x2, y2);
                }
                System.Drawing.Font font = new Font("Arial", 12, (FontStyle.Bold | FontStyle.Italic));
                System.Drawing.Drawing2D.LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height),
                System.Drawing.Color.Blue, Color.DarkRed, 1.2f, true);
                g.DrawString(validateNum, font, brush, 3, 2);
                //画图片的前景干扰点
                for (int i = 0; i < 100; i++)
                {
                    int x = random.Next(image.Width);
                    int y = random.Next(image.Height);
                    image.SetPixel(x, y, Color.FromArgb(random.Next()));
                }
                //画图片的边框线
                g.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);
                //保存图片数据
                MemoryStream stream = new MemoryStream();
                image.Save(stream, ImageFormat.Jpeg);
                //输出图片
                //3>保存验证码到Session对象中
                containsPage.Response.Clear();
                containsPage.Response.ContentType = "image/jpeg";
                containsPage.Response.BinaryWrite(stream.ToArray());
            }
            finally
            {
                g.Dispose();
                image.Dispose();
            }
        }

        #endregion

    }
}
