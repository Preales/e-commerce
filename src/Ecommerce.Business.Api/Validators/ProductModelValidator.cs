using Ecommerce.Business.Api.Models;
using FluentValidation;

namespace Ecommerce.Business.Api.Validators
{
    public class ProductModelValidator : AbstractValidator<ProductModel>
    {
        public ProductModelValidator()
        {
            RuleFor(x => x.Description)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3)
                .MaximumLength(60);

            RuleFor(x => x.Price)
                .GreaterThan(0);

            RuleFor(x => x.Tax)
                .GreaterThanOrEqualTo(0)
                .LessThanOrEqualTo(100);
        }
    }

    public class ProductUpdateModelValidator : AbstractValidator<ProductUpdateModel>
    {
        public ProductUpdateModelValidator()
        {
            Include(new ProductModelValidator());

            RuleFor(x => x.Id)
                .NotEqual(0);
        }
    }
}