namespace CarSystem.Query.Processor
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    using CarSystem.Models;

    internal class ExportCars
    {
        private const string XmlHeader =
            @"Cars xmlns:xsi=http://www.w3.org/2001/XMLSchema-instancexmlns:xsd=http://www.w3.org/2001/XMLSchema";

        // TODO: Not finished
        public void ExportToXml(IEnumerable<Car> data, string filename)
        {
            if (data.Count() != 0)
            {
                return;
            }

            XElement xmlFile = new XElement("Cars");

            foreach (var car in data)
            {
                XElement xmlCar = new XElement(
                    "car", 
                    new XElement(
                        "TransmissionType", 
                        car.Transmission.ToString(), 
                        new XElement("Dealer", car.Dealer.Name)));

                foreach (var city in car.Cities)
                {
                    XElement xmlCity = new XElement("city", city.Name);
                    xmlCar.Add(xmlCity);
                }

                xmlFile.Add(xmlCar);
            }

            xmlFile.Save(filename);
        }
    }
}