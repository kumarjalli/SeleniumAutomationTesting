
#region "Usings"

using System;
using System.Data.OleDb;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Collections.Specialized;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Data;
using Microsoft.Office;
using Excel = Microsoft.Office.Interop.Excel;
using System.Drawing;
using System.Net;
#endregion

namespace Selenium.Core
{

    public static class ExcelHelper
    {
        #region "Public"

 
        public static void ExportData(System.Windows.Forms.DataGridView grid, string saveAsFileName = null, bool exportImages = false)
        {
            if (null != grid && grid.Rows.Count > 0)
            {
                Excel.Application excelApp = null;
                try
                {
                    excelApp = new Excel.Application();
                    Excel.Workbook excelWorkBook = excelApp.Workbooks.Add();
                    Excel.Worksheet excelSheet = excelWorkBook.ActiveSheet;
                    excelSheet.Name = "DataDump";
                    char SINGLE_QUOTE = (char)(34);
                    int row = 1;
                    int column = 1;

                    SortedList<int, string> visibleColumns = new SortedList<int, string>();
                    //'Loop through fields to populate header row in spreadsheet
                    foreach (DataGridViewColumn dc in grid.Columns)
                    {
                        if (dc.Visible)
                        {
                            visibleColumns.Add(dc.DisplayIndex, dc.Name);
                        }
                    }

                    foreach (string columnName in visibleColumns.Values)
                    {
                        excelSheet.Cells[row, column] = grid.Columns[columnName].HeaderText;
                        column += 1;
                    }
                    int columnCount = column;
                    column = 0;
                    row += 1;

                    foreach (DataGridViewRow dr in grid.Rows)
                    {
                        foreach (string columnName in visibleColumns.Values)
                        {
                            try
                            {

                                if ((dr.Cells[columnName].Value == null))
                                {
                                    excelSheet.Cells[row, column + 1] = "";
                                }
                                else
                                {
                                    if (dr.Cells[columnName].ValueType.ToString() == "System.String")
                                    {
                                        string tempValue = dr.Cells[columnName].Value.ToString();
                                        if (tempValue.IndexOf(SINGLE_QUOTE) >= 0)
                                        {
                                            tempValue = tempValue.Replace(@"""", @"""""");
                                        }
                                        excelSheet.Cells[row, column + 1] = @"=""" + tempValue + @"""";

                                        if (exportImages == true)
                                        {
                                            if (columnName.Contains("Image") && !columnName.Contains("ImageName"))
                                            {
                                                string imagePanel = tempValue.Remove(tempValue.Length - 4) + ".png";
                                                string imagePath = System.Configuration.ConfigurationSettings.AppSettings["MyDoorImagePath"] + imagePanel;

                                                WebClient webClient = new WebClient();
                                                webClient.DownloadFile(imagePath, "D:\\tempImage.png");

                                                imagePath = "D:\\tempImage.png";

                                                Excel.Range oRange = (Excel.Range)excelSheet.Cells[row, column + 1];
                                                float Left = (float)((double)oRange.Left);
                                                float Top = (float)((double)oRange.Top);
                                                const float ImageSize = 64;
                                                excelSheet.Shapes.AddPicture(imagePath, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, Left, Top, ImageSize * 2, ImageSize);
                                                oRange.RowHeight = ImageSize + 2;
                                            }
                                        }

                                    }
                                    else
                                    {
                                        excelSheet.Cells[row, column + 1] = dr.Cells[columnName].Value;
                                    }
                                }

                            }
                            catch (System.Exception)
                            {

                            }
                            column += 1;
                        }
                        column = 0;
                        row += 1;
                    }
                    if (!(string.IsNullOrEmpty(saveAsFileName)))
                    {
                        if (System.IO.File.Exists(saveAsFileName))
                        {
                            System.IO.File.Delete(saveAsFileName);
                        }
                        excelWorkBook.SaveAs(saveAsFileName);
                        excelApp.Workbooks.Open(saveAsFileName);
                    }
                    excelApp.Visible = true;
                }
                finally
                {

                }
            }
        }

        public static DataSet ImportData(string fileName, bool hasHeaders)
        {
          string headers = hasHeaders ? "Yes" : "No";
          string excelConnectionString;
          if (fileName.Substring(fileName.LastIndexOf('.')).ToLower() == ".xlsx")
          {
            excelConnectionString = string.Format( "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0;HDR={1};IMEX=0\"",fileName,headers);
          }
          else
          {
            excelConnectionString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=\"Excel 8.0;HDR={1};IMEX=0\"", fileName, headers);
          }

          DataSet output = new DataSet();
          using (OleDbConnection conn = new OleDbConnection(excelConnectionString))
          {
            conn.Open();
            DataTable schemaTable = conn.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });

            foreach (DataRow schemaRow in schemaTable.Rows)
            {
              string sheet = schemaRow["TABLE_NAME"].ToString();

              if (!sheet.EndsWith("_"))
              {
                try
                {
                  OleDbCommand cmd = new OleDbCommand("SELECT * FROM [" + sheet + "]", conn);
                  cmd.CommandType = CommandType.Text;

                  DataTable outputTable = new DataTable(sheet);
                  output.Tables.Add(outputTable);
                  new OleDbDataAdapter(cmd).Fill(outputTable);
                }
                catch (Exception ex)
                {
                  throw new Exception(ex.Message + string.Format("Sheet:{0}.File:F{1}", sheet, fileName), ex);
                }
              }
            }
          }
          return output;
        } 
        #endregion


    }
}
