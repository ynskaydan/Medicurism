using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac;
using Core.Utilities.Business;

namespace Business.Concrete
{
    public class BranchManager : IBranchService
    {
        IBranchDal _branchDal;

        public BranchManager(IBranchDal branchDal)
        {
            _branchDal = branchDal;
        }
        [ValidationAspect(typeof(BranchValidator))]
        public IResult Add(Branch entity)
        {
            IResult result = BusinessRules.Run(CheckBranchNameExist(entity.branchName));
            if (result != null)
            {
                return result;
            }
            _branchDal.Add(entity);
            return new SuccessResult(Messages<Branch>.Added);
        }

        public IResult Delete(Branch entity)
        {
           _branchDal.Delete(entity);
           return new SuccessResult(Messages<Branch>.Deleted);
        }

        public IDataResult<List<Branch>> GetAll()
        {
            return new SuccessDataResult<List<Branch>>(_branchDal.GetAll(), Messages<Branch>.Listed);
        }

        public IDataResult<Branch> GetDtos()
        {
            throw new NotImplementedException();
        }

        public IDataResult<Branch> GetById(int id)
        {
            return new SuccessDataResult<Branch>(_branchDal.Get(b => b.branchId == id),Messages<Branch>.Got);
        }

        public IResult Update(Branch entity)
        {
            _branchDal.Update(entity);
            return new SuccessResult(Messages<Branch>.Updated);
        }
        private IResult CheckBranchNameExist(string branchName)
        {
            var existDoctorName = _branchDal.GetAll(d => d.branchName == branchName);
            if (existDoctorName.Count != 0)
            {
                return new ErrorResult(Messages<Branch>.ThisNameAlreadyExist);
            }

            return new SuccessResult();

        }
    }
}
