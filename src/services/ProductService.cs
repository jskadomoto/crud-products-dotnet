
using Microsoft.EntityFrameworkCore;

public static class ProductService
{
  public static IResult CreateProduct(ProductRequest productRequest, ApplicationDBContext context)
  {
    var category = context.Category.Where(category => category.Id == productRequest.categoryId).First();
    if (category == null)
    {
      return Results.BadRequest(new { Message = "Categoria não encontrada." });
    }

    var product = new Product
    {
      Code = productRequest.Code,
      Name = productRequest.Name,
      Description = productRequest.Description,
      Category = category
    };

    if (productRequest.Tags != null)
    {
      product.Tags = new List<Tag>();

      foreach (var item in productRequest.Tags)
      {
        product.Tags.Add(new Tag { Name = item });
      }
    }

    context.Products.Add(product);
    context.SaveChanges();
    return Results.Created($"/products/{product.Id}", new ProductCreationResult(product, $"Produto: '{product.Name}' adicionado com sucesso", 201));
  }

  public static IResult GetProductById(int id, ApplicationDBContext context)
  {
    var product = context
    .Products
    .Include(product => product.Category)
    .Include(product => product.Tags)
    .Where(product => product.Id == id).First();

    if (product != null)
      return Results.Ok(new SingleProductResult(product, "Produto encontrado"));

    return Results.NotFound(new SingleProductResult(null, "Não encontrado"));
  }

  public static IResult GetProducts(ApplicationDBContext context)
  {
    var products = context
    .Products
    .Include(product => product.Category)
    .Include(product => product.Tags)
    .ToList();

    if (products != null && products.Count > 0)
    {
      return Results.Ok(new ProductResults(products, "Produtos encontrados"));
    }
    return Results.NotFound(new SingleProductResult(null, "Nenhum produto encontrado"));
  }

  public static IResult UpdateProduct(int id, ProductRequest productRequest, ApplicationDBContext context)
  {
    var productSaved = context
    .Products
    .Include(product => product.Tags)
    .Where(product => product.Id == id).First();

    if (productSaved != null)
    {

      var category = context.Category.Where(category => category.Id == productRequest.categoryId).First();

      productSaved.Name = productRequest.Name;
      productSaved.Description = productRequest.Description;
      productSaved.Code = productRequest.Code;
      productSaved.Category = category;
      productSaved.Tags = new List<Tag>();
      if (productRequest.Tags != null)
      {
        productSaved.Tags = new List<Tag>();

        foreach (var item in productRequest.Tags)
        {
          productSaved.Tags.Add(new Tag { Name = item });
        }
      }

      context.SaveChanges();

      return Results.Ok(new ProductCreationResult(productSaved, "Produto atualizado com sucesso", 200));
    }

    return Results.NotFound();
  }

  public static IResult DeleteProduct(int id, ApplicationDBContext context)
  {
    var product = context.Products.Where(product => product.Id == id).First();

    if (product != null)
    {
      context.Products.Remove(product);
      context.SaveChanges();
      return Results.Ok(new ProductDeleteResult($"Produto: {product.Name} deletado com sucesso", 200));
    }

    return Results.NotFound(new ProductDeleteResult("Produto não encontrado", 404));
  }

  internal static object CreateProduct(Product product)
  {
    throw new NotImplementedException();
  }
}