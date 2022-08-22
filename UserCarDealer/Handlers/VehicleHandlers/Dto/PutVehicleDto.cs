namespace UserCarDealer.Handlers.VehicleHandlers.Dto
{
    public class PutVehicleDto
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Vin { get; set; }
        public string Color { get; set; }
        public int YearOfProduction { get; set; }
        public int Course { get; set; }
    }
}