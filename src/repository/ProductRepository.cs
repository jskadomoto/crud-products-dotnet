public class ProductRepository
{
  public List<Product> Products { get; set; } = new List<Product>();

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

public class ProductCreationResult
{
  public Product Product { get; set; }
  public string Message { get; set; }
  public int StatusCode { get; set; }

  public ProductCreationResult(Product product, string message, int statusCode)
  {
    Product = product;
    Message = message;
    StatusCode = statusCode;
  }
}