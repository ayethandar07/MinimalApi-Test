using MinimalApiTest;
using MinimalApiTest.Model;
using MinimalApiTest.Repository;
using MinimalApiTest.Service;

var builder = WebApplication.CreateBuilder(args);

// Register services
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapProductEndpoints();

app.Run();
