using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace ACCA_Backend.DataAccess.Entities.Mapping
{
    public class SubjectsMapping : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Subjects>().ToTable("Subjects");
            modelBuilder.Entity<Subjects>().HasKey(x => x.SubjectId);
            modelBuilder.Entity<Subjects>().Property(x => x.Name).IsRequired();
            modelBuilder.Entity<Subjects>().Property(x => x.Schedule).IsRequired();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-2Q3K0QO\SQLEXPRESS;Database=ACCA;Trusted_Connection=True;");
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}
