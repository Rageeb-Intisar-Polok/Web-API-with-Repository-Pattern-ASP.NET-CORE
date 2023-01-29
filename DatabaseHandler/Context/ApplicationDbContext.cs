using DatabaseHandler.Models.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace DatabaseHandler.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Department> Departments { get; set; }
        public DbSet<LevelTerm> LevelTerm { get; set; }
        public DbSet<Connection> Connections { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Officials> Officials { get; set; }
        public DbSet<Students> Students { get; set; }
        public DbSet<Teachers> Teachers { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

    }
}
