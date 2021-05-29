using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Doctor:IEntity
    {
        public int doctorId { get; set; }
        public string doctorName { get; set; }
        public string doctorSurname { get; set; }
        public string doctorEmail { get; set; }
        //public double doctorPoint { get; set; }

    }
}
