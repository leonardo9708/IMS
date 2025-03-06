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

        [HttpPost("CreateIncident")]
        public async Task<ActionResult<IncidentModel>> CreateProduct(IncidentModel incidentModel)
        {
            await incidenService.CreateProduct(incidentModel);
            return Ok(new BaseResponseModel { Success = true });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BaseResponseModel>> GetIncident(int id)
        {
            var incidentModel = await incidenService.GetIncidents(id);
            if (incidentModel == null)
            {
                return Ok(new BaseResponseModel { Success = false, ErrorMessage = "Incident not foud" });
            }
            return Ok(new BaseResponseModel { Success = true, Data = incidentModel });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateIncident(int id, IncidentModel incidentModel)
        {
            if(id != incidentModel.Id || !await incidenService.IncidentModelExist(id))
            {
                return Ok(new BaseResponseModel { Success = false, ErrorMessage = "Bad request" });
            }
            await incidenService.UpdateIncident(incidentModel);
            return Ok(new BaseResponseModel { Success = true });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIncidents(int id)
        {
            if (!await incidenService.IncidentModelExist(id))
            {
                return Ok(new BaseResponseModel { Success = false, ErrorMessage = "Not Found incident"});
            }
            await incidenService.DeleteIncident(id);
            return Ok(new BaseResponseModel { Success = true });
        }
    }
}
