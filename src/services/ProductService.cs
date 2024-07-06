public static class ProductService
{
  public static IResult CreateProduct(Product product)
  {
    ProductRepository.Instance.Add(product);
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
}