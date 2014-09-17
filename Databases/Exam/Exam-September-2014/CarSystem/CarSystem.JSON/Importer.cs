namespace CarSystem.JSON
{
    using System.IO;

    using CarSystem.Data;
    using CarSystem.Models;

    public class Importer
    {
        private readonly CarDbContext dbContext;

        public Importer(CarDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Import(string path)
        {
            string[] filenames = Directory.GetFiles(path, "data*.json");
            foreach (string filename in filenames)
            {
                this.ReadJsonFile(filename);
            }
        }

        public void ReadJsonFile(string filename)
        {
            this.dbContext.Configuration.AutoDetectChangesEnabled = false;
            using (StreamReader r = new StreamReader(filename))
            {
                string json = r.ReadToEnd();

                dynamic array = JsonConvert.DeserializeObject(json);
                foreach (var item in array)
                {
                    Manufacturer manufacturer = this.GetOrCreateManufacturer(item.ManufacturerName.ToString());
                    City city = this.GetOrCreateCity(item.Dealer.City.ToString());
                    Dealer dealer = this.GetOrCreateDealer(item.Dealer.Name.ToString());

                    Car newCar = new Car
                                     {
                                         Year = item.Year, 
                                         Transmission = item.TransmissionType, 
                                         Model = item.Model, 
                                         Price = item.Price, 
                                         Manufacturer = manufacturer, 
                                         Dealer = dealer
                                     };

                    newCar.Cities.Add(city);
                    this.dbContext.Cars.Add(newCar);
                    this.dbContext.SaveChanges();
                }
            }

            this.dbContext.Configuration.AutoDetectChangesEnabled = true;
        }

        private Dealer GetOrCreateDealer(object name)
        {
            string dealerName = (string)name;
            Dealer dealer = this.dbContext
                                .Dealers
                                .FirstOrDefault(d => d.Name == dealerName);
            if (dealer != null)
            {
                return dealer;
            }

            dealer = new Dealer { Name = dealerName };
            this.dbContext.Dealers.Add(dealer);

            return dealer;
        }

        private City GetOrCreateCity(object name)
        {
            string cityName = (string)name;
            City city = this.dbContext
                            .Cities
                            .FirstOrDefault(c => c.Name == cityName);
            if (city != null)
            {
                return city;
            }

            city = new City { Name = cityName };
            this.dbContext.Cities.Add(city);

            return city;
        }

        private Manufacturer GetOrCreateManufacturer(object name)
        {
            string manufacturerName = (string)name;
            Manufacturer manufacturer = this.dbContext
                                            .Manufacturers
                                            .FirstOrDefault(c => c.Name == name);
            if (manufacturer != null)
            {
                return manufacturer;
            }

            manufacturer = new Manufacturer { Name = manufacturerName };
            this.dbContext.Manufacturers.Add(manufacturer);

            return manufacturer;
        }
    }
}