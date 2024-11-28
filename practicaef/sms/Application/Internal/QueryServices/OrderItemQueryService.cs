using practicaef.Shared.Domain.Repositories;
using practicaef.sms.Domain.Model.Aggregates;
using practicaef.sms.Domain.Model.Queries;
using practicaef.sms.Domain.Repositories;
using practicaef.sms.Domain.Services;

namespace practicaef.sms.Application.Internal.QueryServices;

public class OrderItemQueryService(
    IOrderItemRepository orderItemRepository): IOrderItemQueryService
{
    public async Task<OrderItem?> Handle(GetOrderItemByIdQuery query)
    {
        return await orderItemRepository.FindByIdAsync(query.OrderId);
    }
}