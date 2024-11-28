using practicaef.wms.Domain.Model.Aggregates;
using practicaef.wms.Domain.Model.Queries;

namespace practicaef.wms.Domain.Services;

public interface IInventoryItemQueryService
{
    Task<InventoryItem?> Handle(GetInventoryItemByIdQuery query);
    Task<InventoryItem?> Handle(GetInventoryItemByEpicorSku query);
}