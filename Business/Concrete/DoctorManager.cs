using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class DoctorManager : IDoctorService
    {
        public IResult Add(Doctor entity)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(Doctor entity)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Doctor> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<Doctor> GetDtos()
        {
            throw new NotImplementedException();
        }

        public IResult Update(Doctor entity)
        {
            throw new NotImplementedException();
        }
    }
}
