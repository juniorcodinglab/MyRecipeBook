using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyRecipeBook.Domain.Repositories.User;
using MyRecipeBook.Infrastructure.DataAccess;
using MyRecipeBook.Infrastructure.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipeBook.Infrastructure;

public static class DependencyInjectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        AddRepositories(services);
        AddDbContext(services);
    }
    private static void AddDbContext(this IServiceCollection services)
    {

        var connectionString = "Data Source=localhost;Initial Catalog=meulivrodereceitas;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;";

        services.AddDbContext<MyRecipeBookDbContext>(DbContextOptions =>
        {
            DbContextOptions.UseSqlServer(connectionString);
        });
    }


    private static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserWriteOnlyRepository, UserRepository>();
        services.AddScoped<IUserReadOnlyRepository, UserRepository>();
    }
}

