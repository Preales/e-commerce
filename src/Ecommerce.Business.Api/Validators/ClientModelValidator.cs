using Ecommerce.Business.Api.Models;
using FluentValidation;

namespace Ecommerce.Business.Api.Validators
{
    public class ClientModelValidator : AbstractValidator<ClientModel>
    {
        public ClientModelValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3)
                .MaximumLength(20);

            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3)
                .MaximumLength(100);

            RuleFor(x => x.LastName)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3)
                .MaximumLength(100);

            RuleFor(x => x.Telephone)
              .NotEmpty()
              .NotNull()
              .MinimumLength(1)
              .MaximumLength(60);

            RuleFor(x => x.Email)
              .NotEmpty()
              .NotNull()
              .EmailAddress()
              .MinimumLength(10)
              .MaximumLength(254);
        }
    }
}