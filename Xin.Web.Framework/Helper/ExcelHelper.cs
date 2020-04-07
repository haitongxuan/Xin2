using Microsoft.AspNetCore.Http;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Reflection;
using System.Text;

namespace Xin.Web.Framework.Helper
{
    public class ExcelHelper<T> where T : new()
    {
        /// <summary>
        /// excel转list
        /// </summary>
        /// <param name="excelFile"></param>
        /// <returns></returns>
        public static List<T> ExcelToList(IFormFile excelFile)
        {
            List<T> list = new List<T>();
            try
            {
                if (excelFile == null || excelFile.Length <= 0)
                {
                    throw new Exception("导入文件不能为空");
                }
                else if (!Path.GetExtension(excelFile.FileName).Equals(".xlsx", StringComparison.OrdinalIgnoreCase))
                {
                    throw new Exception("导入文件格式不是.XLSX,请重新导入");
                }

                using (var stream = excelFile.OpenReadStream())
                {
                    using (var package = new ExcelPackage(stream))
                    {
                        try
                        {
                            StringBuilder sb = new StringBuilder();
                            ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                            DataTable dataTable = WorksheetToTable(worksheet);
                            list = DataTableToList(dataTable);
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
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
        public static DataTable WorksheetToTable(ExcelWorksheet worksheet)
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
    }
}
