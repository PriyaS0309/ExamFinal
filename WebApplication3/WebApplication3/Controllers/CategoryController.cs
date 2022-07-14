using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class CategoryController : Controller
    {
        CategoryDBContext db = new CategoryDBContext();   
        // GET: Category
        public ActionResult Index()
        {
            var categoryList=db.Categories.ToList();
            return View(categoryList);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category c)
        {
            db.Categories.Add(c);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Category c = db.Categories.Where(cat => cat.CategoryId == id).FirstOrDefault();
            return View(c);
        }

        [HttpPost]
        public ActionResult Edit(Category c)
        {
            Category cat = db.Categories.Where(x => x.CategoryId == c.CategoryId).FirstOrDefault();
            cat.CategoryName = c.CategoryName;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Category c = db.Categories.Where(cat => cat.CategoryId == id).FirstOrDefault();
            return View(c);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult Delete_Post(int id)
        {
            Category catToDelete = db.Categories.Where(c => c.CategoryId == id).FirstOrDefault();
            db.Categories.Remove(catToDelete);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}