using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;
using Core.Entities.Abstract;

namespace Entities.DTOs
{
    public class AppointmentDto:IDtos
    {
        public string branchName { get; set; }
        public string doctorName{ get; set; }
        public string doctorSurname { get; set; }
        public string hospitalName { get; set; }

    }
}
