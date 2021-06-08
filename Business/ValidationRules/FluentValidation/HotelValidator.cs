using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class HotelValidator:AbstractValidator<Hotel>
    {
        public HotelValidator()
        {
            RuleFor(h => h.hotelId).NotEmpty().NotNull();
        }
    }
}
