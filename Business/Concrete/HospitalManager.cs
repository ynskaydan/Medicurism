using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac;
using Core.Utilities.Business;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Microsoft.EntityFrameworkCore.Internal;

namespace Business.Concrete
{
    public class HospitalManager : IHospitalService
    {
        IHospitalDal _hospitalDal;

        public HospitalManager(IHospitalDal hospitalDal)
        {
            _hospitalDal = hospitalDal;
        }
        [ValidationAspect(typeof(HospitalValidator))]
        public IResult Add(Hospital entity)
        {
            IResult result = BusinessRules.Run(CheckHospitalNameExist(entity.hospitalName));
            if (result.Success)
            {
                return result;
            }
            _hospitalDal.Add(entity);
            return new SuccessResult(Messages<Hospital>.Added);
        }

        public IResult Delete(Hospital entity)
        {
            _hospitalDal.Delete(entity);
            return new SuccessResult(Messages<Hospital>.Deleted);
        }

        public IDataResult<List<Hospital>> GetAll()
        {
            return new SuccessDataResult<List<Hospital>>(_hospitalDal.GetAll(), Messages<Hospital>.Listed);
        }

        public IDataResult<Hospital> GetById(int id)
        {
            return new SuccessDataResult<Hospital>(_hospitalDal.Get(h => h.hospitalId == id),Messages<Hospital>.Got);
        }

        public IResult Update(Hospital entity)
        {
            _hospitalDal.Update(entity);
            return new SuccessResult(Messages<Hospital>.Updated);
        }
        private IResult CheckHospitalNameExist(string hospitalName)
        {
            var existDoctorName = _hospitalDal.GetAll(d => d.hospitalName == hospitalName);
            if (existDoctorName != null)
            {
                return new ErrorResult(Messages<Hospital>.ThisNameAlreadyExist);
            }

            return new SuccessResult();

        }
    }
}
