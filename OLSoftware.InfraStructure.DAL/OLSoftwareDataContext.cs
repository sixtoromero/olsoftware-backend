using OLSoftware.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace OLSoftware.InfraStructure.DAL
{
    public class OLSoftwareDataContext : DbContext
    {        
        public OLSoftwareDataContext([NotNullAttribute] DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProgrammingLanguages> ProgrammingLanguages { get; set; }
        public DbSet<LanguagesByProject> LanguagesByProjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Insertando los Lenguajes de programación
            modelBuilder.Entity<ProgrammingLanguages>().HasData(
                new ProgrammingLanguages
                {
                    Id = 1,
                    ProgrammingLanguage = "C#",
                    Level = "ALTO"
                },
                new ProgrammingLanguages
                {
                    Id = 2,
                    ProgrammingLanguage = "Java",
                    Level = "ALTO"
                },
                new ProgrammingLanguages
                {
                    Id = 3,
                    ProgrammingLanguage= "Python",
                    Level = "ALTO"
                },
                new ProgrammingLanguages
                {
                    Id = 4,
                    ProgrammingLanguage = "C",
                    Level = "MEDIO"
                },
                new ProgrammingLanguages
                {
                    Id = 5,
                    ProgrammingLanguage = "C++",
                    Level = "MEDIO"
                }
                ,
                new ProgrammingLanguages
                {
                    Id = 6,
                    ProgrammingLanguage = "Assembler",
                    Level = "BAJO"
                }

            );
            

            //Creando indices.
            modelBuilder.Entity<Customer>()
                .HasIndex(customer => new { customer.Email });

            modelBuilder.Entity<Project>()
                .HasIndex(project => new { project.ProjectName });

            //Especificando una llave primaria compuesta
            modelBuilder.Entity<Project>().HasKey(x => new { x.Id, x.CustomerId });

            modelBuilder.Entity<Project>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<LanguagesByProject>().HasKey(x => new { x.Id, x.ProjectId, x.ProgrammingLanguagesId });

        }

    }
}
