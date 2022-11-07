//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using System.Drawing.Printing;
//using AspProject.Services;

//namespace AspProject.Controllers
//{
//    public class CategoriesTempController : Controller
//    {
//        private CategoryService _categoryService;



//        public CategoriesTempController()
//        {
//            _categoryService = new CategoryService();

//        }

//        // GET: CategoriesTemp
//        public async Task<IActionResult> Index()
//        {
//              return View(await _categoryService.GetAllCategory());
//        }

//        // GET: CategoriesTemp/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null || _context.Categories == null)
//            {
//                return NotFound();
//            }

//            var categorie = await _context.Categories
//                .FirstOrDefaultAsync(m => m.Id == id);
//            if (categorie == null)
//            {
//                return NotFound();
//            }

//            return View(categorie);
//        }

//        // GET: CategoriesTemp/Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        // POST: CategoriesTemp/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("Id,Name,DisplayOrder,CreatedDateTime")] Categorie categorie)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(categorie);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            return View(categorie);
//        }

//        // GET: CategoriesTemp/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null || _context.Categories == null)
//            {
//                return NotFound();
//            }

//            var categorie = await _context.Categories.FindAsync(id);
//            if (categorie == null)
//            {
//                return NotFound();
//            }
//            return View(categorie);
//        }

//        // POST: CategoriesTemp/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,DisplayOrder,CreatedDateTime")] Categorie categorie)
//        {
//            if (id != categorie.Id)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(categorie);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!CategorieExists(categorie.Id))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(Index));
//            }
//            return View(categorie);
//        }

//        // GET: CategoriesTemp/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null || _context.Categories == null)
//            {
//                return NotFound();
//            }

//            var categorie = await _context.Categories
//                .FirstOrDefaultAsync(m => m.Id == id);
//            if (categorie == null)
//            {
//                return NotFound();
//            }

//            return View(categorie);
//        }

//        // POST: CategoriesTemp/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            if (_context.Categories == null)
//            {
//                return Problem("Entity set 'ApplicationDbContext.Categories'  is null.");
//            }
//            var categorie = await _context.Categories.FindAsync(id);
//            if (categorie != null)
//            {
//                _context.Categories.Remove(categorie);
//            }
            
//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool CategorieExists(int id)
//        {
//          return _context.Categories.Any(e => e.Id == id);
//        }
//    }
//}
