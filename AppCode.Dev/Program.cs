using Microsoft.AspNetCore.Hosting;

namespace AppCode.Dev
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            AppCode.Program.CreateWebHostBuilder(args)
                .UseStartup<DevStartup>();
    }
}