using BCF.DataAccess.Interfaces;
using BCF.DataAccess.Interfaces.Repositories;
using BCF.DataAccess.Reposiories;
using System.Threading.Tasks;

namespace BCF.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BCFContext _dbContext;

        private LocationRepository _locationRepository;
        private VehicleRepository _vehicleRepository;
        private GarageRepository _garageRepository;
        private WarehouseRepository _warehouseRepository;

        public UnitOfWork(BCFContext context)
        {
            _dbContext = context;
        }

        public ILocationRepository LocationRepository => _locationRepository ??= new LocationRepository(_dbContext);

        public IVehicleRepository VehicleRepository => _vehicleRepository ??= new VehicleRepository(_dbContext);

        public IWarehouseRepository WarehouseRepository => _warehouseRepository ??= new WarehouseRepository(_dbContext);

        public IGarageRepository GarageRepository => _garageRepository ??= new GarageRepository(_dbContext);

        public async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
