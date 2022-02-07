namespace BCF.Model.Entities
{
    public class Location
    {
        public int ID { get; set; }

        public string Lat { get; set; }

        public string Long { get; set; }

        public Warehouse Warehouse { get; set; }
    }
}
