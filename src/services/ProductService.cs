
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
    return Results.Created($"/products/{product.Code}", new ProductCreationResult(product, $"Produto: '{product.Name}' adicionado com sucesso", 201));
  }

  public static IResult GetProductByCode(string code)
  {
    var product = ProductRepository.Instance.GetBy(code);
    if (product != null)
      return Results.Ok(new ProductResult(product, "Produto encontrado"));

    return Results.NotFound(new ProductResult(null, "Não encontrado"));
  }

  public static IResult UpdateProduct(Product product)
  {
    var productSaved = ProductRepository.Instance.GetBy(product.Code);
    if (productSaved != null)
    {
      productSaved.Name = product.Name;
      return Results.Ok(new ProductCreationResult(product, "Produto atualizado com sucesso", 200));
    }
    return Results.NotFound();
  }

  public static IResult DeleteProduct(string code)
  {
    var product = ProductRepository.Instance.GetBy(code);
    if (product != null)
    {
      ProductRepository.Remove(product);
      return Results.Ok(new ProductDeleteResult($"Produto: {product.Name} deletado com sucesso", 200));
    }
    return Results.NotFound(new ProductDeleteResult("Produto não encontrado", 404));
  }

  internal static object CreateProduct(Product product)
  {
    throw new NotImplementedException();
  }
}