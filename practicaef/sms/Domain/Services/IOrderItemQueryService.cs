using practicaef.sms.Domain.Model.Aggregates;
using practicaef.sms.Domain.Model.Queries;

namespace practicaef.sms.Domain.Services;

public interface IOrderItemQueryService
{
    Task<OrderItem?> Handle(GetOrderItemByIdQuery query);
}