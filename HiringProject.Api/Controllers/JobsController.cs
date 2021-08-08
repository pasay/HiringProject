using HiringProject.Model.Controllers.Jobs.Requests;
using HiringProject.Model.Controllers.Jobs.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiringProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {

        [HttpGet("all")]
        public async Task<ActionResult<List<JobInfoResponse>>> Get()
        {
            return Ok();
        }
        [HttpGet("all/{CompanyId}")]
        public async Task<ActionResult<List<JobInfoResponse>>> Get([FromRoute] GetAllJobRequest request)
        {
            return Ok();
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<JobInfoResponse>> Get([FromRoute] GetJobIdRequest request)
        {
            return Ok();
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<JobInfoResponse>> Delete([FromRoute] DeleteJobIdRequest request)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<JobInfoResponse>> Post([FromBody] PostJobRequest request)
        {
            return Ok();
        }
    }
}
