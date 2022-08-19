using System.Collections.Generic;
using System.Data.Common;

namespace UserCarDealer.DataModels
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string PresonalId { get; set; }
        public ICollection<SellData> SellDataId { get; set; }

    }
}