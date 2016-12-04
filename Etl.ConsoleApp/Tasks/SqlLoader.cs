using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etl.ConsoleApp.Tasks
{
    public class SqlLoader
    {
        public void Load(DataTable data) {
            var tableName = "TestTable";
            var databaseName = "TestDB";
            var serverName = ".\\sqlexpress";
            var connStr = $"Data Source={serverName}; Database={databaseName}; Integrated Security=SSPI;";


            using (var conn = new SqlConnection(connStr)) {
                conn.Open();
                using (var bulk = new SqlBulkCopy(conn)) {
            bulk.DestinationTableName = tableName;
                    bulk.WriteToServer(data);
                }
            }
        }
    }
}
