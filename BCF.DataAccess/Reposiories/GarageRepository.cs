using BCF.DataAccess.Interfaces.Repositories;
using BCF.Model.Entities;

namespace BCF.DataAccess.Reposiories
{
    public class GarageRepository : BaseRepository<Garage, int>, IGarageRepository
    {
        public GarageRepository(BCFContext context) : base(context) { }
    }
}
