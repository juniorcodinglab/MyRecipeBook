using AutoMapper;
using MyRecipeBook.Communication.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipeBook.Application.Services.AutoMapper;
public class AutoMapping : Profile
{
    public AutoMapping()
    {
        RequestToDomain();
    }

    private void RequestToDomain()
    {
        CreateMap<RequestRegisterUserJson, Domain.Entites.User>()
            .ForMember(dest => dest.Password, opt => opt.Ignore()); // ignorando a propriedade password para o destino
    }
}
