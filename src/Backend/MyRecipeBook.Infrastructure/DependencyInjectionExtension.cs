using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyRecipeBook.Domain.Enums;
using MyRecipeBook.Domain.Repositories;
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
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var databaseType = configuration.GetConnectionString("DatabaseType");
        var databaseTypeEnum = (DatabaseType)Enum.Parse(typeof(DatabaseType), databaseType);

        if (databaseTypeEnum == DatabaseType.MySql)
        {
            AddDbContext_MySQLServer(services, configuration);
        }
        else
        {
            AddDbContext_SQLServer(services, configuration);
        }

        AddRepositories(services);
    }
    private static void AddDbContext_MySQLServer(this IServiceCollection services, IConfiguration configuration)
    {
        throw new NotImplementedException();
    }

    private static void AddDbContext_SQLServer(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("ConnectionSQLServer");

        services.AddDbContext<MyRecipeBookDbContext>(DbContextOptions =>
        {
            DbContextOptions.UseSqlServer(connectionString);
        });
    }

    private static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IUserWriteOnlyRepository, UserRepository>();
        services.AddScoped<IUserReadOnlyRepository, UserRepository>();
    }
}

