using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IAppointmentService:IEntityService<Appointment>
    {
        IDataResult<List<AppointmentDto>> GetDtos();
    }
}
