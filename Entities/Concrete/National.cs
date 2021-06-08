using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class National:IEntity
    {
        public int nationalId { get; set; }
        public int nationalName { get; set; }

    }
}
