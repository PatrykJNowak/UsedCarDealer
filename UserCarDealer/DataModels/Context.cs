using System.Data.Common;
using System.Xml.XPath;
using Microsoft.EntityFrameworkCore;

namespace UserCarDealer.DataModels
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options){}

        public DbSet<SellData> SellData { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Customer> Customer { get; set; }
    }
}