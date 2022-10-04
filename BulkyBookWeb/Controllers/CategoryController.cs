using Microsoft.AspNetCore.Mvc;
using BulkyBookWeb.Data;
using BulkyBookWeb.Models;

namespace BulkyBookWeb.Controllers {
    
    public class CategoryController : Controller {

        private readonly ApplicationDbContext _db;
        
        public CategoryController(ApplicationDbContext db) { _db = db; }
        
        public IActionResult Index() {
            IEnumerable<Category> objectCategoryList = _db.Categories;
            return View(objectCategoryList);
        }

        /*  CREATE FEATURE  */
        //GET
        public IActionResult Create() {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj) {
            if(obj.Name == obj.DisplayOrder.ToString()) {
                ModelState.AddModelError("Name","The Name cannot exactly match the DisplayOrder.");
            }
            if (ModelState.IsValid) {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        /*  EDIT FEATURE  */
        //GET
        public IActionResult Edit(int? id) {
            if (id == null || id == 0) {
                return NotFound();
            }
            var categoryFromDb = _db.Categories.Find(id);
            if (categoryFromDb == null) {
                return NotFound();
            }
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj) {
            if (obj.Name == obj.DisplayOrder.ToString()) {
                ModelState.AddModelError("Name", "The Name cannot exactly match the DisplayOrder.");
            }
            if (ModelState.IsValid) {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }


    }
}
