/* Vars */
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSqlServer<ApplicationDBContext>(builder.Configuration["Database:SqlServer"]);
var app = builder.Build();

/* Endopoints */
/* GET */
app.MapGet("/", () => "Hello World!");
/* By Query Params */
app.MapGet("/products", ([FromQuery] int? id, ApplicationDBContext context) =>
{
  if (id == null || id == 0)
  {
    return ProductService.GetProducts(context);
  }

  return ProductService.GetProductById(id.Value, context);
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
app.MapPut("/products/{id}", ([FromRoute] int id, ProductRequest productRequest, ApplicationDBContext context) => ProductService.UpdateProduct(id, productRequest, context));

/* DELETE */
/* By Route */
app.MapDelete("/products/{id}", ([FromRoute] int id, ApplicationDBContext context) => ProductService.DeleteProduct(id, context));

/* By Query */
app.MapDelete("/products", ([FromQuery] int id, ApplicationDBContext context) => ProductService.DeleteProduct(id, context));

app.Run();
