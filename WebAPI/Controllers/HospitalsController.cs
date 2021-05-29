using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalsController : ControllerBase
    {
       IHospitalService _hospitalService;

       public HospitalsController(IHospitalService hospitalService)
       {
           _hospitalService = hospitalService;
       }

       [HttpGet("getall")]
       public IActionResult GetAll()
       {
           var result = _hospitalService.GetAll();
           if (result.Success)
           {
               return Ok(result);
           }

           return BadRequest(result);
       }

       [HttpGet("getbyid")]
       public IActionResult GetById(int id)
       {
           var result = _hospitalService.GetById(id);
           if (result.Success)
           {
               return Ok(result);
           }

           return BadRequest(result);

       }

       [HttpPost("add")]
       public IActionResult Add(Hospital hospital)
       {
           var result = _hospitalService.Add(hospital);
           if (result.Success)
           {
               return Ok(result);
           }

           return BadRequest(result);
       }

       [HttpDelete("delete")]
       public IActionResult Delete(int id)
       {
           Hospital deletedObject = _hospitalService.GetById(id).Data;
           var result = _hospitalService.Delete(deletedObject);
           if (result.Success)
           {
               return Ok(result);
           }

           return BadRequest(result);
       }

       [HttpPut("update")]
       public IActionResult Update(Hospital hospital)
       {
           var result = _hospitalService.Update(hospital);
           if (result.Success)
           {
               return Ok(result);
           }

           return BadRequest(result);
       }
    }
}
