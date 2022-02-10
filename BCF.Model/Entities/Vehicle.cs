using System;

namespace BCF.Model.Entities
{
    public class Vehicle
    {
        public int Id { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public int Year_Model { get; set; }

        public double Price { get; set; }

        public bool Licensed { get; set; }

        public DateTime Date_Added { get; set; }

        public int GarageId { get; set; }

        public Garage Garage { get; set; }
    }
}
