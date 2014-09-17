namespace Company.DataSeed.Generators
{
    using System.Linq;

    using Company.Data;
    using Company.DataSeed.Contracts;

    public class DepartmentsGenerator : Generator, IGenerator
    {
        public DepartmentsGenerator(CompanyEntities db, ILogger logger, int seedCount)
            : base(db, logger, seedCount)
        {
        }

        public override void Generate()
        {
            this.logger.Log("Adding departments\n");
            for (int i = 0; i < this.count; i++)
            {
                string departmentName = this.random.GetRandomLengthString(10, 50);
                if (this.db.Departments.FirstOrDefault(d => d.name == departmentName) != null)
                {
                    i--;
                    continue;
                }

                Department newDepartment = new Department { name = departmentName };
                this.db.Departments.Add(newDepartment);

                if (i % 100 == 0)
                {
                    this.logger.Log(".");
                    this.db.SaveChanges();
                }
            }

            this.logger.Log("\nDepartments addded\n");
        }
    }
}