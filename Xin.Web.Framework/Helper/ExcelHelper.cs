using Microsoft.AspNetCore.Http;
using NPOI.HPSF;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using OfficeOpenXml;
using Spire.Xls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;
using Xin.Common.CustomAttribute;

namespace Xin.Web.Framework.Helper
{
    public class ExcelHelper<T> where T : new()
    {
        /// <summary>
        /// excel转list
        /// </summary>
        /// <param name="excelFile"></param>
        /// <returns></returns>
        public static List<T> ExcelToList(IFormFile excelFile, bool isFirstRowColumn = true)
        {
            List<T> list = new List<T>();
            try
            {
                var fs = excelFile.OpenReadStream();
                ISheet sheet = null;
                IWorkbook workbook = null;
                DataTable data = new DataTable();
                int startRow = 0;
                if (excelFile == null || excelFile.Length <= 0)
                {
                    throw new Exception("导入文件不能为空");
                }
                else if (Path.GetExtension(excelFile.FileName).Equals(".xlsx", StringComparison.OrdinalIgnoreCase))
                {
                    workbook = new XSSFWorkbook(fs);
                }
                else if (Path.GetExtension(excelFile.FileName).Equals(".xls", StringComparison.OrdinalIgnoreCase))
                {
                    workbook = new HSSFWorkbook(fs);
                }
                else
                {
                    throw new Exception("导入文件格式不是excel,请重新导入");
                }
                sheet = workbook.GetSheetAt(0);

                if (sheet != null)
                {
                    IRow firstRow = sheet.GetRow(0);
                    int cellCount = firstRow.LastCellNum; //一行最后一个cell的编号 即总的列数

                    if (isFirstRowColumn)
                    {
                        for (int i = firstRow.FirstCellNum; i < cellCount; ++i)
                        {
                            ICell cell = firstRow.GetCell(i);
                            if (cell != null)
                            {
                                string cellValue = cell.StringCellValue;
                                if (cellValue != null)
                                {
                                    DataColumn column = new DataColumn(cellValue);
                                    data.Columns.Add(column);
                                }
                            }
                        }
                        startRow = sheet.FirstRowNum + 1;
                    }
                    else
                    {
                        for (int i = firstRow.FirstCellNum; i < cellCount; i++)
                        {
                            DataColumn column = new DataColumn(i.ToString());
                            data.Columns.Add(column);
                        }
                        startRow = sheet.FirstRowNum;
                    }

                    //最后一列的标号
                    int rowCount = sheet.LastRowNum;
                    for (int i = startRow; i <= rowCount; ++i)
                    {
                        IRow row = sheet.GetRow(i);
                        if (row == null) continue; //没有数据的行默认是null　　　　　　　

                        DataRow dataRow = data.NewRow();
                        for (int j = row.FirstCellNum; j < cellCount; ++j)
                        {
                            if (row.GetCell(j) != null) //同理，没有数据的单元格都默认是null
                                dataRow[j] = row.GetCell(j).ToString();
                        }
                        data.Rows.Add(dataRow);
                    }
                    list = DataTableToList(data);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return list;
        }

        /// <summary>
        /// DataTable转List
        /// </summary>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        public static List<T> DataTableToList(DataTable dt)
        {
            // 定义集合  
            List<T> ts = new List<T>();

            if (dt != null && dt.Rows.Count > 0)
            {
                // 获得此模型的类型  
                Type type = typeof(T);
                string tempName = "";
                foreach (DataRow dr in dt.Rows)
                {
                    T t = new T();
                    // 获得此模型的公共属性  
                    PropertyInfo[] propertys = t.GetType().GetProperties();
                    foreach (PropertyInfo pi in propertys)
                    {
                        tempName = pi.Name;
                        // 检查DataTable是否包含此列  
                        if (dt.Columns.Contains(tempName))
                        {
                            // 判断此属性是否有Setter  
                            if (!pi.CanWrite)
                                continue;
                            object value = dr[tempName];
                            if (value != DBNull.Value)
                            {
                                //pi.SetValue(t, value, null);  
                                // pi.SetValue(t, Convert.ChangeType(value, pi.PropertyType, CultureInfo.CurrentCulture), null);
                                pi.SetValue(t, ChanageType(value, pi.PropertyType), null);
                            }
                        }
                    }
                    ts.Add(t);
                }
            }
            return ts;
        }

        /// <summary>
        /// 转换可空类型 如：DateTime? 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="convertsionType"></param>
        /// <returns></returns>
        private static object ChanageType(object value, Type convertsionType)
        {
            //判断convertsionType类型是否为泛型，因为nullable是泛型类,
            if (convertsionType.IsGenericType &&
                //判断convertsionType是否为nullable泛型类
                convertsionType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
            {
                if (value == null || value.ToString().Length == 0)
                {
                    return null;
                }

                //如果convertsionType为nullable类，声明一个NullableConverter类，该类提供从Nullable类到基础基元类型的转换
                NullableConverter nullableConverter = new NullableConverter(convertsionType);
                //将convertsionType转换为nullable对的基础基元类型
                convertsionType = nullableConverter.UnderlyingType;
            }
            return Convert.ChangeType(value, convertsionType);
        }


        /// <summary>
        /// 将worksheet转成datatable
        /// </summary>
        /// <param name="worksheet">待处理的worksheet</param>
        /// <returns>返回处理后的datatable</returns>
        private static DataTable WorksheetToTable(ExcelWorksheet worksheet)
        {
            //获取worksheet的行数
            int rows = worksheet.Dimension.End.Row;
            //获取worksheet的列数
            int cols = worksheet.Dimension.End.Column;

            DataTable dt = new DataTable(worksheet.Name);
            DataRow dr = null;
            for (int i = 1; i <= rows; i++)
            {
                if (i > 1)
                    dr = dt.Rows.Add();

                for (int j = 1; j <= cols; j++)
                {
                    //默认将第一行设置为datatable的标题
                    if (i == 1)
                        dt.Columns.Add(GetString(worksheet.Cells[i, j].Value));
                    //剩下的写入datatable
                    else
                        dr[j - 1] = GetString(worksheet.Cells[i, j].Value);
                }
            }
            return dt;
        }
        private static string GetString(object obj)
        {
            try
            {
                return obj.ToString();
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        /// <summary>
        /// 将泛类型集合List类转换成DataTable
        /// </summary>
        /// <param name="list">泛类型集合</param>
        /// <returns></returns>
        public static DataTable ListToDataTable(List<T> entitys)
        {
            //检查实体集合不能为空
            if (entitys == null || entitys.Count < 1)
            {
                throw new Exception("需转换的集合为空");
            }
            //取出第一个实体的所有Propertie
            Type entityType = entitys[0].GetType();
            PropertyInfo[] entityProperties = entityType.GetProperties();

            //生成DataTable的structure
            //生产代码中，应将生成的DataTable结构Cache起来，此处略
            DataTable dt = new DataTable();
            for (int i = 0; i < entityProperties.Length; i++)
            {
                //dt.Columns.Add(entityProperties[i].Name, entityProperties[i].PropertyType);
                dt.Columns.Add(entityProperties[i].Name);
            }
            //将所有entity添加到DataTable中
            foreach (object entity in entitys)
            {
                //检查所有的的实体都为同一类型
                if (entity.GetType() != entityType)
                {
                    throw new Exception("要转换的集合元素类型不一致");
                }
                object[] entityValues = new object[entityProperties.Length];
                for (int i = 0; i < entityProperties.Length; i++)
                {
                    entityValues[i] = entityProperties[i].GetValue(entity, null);
                }
                dt.Rows.Add(entityValues);
            }
            return dt;
        }

        /// <summary>
        /// 集合导出Excel
        /// </summary>
        /// <param name="list">集合</param>
        /// <param name="columnNames">列名转换</param>
        /// <param name="dicOnly">部分转换</param>
        /// <returns></returns>
        public static byte[] NpoiListToExcel(List<T> list, string sheetName = "Sheet1")
        {
            IWorkbook workbook = new XSSFWorkbook();
            ISheet sheet = workbook.CreateSheet(sheetName);

            var headRow = sheet.CreateRow(0);
            PropertyInfo[] props = typeof(T).GetProperties();
            for (var i = 0; i < props.Length; ++i)
            {
                Object obj = props[i].GetCustomAttribute(typeof(ExcelAttribute));
                if (obj != null)
                {
                    ExcelAttribute head = (ExcelAttribute)obj;
                    headRow.CreateCell(i).SetCellValue(head.Header);
                }
                else
                {
                    headRow.CreateCell(i).SetCellValue(props[i].Name);
                }
            }
            for (var i = 0; i < list.Count; ++i)
            {
                var row = sheet.CreateRow(i + 1);
                for (var j = 0; j < props.Length; ++j)
                {
                    Object obj = props[j].GetCustomAttribute(typeof(ExcelAttribute));
                    var key = props[j];
                    if (obj != null)
                    {
                        ExcelAttribute head = (ExcelAttribute)obj;
                        if (head.Picture)
                        {
                            string url = props[j].GetValue(list[i]).ToString().Split(",")[0];
                            if (!string.IsNullOrWhiteSpace(url))
                            {
                                row.Height = 80 * 20;
                                WebClient temp = new WebClient();
                                byte[] bytes = temp.DownloadData(url);
                                int pictureIdx = workbook.AddPicture(bytes, PictureType.JPEG);
                                XSSFDrawing drawing = (XSSFDrawing)sheet.CreateDrawingPatriarch();
                                XSSFClientAnchor anchor = new XSSFClientAnchor(0, 0, 0, 0, j, i + 1, j + 1, i + 2);
                                XSSFPicture picture = (XSSFPicture)drawing.CreatePicture(anchor, pictureIdx);
                                bytes = null;
                            }
                            continue;
                        }
                        else
                        {
                            var drValue = props[j].GetValue(list[i]) == null ? "" : props[j].GetValue(list[i]).ToString();
                            var type = props[j].PropertyType;
                            if (type == typeof(Int32) || type == typeof(Int32?))
                            {
                                int intV = 0;
                                int.TryParse(drValue, out intV);
                                row.CreateCell(j).SetCellValue(intV);
                            }
                            else if (type == typeof(System.Decimal) || type == typeof(System.Decimal?))
                            {
                                double doubV = 0;
                                double.TryParse(drValue, out doubV);
                                row.CreateCell(j).SetCellValue(doubV);
                            }
                            else if (type == typeof(System.Byte) || type == typeof(System.Byte?))
                            {
                                Byte doubV = 0;
                                Byte.TryParse(drValue, out doubV);
                                row.CreateCell(j).SetCellValue(doubV);
                            }
                            else if (type == typeof(System.Boolean) || type == typeof(System.Boolean?))
                            {
                                Boolean doubV = false;
                                Boolean.TryParse(drValue, out doubV);
                                row.CreateCell(j).SetCellValue(doubV);
                            }
                            else
                            {
                                row.CreateCell(j).SetCellValue(drValue);
                            }
                        }
                    }
                }
            }
            //获取当前列的宽度，然后对比本列的长度，取最大值
            for (int columnNum = 0; columnNum <= props.Length; columnNum++)
            {
                int columnWidth = sheet.GetColumnWidth(columnNum) / 256;
                for (int rowNum = 1; rowNum <= sheet.LastRowNum; rowNum++)
                {
                    IRow currentRow;
                    //当前行未被使用过
                    if (sheet.GetRow(rowNum) == null)
                    {
                        currentRow = sheet.CreateRow(rowNum);
                    }
                    else
                    {
                        currentRow = sheet.GetRow(rowNum);
                    }

                    if (currentRow.GetCell(columnNum) != null)
                    {
                        ICell currentCell = currentRow.GetCell(columnNum);
                        int length = Encoding.Default.GetBytes(currentCell.ToString()).Length;
                        if (columnWidth < length)
                        {
                            columnWidth = length;
                        }
                    }
                    if (columnWidth > 40)
                    {
                        columnWidth = 40;
                    }
                }
                sheet.SetColumnWidth(columnNum, columnWidth * 256);
            }
            //转为字节数组
            MemoryStream stream = new MemoryStream();
            workbook.Write(stream);
            var buf = stream.ToArray();
            workbook.Close();
            stream.Close();
            stream.Dispose();
            return buf;
        }


        public static byte[] EppListToExcel(List<T> data, string seetName = "Seet1")
        {
            using (ExcelPackage excel = new ExcelPackage())
            {
                ExcelWorksheet sheet = excel.Workbook.Worksheets.Add(seetName);
                PropertyInfo[] props = typeof(T).GetProperties();
                for (var i = 0; i < props.Length; ++i)
                {
                    Object obj = props[i].GetCustomAttribute(typeof(ExcelAttribute));
                    if (obj != null)
                    {
                        ExcelAttribute head = (ExcelAttribute)obj;
                        sheet.Cells[1, i + 1].Value = head.Header;
                        if (!string.IsNullOrWhiteSpace(head.DateTime))
                        {
                            sheet.Cells[1, i + 1, data.Count + 1, i + 1].Style.Numberformat.Format = head.DateTime;
                        }
                    }
                    else
                    {
                        sheet.Cells[1, i + 1].Value = props[i].Name;
                    }
                }
                for (var i = 0; i < data.Count; ++i)
                {
                    for (var j = 0; j < props.Length; ++j)
                    {
                        sheet.Cells[i + 2, j + 1].Value = props[j].GetValue(data[i]);
                        //WebClient wb = new WebClient();
                        //byte[] bt = wb.DownloadData("http://8000.bitcoding.top:8888/upload/images/41a38133-559f-43f8-be7d-51e4b11c32fd.png");
                        //Image photo = null;
                        //using (MemoryStream ms = new MemoryStream(bt))
                        //{
                        //    ms.Write(bt, 0, bt.Length);
                        //    photo = Image.FromStream(ms, true);
                        //}
                        //sheet.Drawings.AddPicture(System.Guid.NewGuid().ToString(), photo);
                    }
                }
                MemoryStream stream = new MemoryStream();
                excel.SaveAs(stream);
                stream.Seek(0, SeekOrigin.Begin);
                stream.Close();
                stream.Dispose();
                return stream.ToArray();
            }
        }
        public static Dictionary<string, string> getExcelHead()
        {
            Type t = new T().GetType();
            Dictionary<string, string> dic = new Dictionary<string, string>();

            foreach (var item in t.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                Object obj = item.GetCustomAttribute(typeof(ExcelAttribute));
                ExcelAttribute excel;
                string head = "";
                if (obj != null)
                {
                    excel = (ExcelAttribute)obj;
                    head = excel.Header;
                }
                else
                {
                    head = item.Name;
                }
                dic.Add(item.Name, head);
            }
            return dic;
        }
    }
}
