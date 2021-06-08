using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Business.Concrete
{
    public class DoctorImageManager:IDoctorImageService
    {
        private const string DefaultDoctorImagePath = "/Images/System/DefaultDoctorImage.png";

        public DoctorImageManager(IDoctorImageDal doctorImageDal)
        {
            _doctorImageDal = doctorImageDal;
        }

        IDoctorImageDal _doctorImageDal;
        //IHelper _fileHelper;
        FileHelper _fileHelper;

        public DoctorImageManager(FileHelper fileHelper)
        {
            _fileHelper = fileHelper;
        }

        public IResult Add(DoctorImage doctorImage, IFormFile file)
        {
            IResult result = BusinessRules.Run(CheckIfLimitExceeded(doctorImage),
                CheckDoctorExist(doctorImage.doctorId),
                CheckFileTypeValid(Path.GetExtension(file.FileName)));
            if (result != null )
            {
                return new ErrorResult(result.Message);
            }
            CheckImageFile(doctorImage, file);
            _doctorImageDal.Add(doctorImage);
            return new SuccessResult(Messages<DoctorImage>.Added);
        }

        [ValidationAspect(typeof(DoctorImageValidator))]
        public IResult Update(DoctorImage doctorImage, IFormFile file)
        {
            IResult result = BusinessRules.Run(CheckIfLimitExceeded(doctorImage),
                CheckFileTypeValid(Path.GetExtension(file.FileName)));
            if (!result.Success)
            {
                return new ErrorResult(result.Message);
            }
            ImageUpdate(doctorImage, file);
            _doctorImageDal.Update(doctorImage);
            return new SuccessResult(Messages<DoctorImage>.Updated);
        }
        public IResult Delete(DoctorImage doctorImage)
        {
            var result = BusinessRules.Run(CheckDoctorExist(doctorImage.doctorId));
            if (!result.Success)
            {
                return new ErrorResult(result.Message);
            }

            _doctorImageDal.Delete(doctorImage);
            _fileHelper.Delete(doctorImage.imagePath);
            return new SuccessResult(Messages<DoctorImage>.Deleted);
        }
        public IDataResult<List<DoctorImage>> GetAll()
        {
            return new SuccessDataResult<List<DoctorImage>>(_doctorImageDal.GetAll(), Messages<DoctorImage>.Listed);
        }

        public IDataResult<DoctorImage> GetById(int id)
        {
            return new SuccessDataResult<DoctorImage>(_doctorImageDal.Get(d => d.imageId == id), Messages<DoctorImage>.Got);
        }

        
        private IResult CheckDoctorExist(int doctorImageId)
        {
            DoctorImage selectedDoctorImage = _doctorImageDal.Get(d=> d.doctorId == doctorImageId);
            if(selectedDoctorImage != null)
            {
                return new ErrorResult(Messages<DoctorImage>.NullType);
            }
            return new SuccessResult();
        }

        

        private void ImageUpdate(DoctorImage doctorImage, IFormFile file)
        {
            var result = _doctorImageDal.Get(d => d.imageId == doctorImage.imageId).imagePath;

            if(doctorImage.imagePath == DefaultDoctorImagePath && file != null)
            {
               var uploadedImage = _fileHelper.Upload(file);
                doctorImage.imagePath = uploadedImage.Message;
            }
            else if (result == DefaultDoctorImagePath && file == null)
            {
                doctorImage.imagePath = DefaultDoctorImagePath;
            }
            else if(file==null && result != DefaultDoctorImagePath)
            {
                _fileHelper.Delete(result);
                doctorImage.imagePath = DefaultDoctorImagePath;
            }
            else
            {
                var updatedImage = _fileHelper.Update(file, doctorImage.imagePath);
                doctorImage.imagePath = updatedImage.Message;
            }

        }

        private void CheckImageFile(DoctorImage doctorImage, IFormFile file)
        {
            if (file == null)
            {
                doctorImage.imagePath = DefaultDoctorImagePath;
            }
            var result = _fileHelper.Upload(file);
            doctorImage.imagePath = result.Message;
        }

        private IResult CheckIfLimitExceeded(DoctorImage doctorImage)
        {
            var doctorImageSize = _doctorImageDal.GetAll().Count;
            if (doctorImageSize > 5)
            {
                return new ErrorResult(Messages<DoctorImage>.LimitExceeded);
            }
            return new SuccessResult();
        }
        private IResult CheckFileTypeValid(string type)
        {

            if (type != ".jpeg" && type != ".jpg" && type != ".png" && type != ".svg")
            {
                return new ErrorResult("This type is not valid");
            }
            return new SuccessResult();
        }


    }
}
