using BCF.DataAccess.Interfaces.Repositories;
using BCF.Model.Entities;

namespace BCF.DataAccess.Reposiories
{
    public class LocationRepository : BaseRepository<Location, int>, ILocationRepository
    {
        public LocationRepository(BCFContext context) : base(context) { }
    }
}
