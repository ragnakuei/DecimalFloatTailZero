using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Dapper;
using DecimalFloatTailZero.Extensions;
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
            var sql = @"
SELECT [o].[Guid],
       [o].[Name],
       [o].[Total]
FROM [dbo].[Order] [o]
";
            var param = new DynamicParameters();

            return _sqlConnection.Query<OrderDto>(sql, param);
        }

        public void Create(OrderDto vm)
        {
            _sqlConnection.Open();
            using (var trans = _sqlConnection.BeginTransaction())
            {
                try
                {
                    var sql = @"
INSERT INTO [dbo].[Order]([Guid], [Name], [SubTotal], [BusinessTax], [Total], [FloatPrecision])
VALUES (@Guid, @Name, @SubTotal, @BusinessTax, @Total, @FloatPrecision)
";
                    var orderParam = new DynamicParameters();
                    orderParam.AddDynamicParams(vm);

                    _sqlConnection.Execute(sql, orderParam, trans);

                    sql = @"
INSERT INTO [dbo].[OrderDetail]([Guid], [Item], [OrderGuid], [UnitPrice], [Count], [Comment])
VALUES (@Guid, @Item, @OrderGuid, @UnitPrice, @Count, @Comment)
";
                    vm.Details
                      .ForEach(d =>
                               {
                                   var orderDetailParam = new DynamicParameters();
                                   orderDetailParam.AddDynamicParams(d);

                                   _sqlConnection.Execute(sql, orderDetailParam, trans);
                               });

                    trans.Commit();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    trans.Rollback();
                    throw;
                }
                finally
                {
                    _sqlConnection.Close();
                }
            }
        }

        public OrderBoxDto GetOrder(Guid? orderGuid)
        {
            var sql = @"
SELECT *
FROM [dbo].[Order]
WHERE [Guid] = @OrderGuid

SELECT *
FROM [dbo].[OrderDetail]
WHERE [OrderGuid] = @OrderGuid
";
            var param = new DynamicParameters();
            param.Add("OrderGuid", orderGuid, DbType.Guid);

            var result = new OrderBoxDto();

            var reader = _sqlConnection.QueryMultiple(sql, param);
            result.OrderDto        = reader.ReadFirstOrDefault<OrderDto>();
            result.OrderDetailDtos = reader.Read<OrderDetailDto>();

            return result;
        }
    }
}
