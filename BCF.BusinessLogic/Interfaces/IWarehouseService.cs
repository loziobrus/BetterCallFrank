using BCF.Model.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BCF.BusinessLogic.Interfaces
{
    public interface IWarehouseService
    {
        public IEnumerable<WarehouseDTO> GetAll();

        public Task Insert(WarehouseDTO warehouseDTO);

        public void Update(string id, WarehouseDTO warehouseDTO);

        public void SeedDatabase();
    }
}
