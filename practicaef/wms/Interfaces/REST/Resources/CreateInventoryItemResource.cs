namespace practicaef.wms.Interfaces.REST.Resources;

public record CreateInventoryItemResource(
    string EpicorSku,
    double MinimumQuantity,
    double AvailableQuantity);