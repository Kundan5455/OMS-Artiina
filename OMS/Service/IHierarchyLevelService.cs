using OMS.Model;

namespace OMS.Service
{
    public interface IHierarchyLevelService
    {
        Task<IEnumerable<HierarchyLevel>> GetHierarchyLevels();

        Task<HierarchyLevel> Add(HierarchyLevel level);

        Task<HierarchyLevel> Update(HierarchyLevel level);

        Task Delete(int id);    

    }
}
