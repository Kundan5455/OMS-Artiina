using Dapper.Contrib.Extensions;
using OMS.Model;
using System.Data;
using System.Data.SqlClient;

namespace OMS.Repository.Implementation
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        private IDbConnection _db;

        public ApplicationUserRepository(IConfiguration configuration)
        {
            this._db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }

        public async Task<ApplicationUser> Add(ApplicationUser user)
        {
            var insertedId = await _db.InsertAsync(user);

            return _db.Get<ApplicationUser>(insertedId);
        }

        public async Task<IEnumerable<ApplicationUser>> BulkInsert(IEnumerable<ApplicationUser> users)
        {
            await _db.InsertAsync(users);

            var insertedUsers = users.Select(user => _db.Get<ApplicationUser>(user.Id));

            return insertedUsers;
        }

        public async Task Delete(int id)
        {
            var user = await _db.GetAsync<ApplicationUser>(id);

            if (user == null)
            {
                throw new Exception($"Entry Nod Found");
            }

            await _db.DeleteAsync(user);
        }

        public async Task<IEnumerable<ApplicationUser>> GetAll()
        {
            return await _db.GetAllAsync<ApplicationUser>();
        }

        public async Task<ApplicationUser> Update(ApplicationUser user)
        {
            var updated = await _db.UpdateAsync(user);

            if (updated != true)
            {
                throw new Exception($"Entity Update Failed");
            }

            return await _db.GetAsync<ApplicationUser>(user.Id);
        }
    }
}
