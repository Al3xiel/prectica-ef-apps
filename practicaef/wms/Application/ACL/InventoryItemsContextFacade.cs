using practicaef.wms.Domain.Model.Aggregates;
using practicaef.wms.Domain.Model.Queries;
using practicaef.wms.Domain.Services;
using practicaef.wms.Interfaces.ACL;

namespace practicaef.wms.Application.ACL;

public class InventoryItemsContextFacade(
    IInventoryItemCommandService inventoryItemCommandService,
    IInventoryItemQueryService inventoryItemQueryService) : IInventoryItemsFacade
{
    public Task<InventoryItem?> FetchInventoryItemByEpicorSku(string epicorSku)
    {
        var getInventoryItemByEpicorSku = new GetInventoryItemByEpicorSku(epicorSku);
        var inventoryItem = inventoryItemQueryService.Handle(getInventoryItemByEpicorSku);
        return inventoryItem;
    }
}