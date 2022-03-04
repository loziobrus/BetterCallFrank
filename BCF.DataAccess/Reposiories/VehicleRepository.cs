using BCF.DataAccess.Interfaces.Repositories;
using BCF.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BCF.DataAccess.Reposiories
{
    public class VehicleRepository : BaseRepository<Vehicle, int>, IVehicleRepository
    {
        public VehicleRepository(BCFContext context) : base(context) { }

        public new IQueryable<Vehicle> GetAll()
        {
            IQueryable<Vehicle> query = _dbContext.Set<Vehicle>();

            query = query
                .Include(v => v.Garage)
                .ThenInclude(g => g.Warehouse)
                .ThenInclude(w => w.Location);

            return query;
        }
    }
}
