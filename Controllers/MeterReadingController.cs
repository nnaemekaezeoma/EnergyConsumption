using EnergyConsumption.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EnergyConsumption.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeterReadingController : ControllerBase
    {
        private readonly IProcessRequest process;

        public MeterReadingController(IProcessRequest _process)
        {
            process = _process;
        }
        public IActionResult Get()
        {
            return Ok("Meter Reading");
        }

        [HttpPost]
        [Route("meter-reading-uploads")]
        public IActionResult Upload()
        {
            var file = Request.Form.Files[0];
            if (file.ContentType != "application/vnd.ms-excel")
            {
                return BadRequest(new Response { StatusMessage = "Invalid File Format" });
            }
            return Ok(process.ProcessFileUploadRequest(file));
        }

        [HttpPost]
        [Route("meter-reading-upload")]
        public IActionResult SingleUpload(MeterReadingDto data)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(new Response { StatusMessage = "Invalid Request" });
            }

            return Ok(process.ProcessSingleRequest(data));
        }

        [HttpGet]
        [Route("Accounts")]
        public IActionResult GetAccount(int? id)
        {
            List<AccountDto> data = new List<AccountDto>();
            data = process.Accounts(id);

            if (data.Count > 0)
            {
                return Ok(data);
            }
            return NotFound();
        }
    }
}
