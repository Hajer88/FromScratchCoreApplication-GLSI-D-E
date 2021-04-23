using FromScratchCoreApplication_GLSI_D_E.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FromScratchCoreApplication_GLSI_D_E.Areas.Customer.Services
{
    public interface ICategoryServicecs
    {
        Task<IEnumerable<Category>> GetAllCategories();
        Task<Category> EditCategory(int id, Category category);

        Task<Category> Create(Category category);
    }
}
