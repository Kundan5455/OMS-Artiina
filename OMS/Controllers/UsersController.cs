using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OMS.Model;
using OMS.Service;

namespace OMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IApplicationUserService _userService;

        public UsersController(IApplicationUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("[action]")]
        public async Task<IEnumerable<ApplicationUser>> GetAllUsers() 
        { 
            return await _userService.GetAll();
        }

        [HttpPost("[action]")]
        public async Task<ApplicationUser> AddUser(ApplicationUser user)
        {
            return await _userService.Add(user);
        }

        [HttpPut("[action]")]
        public async Task<ApplicationUser> UpdateUser(ApplicationUser user)
        {
            return await _userService.Update(user);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _userService.Delete(id);
        }

        [HttpPost("[action]")]
        public async Task<IEnumerable<ApplicationUser>> ImportExcel()
        {
            return await _userService.ReadFromLocal();
        }
    }
}
