using EmployeeManagerRazor.Abstractions.Repositories;
using EmployeeManagerRazor.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagerRazor.Web;
public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContextPool<ApplicationDbContext>(option =>
        {
            option.UseSqlServer(Configuration.GetConnectionString("MsDbConnectionString"));
        });
        services.AddRazorPages();
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();

        services.Configure<RouteOptions>(options =>
        {
            options.LowercaseUrls = true;
        });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapRazorPages();
        });
    }
}
