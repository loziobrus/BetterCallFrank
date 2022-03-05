using AutoMapper;
using BCF.Model.Entities;

namespace BCF.Model
{
    public class Mapper: Profile
    {
        public Mapper()
        {
            CreateMap<Warehouse, WarehouseDTO>();
            CreateMap<WarehouseDTO, Warehouse>()
                .ForPath(x => x.Id, opt => opt.MapFrom(a => a._ID));

            CreateMap<Vehicle, VehicleDTO>().ReverseMap();
            CreateMap<Vehicle, VehicleDetailedDTO>().ReverseMap();
            CreateMap<GarageDTO, Garage>().ReverseMap();
            CreateMap<Location, LocationDTO>().ReverseMap();
        }
    }
}
