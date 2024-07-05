public static class ProductService
{
  public static ProductCreationResult CreateProduct(Product product)
  {
    ProductRepository.Instance.Add(product);
    return new ProductCreationResult(product, "Produto adicionado com sucesso", 200);
  }
}
