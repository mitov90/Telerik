namespace StudentSystem.Data
{
    using System.Data.Entity;

    using StudentSystem.Model;

    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
            : base("name=StudentSystem")
        {
        }

        public virtual DbSet<Student> Students { get; set; }

        public virtual DbSet<Homework> Homeworks { get; set; }

        public virtual DbSet<Course> Courses { get; set; }
    }
}