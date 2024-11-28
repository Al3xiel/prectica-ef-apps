using practicaef.sms.Domain.Model.Aggregates;
using practicaef.sms.Domain.Model.Commands;

namespace practicaef.sms.Domain.Services;

public interface IOrderItemCommandService
{
    Task<OrderItem?> Handle(CreateOrderItemCommand command);
}