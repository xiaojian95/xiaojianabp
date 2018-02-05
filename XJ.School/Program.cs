using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using XJ.School.EntityFramework;
using XJ.School.EntityFramework.Data;

namespace XJ.School
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);

            using (var scope=host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    
                    var context = services.GetRequiredService<SchoolDbContext>();


                    DataInitializer.Initializer(context);
                }
                catch (Exception ex)
                {
                    //初始化系统测试数据的时候报错，请联系管理员

                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError("初始化系统测试数据的时候报错，请联系管理员。");
                }
            }

            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
