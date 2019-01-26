using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureKeyVault;

namespace iot_rynningeasen_www
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, builder) =>
                {
                    var config = builder.Build();
                    var azureServiceToken = new AzureServiceTokenProvider();
                    var keyVaultClient = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(azureServiceToken.KeyVaultTokenCallback));

                    builder.AddAzureKeyVault(config["Azure:KeyVaultEndpoint"], keyVaultClient, new DefaultKeyVaultSecretManager());
                })
                .UseStartup<Startup>();
    }
}