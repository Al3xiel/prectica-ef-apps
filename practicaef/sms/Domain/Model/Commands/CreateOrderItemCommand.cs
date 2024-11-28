namespace practicaef.sms.Domain.Model.Commands;

public record CreateOrderItemCommand(
    int OrderId,
    string EpicorSku,
    double RequestedQuantity,
    DateTime OrderedAt
    );