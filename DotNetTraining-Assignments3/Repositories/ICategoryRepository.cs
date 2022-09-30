using DotNetTraining_Assignments3.Models;

namespace DotNetTraining_Assignments3.Repositories
{
    public interface ICategoryRepository
    {
        int GetCategoryIdByName(string categoryName);
    }
}
