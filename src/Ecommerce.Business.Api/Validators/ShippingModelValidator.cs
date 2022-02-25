using Ecommerce.Business.Api.Models;
using FluentValidation;

namespace Ecommerce.Business.Api.Validators
{
    public class ShippingModelValidator : AbstractValidator<ShippingModel>
    {
        public ShippingModelValidator()
        {
            RuleFor(x => x.ClientId)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3)
                .MaximumLength(20);

            RuleFor(x => x.Country)
                .NotEmpty()
                .NotNull()
                .MinimumLength(2)
                .MaximumLength(100);

            RuleFor(x => x.Department)
                .NotEmpty()
                .NotNull()
                .MinimumLength(2)
                .MaximumLength(100);

            RuleFor(x => x.City)
                .NotEmpty()
                .NotNull()
                .MinimumLength(2)
                .MaximumLength(100);

            RuleFor(x => x.Address)
                .NotEmpty()
                .NotNull()
                .MinimumLength(2)
                .MaximumLength(254);
        }
    }

    public class ShippingUpdateModelValidator : AbstractValidator<ShippingUpdateModel>
    {
        public ShippingUpdateModelValidator()
        {
            Include(new ShippingModelValidator());

            RuleFor(x => x.Id)
                .NotEmpty()
                .NotNull();
        }
    }
}