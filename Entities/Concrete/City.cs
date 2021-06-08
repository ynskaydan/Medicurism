using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class City:IEntity
    {
        public int cityId { get; set; }
        public string cityName { get; set; }
    }
}
