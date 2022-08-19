namespace UserCarDealer.DataModels
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Vin { get; set; }
        public string Color { get; set; }
        public int YearOfProduction { get; set; }
        public int Course { get; set; }
        public bool IsAvailable { get; set; }
        public int OwnerCount { get; set; }

    }
}