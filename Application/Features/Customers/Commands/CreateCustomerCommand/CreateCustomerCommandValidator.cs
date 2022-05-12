using FluentValidation;

namespace Application.Features.Customers.Commands.CreateCustomerCommand
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} can not be empty.")
                .MaximumLength(80).WithMessage("{PropertyName} can not exceed {MaxLength} characters.");
            
            RuleFor(p => p.LastName)
                .NotEmpty().WithMessage("{PropertyName} can not be empty.")
                .MaximumLength(80).WithMessage("{PropertyName} can not exceed {MaxLength} characters.");

            RuleFor(p => p.BirthDate)
                .NotEmpty().WithMessage("{PropertyName} can not be empty.");
            
            RuleFor(p => p.PhoneNumber)
                .NotEmpty().WithMessage("{PropertyName} can not be empty.")
                .Matches(@"^(?:6[0-9]{2}|7[1-9][0-9])(?: ?[0-9]{3}){2}\r?$").WithMessage("{PropertyName} is not in spain format")
                .MaximumLength(9).WithMessage("{PropertyName} can not exceed {MaxLength} characters.");

            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("{PropertyName} can not be empty.")
                .EmailAddress().WithMessage("Invalid email.")
                .MaximumLength(100).WithMessage("{PropertyName} can not exceed {MaxLength} characters.");

            RuleFor(p => p.Address)
                .NotEmpty().WithMessage("{PropertyName} can not be empty.")
                .MaximumLength(120).WithMessage("{PropertyName} can not exceed {MaxLength} characters.");
        }
    }
}
