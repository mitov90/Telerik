namespace InsertProductNorthwind
{
    using System;
    using System.Data.SqlClient;

    internal class InsertProduct
    {
        private static void Main()
        {
            var sqlConnection = new SqlConnection(Settings.Default.dbConnectionString);
            sqlConnection.Open();
            using (sqlConnection)
            {
                var result = InserProduct("Malinki-Kapinki", 2, 1, "kg", 2, 1, 1, 1, false, sqlConnection);
                Console.WriteLine("Rows affected: " + result);
            }
        }

        private static int InserProduct(
            string productName, 
            int supplierId, 
            int categoryId, 
            string qualityPerUnit, 
            decimal unitPrice, 
            int unitsInStock, 
            int unitsInOrder, 
            int reorderLevel, 
            bool discontinued, 
            SqlConnection sqlConnection)
        {
            var cmdInsertProduct =
                new SqlCommand(
                    "INSERT INTO Products (ProductName, SupplierID, CategoryID, QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued )"
                    + "VALUES (@ProductName, @SupplierID, @CategoryID, @QuantityPerUnit, @UnitPrice, @UnitsInStock, @UnitsOnOrder, @ReorderLevel, @Discontinued)", 
                    sqlConnection);

            cmdInsertProduct.Parameters.AddWithValue("@ProductName", productName);
            cmdInsertProduct.Parameters.AddWithValue("@SupplierID", supplierId);
            cmdInsertProduct.Parameters.AddWithValue("@CategoryID", categoryId);
            cmdInsertProduct.Parameters.AddWithValue("@QuantityPerUnit", qualityPerUnit);
            cmdInsertProduct.Parameters.AddWithValue("@UnitPrice", unitPrice);
            cmdInsertProduct.Parameters.AddWithValue("@UnitsInStock", unitsInStock);
            cmdInsertProduct.Parameters.AddWithValue("@UnitsOnOrder", unitsInOrder);
            cmdInsertProduct.Parameters.AddWithValue("@ReorderLevel", reorderLevel);
            cmdInsertProduct.Parameters.AddWithValue("@Discontinued", discontinued);

            return cmdInsertProduct.ExecuteNonQuery();
        }
    }
}