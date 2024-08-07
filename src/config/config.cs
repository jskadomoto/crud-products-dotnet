using Microsoft.Extensions.Configuration;
using System;

public static class Config
{
  public static IConfigurationRoot Configuration { get; }

  static Config()
  {

    Configuration = new ConfigurationBuilder().SetBasePath
    (AppContext.BaseDirectory).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true).AddEnvironmentVariables().Build();
  }
  public static string GetConnectionString(string name) => Configuration.GetConnectionString(name);
}