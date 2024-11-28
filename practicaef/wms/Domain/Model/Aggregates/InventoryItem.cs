using practicaef.wms.Domain.Model.ValueObjects;

namespace practicaef.wms.Domain.Model.Aggregates;

public partial class InventoryItem
{
    public int Id { get;}
    public Guid EpicorSku { get; private set; }
    public double MinimumQuantity { get; private set; }
    public double AvailableQuantity { get; private set; }
    public double ReservedQuantity { get; private set; } = 0;
    public double PendingSupplyQuantity { get; private set; } = 0;
    public EInventoryItemStatus Status { get; private set; }
}