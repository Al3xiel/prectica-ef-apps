using practicaef.wms.Domain.Model.Aggregates;

namespace practicaef.sms.Application.Internal.OutboundServices;

public interface IInventoryItemsService
{
    Task<InventoryItem?> GetInventoryItemByEpicorSku(string epicorSku);
}