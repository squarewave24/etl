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
        public void Load(DataSet data) {
            var tableName = "TestTable";
            var databaseName = "TestDB";
            var serverName = ".\\sqlexpress";
            var connStr = $"Data Source={serverName}; Database={databaseName}; Integrated Security=SSPI;";

            var conn = new SqlConnection(connStr);
            

            using (var bulk = new SqlBulkCopy(conn)) {
                bulk.WriteToServer(data.Tables[tableName]);
            }
        }
    }
}
