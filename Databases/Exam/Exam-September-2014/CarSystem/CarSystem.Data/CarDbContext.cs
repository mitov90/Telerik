namespace CarSystem.Data
{
    using System.Data.Entity;

    using CarSystem.Data.Migrations;
    using CarSystem.Models;

    public class CarDbContext : DbContext
    {
        public CarDbContext()
            : base("name=CarDbContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CarDbContext, Configuration>());
        }

        public virtual IDbSet<Car> Cars { get; set; }

        public virtual IDbSet<City> Cities { get; set; }

        public virtual IDbSet<Dealer> Dealers { get; set; }

        public virtual IDbSet<Manufacturer> Manufacturers { get; set; }
    }
}