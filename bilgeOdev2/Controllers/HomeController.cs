using bilgeOdev2.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bilgeOdev2.Controllers
{
    public class HomeController : Controller
    {
        bilgeOdevDb2Entities db = new bilgeOdevDb2Entities();
        
        public ActionResult Index()
        {
            var model = db.Books.ToList();
            return View(model);
        }
        [HttpGet]
        public ActionResult New()
        {
            
            return View("New");
        }
        [HttpPost] 
        public ActionResult Save(Book book)
        {
            if (book.Id==0)
            {
                db.Books.Add(book);
            }
            else
            {
                var book1 = db.Books.Find(book.Id);
                if (book1==null)
                {
                    return HttpNotFound();
                }
                else
                {

                }
                book1.Name = book.Name;
            }
            
            db.SaveChanges();
            return RedirectToAction("Index","Home");
        }

        public ActionResult Update(int id)
        {
            var book1 = db.Books.Find(id);
            if (book1 == null)
                return HttpNotFound();
            return View("New",book1);
        }

        public ActionResult Delete(int id)
        {
            var book1 = db.Books.Find(id);
            if (book1 == null)
                return HttpNotFound();
            db.Books.Remove(book1);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}