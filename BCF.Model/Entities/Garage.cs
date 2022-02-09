using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BCF.Model.Entities
{
    public class Garage
    {
        public int Id { get; set; }

        public string Location { get; set; }

        public List<Vehicle> Vehicles { get; set; }

        public string WarehouseId { get; set; }

        public Warehouse Warehouse { get; set; }
    }
}
