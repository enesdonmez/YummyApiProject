using Microsoft.Extensions.DependencyInjection;

namespace Yummy.AdminUI;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
        builder.Services.AddHttpClient("YummyApi", client =>
        {
            client.BaseAddress = new Uri(builder.Configuration.GetSection("ApiUrl").Value);
        });

        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseRouting();

        app.UseAuthorization();

        app.MapStaticAssets();
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}")
            .WithStaticAssets();

        app.Run();
    }
}
