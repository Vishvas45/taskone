using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskEntityFramework.Models;

namespace TaskEntityFramework.Controllers
{
    public class CategoryController : Controller
    {
        EntitytaskContext db;
        public CategoryController()
        {
            db = new EntitytaskContext();
        }

        public ActionResult Index()
        {
            List<Category> lst = db.Category.ToList();
            
            return View(lst);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category ct)
        {
            db.Category.Add(ct);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            Category ct = db.Category.Find(id);

            return View(ct);
        }
        [HttpPost]
        public ActionResult Edit(Category ct)
        {
            db.Entry<Category>(ct).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
     
	}
}