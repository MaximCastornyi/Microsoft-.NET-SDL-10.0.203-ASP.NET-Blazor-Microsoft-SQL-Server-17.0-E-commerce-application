using FluentValidation;

using OnlineShopBlazor.Models.Db;
using OnlineShopBlazor.Models.ViewModels;

namespace OnlineShopBlazor.Models.Validations
{
    public class ResetPasswordValidator : AbstractValidator<ResetPasswordViewModel>
    {
        public ResetPasswordValidator()
        {


            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Please enter your email address.")
                .EmailAddress().WithMessage("Please enter a valid email address.")
                .MaximumLength(50).WithMessage("Email cannot be longer than 50 characters.");

            RuleFor(x => x.NewPassword)
                .NotEmpty().WithMessage("Please enter a new password.")
                .MinimumLength(8).WithMessage("New password must be at least 8 characters long.")
                .MaximumLength(50).WithMessage("New password cannot be longer than 50 characters.");

            RuleFor(x => x.RecoveryCode)
                   .NotEmpty().WithMessage("Please enter a recovery code.");

        }
    }
}
