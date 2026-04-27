using FluentValidation;
using OnlineShopBlazor.Models.ViewModels;
using OnlineShopBlazor.Models.Db;


using OnlineShopBlazor.Models.Db;

namespace OnlineShopBlazor.Models.Validations
{
    public class RecoveryValidator : AbstractValidator<RecoveryViewModel>
    {
        public RecoveryValidator()
        {

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Please enter your email address.")
                .EmailAddress().WithMessage("Please enter a valid email address.")
                .MaximumLength(50).WithMessage("Email cannot be longer than 50 characters.");
        }
    }
}
