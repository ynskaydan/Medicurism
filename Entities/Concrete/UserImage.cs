using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class UserImage:IEntity
    {
        public int imageId { get; set; }
        public int userId { get; set; }
        public string imagePath { get; set; }
        public DateTime date { get; set; }
    }
}
