using practicaef.sms.Domain.Model.ValueObjects;

namespace practicaef.sms.Domain.Model.Aggregates;

public partial class OrderItem
{
    public int Id { get;}
    public int OrderId { get; private set; }
    public Guid EpicorSku { get; private set; }
    public double RequestedQuantity { get; private set; }
    public DateOnly OrderedAt { get; private set; } = DateOnly.FromDateTime(DateTime.Now);
    public EOrderItemStatus Status { get; private set; }
}