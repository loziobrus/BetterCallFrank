using AutoMapper;
using BCF.Model.Entities;

namespace BCF.Model
{
    public class Mapper: Profile
    {
        public Mapper()
        {
            CreateMap<WarehouseDTO, Warehouse>().ReverseMap();
            CreateMap<VehicleDTO, Vehicle>().ReverseMap();
            CreateMap<GarageDTO, Garage>().ReverseMap();
            CreateMap<Location, LocationDTO>().ReverseMap();
        }
    }
}
