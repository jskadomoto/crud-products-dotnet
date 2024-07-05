
/* Classes  */
public class Product
{
  public required string Code { get; set; }
  public required string Name { get; set; }
}


public class ProductResult
{
  public Product? Product { get; set; }
  public string Message { get; set; }

  public ProductResult(Product? product, string message)
  {
    Product = product;
    Message = message;
  }
}
