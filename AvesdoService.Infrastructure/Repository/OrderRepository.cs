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
    public class OrderRepository : IOrderRepository<OrderModel>
    {
        private readonly IDatabase<SqlParameter> _mssql;

        public OrderRepository(IDatabase<SqlParameter> mssql)
        {
            _mssql = mssql;
        }
        public async Task<int> AddOrderItem(OrderItemModel orderItem)
        {
            string query = "OrderCRUD";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.AddParameter("@ItemID", SqlDbType.Int, orderItem.ItemID);
            parameters.AddParameter("@OrderID", SqlDbType.Int, orderItem.OrderID);
            parameters.AddParameter("@Quantity", SqlDbType.Int, orderItem.Quantity);
            parameters.AddParameter("@Operation", SqlDbType.TinyInt, 2);

            var result = await _mssql.ExecuteReaderAsync(query, parameters);
            
            return result.Rows.Count;
        }

        public Task<Address> CreateAddress(Address address)
        {
            throw new NotImplementedException();
        }

        public async Task<OrderModel> CreateOrderAsync(OrderModel model)
        {
            string query = "OrderCRUD";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.AddParameter("@CustomerID", System.Data.SqlDbType.Int, model.CustomerID);
            parameters.AddParameter("@OrderDate", System.Data.SqlDbType.DateTime, model.OrderDate);
            parameters.AddParameter("@Operation", System.Data.SqlDbType.TinyInt, 1);

            var result = await _mssql.ExecuteReaderAsync(query, parameters);
            
            foreach (DataRow row in result.Rows)
            {
                var newOrder = new OrderModel
                {
                    OrderStatusID = Convert.ToInt32(row["OrderStatusID"]),
                    OrderID = Convert.ToInt32(row["OrderID"]),
                    OrderDate = DateTime.Parse(row["OrderDate"].ToString()),
                    CustomerID = Convert.ToInt32(row["CustomerID"])
                };
                return newOrder;
            }
            return model;
        }

        public async Task<int> DeleteOrderAsync(int id)
        {
            string query = "OrderCRUD";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.AddParameter("@OrderID", System.Data.SqlDbType.Int, id);
            parameters.AddParameter("@Operation", System.Data.SqlDbType.TinyInt, 6);

            var result = await _mssql.ExecuteReaderAsync(query, parameters);
            return result.Rows.Count;
        }

        public async Task<OrderModel> GetOrderAsync(int id)
        {
            string query = "OrderCRUD";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.AddParameter("@OrderID", System.Data.SqlDbType.Int, id);
            parameters.AddParameter("@Operation", System.Data.SqlDbType.TinyInt, 5);

            var result = await _mssql.ExecuteReaderAsync(query, parameters);
            foreach (DataRow row in result.Rows)
            {
                var newOrder = new OrderModel
                {
                    OrderStatusID = Convert.ToInt32(row["OrderStatusID"]),
                    OrderID = Convert.ToInt32(row["OrderID"]),
                    OrderDate = DateTime.Parse(row["OrderDate"].ToString()),
                    CustomerID = Convert.ToInt32(row["CustomerID"])
                };
                return newOrder;
            }
            return null;
        }

        public async Task<IEnumerable<OrderModel>> GetOrdersAsync()
        {
            string query = "OrderCRUD";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.AddParameter("@Operation", System.Data.SqlDbType.TinyInt, 4);

            var result = await _mssql.ExecuteReaderAsync(query, parameters);
            List<OrderModel> orders = new List<OrderModel>();
            foreach (DataRow row in result.Rows)
            {
                orders.Add(new OrderModel
                {
                    OrderStatusID = Convert.ToInt32(row["OrderStatusID"]),
                    OrderID = Convert.ToInt32(row["OrderID"]),
                    OrderDate = DateTime.Parse(row["OrderDate"].ToString()),
                    CustomerID = Convert.ToInt32(row["CustomerID"])
                });
            }
            return orders;
        }

        public async Task<int> RemoveOrderItem(int orderID, int orderItemID)
        {
            string query = "OrderCRUD";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.AddParameter("@OrderID", System.Data.SqlDbType.Int, orderID);
            parameters.AddParameter("@OrderItemID", System.Data.SqlDbType.Int, orderItemID);
            parameters.AddParameter("@Operation", System.Data.SqlDbType.TinyInt, 3);

            var result = await _mssql.ExecuteReaderAsync(query, parameters);

            return result.Rows.Count;
        }

        public async Task<int> UpdateOrderStatus(int orderID, int statusID)
        {
            string query = "OrderCRUD";
            string error = String.Empty;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.AddParameter("@OrderID", System.Data.SqlDbType.Int, orderID);
            parameters.AddParameter("@OrderStatusID", System.Data.SqlDbType.Int, statusID);
            parameters.AddParameter("@Operation", System.Data.SqlDbType.TinyInt, 7);
            //parameters.AddParameter("@Error", System.Data.SqlDbType.NVarChar, error);

            var output = new SqlParameter
            {
                ParameterName = "@Error",
                Value = error,
                SqlDbType = SqlDbType.NVarChar
            };
            output.Direction = ParameterDirection.Output;

            var result = await _mssql.ExecuteReaderAsync(query, parameters);

            foreach (DataRow row in result.Rows)
            {
                error = row["Error"].ToString();
            }
            if (String.IsNullOrEmpty(error))
            {
                return 1;
            }
            return 0;
        }
    }
}
