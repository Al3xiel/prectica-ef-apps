using practicaef.wms.Domain.Model.Commands;
using practicaef.wms.Interfaces.REST.Resources;

namespace practicaef.wms.Interfaces.REST.Transform;

public class CreateInventoryItemCommandFromResourceAssembler
{
    public static CreateInventoryItemCommand ToCommandFromResource(CreateInventoryItemResource resource)
    {
        return new CreateInventoryItemCommand(
            resource.EpicorSku,
            resource.MinimumQuantity,
            resource.AvailableQuantity);
    }
}