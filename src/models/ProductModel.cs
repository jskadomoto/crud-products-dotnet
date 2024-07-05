
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