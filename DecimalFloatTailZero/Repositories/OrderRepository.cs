using System.Collections;
using System.Collections.Generic;
using Dapper;
using DecimalFloatTailZero.Models;
using Microsoft.Data.SqlClient;

namespace DecimalFloatTailZero.Repositories
{
    public class OrderRepository
    {
        private readonly SqlConnection _sqlConnection;

        public OrderRepository(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }

        public IEnumerable<OrderDto> GetOrders()
        {
            var sql   = @"
SELECT [o].[Name],
       [o].[Total]
FROM [dbo].[Order] [o]
";
            var param = new DynamicParameters();

            return _sqlConnection.Query<OrderDto>(sql , param);
        }
    }
}
