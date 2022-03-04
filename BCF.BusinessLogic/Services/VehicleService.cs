using AutoMapper;
using BCF.BusinessLogic.Interfaces;
using BCF.DataAccess.Interfaces;
using BCF.Model.Entities;
using System.Collections.Generic;

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

        public IEnumerable<VehicleDTO> GetAll()
        {
            var vehicles = unitOfWork.VehicleRepository.GetAll();
            return mapper.Map<IEnumerable<VehicleDTO>>(vehicles);
        }
    }
}
