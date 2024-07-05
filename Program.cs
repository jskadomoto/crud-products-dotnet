/* Vars */
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

/* Endopoints */
app.MapGet("/", () => "Hello World!");
app.MapPost("/create-product", (Product product) => ProductService.createProduct(product));
app.Run();
