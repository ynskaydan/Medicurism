using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class DoctorImage:IEntity
    {
        [Key]
        public int imageId { get; set; }
        public int doctorId { get; set; }
        public string imagePath { get; set; }
        public DateTime date { get; set; }
        public DoctorImage()
        {
            date = DateTime.Now;
        }
    }
}
