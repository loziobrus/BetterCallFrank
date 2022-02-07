using BCF.DataAccess.Interfaces.Repositories;
using System.Threading.Tasks;

namespace BCF.DataAccess.Interfaces
{
    public interface IUnitOfWork
    {
        public ILocationRepository LocationRepository { get; }

        public IVehicleRepository VehicleRepository { get; }

        public IGarageRepository GarageRepository { get; }

        public IWarehouseRepository WarehouseRepository { get; }

        public Task Save();
    }
}
