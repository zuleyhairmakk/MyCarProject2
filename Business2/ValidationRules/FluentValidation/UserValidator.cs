using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business2.ValidationRules
{
  public   class UserValidator: AbstractValidator<Users>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName).NotEmpty();
            RuleFor(u => u.LastName).NotEmpty();
            RuleFor(u => u.Password).NotEmpty();
            RuleFor(u => u.Password).Length(8);
            RuleFor(u => u.Password).Must(ContainsNumber);
            RuleFor(u => u.Password).Must(ContainsScript);
            RuleFor(u => u.Email).NotEmpty();



        }

        private bool ContainsScript(string arg)
        {
            return arg.Contains("A");
        }

        private bool ContainsNumber(string arg)
        {
            return arg.Contains("1");
        }
    }
}
