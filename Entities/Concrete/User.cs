using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class User: IEntity
    {
        public int userId { get; set; }
        public string userName { get; set; }
        public string userSurname { get; set; }
        public string userEmail { get; set; }
        public int customerId { get; set; }

    }
}
