public class ProductRepository
{
  private static ProductRepository? _instance;
  public List<Product> Products { get; set; }

  private ProductRepository()
  {
    Products = new List<Product>();
  }

  public static ProductRepository Instance
  {
    get
    {
      if (_instance == null)
      {
        _instance = new ProductRepository();
      }
      return _instance;
    }
  }

  public void Add(Product product)
  {
    Products.Add(product);
  }

  public Product? GetBy(int id)
  {
    return Products.FirstOrDefault(p => p.Id == id);
  }
  

  public static void Remove(Product product)
  {
    Instance.Products.Remove(product);
  }
}
