using NPOI.XWPF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.IO;
using System.Web;
/**************************************************************************************
 * 
 * 
 * 说 明：导出Excel文档
 * 
 * 
 * **********************************************************************************/
namespace TiKu.Common.Office
{
    public class Word
    {

        /// <summary>
        /// 导出数据
        /// </summary>
        /// <param name="data"></param>
        /// <param name="context"></param>
        public void Export(DataTable data, HttpContext context)
        {
            //导出的文件名
            string filename = DateTime.Now.ToFileTimeUtc() + ".docx";
            //创建文档
            XWPFDocument xDocumnet = new XWPFDocument();
            //创建段落
            XWPFParagraph paragraph = xDocumnet.CreateParagraph();
            XWPFRun r1 = paragraph.CreateRun();
            r1.SetBold(true);
            r1.SetText("数据导出demo");
            r1.SetBold(true);

            //表格
            XWPFTable table = xDocumnet.CreateTable(data.Rows.Count, data.Columns.Count);
            for (int k = 0; k < data.Columns.Count; k++)
            {
                table.SetColumnWidth(k, 20 * 256);
            }
            //循环设置行
            for (int i = 0; i < data.Rows.Count; i++)
            {
                //循环设置单元格
                for (int j = 0; j < data.Columns.Count; j++)
                {
                    table.GetRow(i).GetCell(j).SetText(data.Rows[i][data.Columns[j].ColumnName].ToString());
                }

            }
            //声明内存流
            MemoryStream ms = new MemoryStream();
            xDocumnet.Write(ms);
            //下载
            Download(context, filename, ms);
            ms.Close();
            ms.Dispose();
        }




        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="context">请求上下文</param>
        /// <param name="fileName">导出文件的名</param>
        /// <param name="stream">数据流</param>
        public void Download(HttpContext context,
                           string fileName,
                           MemoryStream stream)
        {
            if (context.Request.Browser.Browser == "IE")
                fileName = HttpUtility.UrlEncode(fileName);
            context.Response.Clear();
            context.Response.ClearHeaders();
            context.Response.AddHeader("Content-Disposition", "attachment;fileName=" + fileName);
            context.Response.BinaryWrite(stream.ToArray());
        }

    }
}
