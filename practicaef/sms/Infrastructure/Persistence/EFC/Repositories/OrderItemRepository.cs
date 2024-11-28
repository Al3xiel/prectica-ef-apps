using practicaef.Shared.Infrastructure.Persistence.EFC.Configuration;
using practicaef.Shared.Infrastructure.Persistence.EFC.Repositories;
using practicaef.sms.Domain.Model.Aggregates;
using practicaef.sms.Domain.Repositories;

namespace practicaef.sms.Infrastructure.Persistence.EFC.Repositories;

public class OrderItemRepository(AppDbContext context): BaseRepository<OrderItem>(context), IOrderItemRepository
{
    
}