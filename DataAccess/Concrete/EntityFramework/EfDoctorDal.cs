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
    public class EfDoctorDal:EfEntityRepositoryBase<Doctor,MedicurismContext>,IDoctorDal
    {
        public List<DoctorDto> GetDoctorDtos()
        {
            using (MedicurismContext context = new MedicurismContext())
            {
                var details = from d in context.Doctors
                    join b in context.Branches on d.branchId equals b.branchId
                    select new DoctorDto
                    {
                        doctorName = d.doctorName,
                        branchName = b.branchName
                    };
                return details.ToList();
            }
        }
    }
}
