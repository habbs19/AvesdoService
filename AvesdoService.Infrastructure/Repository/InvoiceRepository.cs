using AvesdoService.Core;
using AvesdoService.Core.Interfaces;
using AvesdoService.Core.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvesdoService.Infrastructure.Repository
{
    public class InvoiceRepository : IInvoiceRepository<InvoiceModel>
    {
        private readonly IDatabase<SqlParameter> _mssql;

        public InvoiceRepository(IDatabase<SqlParameter> mssql)
        {
            _mssql = mssql;
        }

        public Task<Address> CreateAddress(Address address)
        {
            throw new NotImplementedException();
        } 

        public async Task<InvoiceModel> CreateInvoiceAsync(int orderID, int addressID)
        {
            string query = "InvoiceCRUD";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.AddParameter("@OrderID", System.Data.SqlDbType.Int, orderID);
            sqlParameters.AddParameter("@AddressID", System.Data.SqlDbType.Int,addressID);
            sqlParameters.AddParameter("@Operation", System.Data.SqlDbType.TinyInt, 1);

            var result = await _mssql.ExecuteReaderAsync(query, sqlParameters);

            foreach (DataRow row in result.Rows)
            {
                return new InvoiceModel
                {
                    InvoiceID = Convert.ToInt32(row["InvoiceID"]),
                    OrderID = Convert.ToInt32(row["OrderID"]),
                    AddressID = Convert.ToInt32(row["AddressID"]),
                    SubTotal = Convert.ToDecimal(row["SubTotal"]),
                    Total = Convert.ToDecimal(row["Total"])
                };

            }
            return null;
        }

        public async Task<InvoiceModel> GetInvoiceByInvoiceIDAsync(int invoiceID)
        {
            string query = "InvoiceCRUD";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.AddParameter("@OrderID", System.Data.SqlDbType.Int, invoiceID);
            sqlParameters.AddParameter("@Operation", System.Data.SqlDbType.TinyInt, 2);

            var result = await _mssql.ExecuteReaderAsync(query, sqlParameters);

            foreach (DataRow row in result.Rows)
            {
                return new InvoiceModel
                {
                    InvoiceID = Convert.ToInt32(row["InvoiceID"]),
                    OrderID = Convert.ToInt32(row["OrderID"]),
                    AddressID = Convert.ToInt32(row["AddressID"]),
                    SubTotal = Convert.ToDecimal(row["SubTotal"]),
                    Total = Convert.ToDecimal(row["Total"])
                };
            }
            return null;
        }

        public async Task<InvoiceModel> GetInvoiceByOrderIDAsync(int orderID)
        {
            string query = "InvoiceCRUD";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.AddParameter("@OrderID", System.Data.SqlDbType.Int, orderID);
            sqlParameters.AddParameter("@Operation", System.Data.SqlDbType.TinyInt, 2);

            var result = await _mssql.ExecuteReaderAsync(query, sqlParameters);

            foreach (DataRow row in result.Rows)
            {
                return new InvoiceModel
                {
                    InvoiceID = Convert.ToInt32(row["InvoiceID"]),
                    OrderID = Convert.ToInt32(row["OrderID"]),
                    AddressID = Convert.ToInt32(row["AddressID"]),
                    SubTotal = Convert.ToDecimal(row["SubTotal"]),
                    Total = Convert.ToDecimal(row["Total"])
                };
            }
            return null;
        }

        public Task<IEnumerable<InvoiceModel>> GetInvoicesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
