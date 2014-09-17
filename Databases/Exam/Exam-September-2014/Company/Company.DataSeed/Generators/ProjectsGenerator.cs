namespace Company.DataSeed.Generators
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Company.Data;
    using Company.DataSeed.Contracts;

    internal class ProjectsGenerator : Generator, IGenerator
    {
        public ProjectsGenerator(CompanyEntities db, ILogger logger, int seedCount)
            : base(db, logger, seedCount)
        {
        }

        public override void Generate()
        {
            List<int> employeesIds = this.db.Employees.Select(e => e.id).ToList();

            this.logger.Log("Adding projects, Projects-Employees\n");

            for (int i = 0; i < this.count; i++)
            {
                Project project = new Project { name = this.random.GetRandomLengthString(5, 50) };
                this.db.Projects.Add(project);

                int teamMembers = this.random.GetChance(30) ? 5 : this.random.GetRandomNumber(2, 20);
                HashSet<int> teamIds = new HashSet<int>();
                while (teamIds.Count != teamMembers)
                {
                    teamIds.Add(employeesIds[this.random.GetRandomNumber(0, employeesIds.Count - 1)]);
                }

                foreach (int id in teamIds)
                {
                    DateTime startDate = this.random.GetRandomDate();
                    DateTime endDate = this.random.GetRandomDate(startDate);
                    EmployeesProject newProject = new EmployeesProject
                                                      {
                                                          Project = project, 
                                                          startDate = startDate, 
                                                          endDate = endDate, 
                                                          employeeId = id, 
                                                      };

                    this.db.EmployeesProjects.Add(newProject);
                }

                if (i % 100 == 0)
                {
                    this.logger.Log(".");
                    this.db.SaveChanges();
                }
            }

            this.logger.Log("\nProjects addded\n");
        }
    }
}