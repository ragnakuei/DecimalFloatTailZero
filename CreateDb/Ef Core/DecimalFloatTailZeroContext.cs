using CreateDb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace CreateDb.Ef_Core
{
public class DecimalFloatTailZeroContext : DbContext
{
    private readonly AppSettingsDto _appSettings;

    public DecimalFloatTailZeroContext(DbContextOptions options,
                         IConfiguration configuration)
        : base(options)
    {
        _appSettings = configuration.Get<AppSettingsDto>();
    }

    public DbSet<Order> Order { get; set; }
    public DbSet<OrderDetail> OrderDetail { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(_appSettings.Db.DefaultSchema);
        modelBuilder.UseCollation(_appSettings.Db.Collation);

        modelBuilder.ApplyConfiguration(new OrderConfiguration(_appSettings));
        modelBuilder.ApplyConfiguration(new OrderDetailConfiguration(_appSettings));

    }
}

internal class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    private readonly AppSettingsDto _appSettings;

    public OrderConfiguration(AppSettingsDto appSettings)
    {
        _appSettings = appSettings;
    }

    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable(nameof(Order), _appSettings.Db.DefaultSchema);

        builder.HasKey(x => new
                            {
                                x.Id,
                            })
                       .IsClustered();

        builder.HasIndex(u => u.Guid)
               .HasDatabaseName($"IX_{nameof(Order)}_{nameof(Order.Guid)}")
               .IsUnique();

        builder.Property(x => x.Id)
               .IsRequired()
               .UseIdentityColumn(1, 1)
               .HasColumnType(SqlDbTypes.Bigint)
               .HasComment("ID");

        builder.Property(x => x.Guid)
               .IsRequired()
               .HasColumnType(SqlDbTypes.Uniqueidentifier)
               .HasComment("Guid");

        builder.Property(x => x.Name)
               .IsRequired()
               .HasColumnType(SqlDbTypes.Nvarchar(50))
               .HasComment("名稱");

        builder.Property(x => x.SubTotal)
               .IsRequired()
               .HasColumnType(SqlDbTypes.Varchar(30))
               .HasComment("小計");

        builder.Property(x => x.BusinessTax)
               .IsRequired()
               .HasColumnType(SqlDbTypes.Varchar(30))
               .HasComment("營業稅");

        builder.Property(x => x.Total)
               .IsRequired()
               .HasColumnType(SqlDbTypes.Varchar(30))
               .HasComment("總計");

        builder.Property(x => x.FloatPrecision)
               .IsRequired()
               .HasColumnType(SqlDbTypes.Numeric(12,10))
               .HasComment("浮點數解析度");


         // 以下是 FK 設定
    }
}

internal class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
{
    private readonly AppSettingsDto _appSettings;

    public OrderDetailConfiguration(AppSettingsDto appSettings)
    {
        _appSettings = appSettings;
    }

    public void Configure(EntityTypeBuilder<OrderDetail> builder)
    {
        builder.ToTable(nameof(OrderDetail), _appSettings.Db.DefaultSchema);

        builder.HasKey(x => new
                            {
                                x.Id,
                            })
                       .IsClustered();

        builder.HasIndex(u => u.Guid)
               .HasDatabaseName($"IX_{nameof(OrderDetail)}_{nameof(OrderDetail.Guid)}")
               .IsUnique();

        builder.Property(x => x.Id)
               .IsRequired()
               .UseIdentityColumn(1, 1)
               .HasColumnType(SqlDbTypes.Bigint)
               .HasComment("ID");

        builder.Property(x => x.Guid)
               .IsRequired()
               .HasColumnType(SqlDbTypes.Uniqueidentifier)
               .HasComment("Guid");

        builder.Property(x => x.OrderGuid)
               .IsRequired()
               .HasColumnType(SqlDbTypes.Uniqueidentifier)
               .HasComment("訂單 Guid");

        builder.Property(x => x.Item)
               .IsRequired()
               .HasColumnType(SqlDbTypes.Nvarchar(50))
               .HasComment("項目");

        builder.Property(x => x.UnitPrice)
               .IsRequired()
               .HasColumnType(SqlDbTypes.Varchar(30))
               .HasComment("單價");

        builder.Property(x => x.Count)
               .IsRequired()
               .HasColumnType(SqlDbTypes.Int)
               .HasComment("數量");

        builder.Property(x => x.Amount)
               .IsRequired()
               .HasColumnType(SqlDbTypes.Varchar(30))
               .HasComment("金額");

        builder.Property(x => x.Comment)
               .HasColumnType(SqlDbTypes.Nvarchar(1000))
               .HasComment("備註");


         // 以下是 FK 設定
         builder.HasOne(x => x.Order)
                .WithMany()
                .IsRequired()
                .HasConstraintName($"FK_{nameof(OrderDetail)}_{nameof(OrderDetail.OrderGuid)}_{nameof(Order)}_{nameof(Order.Guid)}")
                .HasPrincipalKey(x => x.Guid)
                .OnDelete(DeleteBehavior.NoAction);

    }
}
}
