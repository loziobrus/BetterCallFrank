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
            //CreateMap<VehicleDTO, Vehicle>()
            //    .ForPath(x => x.Id, opt => opt.MapFrom(a => a._ID));
            CreateMap<GarageDTO, Garage>().ReverseMap();
            CreateMap<Location, LocationDTO>().ReverseMap();
        }
    }
}
