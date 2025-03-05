using BusinessLogic.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.Entities;
using Model.Models;

namespace IMS.ApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidentController(IIncidentService incidenService) : ControllerBase
    {
        [HttpGet("GetIncident")]
        public async Task<ActionResult<BaseResponseModel>> GetIncidents()
        {
            var incidents = await incidenService.GetIncidents();
            return Ok(new BaseResponseModel { Success = true, Data = incidents });
        }
    }
}
