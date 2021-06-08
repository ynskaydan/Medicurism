using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class HospitalValidator:AbstractValidator<Hospital>
    {
        public HospitalValidator()
        {
            RuleFor(h => h.hospitalId).NotEmpty();
        }
    }
}
