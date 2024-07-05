public static class ProductService
{
  private static readonly ProductRepository repository = new ProductRepository();

  public static ProductCreationResult CreateProduct(Product product)
  {
    repository.Add(product);
    return new ProductCreationResult(product, "Produto adicionado com sucesso", 200);
  }
}
