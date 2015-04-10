using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
/*****************************************************************************
 * 
 * className:文件上传
 * author:李朝强
 * date:2014/05/30
 * mark:文件上传
 * 
 * ***************************************************************************/
namespace TiKu.Common
{
    public class UpfileTool
    {
        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="stream">文件流</param>
        /// <param name="fileName">上传的文件名</param>
        /// <param name="uploadPath">要上传的虚拟目录</param>
        /// <param name="extension">允许上传的文件扩展名</param>
        /// <param name="maxSize">允许最大上传文件（字节)</param>
        /// <param name="_newfile">新文件名</param>
        /// <param name="error">错误信息</param>
        /// <returns></returns>
        public static bool Upload(Stream stream,
                                  string fileName,
                                  string uploadPath,
                                  string[] extension,
                                  long maxSize,
                                  ref string _newfile,
                                  ref string error)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                error = "上传文件名无效！";
                return false;
            }
            if (stream == null || stream.Length == 0)
            {
                error = "上传文件无效！";
                return false;
            }
            string strExtension = System.IO.Path.GetExtension(fileName);//扩展名
            //验证文件扩展名
            if (string.Join("|", extension).ToLower().IndexOf(strExtension.ToLower()) < 0)
            {
                error = "上传文件格式无效！";
                return false;
            }
            //验证文件大小
            if (stream.Length > maxSize)
            {
                error = "上传文件过大！";
                return false;
            }
            //文件目录
            _newfile = string.Format("{0}{1}", DateTime.Now.ToString("yyyyMMddHHmmssfff"), strExtension);//新文件名
            //获取物理路径
            uploadPath = TiKu.Common.Util.GetPath(uploadPath);
            //验证上传目录是否存在，不存在则创建
            if (System.IO.Directory.Exists(uploadPath) == false)
            {
                System.IO.Directory.CreateDirectory(uploadPath);
            }
            string strWriteFile = uploadPath + _newfile;//上传文件物理路径
            //创建文件
            FileStream fs = new FileStream(strWriteFile, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            try
            {
                long index = stream.Length;
                while (index >= 0)
                {
                    byte[] buffer = new byte[1];
                    stream.Read(buffer, 0, 1);
                    fs.Write(buffer, 0, 1);
                    index--;
                }
            }
            catch { }
            finally
            {
                stream.Close();
                stream.Dispose();
                fs.Close();
                fs.Dispose();
            }
            return true;
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="postedFile">单个上传文件</param>
        /// <param name="_newfile">新文件名</param>
        /// <param name="extension">允许上传文件扩展名</param>
        /// <param name="maxlength">允许上传的最大长度</param>
        /// <param name="error">错误信息</param>
        /// <returns></returns>
        public static bool Upload(System.Web.HttpPostedFile postedFile,
                                  string[] extension,
                                  long maxlength,
                                  string uploadPath,
                                  ref string _newfile,
                                  ref string error)
        {
            return Upload(postedFile.InputStream,
                     postedFile.FileName,
                     uploadPath,
                     extension,
                     maxlength,
                     ref _newfile,
                     ref error);
        }
    }
}
