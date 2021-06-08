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
using Entities.DTOs;

namespace Business.Concrete
{
    public class DoctorManager : IDoctorService
    {
        IDoctorDal _doctorDal;


        public DoctorManager(IDoctorDal doctorDal)
        {
            _doctorDal = doctorDal;
        }
        [ValidationAspect(typeof(DoctorValidator))]
        public IResult Add(Doctor entity)
        {
            IResult result = BusinessRules.Run(
CheckDoctorBranchCapacity(entity.branchId));
            if (result != null)
            {
                return result;
            }
            _doctorDal.Add(entity);
            return new SuccessResult(Messages<Doctor>.Added);
        }

        private IResult CheckDoctorBranchCapacity(int branchId)
        {
            var sizeOfBranch = _doctorDal.GetAll(d => d.branchId == branchId).Count;
            if (sizeOfBranch > 5)
            {
                return new ErrorResult(Messages<Doctor>.OutBranchOfLimit);

            }
            return new SuccessResult();
        }

        public IResult Delete(Doctor entity)
        {
            _doctorDal.Delete(entity);
            return new SuccessResult(Messages<Doctor>.Deleted);
        }

        public IDataResult<List<Doctor>> GetAll()
        {
            return new SuccessDataResult<List<Doctor>>(_doctorDal.GetAll(), Messages<Doctor>.Listed);
        }

        public IDataResult<List<DoctorDto>> GetDtos()
        {
            return new SuccessDataResult<List<DoctorDto>>(_doctorDal.GetDoctorDtos(), Messages<Doctor>.ListedDto);
        }

        public IDataResult<Doctor> GetById(int id)
        {
            return new SuccessDataResult<Doctor>(_doctorDal.Get(d => d.doctorId == id), Messages<Doctor>.Got);
        }

        public IResult Update(Doctor entity)
        {
            IResult result = BusinessRules.Run(
                CheckDoctorBranchCapacity(entity.branchId));
            if (result != null)
            {
                return result;
            }

            _doctorDal.Update(entity);
            return new SuccessResult(Messages<Doctor>.Updated);
        }
    }
}
