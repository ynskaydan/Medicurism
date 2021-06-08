using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class AppointmentValidator:AbstractValidator<Appointment>
    {
        public AppointmentValidator()
        {
            RuleFor(a => a.appointmentId).NotEmpty().NotNull();
            RuleFor(a => a.AppointmentDate).NotEmpty();
            RuleFor(a => a.AppointmentDate.Year).GreaterThan(DateTime.Now.Year);
            RuleFor(a => a.AppointmentDate.Month).GreaterThan(DateTime.Now.Month).When(a=>a.AppointmentDate.Year == DateTime.Now.Year);
            RuleFor(a => a.AppointmentDate.Day).GreaterThan(DateTime.Now.Day).When(a => a.AppointmentDate.Month == DateTime.Now.Month);
        }
    }
}
