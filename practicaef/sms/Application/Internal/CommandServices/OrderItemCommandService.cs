using practicaef.Shared.Domain.Repositories;
using practicaef.sms.Domain.Model.Aggregates;
using practicaef.sms.Domain.Model.Commands;
using practicaef.sms.Domain.Repositories;
using practicaef.sms.Domain.Services;

namespace practicaef.sms.Application.Internal.CommandServices;

public class OrderItemCommandService (
    IOrderItemRepository orderItemRepository,
    IUnitOfWork unitOfWork) : IOrderItemCommandService
{
    public async Task<OrderItem?> Handle(CreateOrderItemCommand command)
    {
        if(command.RequestedQuantity <= 0)
        {
            throw new ArgumentException("Requested quantity must be greater than 0");
        }
        if(command.OrderedAt > DateTime.Now)
        {
            throw new ArgumentException("Ordered at must be less than or equal to current date");
        }
        var orderItem = new OrderItem(command.OrderId, command.EpicorSku, command.RequestedQuantity, command.OrderedAt);
        await orderItemRepository.AddAsync(orderItem);
        await unitOfWork.CompleteAsync();
        return orderItem;
    }
}