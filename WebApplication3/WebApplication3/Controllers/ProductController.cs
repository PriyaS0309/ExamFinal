using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class ProductController : Controller
    {
        CategoryDBContext db = new CategoryDBContext();
        // GET: Product
        public ActionResult Index()
        {
           var productList= db.Products.Include("Category").ToList();
            return View(productList);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Category_CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName");

            return View();
        }

        [HttpPost]
        public ActionResult Create(Product prdct)
        {
            db.Products.Add(prdct);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var product=db.Products.Where(p => p.ProductId == id).FirstOrDefault();
            //ViewBag.categories = db.Categories.ToList();
            ViewBag.Category_CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", product.Category_CategoryId);
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product pr)
        {

            if (ModelState.IsValid)
            {
                db.Entry(pr).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            //var productToUpdate = db.Products.Where(p => p.ProductId == pr.ProductId).FirstOrDefault();
            //productToUpdate.ProductName = pr.ProductName;

            //db.SaveChanges();

            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Product prod = db.Products.Where(p => p.ProductId == id).FirstOrDefault();
            return View(prod);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult Delete_Post(int id)
        {
            var product = db.Products.Where(p => p.ProductId == id).FirstOrDefault();
            db.Products.Remove(product);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}