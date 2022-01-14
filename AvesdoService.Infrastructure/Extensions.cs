using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvesdoService.Infrastructure
{
    public static class Extensions
    {
        public static List<SqlParameter> AddParameter(this List<SqlParameter> parameters, string parameterName, System.Data.SqlDbType sqlDbType, object value)
        {
            parameters.Add(new SqlParameter
            {
                SqlDbType = sqlDbType,
                ParameterName = parameterName,
                Value = value
            });
            return parameters;
        }
    }
}
