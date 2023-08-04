using Microsoft.EntityFrameworkCore;
using TestWebApp.Application.Services;
using TestWebApp.Application.Services.Interfaces;
using TestWebApp.Data.Contexts;
using TestWebApp.Data.Repositories;
using TestWebApp.Data.Repositories.Interfaces;
using TestWebApp.Domain.PostgresEF;
using TestWebApp.Domain.Requests;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;

    }
    
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<PostgresContext>(options =>
            options.UseNpgsql(Configuration.GetConnectionString("DbConnectionString")));
        services.AddScoped<ICompanyService, CompanyService>();
        services.AddScoped<IEmployeeService, EmployeeService>();
        //services.AddScoped(typeof(IEntityRepository<>), typeof(IEntityRepository<>));
        services.AddScoped<IEntityRepository<Employee>, EntityRepository<Employee>>();
        services.AddScoped<IEntityRepository<Company>, EntityRepository<Company>>();
        services.AddScoped<IEntityRepository<SystemLog>, EntityRepository<SystemLog>>();

    }

    public void ConfigureEnpoints(WebApplication app)
    {
        app.MapPost("/api/employees", async (CreateNewEmployeeRequest request,
            IEmployeeService employeeService, CancellationToken cancellationToken) =>
        {
            await employeeService.CreateNewEmployeeAsync(request, cancellationToken);
            return Results.Ok();
        });
        
        app.MapPost("/api/companies", async (CreateNewCompanyRequest request,
            ICompanyService companyService, CancellationToken cancellationToken) =>
        {
            await companyService.CreateNewCompanyAsync(request, cancellationToken);
            return Results.Ok();
        });
    }

    public void Configure(WebApplication app, IWebHostEnvironment env) {
        app.UseHttpsRedirection();
        app.UseRouting();
        app.Run();
    }
}

