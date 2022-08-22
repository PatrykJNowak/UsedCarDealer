using System.Collections.Generic;
using Microsoft.VisualBasic;
using Npgsql.PostgresTypes;

namespace UserCarDealer.DataModels
{
    public class SellData
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int VehicleId { get; set; }
        // public ICollection<Customer> CustomerId { get; set; }
        // public ICollection<Vehicle> VehicleId { get; set; }
        public string Date { get; set; }
    }
}
