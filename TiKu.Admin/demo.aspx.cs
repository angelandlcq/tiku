
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TiKu.WebUI.Page;

namespace TiKu.Admin
{
    public partial class demo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            string[] strArray = { "A、\"中国\"", "B、\r\n10%", "C:\\E", "D、<div><img src='a.jpg' alt=''/><i></i><span><br/>&nbsp;&nbsp;aaa</span></div>" };
            string strJson = TiKu.Common.JsonHelper.ToJson(strArray);
            strArray = TiKu.Common.JsonHelper.MapToObject<string[]>(strJson);

            //Response.Write("{");
            //Response.Write("opions:");
            //Response.Write(strJson);
            //Response.Write("}");
            //return;
            for (int i = 0; i < strArray.Length; i++)
            {
                Response.Write(strArray[i] + "<br/>");
            }
            // Response.Write(TiKu.Common.JsonHelper.ToJson(strArray));
            string filename = DateTime.Now.ToFileTime().ToString() + ".xls";
            ///filename = TiKu.Common.Util.GetPath("upload/" + filename + ".xls");
            //FileStream fs = new FileStream(filename, FileMode.CreateNew, FileAccess.ReadWrite);
            //IWorkbook workbook = new HSSFWorkbook();//创建Workbook对象
            //ISheet sheet = workbook.CreateSheet("Sheet1");//创建工作表
            //IRow row = sheet.CreateRow(0);//在工作表中添加一行
            //ICell cell = row.CreateCell(0);//在行中添加一列
            //cell.SetCellValue("test");//设置列的内容
            //workbook.Write(fs);
            //fs.Close();
            //fs.Dispose();
            //DataTable dt = GetData().Tables[0];
            //MemoryStream ms = ReadToExcel(dt);
            //Export(Context, filename, ms);
            //ms.Close();
            //ms.Dispose();
            //Response.End();
            // TiKu.Common.Office.Excel ex = new Common.Office.Excel();
            //ex.Export(Context, filename, "", null, dt);
            //TiKu.Common.Office.Word wd = new Common.Office.Word();
            //wd.Export(dt, Context);
        }

        /// <summary>
        /// /
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
        }

        ///// <summary>
        ///// 导出
        ///// </summary>
        ///// <param name="context"></param>
        ///// <param name="fileName"></param>
        ///// <param name="ms"></param>
        //private void Export(HttpContext context, string fileName, MemoryStream ms)
        //{
        //    if (context.Request.Browser.Browser == "IE")
        //        fileName = HttpUtility.UrlEncode(fileName);
        //    context.Response.AddHeader("Content-Disposition", "attachment;fileName=" + fileName);
        //    context.Response.BinaryWrite(ms.ToArray());
        //}

        ///// <summary>
        ///// 导出Excel
        ///// </summary>
        ///// <param name="data">数据表</param>
        ///// <returns></returns>
        //public MemoryStream ReadToExcel(DataTable data)
        //{
        //    //声明内存流
        //    MemoryStream ms = new MemoryStream();
        //    //声明工作薄
        //    IWorkbook __workbook = new HSSFWorkbook();
        //    //创建工作表
        //    ISheet __sheet = __workbook.CreateSheet("管理员操作日志");
        //    //创建行
        //    IRow __rHeader = __sheet.CreateRow(0);//头部
        //    for (int i = 0; i < data.Columns.Count; i++)
        //    {
        //        //创建单元格
        //        ICell cell = __rHeader.CreateCell(i);
        //        cell.SetCellValue(data.Columns[i].Caption);
        //        //单元格样式
        //        ICellStyle cellStyle = __workbook.CreateCellStyle();
        //        cellStyle.FillPattern = FillPattern.SolidForeground;
        //        cellStyle.FillBackgroundColor = NPOI.HSSF.Util.HSSFColor.Green.Index;
        //        //设置字体
        //        IFont font = __workbook.CreateFont();
        //        font.Color = NPOI.HSSF.Util.HSSFColor.White.Index;
        //        cellStyle.SetFont(font);

        //        cell.CellStyle = cellStyle;
        //        cellStyle.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.Green.Index;
        //        __sheet.SetColumnWidth(i, 20 * 256);

        //    }
        //    //数据行
        //    int k = 1;
        //    foreach (DataRow dr in data.Rows)
        //    {
        //        IRow row = __sheet.CreateRow(k);
        //        for (int j = 0; j < data.Columns.Count; j++)
        //        {
        //            row.CreateCell(j).SetCellValue(dr[data.Columns[j].ColumnName].ToString());
        //        }
        //        k++;
        //    }
        //    __workbook.Write(ms);
        //    return ms;
        //}

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataSet GetData()
        {
            DataSet ds = new BLL.tb_AdminLog().GetListData(100,
                                                                             null,
                                                                             null,
                                                                             null);
            return ds;
        }
    }
}