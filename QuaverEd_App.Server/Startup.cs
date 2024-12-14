
//using Microsoft.AspNetCore.Identity;
//using Microsoft.EntityFrameworkCore;
//using QuaverEd_App.Data;
//public class Startup
//{
//    public void ConfigureServices(IServiceCollection services)
//    {
//        var connectionString = "server=localhost;user=root;password=Harriet21;database=ef";

//        var serverVersion = new MySqlServerVersion(new Version(8, 0, 40));

//        services.AddDbContext<QuaverEd_AppDbContext>(
//            dbContextOptions => dbContextOptions
//                .UseMySql(connectionString, serverVersion)
//                // The following three options help with debugging, but should
//                // be changed or removed for production.
//                .LogTo(Console.WriteLine, LogLevel.Information)
//                .EnableSensitiveDataLogging()
//                .EnableDetailedErrors()
//        );

//    }

//}