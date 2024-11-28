using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using practicaef.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using practicaef.sms.Domain.Model.Aggregates;
using practicaef.wms.Domain.Model.Aggregates;

namespace practicaef.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.AddCreatedUpdatedInterceptor();
        base.OnConfiguring(builder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.Entity<OrderItem>().HasKey(o => o.Id);
        builder.Entity<OrderItem>().Property(o => o.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<OrderItem>().Property(o => o.EpicorSku).IsRequired();
        builder.Entity<OrderItem>().Property(o => o.Status).IsRequired();
        builder.Entity<OrderItem>().Property(o => o.RequestedQuantity).IsRequired();
        builder.Entity<OrderItem>().Property(o => o.OrderedAt).IsRequired();
        
        builder.Entity<InventoryItem>().HasKey(i => i.Id);
        builder.Entity<InventoryItem>().Property(i => i.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<InventoryItem>().Property(i => i.EpicorSku).IsRequired();
        builder.Entity<InventoryItem>().HasIndex(i => i.EpicorSku).IsUnique();
        builder.Entity<InventoryItem>().Property(i => i.Status).IsRequired();
        builder.Entity<InventoryItem>().Property(i => i.MinimumQuantity).IsRequired();
        builder.Entity<InventoryItem>().Property(i => i.AvailableQuantity).IsRequired();
        builder.Entity<InventoryItem>().Property(i => i.ReservedQuantity).IsRequired();
        builder.Entity<InventoryItem>().Property(i => i.PendingSupplyQuantity).IsRequired();
        
        builder.UseSnakeCaseNamingConvention();
    }
}
