using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#region NPOI
using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.SS.UserModel;
using System.Web;
using System.IO;
using System.Data;
using System.Collections;
using System.Web.UI.WebControls;
#endregion
/*========================================================================================
 * 
 * 
 * 说  明：导入、导出Excel
 * 作  者：李朝强
 * 日  期：2015/03/28
 * 
 * 
 * =====================================================================================*/
namespace TiKu.Common.Office
{
    public class Excel
    {

        #region ===============================================导出==================================
        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="context">请求上下文</param>
        /// <param name="fileName">导出文件的名</param>
        /// <param name="stream">数据流</param>
        public void Export(HttpContext context,
                           string fileName,
                           MemoryStream stream)
        {
            if (context.Request.Browser.Browser == "IE")
                fileName = HttpUtility.UrlEncode(fileName);
            context.Response.AddHeader("Content-Disposition", "attachment;fileName=" + fileName);
            context.Response.BinaryWrite(stream.ToArray());
        }

        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="context">上下文</param>
        /// <param name="filename">导出的文件名</param>
        /// <param name="data">数据</param>
        public void Export(HttpContext context,
                           string filename,
                           string sheetName,
                           Hashtable hashColumnInfos,
                           DataTable data)
        {
            MemoryStream ms = null;
            try
            {
                ms = ReadToExcel(data,
                                 sheetName,
                                 hashColumnInfos);
                //执行导出
                Export(context, filename, ms);
            }
            catch (Exception ex) { throw ex; }
            finally
            {
                if (null != ms)
                {
                    ms.Close();
                    ms.Dispose();
                }
            }
        }

        /// <summary>
        /// 从Repeat控件中，导出Excel
        /// </summary>
        /// <param name="RepList">控件</param>
        /// <param name="filename">文件名</param>
        /// <param name="sheetName">工作表</param>
        public void Export(Repeater RepList,
                           string filename,
                           string sheetName,
                           HttpContext context)
        {
            object data = RepList.DataSource;
            if (data is DataTable)
            {
                Export(context,
                       filename,
                       sheetName,
                       null,
                       (DataTable)data);
                return;
            }
            if (data is DataView)
            {
                return;
            }
            if (data is IList)
            {
                return;
            }
        }
        #endregion

        #region ================================================数据流========================================
        /// <summary>
        /// 把DataTable对象，读取到内存流中
        /// </summary>
        /// <param name="data">DataTable对象</param>
        /// <param name="hashColumnInfos">（可选）列</param>
        /// <returns></returns>
        public MemoryStream ReadToExcel(DataTable data,
                                        string sheetName,
                                        Hashtable hashColumnInfos)
        {
            sheetName = string.IsNullOrEmpty(sheetName) ? string.Format("Sheet-{0:yyy/MM/dd}", DateTime.Now) : sheetName;
            //0>内存流
            MemoryStream ms = new MemoryStream();
            //1>创建工作薄
            IWorkbook __workbook = new HSSFWorkbook();
            //2>创建工作表
            ISheet __sheet = __workbook.CreateSheet(sheetName);


            #region 单元格样式
            //单元格样式
            ICellStyle cellStyle = __workbook.CreateCellStyle();
            cellStyle.FillPattern = FillPattern.SolidForeground;
            cellStyle.FillBackgroundColor = NPOI.HSSF.Util.HSSFColor.Green.Index;
            //设置字体
            IFont font = __workbook.CreateFont();
            font.Color = NPOI.HSSF.Util.HSSFColor.White.Index;
            cellStyle.SetFont(font);

            cellStyle.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.Green.Index;
            #endregion

            #region 3>创建表头
            //创建一行
            IRow __header = __sheet.CreateRow(0);
            if (null == hashColumnInfos)
            {
                for (int i = 0; i < data.Columns.Count; i++)
                {
                    //创建单元格
                    ICell __cell = __header.CreateCell(i);
                    __cell.SetCellValue(data.Columns[i].ColumnName);
                    __sheet.SetColumnWidth(i, 20 * 256);
                    __cell.CellStyle = cellStyle;
                }
            }
            else
            {
                int j = 0;
                foreach (DictionaryEntry item in hashColumnInfos)
                {
                    //创建单元格
                    ICell __cell = __header.CreateCell(j);
                    __cell.SetCellValue(item.Value.ToString());
                    __sheet.SetColumnWidth(j, 20 * 256);
                    __cell.CellStyle = cellStyle;
                    ++j;
                }
            }
            #endregion

            #region 4>创建数据行
            int c = 0;
            for (int k = 0; k < data.Rows.Count; k++)
            {
                IRow __dataRow = __sheet.CreateRow(k + 1);
                for (c = 0; c < data.Columns.Count; c++)
                {
                    ICell iCell = __dataRow.CreateCell(c);
                    iCell.SetCellValue(data.Rows[k][data.Columns[c].ColumnName].ToString());
                    c++;
                }
                c = 0;
            }
            #endregion

            //5>最后，写入内存流
            __workbook.Write(ms);
            return ms;

        }

        /// <summary>
        /// 把IDataReader对象，读取到内存流中
        /// </summary>
        /// <param name="dataReader">IDataReader对象</param>
        /// <param name="sheetName">工作表名称</param>
        /// <param name="hashColumnInfos">列</param>
        /// <returns></returns>
        public MemoryStream ReadToExcel(IDataReader dataReader,
                                        string sheetName,
                                        Hashtable hashColumnInfos)
        {
            //0>内存流
            MemoryStream ms = new MemoryStream();
            //1>创建工作薄
            IWorkbook __workbook = new HSSFWorkbook();

            //2>创建工作表
            ISheet __sheet = __workbook.CreateSheet(sheetName);

            #region 3>表头
            IRow __header = __sheet.CreateRow(0);
            if (null == hashColumnInfos)
            {
                for (int i = 0; i < dataReader.FieldCount; i++)
                {
                    ICell iHeaderCell = __header.CreateCell(i);
                    iHeaderCell.SetCellValue(dataReader.GetName(i));
                }
            }
            else
            {
                int j = 0;
                foreach (DictionaryEntry item in hashColumnInfos)
                {
                    //创建单元格
                    ICell __cell = __header.CreateCell(j);
                    __cell.SetCellValue(item.Value.ToString());
                    ++j;
                }
            }
            #endregion

            #region 4>数据行
            int n = 1;
            while (dataReader.Read())
            {
                IRow __dataRow = __sheet.CreateRow(n);
                for (int c = 0; c < dataReader.FieldCount; c++)
                {
                    ICell iCell = __dataRow.CreateCell(c);
                    iCell.SetCellValue((dataReader.GetValue(c) ?? "").ToString());
                }
            }
            #endregion

            //5>写入内存流
            __workbook.Write(ms);

            return ms;
        }
        #endregion


    }
}
