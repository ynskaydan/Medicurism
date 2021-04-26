using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BranchManager : IBranchService
    {
        IBranchDal _branchDal;

        public BranchManager(IBranchDal branchDal)
        {
            _branchDal = branchDal;
        }

        public IResult Add(Branch entity)
        {
            _branchDal.Add(entity);
            return new SuccessResult(addedMessage);
        }

        public IResult Delete(Branch entity)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Branch> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<Branch> GetDtos()
        {
            throw new NotImplementedException();
        }

        public IResult Update(Branch entity)
        {
            throw new NotImplementedException();
        }
    }
}
