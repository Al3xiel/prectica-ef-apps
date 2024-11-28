using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using practicaef.sms.Domain.Model.Queries;
using practicaef.sms.Domain.Services;
using practicaef.sms.Interfaces.REST.Resources;
using practicaef.sms.Interfaces.REST.Transform;
using Swashbuckle.AspNetCore.Annotations;

namespace practicaef.sms.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Order Items")]
public class OrderItemsController(
    IOrderItemCommandService orderItemCommandService,
    IOrderItemQueryService orderItemQueryService
) : ControllerBase
{
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a new order item",
        Description = "Create a new order item in the system",
        OperationId = "CreateOrderItem")]
    [SwaggerResponse(StatusCodes.Status201Created, "The order item was created", typeof(OrderItemResource))]
    public async Task<IActionResult> CreateProduct([FromBody] CreateOrderItemResource resource)
    {
        var createOrderItemCommand = CreateOrderItemCommandFromResourceAssembler.ToCommandFromResource(resource);
        var orderItem = await orderItemCommandService.Handle(createOrderItemCommand);
        if (orderItem is null) return BadRequest();
        var orderItemResource = OrderItemResourceFromEntityAssembler.ToResourceFromEntity(orderItem);
        return CreatedAtAction(nameof(GetOrderItemById), new { orderItemId = orderItem.Id }, orderItemResource);
    }
    
    [HttpGet("{orderItemId:int}")]
    [SwaggerOperation (
        Summary = "Get order item by id",
        Description = "Get an order item by its id",
        OperationId = "GetOrderItemById")]
    [SwaggerResponse(StatusCodes.Status200OK, "The order item was found", typeof(OrderItemResource))]
    public async Task<IActionResult> GetOrderItemById([FromRoute] int orderItemId)
    {
        var getOrderItemByIdQuery = new GetOrderItemByIdQuery(orderItemId);
        var orderItem = await orderItemQueryService.Handle(getOrderItemByIdQuery);
        if (orderItem is null) return NotFound();
        var orderItemResource = OrderItemResourceFromEntityAssembler.ToResourceFromEntity(orderItem);
        return Ok(orderItemResource);
    }
}