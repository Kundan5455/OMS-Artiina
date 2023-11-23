using Dapper.Contrib.Extensions;
using OMS.Model;
using System.Data;
using System.Data.SqlClient;

namespace OMS.Repository.Implementation
{
    public class HierarchyLevelRepository : IHierarchyLevelRepository
    {
        private IDbConnection _db;
        
        public HierarchyLevelRepository(IConfiguration configuration)
        {
            this._db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }
        public async Task<HierarchyLevel> Add(HierarchyLevel level)
        {
            var insertedId = await _db.InsertAsync(level);

            return _db.Get<HierarchyLevel>(insertedId);
        }

        public async Task Delete(int id)
        {
            var level = await _db.GetAsync<HierarchyLevel>(id);

            if (level == null) 
            {
                throw new Exception($"Entry Nod Found");
            }

            await _db.DeleteAsync(level);
        }

        public async Task<IEnumerable<HierarchyLevel>> GetHierarchyLevels()
        {
            return await _db.GetAllAsync<HierarchyLevel>();
        }

        public async Task<HierarchyLevel> Update(HierarchyLevel level)
        {
            var updated = await _db.UpdateAsync(level);
            
            if (updated != true)
            {
                throw new Exception($"Entity Update Failed");
            }

            return await _db.GetAsync<HierarchyLevel>(level.Id);
        }
    }
}
