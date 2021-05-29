using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Business.Constants;

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
            return new SuccessResult(Messages<Branch>.Added);
        }

        public IResult Delete(Branch entity)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Branch>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<Branch> GetDtos()
        {
            throw new NotImplementedException();
        }

        public IDataResult<Branch> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Branch entity)
        {
            throw new NotImplementedException();
        }
    }
}
