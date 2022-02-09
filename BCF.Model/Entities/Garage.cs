using System.Collections.Generic;

namespace BCF.Model.Entities
{
    public class Garage
    {
        public int _ID { get; set; }

        public string Location { get; set; }

        public List<Vehicle> Vehicles { get; set; }

        public int WarehouseId { get; set; }

        public Warehouse Warehouse { get; set; }
    }
}
