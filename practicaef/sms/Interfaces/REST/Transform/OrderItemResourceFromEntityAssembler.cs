using practicaef.sms.Domain.Model.Aggregates;
using practicaef.sms.Interfaces.REST.Resources;

namespace practicaef.sms.Interfaces.REST.Transform;

public class OrderItemResourceFromEntityAssembler
{
    public static OrderItemResource ToResourceFromEntity(OrderItem entity)
    {
        return new OrderItemResource
        (
            entity.Id,
            entity.EpicorSku.ToString(),
            entity.RequestedQuantity,
            entity.Status.ToString(),
            entity.OrderedAt.ToString()
        );
    }
}