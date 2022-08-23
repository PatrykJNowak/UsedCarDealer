using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace UserCarDealer.DataModels
{
    public class Vehicle
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required][MaxLength(15)]
        public string Model { get; set; }
        [Required][MaxLength(15)]
        public string Vin { get; set; }
        [Required][MaxLength(20)]
        public string Color { get; set; }
        [Required][MaxLength(10)]
        public int YearOfProduction { get; set; }
        [Required][MaxLength(4)]
        public int Course { get; set; }
        public bool IsAvailable { get; set; }
        public int OwnerCount { get; set; }
        public ICollection<SellData> SellDataId { get; set; }

    }
}