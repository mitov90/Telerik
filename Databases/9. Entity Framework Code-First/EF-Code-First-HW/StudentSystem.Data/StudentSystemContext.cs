namespace StudentSystem.Data
{
    using System.Data.Entity;

    using StudentSystem.Model;

    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
            : base("StudentSystem")
        {
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Homework> Homeworks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new HomeworkMappings());
            modelBuilder.Configurations.Add(new StudentMappings());
            modelBuilder.Configurations.Add(new CourseMappings());
            base.OnModelCreating(modelBuilder);
        }
    }
}
