using practicaef.sms.Domain.Model.ValueObjects;

namespace practicaef.sms.Domain.Model.Aggregates;

public partial class OrderItem
{
    public int Id { get;}
    public int OrderId { get; private set; }
    public string EpicorSku { get; private set; }
    public int RequestedQuantity { get; private set; }
    public DateOnly OrderedAt { get; private set; }
    public EOrderItemStatus Status { get; private set; }
    
    public OrderItem(){}
}