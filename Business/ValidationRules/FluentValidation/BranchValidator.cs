using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class BranchValidator:AbstractValidator<Branch>
    {
        public BranchValidator()
        {
            RuleFor(b => b.branchId).NotEmpty().NotNull();
        }
    }
}
