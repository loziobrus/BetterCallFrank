using AutoMapper;
using BCF.BusinessLogic.Interfaces;
using BCF.DataAccess.Interfaces;
using BCF.Model.Entities;
using System.Collections.Generic;
using System.Linq;

namespace BCF.BusinessLogic.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public VehicleService(IMapper _mapper, IUnitOfWork _unitOfWork)
        {
            mapper = _mapper;
            unitOfWork = _unitOfWork;
        }

        public IEnumerable<VehicleDetailedDTO> GetAll()
        {
            var vehicles = unitOfWork.VehicleRepository.GetAll();

            var vehiclesDetailed = mapper.Map<IEnumerable<VehicleDetailedDTO>>(vehicles);

            foreach(var v in vehiclesDetailed)
            {
                var details = vehicles.Where(x => x.Id == v._ID).FirstOrDefault();

                v.Location = new LocationFullDTO
                {
                    WarehouseName = details.Garage.Warehouse.Name,
                    Garage = details.Garage.Location,
                    WarehouseLocation = mapper.Map<LocationDTO>(details.Garage.Warehouse.Location)
                };
            }

            return vehiclesDetailed;
        }
    }
}
