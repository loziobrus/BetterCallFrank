using BCF.Model.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BCF.BusinessLogic.Interfaces
{
    public interface IVehicleService
    {
        public IEnumerable<VehicleDetailedDTO> GetAll();
    }
}
