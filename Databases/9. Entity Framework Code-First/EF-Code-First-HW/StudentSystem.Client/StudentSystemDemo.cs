namespace StudentSystem.Client
{
    using System.Data.Entity;

    using StudentSystem.Data;
    using StudentSystem.Data.Migrations;
    using StudentSystem.Model;

    internal class StudentSystemDemo
    {
        private static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentSystemContext, Configuration>());

            using (var studentSystem = new StudentSystemContext())
            {
                studentSystem.Students.Add(new Student()
                {
                    Name = "Svetlin Nakov",
                    Number = 5000981
                });

                studentSystem.SaveChanges();
            }
        }
    }
}
