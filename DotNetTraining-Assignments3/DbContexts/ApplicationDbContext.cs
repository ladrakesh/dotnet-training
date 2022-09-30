using DotNetTraining_Assignments3.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DotNetTraining_Assignments3.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }
    }
}
