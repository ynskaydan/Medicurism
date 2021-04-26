using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Branch:IEntity
    {
        public int branchId { get; set; }
        public string branchName { get; set; }

    }
}
