using DotNetTraining_Assignments4.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetTraining_Assignments4.DbContexts
{
    public interface IApplicationDbContext
    {
        DbSet<Product> Products { get; set; }

        DbSet<Category> Categories { get; set; }

        Task<int> SaveChanges();        
    }
}
