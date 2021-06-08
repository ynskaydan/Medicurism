using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
    public class Hospital: IEntity
    {
        [Key]
        public int hospitalId { get; set; }
        public string hospitalName { get; set; }
        public string cityId { get; set; }
        //public double hospitalPoint { get; set; }
    }
}
