/* Vars */
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

/* Endopoints */
/* GET */
app.MapGet("/", () => "Hello World!");
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

/* POST */
app.MapPost("/create-product", (Product product) => ProductService.CreateProduct(product));

/* PUT */
app.MapPut("/update-product", (Product product) => ProductService.UpdateProduct(product));

/* DELETE */
app.MapDelete("/delete-product/{code}", ([FromRoute] string code) => ProductService.DeleteProduct(code));


app.Run();
