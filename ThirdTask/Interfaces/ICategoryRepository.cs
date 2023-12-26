

using ThirdTask.Models;

namespace ThirdTask.Interfaces
{
    public interface ICategoryRepository
    {
        void AddCategory(Category category);
        ICollection<Category> GetAllCategories();
        ICollection<Category> GetAllCategoriesOrderedByMostSold();
    }
}
