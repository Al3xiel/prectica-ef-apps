using practicaef.wms.Domain.Model.Aggregates;

namespace practicaef.wms.Interfaces.ACL;

public interface IInventoryItemsFacade
{
    Task<InventoryItem?> FetchInventoryItemByEpicorSku(string epicorSku);
}