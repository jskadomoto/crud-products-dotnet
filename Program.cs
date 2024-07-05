/* Vars */
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

/* Endopoints */
app.MapGet("/", () => "Hello World!");
app.MapPost("/create-product", (Product product) => ProductService.CreateProduct(product));
/* By Query Params */
app.MapGet("/get-product", ([FromQuery] string code) =>
{
  var product = ProductRepository.Instance.GetBy(code);
  return product;
});
/* By Route */
app.MapGet("/get-product/{code}", ([FromRoute] string code) =>
{
  var product = ProductRepository.Instance.GetBy(code);
  return product;
});
/* By Headers */
app.MapGet("/get-product-header", (HttpRequest request) =>
{
  return request.Headers["product-code"].ToString();
});
app.Run();
