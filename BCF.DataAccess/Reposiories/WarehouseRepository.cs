using BCF.DataAccess.Interfaces.Repositories;
using BCF.Model.Entities;
using System.Linq;

namespace BCF.DataAccess.Reposiories
{
    public class WarehouseRepository : BaseRepository<Warehouse, string>, IWarehouseRepository
    {
        public WarehouseRepository(BCFContext context) : base(context) { }

        public new IQueryable<Warehouse> GetAll()
        {
            IQueryable<Warehouse> query = _dbContext.Set<Warehouse>();

            query = query
                .Include(w => w.Location)
                .Include(w => w.Cars)
                .ThenInclude(f => f.Vehicles);

            return query;
        }
    }
}
