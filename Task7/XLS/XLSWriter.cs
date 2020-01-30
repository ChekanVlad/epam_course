using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace XLS
{
    /// <summary>
    /// XLSWriter class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static class XLSWriter<T>
    {
        /// <summary>
        /// write method
        /// </summary>
        /// <param name="directory"></param>
        /// <param name="fileName"></param>
        /// <param name="header"></param>
        /// <param name="data"></param>
        public static void Write(string directory, string fileName, List<string> header, List<T> data)
        {
            string path = directory + fileName + ".xlsx";
            var excelApp = new Application();
            Workbook book = excelApp.Workbooks.Add();
            Worksheet sheet = book.Sheets[1];

            for (int i = 1; i < header.Count() + 1; i++)
            {
                sheet.Cells[1, i] = header[i - 1];
            }

            Type type = typeof(T);
            PropertyInfo[] fields = type.GetProperties();

            int rows = 2;
            int columns = 1;

            foreach (T obj in data)
            {
                columns = 1;
                foreach (PropertyInfo field in fields)
                {
                    if (!field.CanWrite)
                        continue;
                    sheet.Cells[rows, columns] = field.GetValue(obj);
                    columns++;
                }
                rows++;
            }
            book.SaveAs(path);
            book.Close();
            excelApp.Quit();
        }
    }
}
