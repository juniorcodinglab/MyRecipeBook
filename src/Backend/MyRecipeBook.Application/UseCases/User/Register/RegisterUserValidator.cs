using FluentValidation;
using MyRecipeBook.Communication.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyRecipeBook.Exceptions;

namespace MyRecipeBook.Application.UseCases.User.Register;

public class RegisterUserValidator : AbstractValidator<RequestRegisterUserJson>
{
    public RegisterUserValidator()
    {
        RuleFor(user => user.Name).NotEmpty().WithMessage(ResourceMessagesException.NAME_EMPTY);
        RuleFor(user => user.Email).NotEmpty().WithMessage(ResourceMessagesException.EMAIL_EMPTY);
        RuleFor(user => user.Email).EmailAddress().WithMessage(ResourceMessagesException.EMAIL_INVALID);
        RuleFor(user => user.Password.Length).GreaterThanOrEqualTo(6).WithMessage(ResourceMessagesException.PASSWORD_EMPTY);
    }
}

