using Serilog;
using Serilog.Events;
using Serilog.Formatting.Compact;

namespace SerilogDemoApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Create a builder first to access configuration
            var builder = WebApplication.CreateBuilder(args);

            // Configure Serilog to read settings from appsettings.json
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Configuration)  // Correctly access appsettings.json
                .CreateLogger();

            try
            {
                builder.Host.UseSerilog(); // Integrate Serilog with ASP.NET Core logging

                // Add services to the container
                builder.Services.AddControllersWithViews();

                var app = builder.Build();

                // Configure the HTTP request pipeline
                if (!app.Environment.IsDevelopment())
                {
                    app.UseExceptionHandler("/Home/Error");
                    app.UseHsts();
                }

                app.UseHttpsRedirection();
                app.UseStaticFiles();
                app.UseRouting();
                app.UseAuthorization();

                app.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                app.Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Application failed to start");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}