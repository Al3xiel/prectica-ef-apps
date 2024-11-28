using practicaef.sms.Domain.Model.ValueObjects;

namespace practicaef.sms.Domain.Model.Aggregates;

public partial class OrderItem
{
    public int Id { get;}
    public int OrderId { get; private set; }
    public Guid EpicorSku { get; private set; }
    public double RequestedQuantity { get; private set; }
    public DateOnly OrderedAt { get; private set; }
    public EOrderItemStatus Status { get; private set; }
    
    public OrderItem(int orderId, string epicorSku, double requestedQuantity, DateOnly orderedAt)
    {
        this.OrderId = orderId;
        this.EpicorSku = Guid.Parse(epicorSku);
        this.RequestedQuantity = requestedQuantity;
        this.Status = EOrderItemStatus.WaitingForInventory;
        this.OrderedAt = orderedAt;
    }
}