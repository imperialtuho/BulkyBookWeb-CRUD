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
    }
}
