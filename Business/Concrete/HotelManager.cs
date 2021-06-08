using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
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
        [ValidationAspect(typeof(HotelValidator))]
        public IResult Add(Hotel entity)
        {
            _hotelDal.Add(entity);
            return new SuccessResult(Messages<Hotel>.Added);
        }

        public IResult Delete(Hotel entity)
        {
            _hotelDal.Delete(entity);
            return new SuccessResult(Messages<Hotel>.Deleted);
        }

        public IResult Update(Hotel entity)
        {
            _hotelDal.Update(entity);
            return new SuccessResult(Messages<Hotel>.Updated);
        }

        public IDataResult<List<Hotel>> GetAll()
        {
            return new SuccessDataResult<List<Hotel>>(_hotelDal.GetAll(), Messages<Hotel>.Listed);
        }
        public IDataResult<Hotel> GetById(int id)
        {
            return new SuccessDataResult<Hotel>(_hotelDal.Get(h => h.hotelId == id),Messages<Hotel>.Got);
        }
    }
}
