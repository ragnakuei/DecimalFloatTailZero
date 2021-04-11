using System.Data;
using Dapper;
using DecimalFloatTailZero.Extensions;

namespace DecimalFloatTailZero.Infra
{
    /// <summary>
    /// db 的 varchar 對應 C# 的 decimal?
    /// </summary>
    public class AnsiStringToNullDecimalHandler : SqlMapper.TypeHandler<decimal?>
    {
        // Read From Db
        public override decimal? Parse(object value)
        {
            return value?.ToString()?.ToNullableDecimal();
        }

        // Write To Db
        public override void SetValue(IDbDataParameter parameter, decimal? value)
        {
            parameter.Value  = value?.ToString();
            parameter.DbType = DbType.AnsiString;
        }
    }
}
