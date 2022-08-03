using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace PlatformService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope
                    .ServiceProvider
                    .GetService<AppDbContext>());
            }
        }

        private static void SeedData(AppDbContext context)
        {
            if (!context.Platforms.Any())
            {
                Console.WriteLine("Seeding data");
                context
                    .Platforms
                    .AddRange(new Models.Platform()
                    { Name = "Data1", Publisher = "Microsoft", Cost = "Free" },
                    new Models.Platform()
                    { Name = "Data2", Publisher = "Microsoft", Cost = "Free" },
                    new Models.Platform()
                    { Name = "Data3", Publisher = "Microsoft", Cost = "Free" });
                
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Data is ready");
            }
        }
    }
}
