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
        var inventoryItem = new InventoryItem(command.EpicorSku, command.MinimumQuantity, command.AvailableQuantity);
        await inventoryItemRepository.AddAsync(inventoryItem);
        await unitOfWork.CompleteAsync();
        return inventoryItem;
    }
}