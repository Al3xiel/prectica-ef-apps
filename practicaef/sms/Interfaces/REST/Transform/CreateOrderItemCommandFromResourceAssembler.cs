using practicaef.sms.Domain.Model.Commands;
using practicaef.sms.Interfaces.REST.Resources;

namespace practicaef.sms.Interfaces.REST.Transform;

public class CreateOrderItemCommandFromResourceAssembler
{
    public static CreateOrderItemCommand ToCommandFromResource(CreateOrderItemResource resource)
    {
        return new CreateOrderItemCommand(
            resource.OrderId, 
            resource.EpicorSku,
            resource.RequestedQuantity,
            resource.OrderedAt);
    }
}