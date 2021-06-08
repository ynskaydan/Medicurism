using Business.Abstract;
using Core.Utilities.Helpers;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorImagesController : ControllerBase
    {
        private static string _currentDirectory = Environment.CurrentDirectory + "\\wwwroot";
        IDoctorImageService _doctorImageService;
      //  FileHelper fileHelper;
        public DoctorImagesController(IDoctorImageService doctorImageService)
        {
            _doctorImageService = doctorImageService;
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm(Name = "Image")] IFormFile file, [FromForm] DoctorImage doctorImage)
        {
            var result = _doctorImageService.Add(doctorImage,file);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPut("update")]
        public IActionResult Update([FromForm(Name = "Image")] IFormFile file, [FromForm] DoctorImage doctorImage)
        {
            var result = _doctorImageService.Update(doctorImage, file);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpDelete("Delete")]
        public IActionResult Delete([FromForm] int id)
        {
            DoctorImage deletedEntity = _doctorImageService.GetById(id).Data;
            var result = _doctorImageService.Delete(deletedEntity);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _doctorImageService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        

        
    }
}
