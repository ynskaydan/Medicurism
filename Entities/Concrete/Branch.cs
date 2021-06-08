using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
    public class Branch:IEntity
    {
        [Key]
        public int branchId { get; set; }
        public string branchName { get; set; }

    }
}
