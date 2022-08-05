using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskEntityFramework.Models;

namespace TaskEntityFramework.Controllers
{

    public class ProductController : Controller
    {

      public static int start =0;
        EntitytaskContext db = new EntitytaskContext();

        
        public ActionResult Display(string id)
        {

            if (id == null)
            {
                start = 0;
            }
            else if (id == "1")
            {
                start = start + 10;
            }
            else if (id == "0")
            {
                start = start - 10;
            }

            List<Product> lst = db.Products.ToList();
            List<Product> lstdata = new List<Product>();
            foreach (Product p in db.Products.ToList())
            {
                Category c = db.Category.Find(p.CategoryId);
                p.Category = c;

            }

                int i = 0;
                if (start < lst.Count && start >= 0)
                {

                    for (i = start; i < (start + 10); i++)
                    {
                        if (i < lst.Count)
                        {

                            lstdata.Add(lst[i]);


                        }
                    }

                    // start = i;

                    return View(lstdata);
                }


                else
                {
                    ViewBag.msg = "stopped";
                    ViewBag.status = "disabled";
                    return View(lstdata);

                }
            }
        
        
        

        public ActionResult Create()
        {
            ViewBag.categories = GetCategories();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product pt)
        {
            db.Products.Add(pt);
            db.SaveChanges();
            return RedirectToAction("Display");
        }
        public ActionResult Edit(int id)
        {
            ViewBag.categories = GetCategories();

            Product pt = db.Products.Find(id);
            return View(pt);
        }
        [HttpPost]
        public ActionResult Edit(Product pt)
        {
            db.Entry<Product>(pt).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Display");
        }
     
        public ActionResult Delete(int id)
        {
            Product pt = db.Products.Find(id);
            db.Products.Remove(pt);
            db.SaveChanges();
            return RedirectToAction("Display");
        }
         public List<SelectListItem>GetCategories()
        {
            List<SelectListItem> lst = new List<SelectListItem>();
            List<Category> ct = db.Category.ToList();
            foreach(Category t in ct)
            {
                SelectListItem s = new SelectListItem() { Text = t.CategoryName, Value = t.CategoryId.ToString() };
                lst.Add(s);
            }
            return lst;
        }
	}
}