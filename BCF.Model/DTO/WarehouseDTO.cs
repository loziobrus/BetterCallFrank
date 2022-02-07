namespace BCF.Model.Entities
{
    public class WarehouseDTO
    {
        public string _ID { get; set; }

        public string Name { get; set; }

        public LocationDTO Location { get; set; }

        public GarageDTO Cars { get; set; }
    }
}
