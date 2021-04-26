using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Hospital: IEntity
    {
        public int hospitalId { get; set; }
        public string hospitalName { get; set; }
        public string hospitalCity { get; set; }
        public double hospitalPoint { get; set; }
    }
}
