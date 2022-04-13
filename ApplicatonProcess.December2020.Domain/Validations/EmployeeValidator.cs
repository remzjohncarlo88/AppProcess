using FluentValidation;
using FluentValidation.Results;
using ApplicatonProcess.December2020.Domain.Models;

namespace ApplicatonProcess.December2020.Domain.Validations
{
    class EmployeeValidator : AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            //var _restClient = new RestClient();

            RuleFor(m => m.Id).NotNull();

            RuleFor(m => m.Name).MinimumLength(5).WithMessage("Name must be at least 5 characters.");

            RuleFor(m => m.FamilyName).MinimumLength(5).WithMessage("Family Name must be at least 5 characters.");

            RuleFor(m => m.Address).MinimumLength(10).WithMessage("Address must be at least 10 characters.");

            //RuleFor(m => m.CountryOfOrigin).MustAsync(async (country, cancellation) => (await _restClient.GetAsync($"https://restcountries.eu/rest/v2/name/{country}?fullText=true")).IsSuccessStatusCode).WithMessage("Country name is not valid.");

            RuleFor(x => x.EmailAddress).EmailAddress().NotNull().WithMessage("Email must be valid e-email address.");

            RuleFor(x => x.Age).InclusiveBetween(20, 60).WithMessage("Age must be between 20 to 60.");

            RuleFor(x => x.Hired).NotNull().WithMessage("Hired property must not be empty.");
        }

        protected override bool PreValidate(ValidationContext<Employee> context, ValidationResult result)
        {
            if (context.InstanceToValidate == null)
            {
                result.Errors.Add(new ValidationFailure("", "Error 400."));

                return false;
            }
            return true;
        }
    }
}
