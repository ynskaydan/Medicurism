using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfAppointmentDal:EfEntityRepositoryBase<Appointment,MedicurismContext>,IAppointmenDal
    {
        public List<AppointmentDto> GetAppointmentDtos()
        {
            using (MedicurismContext context = new MedicurismContext())
            {
                var details = from a in context.Appointments
                    join b in context.Branches on a.branchId equals b.branchId
                    join d in context.Doctors on a.doctorId equals d.doctorId
                    join h in context.Hospitals on a.hospitalId equals h.hospitalId
                    select new AppointmentDto()
                    {
                        doctorName = d.doctorName,
                        doctorSurname = d.doctorSurname,
                        branchName = b.branchName,
                        hospitalName = h.hospitalName,

                    };
                return details.ToList();
            }
        }
    }
}
