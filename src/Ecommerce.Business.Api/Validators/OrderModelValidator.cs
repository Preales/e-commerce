using Ecommerce.Business.Api.Models;
using FluentValidation;

namespace Ecommerce.Business.Api.Validators
{
    public class OrderModelValidator : AbstractValidator<OrderModel>
    {
        public OrderModelValidator()
        {
            RuleFor(x => x.ClientId)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3)
                .MaximumLength(20);

            RuleFor(x => x.ShippingId)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.DiscountTotal)
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.AmountTotal)
                .GreaterThan(0);
        }
    }

    public class OrderUpdateModelValidator : AbstractValidator<OrderUpdateModel>
    {
        public OrderUpdateModelValidator()
        {
            Include(new OrderModelValidator());

            RuleFor(x => x.Id)
                .NotEmpty()
                .NotNull();
        }
    }
}