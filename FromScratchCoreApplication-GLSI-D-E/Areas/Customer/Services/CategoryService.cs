using FromScratchCoreApplication_GLSI_D_E.Data;
using FromScratchCoreApplication_GLSI_D_E.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FromScratchCoreApplication_GLSI_D_E.Areas.Customer.Services
{
    public class CategoryService : ICategoryServicecs
    {
        private readonly ApplicationDbContext _db;
        public CategoryService(ApplicationDbContext db)
        {
            _db = db;
        }
        //public CategoryService()
        //{
                //_db=new ApplicationDbContext();
        //}
        public async Task<Category> Create(Category category)
        {
            _db.categories.Add(category);
            await _db.SaveChangesAsync();
            return category;
        }

        public async Task<Category> EditCategory(int id, Category category)
        {
            var CatInDb = _db.categories.SingleOrDefault(c => c.Id == id);
            _db.Update(category);
            //var CatInDb = await _db.categories.FindAsync(id);
            //CatInDb.Name = category.Name;
            await _db.SaveChangesAsync();
            return category;
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await _db.categories.ToListAsync();
        }
    }
}
