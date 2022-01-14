using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvesdoService.Core
{
    public interface IDatabase<T> where T : class
    {
        Task<DataTable?> ExecuteReaderAsync(string query, List<T>? parameters = null, bool storedProcedure = true);
        Task<int> ExecuteNonQueryAsync(string query, List<T>? parameters = null);
        IDbConnection GetConnection();

    }
}
