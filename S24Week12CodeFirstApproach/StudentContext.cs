using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S24Week12CodeFirstApproach
{
    // context class
    public class StudentContext : DbContext
    {
        // entity sets
        // DbSet properties
        public DbSet<Student> Students { get; set; }
        public DbSet<Standard> Standards { get; set; }


        // define connection string
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(LocalDB)\MSSQLLocalDB; Database=SchoolEfCore; Trusted_Connection=True;MultipleActiveResultSets=true;");
        }


        // data seed
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Standard>().HasData(
                new Standard { StandardId = 1, Name = "Standard 1" },
                new Standard { StandardId = 2, Name = "Standard 2" },
                new Standard { StandardId = 3, Name = "Standard 3" }
            );

            modelBuilder.Entity<Student>().HasData(
                new Student { StudentId = 1, Name = "John", StandardId = 1 },
                new Student { StudentId = 2, Name = "Anne", StandardId = 1 },
                new Student { StudentId = 3, Name = "Mark", StandardId = 2 }
            );
        }
    }
}
