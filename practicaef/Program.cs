using Microsoft.EntityFrameworkCore;
using practicaef.Shared.Domain.Repositories;
using practicaef.Shared.Infrastructure.Interfaces.ASP.Configuration;
using practicaef.Shared.Infrastructure.Persistence.EFC.Configuration;
using practicaef.Shared.Infrastructure.Persistence.EFC.Repositories;
using practicaef.sms.Application.Internal.CommandServices;
using practicaef.sms.Application.Internal.QueryServices;
using practicaef.sms.Domain.Repositories;
using practicaef.sms.Domain.Services;
using practicaef.sms.Infrastructure.Persistence.EFC.Repositories;
using practicaef.wms.Application.Internal.CommandServices;
using practicaef.wms.Application.Internal.QueryServices;
using practicaef.wms.Domain.Repositories;
using practicaef.wms.Domain.Services;
using practicaef.wms.Infrastructure.Persistence.EFC.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));

// Add Database Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (connectionString is null)
    throw new Exception("Connection string is null.");
builder.Services.AddDbContext<AppDbContext>(options =>
{
    if (builder.Environment.IsDevelopment())
        options.UseMySQL(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableDetailedErrors()
            .EnableSensitiveDataLogging();
    else if (builder.Environment.IsProduction())
        options.UseMySQL(connectionString);
});

// OpenAPI/Swagger Configuration
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => options.EnableAnnotations());

//Dependency Injection Configuration
//TODO:ADD DEPENDENCY INJECTION CONFIGURATION

//Shared Bounded Context Dependency Injection Configuration
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IOrderItemRepository, OrderItemRepository>();
builder.Services.AddScoped<IOrderItemQueryService, OrderItemQueryService>();
builder.Services.AddScoped<IOrderItemCommandService, OrderItemCommandService>();

builder.Services.AddScoped<IInventoryItemRepository, InventoryItemRepository>();
builder.Services.AddScoped<IInventoryItemQueryService, InventoryItemQueryService>();
builder.Services.AddScoped<IInventoryItemCommandService, InventoryItemCommandService>();

var app = builder.Build();

// Verify Database Objects are Created
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();