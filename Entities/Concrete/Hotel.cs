using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Hotel: IEntity
    {
        public int hotelId { get; set; }
        public int cityId { get; set; }
        public string hotelName { get; set; }
    }
}
