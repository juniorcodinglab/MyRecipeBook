using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyRecipeBook.Application.Services.AutoMapper;
using MyRecipeBook.Application.Services.Cryptography;
using MyRecipeBook.Application.UseCases.User.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MyRecipeBook.Application;

public static class DependencyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        AddAutoMapper(services);
        AddUseCases(services);
        AddPasswordEncrpter(services, configuration);
    }

    private static void AddAutoMapper(IServiceCollection services)
    {
        services.AddScoped(option => new AutoMapper.MapperConfiguration(
            options => options.AddProfile(new AutoMapping())
        ).CreateMapper());
    }

    /* Quando alguém solicitar essa interface, irá devolver uma instância da classe */
    private static void AddUseCases(IServiceCollection services)
    {
        services.AddScoped<IRegisterUserUseCase, RegisterUserUseCase>();
    }

    /* Quando alguém solicitar essa interface, irá devolver uma instância da classe */
    private static void AddPasswordEncrpter(IServiceCollection services, IConfiguration configuration)
    {
        var additionalKey = configuration.GetSection("Settings:Password:AdditionalKey").Value;
        services.AddScoped(options => new PassswordEncripter(additionalKey!));
    }
}
