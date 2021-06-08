using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;
using Core.Entities.Abstract;

namespace Entities.DTOs
{
    public class DoctorDto:IDtos
    {
        public string doctorName { get; set; }
        public string branchName { get; set; }
    }
}
