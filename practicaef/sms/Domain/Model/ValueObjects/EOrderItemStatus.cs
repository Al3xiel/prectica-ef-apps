namespace practicaef.sms.Domain.Model.ValueObjects;

public enum EOrderItemStatus
{
    ReadyForDispatch,
    WaitingForInventory,
    Dispatching,
    Completed
}