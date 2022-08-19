using System.Data.Common;

namespace UserCarDealer.DataModels
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public int PresonalId { get; set; }
    }
}