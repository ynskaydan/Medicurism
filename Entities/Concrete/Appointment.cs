using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.Concrete
{
    public class Appointment:IEntity
    {
        public int appointmentId  { get; set; }
        public int doctorId { get; set; }
        public int branchId { get; set; }
        public int hospitalId { get; set; }
        public DateTime AppointmentDate { get; set; }
    }
}
