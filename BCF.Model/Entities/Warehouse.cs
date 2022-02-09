using System.ComponentModel.DataAnnotations;

namespace BCF.Model.Entities
{
    public class Warehouse
    {
        [Key]
        public string _ID { get; set; }

        public string Name { get; set; }

        public int LocationId { get; set; }

        public Location Location { get; set; }

        public int GarageId { get; set; }

        public Garage Cars { get; set; }
    }
}
