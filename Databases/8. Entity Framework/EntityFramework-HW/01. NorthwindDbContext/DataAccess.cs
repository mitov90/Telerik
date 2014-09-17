using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;

using NorthwindModels;

public static class DataAccess
{
    private static NorthwindEntities northwind;

    public static void Initialize(NorthwindEntities northwindContext)
    {
        northwind = northwindContext;
    }

    public static void InsertNewCustomer(
        string customerId, 
        string companyName, 
        string contactName, 
        string contactTitle, 
        string address, 
        string city, 
        string region, 
        string postalCode, 
        string country, 
        string phone, 
        string fax)
    {
        var newCustomer = new Customer
                              {
                                  CustomerID = customerId, 
                                  CompanyName = companyName, 
                                  ContactName = contactName, 
                                  ContactTitle = contactTitle, 
                                  Address = address, 
                                  City = city, 
                                  Region = region, 
                                  PostalCode = postalCode, 
                                  Country = country, 
                                  Phone = phone, 
                                  Fax = fax
                              };

        northwind.Customers.Add(newCustomer);

        northwind.SaveChanges();
    }

    public static Customer GetCustomerById(string customerId)
    {
        var customer = northwind.Customers.FirstOrDefault(c => c.CustomerID == customerId);
        return customer;
    }

    public static void UpdateCustomerById(
        string customerId, 
        string companyName, 
        string contactName, 
        string contactTitle, 
        string address, 
        string city, 
        string region, 
        string postalCode, 
        string country, 
        string phone, 
        string fax)
    {
        var customerToUpdate = northwind.Customers.FirstOrDefault(c => c.CustomerID == customerId);

        if (customerToUpdate == null)
        {
            return;
        }

        customerToUpdate.CompanyName = companyName;
        customerToUpdate.ContactName = contactName;
        customerToUpdate.ContactTitle = contactTitle;
        customerToUpdate.Address = address;
        customerToUpdate.City = city;
        customerToUpdate.Region = region;
        customerToUpdate.PostalCode = postalCode;
        customerToUpdate.Country = country;
        customerToUpdate.Phone = phone;
        customerToUpdate.Fax = fax;

        northwind.SaveChanges();
    }

    public static void RemoveCustomerById(string customerId)
    {
        var customerToRemove = northwind.Customers.FirstOrDefault(c => c.CustomerID == customerId);

        if (customerToRemove == null)
        {
            return;
        }

        northwind.Customers.Remove(customerToRemove);
        northwind.SaveChanges();
    }

    public static IEnumerable<Order> GetOrders(int year, string shipCountry)
    {
        var orders =
            northwind.Orders.Where(
                o =>
                    o.OrderDate.HasValue &&
                    o.OrderDate.Value.Year == year &&
                    o.ShipCountry == shipCountry);

        return orders;
    }

    public static IEnumerable<string> GetCustomersHavingOrderNativeQuery(int year, string shipCountry)
    {
        const string Query = 
            @"SELECT C.ContactName
                FROM Orders AS O
                JOIN Customers AS C
                  ON O.CustomerID = C.CustomerID
                 AND YEAR(O.ORDERDATE) = {0}
                 AND O.ShipCountry = {1}
               ORDER BY C.ContactName";

        object[] parameters = { year, shipCountry };
        var result = northwind.Database.SqlQuery<string>(Query, parameters);

        return result;
    }

    public static IEnumerable<Sales_by_Year_Result> GetSalesByRegionAndYear(
        string shipRegion, 
        DateTime? beginningDate, 
        DateTime? endingDate)
    {
        var salesByRegionAndYear = from salesByYear in northwind.Sales_by_Year(beginningDate, endingDate)
                                   join order in northwind.Orders.Where(o => o.ShipRegion == shipRegion) on
                                       salesByYear.OrderID equals order.OrderID
                                   select salesByYear;

        return salesByRegionAndYear;
    }

    public static IEnumerable<SupplierIncomeByYear_Result> GetSupplierIncomeByYear(
        string supplierContactName, 
        DateTime? beginningDate, 
        DateTime? endingDate)
    {
        var supplierIncomeByYear = northwind.SupplierIncomeByYear(supplierContactName, beginningDate, endingDate);
        return supplierIncomeByYear;
    }

    public static void InsertNewOrder(
        string customerId, 
        int employeeId, 
        DateTime orderDate, 
        DateTime requiredDate, 
        DateTime shippedDate, 
        int shipVia, 
        decimal freight, 
        string shipName, 
        string shipAddress, 
        string shipCity, 
        string shipRegion, 
        string shipPostalCode, 
        string shipCountry)
    {
        var newOrder = new Order
                           {
                               CustomerID = customerId, 
                               EmployeeID = employeeId, 
                               OrderDate = orderDate, 
                               RequiredDate = requiredDate, 
                               ShippedDate = shippedDate, 
                               ShipVia = shipVia, 
                               Freight = freight, 
                               ShipName = shipName, 
                               ShipAddress = shipAddress, 
                               ShipCity = shipCity, 
                               ShipRegion = shipRegion, 
                               ShipPostalCode = shipPostalCode, 
                               ShipCountry = shipCountry
                           };

        northwind.Orders.Add(newOrder);
        northwind.SaveChanges();
    }

    public static void GenerateDatabaseFromModel(string databaseName)
    {
        var createDatabaseScript = (northwind as IObjectContextAdapter).ObjectContext.CreateDatabaseScript();

        var connection = new SqlConnection(ConfigurationManager.ConnectionStrings[databaseName].ConnectionString);
        connection.Open();

        using (connection)
        {
            var useMasterCommand = new SqlCommand("USE master", connection);
            useMasterCommand.ExecuteNonQuery();

            var createDatabaseCommand = new SqlCommand("CREATE DATABASE NorthwindTwin", connection);
            createDatabaseCommand.ExecuteNonQuery();

            var useNewDatabaseCommand = new SqlCommand("USE NorthwindTwin", connection);
            useNewDatabaseCommand.ExecuteNonQuery();

            var copySchemaCommand = new SqlCommand(createDatabaseScript, connection);
            copySchemaCommand.ExecuteNonQuery();
        }
    }
}