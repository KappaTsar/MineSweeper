using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using Dapper;

namespace MineSweeper.db
{
    class SqliteDataAccess<T>
    {
        public static List<T> LoadData(string sqlInput)
        {
            using(IDbConnection idbcnn = new SQLiteConnection(LoadConectionString()))
            {
                var output = idbcnn.Query<T>(sqlInput); //new DynamicParameters
                return output.ToList();
            }
        }

        private static string LoadConectionString(string id = "ScoreTableConection")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
