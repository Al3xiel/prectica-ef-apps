using practicaef.wms.Domain.Model.ValueObjects;

namespace practicaef.wms.Domain.Model.Aggregates;

public partial class InventoryItem
{
    public int Id { get;}
    public string EpicorSku { get; private set; }
    public int MinimumQuantity { get; private set; }
    public int AvailableQuantity { get; private set; }
    public EInventoryItemStatus Status { get; private set; }
    
    public InventoryItem(){}
    
}