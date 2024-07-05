public class ProductRepository
{
  public List<Product>? Products { get; set; }

  public void Add(Product product)
  {
    if (Products == null)
      Products = new List<Product>();

    Products.Add(product);
  }

  public ProductResult GetBy(string code)
  {
    if (Products != null)
    {
      var product = Products.FirstOrDefault(p => p.Code == code);
      if (product != null)
      {
        return new ProductResult(product, "Produto encontrado");
      }
    }

    return new ProductResult(null, "Produto não encontrado");
  }
}
