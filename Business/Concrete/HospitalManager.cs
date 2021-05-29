using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Abstract;

namespace Business.Concrete
{
    public class HospitalManager : IHospitalService
    {
        IHospitalDal _hospitalDal;

        public HospitalManager(IHospitalDal hospitalDal)
        {
            _hospitalDal = hospitalDal;
        }

        public IResult Add(Hospital entity)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(Hospital entity)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Hospital>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<Hospital> GetDtos()
        {
            throw new NotImplementedException();
        }

        public IDataResult<Hospital> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Hospital entity)
        {
            throw new NotImplementedException();
        }
    }
}
