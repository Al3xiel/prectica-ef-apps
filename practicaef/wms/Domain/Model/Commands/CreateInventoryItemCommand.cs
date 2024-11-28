namespace practicaef.wms.Domain.Model.Commands;

public record CreateInventoryItemCommand(
    string EpicorSku,
    double MinimumQuantity,
    double AvailableQuantity
    );