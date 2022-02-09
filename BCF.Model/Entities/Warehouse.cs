namespace BCF.Model.Entities
{
    public class Warehouse
    {
        public string _ID { get; set; }

        public string Name { get; set; }

        public int LocationId { get; set; }

        public Location Location { get; set; }

        public int GarageId { get; set; }

        public Garage Cars { get; set; }
    }
}
