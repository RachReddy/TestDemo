using  InstrumentsApi.Repository;
using InstrumentsApi.Repositories;
using InstrumentsApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//WRONG builder.Services.AddControllers(); => S in services should be caps

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();  // ← add this
builder.Services.AddSwaggerGen();             // ← add this

// Register existing instruments repo
builder.Services.AddSingleton<InstrumentRepository>();

// Register order dependencies // DI setup
builder.Services.AddSingleton<IOrderRepository, OrderRepository>();
builder.Services.AddSingleton<IOrderService, OrderService>();


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();                             // ← add this
app.UseSwaggerUI();                           // ← add this

app.MapControllers();
app.Run();



