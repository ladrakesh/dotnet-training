using DotNetTraining_Assignments3.DbContexts;

namespace DotNetTraining_Assignments3.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public int GetCategoryIdByName(string categoryName)
        {
            var category = _db.Categories.FirstOrDefault(x => x.Name == categoryName);
            return category?.Id ?? 0;
        }
    }
}
