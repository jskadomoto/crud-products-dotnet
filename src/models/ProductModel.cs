
/* Classes  */
public class Product
{
  public int Id { get; set; }
  public required string Code { get; set; }
  public required string Name { get; set; }
  public string? Description { get; set; }
  public int CategoryId { get; set; }
  public required Category Category { get; set; }

  public List<Tag>? Tags { get; set; }
}


public class SingleProductResult
{
  public Product? Product { get; set; }
  public string Message { get; set; }

  public SingleProductResult(Product? product, string message)
  {
    Product = product;
    Message = message;
  }
}
public class ProductResults
{
  public List<Product>? Product { get; set; }
  public string? Message { get; set; }
  public int Page { get; set; }
  public int Limit { get; set; }
  public int PageCount { get; set; }
  public int TotalResults { get; set; }

  public ProductResults(List<Product>? product, string? message, int page, int limit, int pageCount, int totalResults)
  {
    Product = product;
    Message = message;
    Page = page;
    Limit = limit;
    PageCount = pageCount;
    TotalResults = totalResults;
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