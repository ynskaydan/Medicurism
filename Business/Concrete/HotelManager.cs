using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Core.Utilities.Results.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class HotelManager:IHotelService
    {
        IHotelDal _hotelDal;

        public HotelManager(IHotelDal hotelDal)
        {
            _hotelDal = hotelDal;
        }

        public IResult Add(Hotel entity)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(Hotel entity)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Hotel entity)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Hotel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<Hotel> GetDtos()
        {
            throw new NotImplementedException();
        }

        public IDataResult<Hotel> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
