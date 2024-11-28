namespace practicaef.sms.Interfaces.REST.Resources;

public record CreateOrderItemResource(
    int OrderId,
    string EpicorSku,
    double RequestedQuantity,
    DateTime OrderedAt
    );