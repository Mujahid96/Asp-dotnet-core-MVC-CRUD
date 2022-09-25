using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
             _db = db;
        }
        public IActionResult Index()
        {
            //var objCategoryList= _db.Categories.ToList();
            IEnumerable<Category> objCategoryList=_db.Categories;
            return View(objCategoryList);
        }

        public IActionResult Demo()
        {
            //var objCategoryList= _db.Categories.ToList();
            IEnumerable<Category> objCategoryList = _db.Categories;
            return View(objCategoryList);
        }

        //GET Action
        public IActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj); //database e add korar jonno 
                _db.SaveChanges(); // Database e change ta save kora jonno

                return RedirectToAction("Index"); //ekhane J page e datagulo dekhano ache se page e redirect kore dea hoise. jeno amra impact ta dekhte pari.
                                                  //ekhane jodi alada controller e thakto tahole pashe comma diye controller er name likhe dea  lagto.

            }
            return View(obj);
        }
    }
}
