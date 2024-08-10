public static class Config
{
  public static IConfigurationRoot Configuration { get; }

  static Config()
  {

    Configuration = new ConfigurationBuilder().SetBasePath
    (AppContext.BaseDirectory).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true).AddEnvironmentVariables().Build();
  }
  public static string GetConnectionString(string name)
  {
    return Configuration.GetConnectionString(name ?? "DefaultConnection")
           ?? throw new InvalidOperationException($"Connection string '{name ?? "DefaultConnection"}' not found.");
  }
}