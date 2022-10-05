using DotNetTraining_Assignments4.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DotNetTraining_Assignments4.DbContexts
{
    public class ApplicationDbContext : DbContext,IApplicationDbContext
    {
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public async Task<int> SaveChanges()
        {
            return await base.SaveChangesAsync();
        }
    }
}
