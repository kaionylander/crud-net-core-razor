using CrudNetCoreRazor.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudNetCoreRazor.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Curso> Curso { get; set; }
    }
}
