using OMS.Model;

namespace OMS.Repository
{
    public interface IHierarchyLevelRepository
    {
        Task<IEnumerable<HierarchyLevel>> GetHierarchyLevels();

        Task<HierarchyLevel> Add(HierarchyLevel level);

        Task<HierarchyLevel> Update(HierarchyLevel level);

        Task Delete(int id);
    }
}
