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
    public class AppointmentManager : IAppointmentService
    {
        IAppointmenDal _appointmenDal;

        public AppointmentManager(IAppointmenDal appointmenDal)
        {
            _appointmenDal = appointmenDal;
        }
        [ValidationAspect(typeof(AppointmentValidator))]
        public IResult Add(Appointment entity)
        {
           _appointmenDal.Add(entity);
           return new SuccessResult(Messages<Appointment>.Added);
        }

        public IResult Delete(Appointment entity)
        {
            _appointmenDal.Delete(entity);
            return new SuccessResult(Messages<Appointment>.Deleted);
        }

        public IResult Update(Appointment entity)
        {
            _appointmenDal.Update(entity);
            return new SuccessResult(Messages<Appointment>.Updated);
        }

        public IDataResult<List<Appointment>> GetAll()
        {
            return new SuccessDataResult<List<Appointment>>(_appointmenDal.GetAll(), Messages<Appointment>.Listed);
        }

        public IDataResult<Appointment> GetDtos()
        {
            throw new NotImplementedException();
        }

        public IDataResult<Appointment> GetById(int id)
        {
            return new SuccessDataResult<Appointment>(_appointmenDal.Get(a => a.appointmentId == id),
                Messages<Appointment>.Listed);
        }
    }
}
