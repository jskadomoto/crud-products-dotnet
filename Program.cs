/* Vars */
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSqlServer<ApplicationDBContext>(builder.Configuration["Database:SqlServer"]);
var app = builder.Build();

/* Endopoints */
/* GET */
app.MapGet("/", () => "Hello World!");
/* By Query Params */
app.MapGet("/products", ([FromQuery] int id, ApplicationDBContext context) =>
{
  var product = ProductService.GetProductById(id, context);
  return product;
});
/* By Route */
app.MapGet("/products/{id}", ([FromRoute] int id, ApplicationDBContext context) =>
{
  var product = ProductService.GetProductById(id, context);
  return product;
});

/* POST */
app.MapPost("/products", (ProductRequest productRequest, ApplicationDBContext context) => ProductService.CreateProduct(productRequest, context));

/* PUT */
app.MapPut("/products", (Product product) => ProductService.UpdateProduct(product));

/* DELETE */
/* By Route */
app.MapDelete("/products/{id}", ([FromRoute] int id) => ProductService.DeleteProduct(id));

/* By Query */
app.MapDelete("/products", ([FromQuery] int id) => ProductService.DeleteProduct(id));

app.Run();
