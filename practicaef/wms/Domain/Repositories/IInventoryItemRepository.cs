using practicaef.Shared.Domain.Repositories;
using practicaef.wms.Domain.Model.Aggregates;

namespace practicaef.wms.Domain.Repositories;

public interface IInventoryItemRepository:IBaseRepository<InventoryItem>
{
    Task<InventoryItem?> FindInventoryItemByEpicorSkuAsync(string epicorSku);
}