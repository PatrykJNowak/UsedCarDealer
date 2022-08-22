namespace UserCarDealer.Handlers.SellDataHandlers.Dto
{
    public class PutSellDataDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int VehicleId { get; set; }
        public string Date { get; set; }
    }
}