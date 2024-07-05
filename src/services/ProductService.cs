public static class ProductService
{
  public static string createProduct(Product product)
{
  return product.Code + " - " + product.Name;
}
}