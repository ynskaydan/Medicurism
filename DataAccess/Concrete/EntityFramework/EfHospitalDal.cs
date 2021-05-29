﻿using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess.EntityFramework;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfHospitalDal:EfEntityRepositoryBase<Hospital,MedicurismContext>,IHospitalDal
    {
    }
}
