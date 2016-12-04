using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etl.ConsoleApp.Tasks
{
    public class SqlLoader
    {
        public void Load(DataSet data)
        {
            var connStr = "";
            var tableName = "TestTable";
            var databaseName = "TestDB";

            var conn = new SqlConnection(connStr);
            var ds = new DataSet();
            ds.Tables.Add(new DataTable(tableName));
                using (var bulk = new SqlBulkCopy(conn))
                {
                    bulk.WriteToServer(data)
                }
        }
    }
}
