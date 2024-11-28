using practicaef.wms.Domain.Model.Aggregates;
using practicaef.wms.Interfaces.REST.Resources;

namespace practicaef.wms.Interfaces.REST.Transform;

public class InventoryItemResourceFromEntityAssembler
{
    public static InventoryItemResource ToResourceFromEntity(InventoryItem entity)
    {
        return new InventoryItemResource(
            entity.Id,
            entity.EpicorSku.ToString(),
            entity.Status.ToString(),
            entity.MinimumQuantity,
            entity.AvailableQuantity,
            entity.ReservedQuantity,
            entity.PendingSupplyQuantity
            );
    }
}