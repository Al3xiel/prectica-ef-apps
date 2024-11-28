using practicaef.wms.Domain.Model.Aggregates;
using practicaef.wms.Domain.Model.Commands;

namespace practicaef.wms.Domain.Services;

public interface IInventoryItemCommandService
{
    Task<InventoryItem?> Handle(CreateInventoryItemCommand command);
}