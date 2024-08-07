/* Vars */
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApplicationDBContext>();
var app = builder.Build();

/* Endopoints */
/* GET */
app.MapGet("/", () => "Hello World!");
/* By Query Params */
app.MapGet("/products", ([FromQuery] string code) =>
{
  var product = ProductService.GetProductByCode(code);
  return product;
});
/* By Route */
app.MapGet("/products/{code}", ([FromRoute] string code) =>
{
  var product = ProductService.GetProductByCode(code);
  return product;
});

/* POST */
app.MapPost("/products", (Product product) => ProductService.CreateProduct(product));

/* PUT */
app.MapPut("/products", (Product product) => ProductService.UpdateProduct(product));

/* DELETE */
/* By Route */
app.MapDelete("/products/{code}", ([FromRoute] string code) => ProductService.DeleteProduct(code));

/* By Query */
app.MapDelete("/products", ([FromQuery] string code) => ProductService.DeleteProduct(code));

app.Run();
