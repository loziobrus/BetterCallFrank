using System;

namespace BCF.Model.Entities
{
    public class VehicleDetailedDTO
    {
        public int _ID { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public int Year_Model { get; set; }

        public double Price { get; set; }

        public bool Licensed { get; set; }

        public DateTime Date_Added { get; set; }

        public LocationFullDTO Location { get; set; }
    }
}
