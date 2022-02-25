using Ecommerce.Business.Api.Models;
using FluentValidation;

namespace Ecommerce.Business.Api.Validators
{
    public class OrderRequestModelValidator : AbstractValidator<OrderRequestModel>
    {
        public OrderRequestModelValidator()
        {
            RuleFor(x => x.ClientId)
               .NotEmpty()
               .NotNull()
               .MinimumLength(3)
               .MaximumLength(20);

            RuleFor(x => x.ShippingId)
                .NotNull()
                .NotEmpty();

            RuleForEach(detail => detail.OrderDetails).SetValidator(new OrderDetailRequestModelValidator());
        }
    }
}
