using ACCA_Backend.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;


namespace ACCA_Backend.DataAccess.Repository.Context
{
    public class AccaSystemContext : DbContext
    {

        private static AccaSystemContext? accaSystemContext;
        public AccaSystemContext()
        {
        }

        public AccaSystemContext(DbContextOptions<AccaSystemContext> options) : base(options){
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Sessions> Sessions { get; set; }

        public static AccaSystemContext Create()
        {
            if (accaSystemContext == null)
            {
                accaSystemContext = new AccaSystemContext();
            }
            return accaSystemContext;
        }
    }
}