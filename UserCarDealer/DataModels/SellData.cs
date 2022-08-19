using Microsoft.VisualBasic;

namespace UserCarDealer.DataModels
{
    public class SellData
    {
        public int Id { get; set; }
        public Customer CustomerId { get; set; }
        public Vehicle VehicleId { get; set; }
        public string Date { get; set; }
    }
}