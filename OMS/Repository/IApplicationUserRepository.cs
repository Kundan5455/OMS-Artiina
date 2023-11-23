using OMS.Model;

namespace OMS.Repository
{
    public interface IApplicationUserRepository
    {
        Task<IEnumerable<ApplicationUser>> GetAll();

        Task<ApplicationUser> Add(ApplicationUser user);

        Task<ApplicationUser> Update(ApplicationUser user);

        Task Delete(int id);

        Task<IEnumerable<ApplicationUser>> BulkInsert(IEnumerable<ApplicationUser> users);
    }
}
