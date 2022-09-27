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

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {

            if (obj.Name != null && char.IsUpper(obj.Name[0]) == false)
            {
                ModelState.AddModelError("Categories", "Name must be starts with upparcase");

                                         // field name, error msg
                                         //field name can be Name/id/DisplayOrder/ whole Categories.
            }
           

            if (ModelState.IsValid) //eta diye amader mainly chk korte hoye input field gulo so full hoise naki 
            {

                TempData["success"] = "Category Created Successfully";
              
                    _db.Categories.Add(obj); //database e add korar jonno 
                    _db.SaveChanges(); // Database e change ta save kora jonno

             
             

                return RedirectToAction("Index"); //ekhane J page e datagulo dekhano ache se page e redirect kore dea hoise. jeno amra impact ta dekhte pari.
                                                  //ekhane jodi alada controller e thakto tahole pashe comma diye controller er name likhe dea  lagto.

            }
           


            return View(obj);
        }




        //GET Action
        public IActionResult Edit(int? id)
        {
            if(id==null|| id == 0)
            {
                return NotFound();
            }

            var categoryFromDb = _db.Categories.Find(id);
            //var categoryFromDbFirst=_db.Categories.FirstOrDefault(u=>u.Id==id);
            //var categoryFromDbSingle=_db.Categories.SingleOrDefault(u=>u.Id==id);   

            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {

            if (obj.Name != null && char.IsUpper(obj.Name[0]) == false)
            {
                ModelState.AddModelError("Categories", "Name must be starts with upparcase");

                // field name, error msg
                //field name can be Name/id/DisplayOrder/ whole Categories.
            }


            if (ModelState.IsValid) //eta diye amader mainly chk korte hoye input field gulo so full hoise naki 
            {

                TempData["success"] = "Category Edited Successfully";

                _db.Categories.Update(obj); //database e Update korar jonno 
                _db.SaveChanges(); // Database e change ta save kora jonno
                return RedirectToAction("Index"); //ekhane J page e datagulo dekhano ache se page e redirect kore dea hoise. jeno amra impact ta dekhte pari.
                                                  //ekhane jodi alada controller e thakto tahole pashe comma diye controller er name likhe dea  lagto.

            }



            return View(obj);
        }


        //GET Action
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var categoryFromDb = _db.Categories.Find(id);
            //var categoryFromDbFirst=_db.Categories.FirstOrDefault(u=>u.Id==id);
            //var categoryFromDbSingle=_db.Categories.SingleOrDefault(u=>u.Id==id);   

            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {

           

            var obj = _db.Categories.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            TempData["success"] = "Category Deleted Successfully";
            _db.Categories.Remove(obj); 
                _db.SaveChanges(); 
                return RedirectToAction("Index"); 


        }

    }
}
