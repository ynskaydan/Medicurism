using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface IDoctorImageService
    {
        IResult Add(DoctorImage doctorImage, IFormFile file);
        IResult Update(DoctorImage doctorImage, IFormFile file);
        IDataResult<List<DoctorImage>> GetAll();
        IDataResult<DoctorImage> GetById(int id);
        IResult Delete(DoctorImage doctorImage);




    }
}
