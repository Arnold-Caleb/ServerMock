using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data;

using MySql.Data.MySqlClient;
using Dapper;

namespace AccessDataLibrary
{
    class DataAccess
    {
        public async Task<List<T>> LoadData<T, U>(string sql, U parameters, string connectionString)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                var rows = await connection.QueryAsync<T>(sql, parameters);

                return rows.ToList();
            }
        }

        public Task SaveData<U>(string sql, U parameters, string connectionString)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                return connection.ExecuteAsync(sql, parameters);
            }
        }

    }
}
