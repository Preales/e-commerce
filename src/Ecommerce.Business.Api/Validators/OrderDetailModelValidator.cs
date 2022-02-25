using Ecommerce.Business.Api.Models;
using FluentValidation;

namespace Ecommerce.Business.Api.Validators
{
    public class OrderDetailModelValidator : AbstractValidator<OrderDetailModel>
    {
        public OrderDetailModelValidator()
        {
            RuleFor(x => x.OrderId)
                .NotEmpty()
                .NotNull();

            Include(new OrderDetailRequestModelValidator());
        }
    }

    public class OrderDetailRequestModelValidator : AbstractValidator<OrderDetailRequestModel>
    {
        public OrderDetailRequestModelValidator()
        {

            RuleFor(x => x.ProductId)
                .NotNull()
                .NotEqual(0);

            RuleFor(x => x.Price)
                .GreaterThan(0);

            RuleFor(x => x.Tax)
                .GreaterThanOrEqualTo(0)
                .LessThanOrEqualTo(100);

            RuleFor(x => x.Quantity)
                .GreaterThan(0);

            RuleFor(x => x.Discount)
                .GreaterThanOrEqualTo(0);
        }
    }

    public class OrderDetailUpdateModelValidator : AbstractValidator<OrderDetailUpdateModel>
    {
        public OrderDetailUpdateModelValidator()
        {
            Include(new OrderDetailModelValidator());

            RuleFor(x => x.Id)
                .NotEmpty()
                .NotNull();
        }
    }
}