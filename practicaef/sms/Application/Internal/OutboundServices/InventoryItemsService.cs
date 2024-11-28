using practicaef.wms.Domain.Model.Aggregates;
using practicaef.wms.Interfaces.ACL;

namespace practicaef.sms.Application.Internal.OutboundServices;

public class InventoryItemsService(IInventoryItemsFacade inventoryItemsFacade): IInventoryItemsService 
{
    public async Task<InventoryItem?> GetInventoryItemByEpicorSku(string epicorSku)
    {
        return await inventoryItemsFacade.FetchInventoryItemByEpicorSku(epicorSku);
    }
}