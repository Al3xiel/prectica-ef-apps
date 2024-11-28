using practicaef.wms.Domain.Model.Aggregates;
using practicaef.wms.Domain.Model.Queries;
using practicaef.wms.Domain.Repositories;
using practicaef.wms.Domain.Services;

namespace practicaef.wms.Application.Internal.QueryServices;

public class InventoryItemQueryService(IInventoryItemRepository inventoryItemRepository): IInventoryItemQueryService
{
    public async Task<InventoryItem?> Handle(GetInventoryItemByIdQuery query)
    {
        return await inventoryItemRepository.FindByIdAsync(query.InventoryItemId);
    }

    public async Task<InventoryItem?> Handle(GetInventoryItemByEpicorSku query)
    {
        return await inventoryItemRepository.FindInventoryItemByEpicorSkuAsync(query.EpicorSku);
    }
}