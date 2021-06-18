using Microsoft.EntityFrameworkCore;
using TeamAssignment.Models;

namespace TeamAssignment.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Team> Teams{ get; set; }

    }
}