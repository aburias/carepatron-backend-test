using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.Clients.Commands.CreateClient
{
    public class CreateClientValidator : AbstractValidator<CreateClientCommand>
    {
        public CreateClientValidator()
        {
            RuleFor(c => c.Email).NotEmpty().NotNull().EmailAddress().WithMessage("Invalid email address.");
            RuleFor(c => c.Id).NotEmpty().NotNull().WithMessage("Id is required");
            RuleFor(c => c.FirstName).NotEmpty().NotNull().WithMessage("First Name is required.");
            RuleFor(c => c.LastName).NotEmpty().NotNull().WithMessage("Last Name is required.");
            RuleFor(c => c.PhoneNumber).NotEmpty().NotNull().WithMessage("Phone Number is required.");
        }
    }
}
