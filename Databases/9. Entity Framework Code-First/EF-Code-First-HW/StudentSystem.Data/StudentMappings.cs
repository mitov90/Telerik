﻿namespace StudentSystem.Data
{
    using System.Data.Entity.ModelConfiguration;

    using StudentSystem.Model;

    public class StudentMappings : EntityTypeConfiguration<Student>
    {
        public StudentMappings()
        {
            this.HasKey(s => s.Id);

            this.Property(s => s.Name).IsUnicode(true);
            this.Property(s => s.Name).HasMaxLength(255);
            this.Property(s => s.Name).IsRequired();

            this.Property(s => s.Number).IsRequired();
        }
    }
}
