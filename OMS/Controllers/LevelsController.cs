using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OMS.Model;
using OMS.Service;

namespace OMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LevelsController : ControllerBase
    {
        private IHierarchyLevelService _levelService;

        public LevelsController(IHierarchyLevelService levelService)
        {
            _levelService = levelService;
        }

        [HttpGet("[action]")]
        public async Task<IEnumerable<HierarchyLevel>> GetAllLevels() 
        {
            return await _levelService.GetHierarchyLevels();
        }

        [HttpPost("[action]")]
        public async Task<HierarchyLevel> AddLevel(HierarchyLevel level)
        {
            return await _levelService.Add(level);
        }

        [HttpPut("[action]")]
        public async Task<HierarchyLevel> UpdateLevel(HierarchyLevel level)
        {
            return await _levelService.Update(level);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _levelService.Delete(id);
        }
    }
}
