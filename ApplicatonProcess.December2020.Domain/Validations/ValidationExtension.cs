using FluentValidation.Results;
using ApplicatonProcess.December2020.Domain.Models;
using System.Collections.Generic;

namespace ApplicatonProcess.December2020.Domain.Validations
{
    public static class ValidationExtension
    {
        public static bool IsValid(this Employee employee, out IEnumerable<string> errors)
        {
            var validator = new EmployeeValidator();

            var validationResult = validator.Validate(employee);

            errors = AggregateErrors(validationResult);

            return validationResult.IsValid;
        }

        private static List<string> AggregateErrors(ValidationResult validationResult)
        {
            var errors = new List<string>();

            if (!validationResult.IsValid)
                foreach (var error in validationResult.Errors)
                    errors.Add(error.ErrorMessage);

            return errors;
        }
    }
}
