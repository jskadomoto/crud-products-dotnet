
/* Classes  */
public class Product
{
  public int Id { get; set; }
  public required string Code { get; set; }
  public required string Name { get; set; }
  public string? Description { get; set; }
  public required Category Category { get; set; }
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


public class ProductDeleteResult
{
  public string Message { get; set; }
  public int StatusCode { get; set; }

  public ProductDeleteResult(string message, int statusCode)
  {
    Message = message;
    StatusCode = statusCode;
  }
}