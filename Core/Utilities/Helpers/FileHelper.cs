using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.Helpers
{
    public class FileHelper
    {
        public static string _currentDirectory = Environment.CurrentDirectory + "\\wwwroot";
        public static string _folderName = "\\images\\uploads";

        public IResult Upload(IFormFile file) {
            IResult result = BusinessRules.Run(CheckFileExist(file));
            if (!result.Success)
            {
                return new ErrorResult(result.Message);
            }
            var type = Path.GetExtension(file.FileName);
            var randomName = Guid.NewGuid().ToString();
            CheckDirectoryExistIfNotCreate(_currentDirectory + _folderName);
            CreateFile(_currentDirectory + _folderName + randomName + type,file);
            return new SuccessResult((_folderName + randomName + type).Replace("\\", "/"));
        }
        public IResult Update(IFormFile file, string imagePath)
        {
            IResult result = BusinessRules.Run(CheckFileExist(file)/*CheckFileTypeValid(Path.GetExtension(file.FileName))*/);
            if (!result.Success)
            {
                return new ErrorResult(result.Message);
            }
            var type = Path.GetExtension(file.FileName);
            var randomName = Guid.NewGuid().ToString();

            DeleteOldFile((_currentDirectory + imagePath).Replace("/", "\\"));

            CheckDirectoryExistIfNotCreate(_currentDirectory + _folderName);

            CreateFile(_currentDirectory + _folderName + randomName + type, file);

            return new SuccessResult((_folderName + randomName + type).Replace("\\", "/"));

        }

        public IResult Delete(string path)
        {
            DeleteOldFile(_currentDirectory + path.Replace("/", "\\"));
            return new SuccessResult();
        }

        private void DeleteOldFile(string directory)
        {
            if (File.Exists(directory.Replace("/", "\\")))
            {
                File.Delete(directory.Replace("/", "\\"));
            }
        }

        private void CreateFile(string directory, IFormFile file)
        {
            using (FileStream fs = File.Create(directory))
            {
                file.CopyTo(fs);
                fs.Flush();
            }
        }

        private void CheckDirectoryExistIfNotCreate(string directory)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }

        //private IResult CheckFileTypeValid(string type)
        //{
        //    if(type != ".jpeg" && type != ".jpg" && type != ".png" && type != ".svg")
        //    {
        //        return new ErrorResult("This type is not valid");
        //    }
        //    return new SuccessResult();
        //}

        private IResult CheckFileExist(IFormFile file)
        {
            if(file != null && file.Length > 0)
            {
                return new SuccessResult();
            }
            return new ErrorResult("It's not file.");
            
        }
    }
}
