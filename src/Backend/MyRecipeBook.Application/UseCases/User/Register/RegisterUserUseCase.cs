using AutoMapper;
using MyRecipeBook.Application.Services.AutoMapper;
using MyRecipeBook.Application.Services.Cryptography;
using MyRecipeBook.Communication.Requests;
using MyRecipeBook.Communication.Responses;
using MyRecipeBook.Domain.Repositories.User;
using MyRecipeBook.Exceptions;
using MyRecipeBook.Exceptions.ExceptionsBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipeBook.Application.UseCases.User.Register;

public class RegisterUserUseCase : IRegisterUserUseCase
{
    private readonly IUserWriteOnlyRepository _writeOnlyRepository;
    private readonly IUserReadOnlyRepository _readOnlyRepository;
    private readonly IMapper _mapper;
    private readonly PassswordEncripter _passswordEncripter;

    public RegisterUserUseCase(
        IUserWriteOnlyRepository writeOnlyRepository, 
        IUserReadOnlyRepository readOnlyRepository, 
        PassswordEncripter passswordEncripter,
        IMapper mapper)
    {
        _writeOnlyRepository = writeOnlyRepository;
        _readOnlyRepository = readOnlyRepository;
        _mapper = mapper;
        _passswordEncripter = passswordEncripter;
    }
    public async Task<ResponseRegisterUserJson> Execute(RequestRegisterUserJson request)
    {
        Validate(request);

        var user = _mapper.Map<Domain.Entites.User>(request);
        user.Password = _passswordEncripter.Encrypt(request.Password);

        await _writeOnlyRepository.Add(user);

        return new ResponseRegisterUserJson
        {
            Name = request.Name,
        };
    }

    private void Validate(RequestRegisterUserJson request)
    {
        var validator = new RegisterUserValidator();
        var result = validator.Validate(request);

        if(!result.IsValid )
        {
            var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}

