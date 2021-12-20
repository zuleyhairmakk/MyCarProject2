using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business2.ValidationRules.FluentValidation
{
  public   class CarImagesValidator: AbstractValidator<CarImages>
    {
        public CarImagesValidator()
        {
            RuleFor(c => c.CarId).NotEmpty();
        }
    }
}
