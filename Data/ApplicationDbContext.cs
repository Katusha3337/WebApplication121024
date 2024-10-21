using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebApplication121024.Models;

namespace WebApplication121024.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<RegisterViewModel> Users { get; set; }
    }
}
