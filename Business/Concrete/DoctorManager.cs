﻿using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Abstract;

namespace Business.Concrete
{
    public class DoctorManager : IDoctorService
    {
        IDoctorDal _doctorDal;

        public DoctorManager(IDoctorDal doctorDal)
        {
            _doctorDal = doctorDal;
        }

        public IResult Add(Doctor entity)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(Doctor entity)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Doctor>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<Doctor> GetDtos()
        {
            throw new NotImplementedException();
        }

        public IDataResult<Doctor> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Doctor entity)
        {
            throw new NotImplementedException();
        }
    }
}
