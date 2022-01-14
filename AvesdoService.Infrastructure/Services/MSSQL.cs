using AvesdoService.Core;
using AvesdoService.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvesdoService.Infrastructure.Services
{
    public class MSSQL : BaseDB, IDatabase<SqlParameter>
    {
        public MSSQL(string connectionString) : base(connectionString) { }

        public async Task<int> ExecuteNonQueryAsync(string query, List<SqlParameter>? parameters = null)
        {
            var connection = (SqlConnection)GetConnection();
            using (connection)
            {
                using (var command = new SqlCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        foreach (SqlParameter p in parameters)
                        {
                            command.Parameters.Add(p);
                        }
                    }

                    int result = -1;
                    try
                    {
                        await connection.OpenAsync();
                        result = await command.ExecuteNonQueryAsync();
                    }
                    catch (Exception e)
                    {
                        //_logger.Fatal(e, e.Message);
                    }
                    return result;

                }
            }
        }

        public async Task<DataTable?> ExecuteReaderAsync(string query, List<SqlParameter>? parameters = null, bool storedProcedure = true)
        {
            var connection = (SqlConnection)GetConnection();
            using (connection)
            {
                using (var command = new SqlCommand(query, connection))
                {
                    if (storedProcedure)
                    {
                        command.CommandType = CommandType.StoredProcedure;
                    }

                    if (parameters != null)
                    {
                        foreach (SqlParameter p in parameters)
                        {
                            command.Parameters.Add(p);
                        }
                    }

                    var dt = new DataTable();

                    try
                    {
                        await connection.OpenAsync();

                        SqlDataAdapter da = new SqlDataAdapter(command);
                        var result = da.Fill(dt);
                        return dt;
                    }
                    catch (Exception e)
                    {
                        //_logger.Fatal(e, e.Message);
                        Console.WriteLine(e.Message);
                    }

                    return dt;
                }
            }
        }

        public IDbConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}