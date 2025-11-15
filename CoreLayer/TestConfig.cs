using Microsoft.Extensions.Configuration;

namespace CoreLayer
{
    public class TestConfig
    {
        public IConfigurationRoot Configuration { get; set; }

        public TestConfig()
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
        }
        public string GetApplicationLink()
        {
            return Configuration["ApplicationUrl"] ?? string.Empty;
        }
        public BrowserInfo GetBrowserInfo(string browserName)
        {
            var browserConfig = Configuration.GetSection("Browsers")
                                           .GetChildren()
                                           .FirstOrDefault(s => s["Name"] == browserName);

            if (browserConfig != null)
            {
                return new BrowserInfo
                {
                    Name = browserConfig["Name"]!,
                    Options = browserConfig["Options"]!
                };
            }
            else
            {
                return new BrowserInfo
                {
                    Name = string.Empty,
                    Options = string.Empty
                };
            }
        }
    }
    public class BrowserInfo
    {
        public string? Name { get; set; }
        public string? Options { get; set; }
    }
}
