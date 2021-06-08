using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results.Abstract;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IDoctorService:IEntityService<Doctor>
    {
        IDataResult<List<DoctorDto>> GetDtos();
    }
}
