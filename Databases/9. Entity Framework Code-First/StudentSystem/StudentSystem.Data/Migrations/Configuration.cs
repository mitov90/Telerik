namespace StudentSystem.Data.Migrations
{
    using System.Data.Entity.Migrations;

    using StudentSystem.Model;

    public sealed class Configuration : DbMigrationsConfiguration<StudentSystemContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            this.ContextKey = "StudentSystem.Data.StudentSystemContext";
        }

        protected override void Seed(StudentSystemContext context)
        {
            context.Courses.AddOrUpdate(
                new Course
                    {
                        Name = "C#", 
                        Description = "Learn basic part of programming", 
                        Materials = "Introduction to C# "
                    }, 
                new Course
                    {
                        Name = "JavaScript", 
                        Description = "Learn basic part of JavaScript", 
                        Materials = "JavaScript for Dummies"
                    }, 
                new Course
                    {
                        Name = "C# 2", 
                        Description = "Learn advanced part of programming", 
                        Materials = "Introduction to C#"
                    });

            context.Homeworks.AddOrUpdate(
                new Homework { Content = "Entity Framework Code First" }, 
                new Homework { Content = "Entity Framework" }, 
                new Homework { Content = "Transact-SQL" });
        }
    }
}