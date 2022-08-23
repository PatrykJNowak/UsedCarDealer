using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;

namespace UserCarDealer.DataModels
{
    public class Customer
    {
        public int Id { get; set; }
        [Required][MaxLength(15)]
        public string Name { get; set; }
        [Required][MaxLength(20)]
        public string SurName { get; set; }
        [Required][MaxLength(15)]
        public string PresonalId { get; set; }
        public ICollection<SellData> SellDataId { get; set; }
    }
}