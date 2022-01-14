using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvesdoService.Core.Interfaces
{
    public abstract class BaseDB
    {
        protected string _connectionString;

        public BaseDB(string connectionString)
        {
            _connectionString = connectionString;
        }
    }
}
