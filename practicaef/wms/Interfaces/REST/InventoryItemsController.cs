using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using practicaef.wms.Domain.Model.Queries;
using practicaef.wms.Domain.Services;
using practicaef.wms.Interfaces.REST.Resources;
using practicaef.wms.Interfaces.REST.Transform;
using Swashbuckle.AspNetCore.Annotations;

namespace practicaef.wms.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Inventory Items")]
public class InventoryItemsController(
    IInventoryItemCommandService inventoryItemCommandService,
    IInventoryItemQueryService inventoryItemQueryService
) : ControllerBase
{
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a new inventory item",
        Description = "Create a new inventory item in the system",
        OperationId = "CreateInventoryItem"
    )]
    [SwaggerResponse(StatusCodes.Status201Created, "The inventory item was created", typeof(InventoryItemResource))]
    public async Task<IActionResult> CreateInventoryItem([FromBody] CreateInventoryItemResource resource)
    {
        var createInventoryItemCommand = CreateInventoryItemCommandFromResourceAssembler.ToCommandFromResource(resource);
        var inventoryItem = await inventoryItemCommandService.Handle(createInventoryItemCommand);
        if (inventoryItem is null) return BadRequest();
        var inventoryItemResource = InventoryItemResourceFromEntityAssembler.ToResourceFromEntity(inventoryItem);
        return CreatedAtAction(nameof(GetInventoryItemById), new { inventoryItemId = inventoryItem.Id }, inventoryItemResource);
    }
    
    [HttpGet("{inventoryItemId:int}")]
    [SwaggerOperation (
        Summary = "Get inventory item by id",
        Description = "Get an inventory item by its id",
        OperationId = "GetInventoryItemById"
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "The inventory item was found", typeof(InventoryItemResource))]
    public async Task<IActionResult> GetInventoryItemById([FromRoute] int inventoryItemId)
    {
        var getInventoryItemByIdQuery = new GetInventoryItemByIdQuery(inventoryItemId);
        var inventoryItem = await inventoryItemQueryService.Handle(getInventoryItemByIdQuery);
        if (inventoryItem is null) return NotFound();
        var inventoryItemResource = InventoryItemResourceFromEntityAssembler.ToResourceFromEntity(inventoryItem);
        return Ok(inventoryItemResource);
    }
}