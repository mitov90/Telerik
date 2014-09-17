using System;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;

using NorthwindModels;

internal class UserRepositoryDbContextDemo
{
    private static void Main()
    {
        using (var dbContext = new UserRepositoryEntities())
        {
            DataAccess.Initialize(dbContext);

            try
            {
                DataAccess.InsertNewUser(
                    "Admins",
                    "salman",
                    "s3cr3t", 
                    "Salman",
                    "Khan");
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var validationResult in ex.EntityValidationErrors)
                {
                    foreach (var error in validationResult.ValidationErrors)
                    {
                        Console.WriteLine(error.ErrorMessage);
                    }
                }
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.InnerException.InnerException.Message);
            }
        }
    }
}
