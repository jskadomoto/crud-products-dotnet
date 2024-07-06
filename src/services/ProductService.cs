public static class ProductService
{
  public static ProductCreationResult CreateProduct(Product product)
  {
    ProductRepository.Instance.Add(product);
    return new ProductCreationResult(product, "Produto adicionado com sucesso", 200);
  }
  public static ProductCreationResult UpdateProduct(Product product)
  {
    var productSaved = ProductRepository.Instance.GetBy(product.Code);
    if (productSaved.Product != null)
    {
      productSaved.Product.Name = product.Name;
    }
    return new ProductCreationResult(product, "Produto atualizado com sucesso", 200);
  }

  public static ProductDeleteResult DeleteProduct(string code)
  {
    var findProduct = ProductRepository.Instance.GetBy(code);
    if (findProduct.Product != null)
    {
      ProductRepository.Remove(findProduct.Product);
      return new ProductDeleteResult($"Produto {findProduct.Product.Name} deletado com sucesso", 200);
    }
    return new ProductDeleteResult("Produto não encontrado", 404);
  }
}
