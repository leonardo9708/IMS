using BusinessLogic.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Models;

namespace IMS.ApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUsersService usersService) : ControllerBase
    {
        [HttpGet("GetUsers")]
        public async Task<ActionResult<BaseResponseModel>> GetUsers()
        {
            var users = await usersService.GetUsers();
            return Ok(new BaseResponseModel { Success = true, Data = users });
        }
    }
}
