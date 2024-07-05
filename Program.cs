/* Vars */
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

/* Endopoints */
app.MapGet("/", () => "Hello World!");
app.MapPost("/create-product", (Product product) => ProductService.createProduct(product));
/* By Query Params */
app.MapGet("/get-product", ([FromQuery] string id, [FromQuery] string name) =>
{
  return id + " - " + name;
});
/* By Route */
app.MapGet("/get-product/{id}/{name}", ([FromRoute] string id, [FromRoute] string name) =>
{
  return id + " - " + name;
});
/* By Headers */
app.MapGet("/get-product-header", (HttpRequest request) =>
{
  return request.Headers["product-code"].ToString();
});
app.Run();
