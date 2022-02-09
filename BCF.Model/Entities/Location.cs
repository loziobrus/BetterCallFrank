namespace BCF.Model.Entities
{
    public class Location
    {
        public int Id { get; set; }

        public string Lat { get; set; }

        public string Long { get; set; }

        public string WarehouseId { get; set; }

        public Warehouse Warehouse { get; set; }
    }
}
