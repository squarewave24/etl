using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Etl.ConsoleApp.Framework;
using Newtonsoft.Json;

namespace Etl.ConsoleApp.Tasks
{
    public class SqlLoader : LoaderTask
    {
        public SqlLoader(int jobId) : base(jobId) {

        }
        public override void OnLoad(DataTable data) {

            dynamic config = GetConfig();
            if (config.loader == null || config.loader.type == null || config.loader.type != GetType().Name)
                throw new ArgumentException(string.Format("configuration not found for {0}", GetType().Name));

            string database = config.loader.database;
            string table = config.loader.table;
            string server = config.loader.server;

            var mappings = config.loader.mappings as IEnumerable<dynamic>;
            if (string.IsNullOrEmpty(database)) throw new ArgumentNullException("database missing in config");
            if (string.IsNullOrEmpty(table)) throw new ArgumentNullException("destination table name missing in configuration");
            if (string.IsNullOrEmpty(server)) throw new ArgumentNullException("server name missing in configuration");
            if (mappings == null) throw new ArgumentNullException("loader table column mappings are missing in configuration");

            var connStr = string.Format("Data Source={0}; Database={1}; Integrated Security=SSPI;", server, database);

            using (var conn = new SqlConnection(connStr)) {
                conn.Open();
                using (var bulk = new SqlBulkCopy(conn)) {
                    bulk.DestinationTableName = table;


                    foreach (dynamic m in mappings)
                        AddtMapping(bulk.ColumnMappings, m);
            

                    bulk.WriteToServer(data);
                }
            }

            
        }



//        public void Load(DataTable data) {
//            var tableName = "TestTable";
//            var databaseName = "TestDB";
//            var serverName = ".\\sqlexpress";
//            var connStr = $"Data Source={serverName}; Database={databaseName}; Integrated Security=SSPI;";
//
//
//            using (var conn = new SqlConnection(connStr)) {
//                conn.Open();
//                using (var bulk = new SqlBulkCopy(conn)) {
//                    bulk.DestinationTableName = tableName;
//                    AddtMappings( bulk.ColumnMappings);
//                    bulk.WriteToServer(data);
//                }
//            }
//        }
        private void AddtMapping(SqlBulkCopyColumnMappingCollection map, dynamic mapPair)
        {
            
            var source = mapPair.source.ToString();
            var dest = mapPair.destination.ToString();
            if (string.IsNullOrEmpty(source)) throw new ArgumentNullException("loader mapping is invalid because source is missing ");
            if (string.IsNullOrEmpty(dest)) throw new ArgumentNullException("loader mapping is invalid because destination is missing");
            map.Add(source, dest);
        }

        private void AddtMappings(SqlBulkCopyColumnMappingCollection map)
        {
            map.Add("Make", "Make");
            map.Add("Model", "Model");  
        }
    }
}
