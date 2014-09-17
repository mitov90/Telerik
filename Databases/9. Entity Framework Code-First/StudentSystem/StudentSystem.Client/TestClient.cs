namespace StudentSystem.Client
{
    using System;
    using System.Data.Entity;

    using StudentSystem.Data;
    using StudentSystem.Data.Migrations;
    using StudentSystem.Model;

    internal class TestClient
    {
        private static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentSystemContext, Configuration>());
            using (var db = new StudentSystemContext())
            {
                db.Students.Add(new Student { Name = "Pesho", Number = "2384832" });

                db.SaveChanges();

                foreach (var student in db.Students)
                {
                    Console.WriteLine(student.StudentId + " " + student.Name + " " + student.Number);
                }
            }
        }
    }
}
