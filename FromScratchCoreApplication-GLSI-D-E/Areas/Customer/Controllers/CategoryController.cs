using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FromScratchCoreApplication_GLSI_D_E.Data;
using FromScratchCoreApplication_GLSI_D_E.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FromScratchCoreApplication_GLSI_D_E.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        //HTTP-GET
        //Async et await permettent d'appeler plusieurs fonctionnalités d'une manière asynchrone
        public async Task<IActionResult> Index()
        {
            return View(await _db.categories.ToListAsync());
        }
        //HTPP-Get
        public IActionResult Create()
        {
            return View();
        }
        //HTTP-POST
        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            if(ModelState.IsValid)
            //Si le modèle introduit est valide
            {
                _db.categories.Add(category);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var cat = await _db.categories.FindAsync(id);
            return View(cat);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Category category)
        {
            if(ModelState.IsValid)
            {
                //Update peut être remplacé par mapping automatique ou manuelle

                _db.Update(category);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }
        //HTTP-GET
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var cat = await _db.categories.FindAsync(id);
            return View(cat);
        }
        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var cat = await _db.categories.FindAsync(id);
            if (cat == null) return View();
            _db.categories.Remove(cat);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            
        }


        
    }
}
