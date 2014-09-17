namespace CarSystem.Query.Processor
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    using CarSystem.Data;
    using CarSystem.Models;

    public class QueryProcessor
    {
        private readonly CarDbContext dbContext;

        private readonly ExportCars exporter;

        public QueryProcessor(CarDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.exporter = new ExportCars();
        }

        public void ReadXmlQueries(string filename)
        {
            IEnumerable<XElement> xmlQueries = XElement.Load(filename).Elements("Query");
            IList<Car> results = new List<Car>();

            foreach (var xmlQuery in xmlQueries)
            {
                IQueryable<Car> query = this.dbContext.Cars.AsQueryable();

                string resultFilename = xmlQuery.Attribute("OutputFileName").Value;

                XElement xElement = xmlQuery.Element("WhereClauses");
                if (xElement != null)
                {
                    IEnumerable<XElement> xmlWheres = xElement.Elements("WhereClause");

                    query = xmlWheres.Aggregate(query, this.AddWhereClauses);
                }

                query = this.AddOrderBy(query, xmlQuery);

                this.exporter.ExportToXml(query.ToList(), resultFilename);
            }
        }

        private IQueryable<Car> AddOrderBy(IQueryable<Car> command, XContainer xmlOrderBy)
        {
            XElement xElement = xmlOrderBy.Element("OrderBy");
            if (xElement == null)
            {
                return command;
            }

            string value = xElement.Value;
            switch (value)
            {
                case "Id":
                    command = command.OrderBy(c => c.Id);
                    break;
                case "Year":
                    command = command.OrderBy(c => c.Year);
                    break;
                case "Model":
                    command = command.OrderBy(c => c.Model);
                    break;
                case "Price":
                    command = command.OrderBy(c => c.Price);
                    break;
                case "Manufacturer":
                    command = command.OrderBy(c => c.Manufacturer.Name);
                    break;
                case "Dealer":
                    command = command.OrderBy(c => c.Dealer.Name);
                    break;
            }

            return command;
        }

        private IQueryable<Car> AddWhereClauses(IQueryable<Car> command, XElement xmlWhere)
        {
            string property = xmlWhere.Attribute("PropertyName").Value;
            string propertyType = xmlWhere.Attribute("Type").Value;
            string value = xmlWhere.Value;

            command = this.GetLinqWhere(command, property, propertyType, value);

            return command;
        }

        private IQueryable<Car> GetLinqWhere(
            IQueryable<Car> command, 
            string property, 
            string propertyType, 
            string value)
        {
            int valueAsNumber = 0;
            int.TryParse(value, out valueAsNumber);
            switch (property)
            {
                case "Id":
                    switch (propertyType)
                    {
                        case "Equals":
                            command = command.Where(c => c.Id == valueAsNumber);

                            break;
                        case "GreaterThan":
                            command = command.Where(c => c.Id > valueAsNumber);

                            break;
                        case "LessThan":
                            command = command.Where(c => c.Id < valueAsNumber);

                            break;
                    }

                    break;
                case "Year":
                    switch (propertyType)
                    {
                        case "Equals":
                            command = command.Where(c => c.Year == valueAsNumber);

                            break;
                        case "GreaterThan":
                            command = command.Where(c => c.Year > valueAsNumber);

                            break;
                        case "LessThan":
                            command = command.Where(c => c.Year < valueAsNumber);

                            break;
                    }

                    break;
                case "Price":
                    switch (propertyType)
                    {
                        case "Equals":
                            command = command.Where(c => c.Price == (decimal)valueAsNumber);
                            break;
                        case "GreaterThan":
                            command = command.Where(c => c.Price > (decimal)valueAsNumber);
                            break;
                        case "LessThan":
                            command = command.Where(c => c.Price < (decimal)valueAsNumber);
                            break;
                    }

                    break;
                case "Model":
                    switch (propertyType)
                    {
                        case "Equals":
                            command = command.Where(c => c.Model == value);
                            break;
                        case "Contains":
                            command = command.Where(c => c.Model.Contains(value));
                            break;
                    }

                    break;
                case "Manufacturer":
                    switch (propertyType)
                    {
                        case "Equals":
                            command = command.Where(c => c.Manufacturer.Name == value);
                            break;
                        case "Contains":
                            command = command.Where(c => c.Manufacturer.Name.Contains(value));
                            break;
                    }

                    break;
                case "Dealer":
                    switch (propertyType)
                    {
                        case "Equals":
                            command = command.Where(c => c.Dealer.Name == value);
                            break;
                        case "Contains":
                            command = command.Where(c => c.Dealer.Name.Contains(value));
                            break;
                    }

                    break;
                case "City":
                    switch (propertyType)
                    {
                        case "Equals":
                            command = command.Where(c => c.Cities.FirstOrDefault(city => city.Name == value) != null);
                            break;
                    }

                    break;
            }

            return command;
        }
    }
}