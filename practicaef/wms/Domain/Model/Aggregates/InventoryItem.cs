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
    
    public InventoryItem(string epicorSku, double minimumQuantity, double availableQuantity)
    {
        this.EpicorSku = Guid.Parse(epicorSku);
        this.Status = EInventoryItemStatus.WithStock;
        this.MinimumQuantity = minimumQuantity;
        this.AvailableQuantity = availableQuantity;
        this.ReservedQuantity = 0;
        this.PendingSupplyQuantity = 0;
    }
}