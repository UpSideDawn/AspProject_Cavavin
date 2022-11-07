
using AspProject.Services;
using DataTransfertObject.DTO;
using Microsoft.AspNetCore.Mvc;
using Mapster;
using AspProject.Models;

namespace AspProject.Controllers
{
    public class CategoryController : Controller
    {
        private CategoryService _categoryService;

        public CategoryController()
        {
            _categoryService = new CategoryService();
        }

        public async Task<IActionResult> IndexAsync()
        {
            return View(await _categoryService.GetAllCategory());
        }

        public async Task<IActionResult> Details(int id)
        {
            var resultat = _categoryService.GetCategoryById(id);

            if (resultat == null)
            {
                return NotFound();
            }

            return View(resultat) ;
        }

        //GET
        public IActionResult Create()                                                                     //Vue Creation
        {

            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategorieViewDTO categorieViewDTO)                                                   //Creation
        {
            if (categorieViewDTO.Name == categorieViewDTO.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "Name ne peux pas être identique à DisplayOrder.");
            }
           // var resultat = "test";
            if (ModelState.IsValid)
            {
               await _categoryService.CreateCategorie(categorieViewDTO);

                TempData["Success"] = "La catégorie a été créée avec succès";
                return RedirectToAction("Index");
            }
            return View(categorieViewDTO);

        }

        public async Task<IActionResult> Edit(int id)                                                                  //Edition
        {
            var resultat = await _categoryService.GetCategoryById(id);

            if (resultat == null)
            {
                return NotFound();
            }

            return View(resultat);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CategorieViewDTO categorieViewDTO)
        {
            if (categorieViewDTO.Name == categorieViewDTO.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "Name ne peux pas être identique à DisplayOrder.");
            }
            if (ModelState.IsValid)
            {
                await _categoryService.EditCategorie(categorieViewDTO);

                TempData["Success"] = "La catégorie a été modifiée avec succès";
                return RedirectToAction("Index");
            }
            return View(categorieViewDTO);

        }

//        [HttpDelete]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Delete(int id)
//        {
//            var resultat = _categoryService.GetCategoryById(id);

//            if (resultat == null)
//            {
//                return NotFound();
//            }

//            // return View(resultat);

//            await _categoryService.DeleteCategorie(id);

//            TempData["Success"] = "La catégorie a été supprimée avec succès";     //Cree des données temporaires (jusqu'a refresh de la page)
//            return RedirectToAction("Index");
///*
//            var categorieFromDb = _categoryService.GetCategoryById(id);

//            _categoryService.Remove(categorieFromDb);
//            _db.SaveChanges();

//            return RedirectToAction("Index");

//            //var retour = _db.Categories.SupprimerCategorie(id);

//            //return Ok(retour);
//*/
//        }

        public async Task<IActionResult> Delete(int id)                                                                  //Edition
        {


            var resultat = await _categoryService.GetCategoryById(id);

            if (resultat == null)
            {
                return NotFound();
            }

            return View(resultat);
        }

        //POST
        [HttpPost] //Si autre nom possibilité de [HttpPost, "delete"]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePOST(int id)
        {
            var resultat = _categoryService.GetCategoryById(id);

            if (resultat == null)
            {
                return NotFound();
            }

            // return View(resultat);

            await _categoryService.DeleteCategorie(id);

            TempData["Success"] = "La catégorie a été supprimée avec succès";     //Cree des données temporaires (jusqu'a refresh de la page)
            return RedirectToAction("Index");

        }
    }
}
