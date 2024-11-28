namespace practicaef.wms.Interfaces.REST.Resources;

public record InventoryItemResource(
    int id,
    string epicorSku,
    string status,
    double minimumQuantity,
    double availableQuantity,
    double reservedQuantity,
    double pendingSupplyQuantity
    );