using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using TAApplicationPS4.Data;
using TAApplicationPS4.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;

namespace TAApplicationPS4
{   
    /// <summary>
    /// Gets a database context instance from the dependency injection container.
    /// Calls the TA_DB_Initializer.Intialize method.
    /// Disposes the context when the Initialize method compeletes.
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            CreateDbIfNotExists(host);
            CreateAndSeedUsersRolesDB(host);

            host.Run();
        }

        /// <summary>
        /// Creates a database if one does not exist.
        /// </summary>
        /// <param name="host"></param>
        private static void CreateDbIfNotExists(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<TA_DB>();
                    var usersRolesDB = services.GetRequiredService<TAUsersRolesDB>();
                    TA_DB_Initializer.Initialize(context, usersRolesDB);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred creating the DB.");
                }
            }
        }

        /// <summary>
        /// Creates the UsersRolesDB database and seeds it.
        /// </summary>
        /// <param name="host"></param>
        private static void CreateAndSeedUsersRolesDB(IHost host)
        {
            using(var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<TA_DB>();
                    var usersRolesDB = services.GetRequiredService<TAUsersRolesDB>();
                    UserManager<TAUser> um = services.GetRequiredService<UserManager<TAUser>>();
                    RoleManager<IdentityRole> rm = services.GetRequiredService<RoleManager<IdentityRole>>();
                    SeedUsersRolesDB.InitializeAsync(usersRolesDB, context, um, rm).Wait();
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred creating the DB.");
                }
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
