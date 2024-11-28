namespace practicaef.sms.Interfaces.REST.Resources;

public record OrderItemResource(
    int id,
    string epicorSku,
    double requestedQuantity,
    string orderItemStatus,
    string orderedAt
    );