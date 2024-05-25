using CommonLibrary.ValidationServices;
using FluentValidation;
using ModelsLibrary.Models.RequestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinessLayer.BusinessServices.Validation
{
    public class SignupValidator : AbstractValidator<SignupRequest>
    {
        public string nameRegex = @"^[A-Z]{1}[a-z]{2}[a-z]*$";
        public SignupValidator() 
        {
            RuleFor(x=>x.FirstName).Must(name=> !string.IsNullOrEmpty(name))
                .WithErrorCode(ValidationMessages.GetExternalCode(ValidationMessages.FirstNameEmptyOrNull).ToString())
                .WithMessage(ValidationMessages.GetExternalMessage(ValidationMessages.FirstNameEmptyOrNull));
            RuleFor(x => x.FirstName).Must(name => Regex.IsMatch(name, nameRegex))
                .WithErrorCode(ValidationMessages.GetExternalCode(ValidationMessages.FirstNameMinimum).ToString())
                .WithMessage(ValidationMessages.GetExternalMessage(ValidationMessages.FirstNameMinimum));
        }
    }
}
