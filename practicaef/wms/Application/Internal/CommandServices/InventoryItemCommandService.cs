using practicaef.Shared.Domain.Repositories;
using practicaef.wms.Domain.Model.Aggregates;
using practicaef.wms.Domain.Model.Commands;
using practicaef.wms.Domain.Repositories;
using practicaef.wms.Domain.Services;

namespace practicaef.wms.Application.Internal.CommandServices;

public class InventoryItemCommandService(
    IInventoryItemRepository inventoryItemRepository,
    IUnitOfWork unitOfWork) : IInventoryItemCommandService
{
    public async Task<InventoryItem?> Handle(CreateInventoryItemCommand command)
    {
        if (command.MinimumQuantity <= 0)
        {
            throw new ArgumentException("Minimum quantity must be greater than 0"); 
        }
        if (command.AvailableQuantity < (command.MinimumQuantity * 3))
        {
            throw new ArgumentException("Available quantity must be at least 3 times the minimum quantity");
        }
        
        var inventoryItem = new InventoryItem(command.EpicorSku, command.MinimumQuantity, command.AvailableQuantity);
        await inventoryItemRepository.AddAsync(inventoryItem);
        await unitOfWork.CompleteAsync();
        return inventoryItem;
    }
}