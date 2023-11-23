using OMS.Model;

namespace OMS.Service
{
    public interface IApplicationUserService
    {
        Task<IEnumerable<ApplicationUser>> GetAll();

        Task<ApplicationUser> Add(ApplicationUser user);

        Task<ApplicationUser> Update(ApplicationUser user);

        Task Delete(int id);

        Task<IEnumerable<ApplicationUser>> ReadFromLocal();
    }
}
