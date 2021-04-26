using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class HospitalManager : IHospitalService
    {
        public IResult Add(Hospital entity)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(Hospital entity)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Hospital> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<Hospital> GetDtos()
        {
            throw new NotImplementedException();
        }

        public IResult Update(Hospital entity)
        {
            throw new NotImplementedException();
        }
    }
}
