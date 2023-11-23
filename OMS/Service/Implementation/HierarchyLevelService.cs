using OMS.Model;
using OMS.Repository;

namespace OMS.Service.Implementation
{
    public class HierarchyLevelService : IHierarchyLevelService
    {
        private IHierarchyLevelRepository _hierarchyLevelRepository;

        public HierarchyLevelService(IHierarchyLevelRepository hierarchyLevelRepository)
        {
            _hierarchyLevelRepository = hierarchyLevelRepository;
        }

        public async Task<HierarchyLevel> Add(HierarchyLevel level)
        {
            return await _hierarchyLevelRepository.Add(level);
        }

        public async Task Delete(int id)
        {
            await _hierarchyLevelRepository.Delete(id);
        }

        public async Task<IEnumerable<HierarchyLevel>> GetHierarchyLevels()
        {
            return await _hierarchyLevelRepository.GetHierarchyLevels();
        }

        public async Task<HierarchyLevel> Update(HierarchyLevel level)
        {
            return await _hierarchyLevelRepository.Update(level);
        }
    }
}
