/* Vars */
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

/* Endopoints */
app.MapGet("/", () => "Hello World!");
app.MapPost("/create-product", (Product product) => {
  return product.Code + " - " + product.Name;
});
app.Run();

/* Classes  */
public class Product {
  public required string Code { get; set; }
  public required string Name { get; set; }
}