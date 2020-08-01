using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data;

using MySql.Data.MySqlClient;
using Dapper;

namespace AccessDataLibrary
{
    public static class DataAccess
    {
        public static async Task<List<T>> LoadData<T, U>(string sql, U parameters, string connectionString)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                var rows = await connection.QueryAsync<T>(sql, parameters);

                return rows.ToList();
            }
        }

        public static void SaveData<U>(string sql, U parameters, string connectionString)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                connection.ExecuteAsync(sql, parameters);
            }
        }

    }
}
