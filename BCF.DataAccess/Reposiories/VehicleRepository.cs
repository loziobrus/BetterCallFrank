using BCF.DataAccess.Interfaces.Repositories;
using BCF.Model.Entities;

namespace BCF.DataAccess.Reposiories
{
    public class VehicleRepository : BaseRepository<Vehicle, int>, IVehicleRepository
    {
        public VehicleRepository(BCFContext context) : base(context) { }
    }
}
