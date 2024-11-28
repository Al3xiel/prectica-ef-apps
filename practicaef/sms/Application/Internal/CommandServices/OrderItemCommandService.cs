using practicaef.Shared.Domain.Repositories;
using practicaef.sms.Application.Internal.OutboundServices;
using practicaef.sms.Domain.Model.Aggregates;
using practicaef.sms.Domain.Model.Commands;
using practicaef.sms.Domain.Repositories;
using practicaef.sms.Domain.Services;

namespace practicaef.sms.Application.Internal.CommandServices;

public class OrderItemCommandService (
    IOrderItemRepository orderItemRepository,
    IInventoryItemsService inventoryItemsService,
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
        
        var inventoryItem = await inventoryItemsService.GetInventoryItemByEpicorSku(command.EpicorSku);
        if(inventoryItem == null)
        {
            throw new ArgumentException("Inventory item not found");
        }
        
        var orderItem = new OrderItem(command.OrderId, command.EpicorSku, command.RequestedQuantity, command.OrderedAt);
        await orderItemRepository.AddAsync(orderItem);
        await unitOfWork.CompleteAsync();
        return orderItem;
    }
}