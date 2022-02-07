using System.Collections.Generic;

namespace BCF.Model.Entities
{
    public class GarageDTO
    {
        public string Location { get; set; }

        public List<VehicleDTO> Vehicles { get; set; }

    }
}
