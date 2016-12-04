using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Etl.ConsoleApp.Tasks
{
    public class CsvExtractor
    {





        // as found on http://stackoverflow.com/questions/1050112/how-to-read-a-csv-file-into-a-net-datatable
        public static DataTable GetDataTableFromCsv(string path, bool isFirstRowHeader) {
            string header = isFirstRowHeader ? "Yes" : "No";

            string pathOnly = Path.GetDirectoryName(path);
            string fileName = Path.GetFileName(path);

            string sql = @"SELECT * FROM [" + fileName + "]";

            using (OleDbConnection connection = new OleDbConnection(
                      @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pathOnly +
                      ";Extended Properties=\"Text;HDR=" + header + "\""))
            using (OleDbCommand command = new OleDbCommand(sql, connection))
            using (OleDbDataAdapter adapter = new OleDbDataAdapter(command)) {
                DataTable dataTable = new DataTable();
                dataTable.Locale = CultureInfo.CurrentCulture;
                adapter.Fill(dataTable);
                foreach (var c in dataTable.Columns)
                {
                    var col = c as DataColumn;
                    if (col != null)
                        col.ColumnName = Regex.Replace(col.ColumnName, @"[^\u0000-\u007F]+", string.Empty);
                }
                return dataTable;
            }
        }
    }
}
