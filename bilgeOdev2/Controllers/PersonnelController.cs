using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bilgeOdev2.Models.EntityFramework;
using System.Data.Entity;
using bilgeOdev2.ViewModels;

namespace bilgeOdev2.Controllers
{
    public class PersonnelController : Controller
    {
        bilgeOdevDb2Entities1 db = new bilgeOdevDb2Entities1();
        // GET: Personnel
        public ActionResult Index()
        {
           
            var model = db.Users.Include(z=>z.Book).ToList();
            return View(model);
        }

        public ActionResult New()
        {
            var model = new PersonelFormViewModel() {Books=db.Books.ToList() };
            return View("PersonelForm",model);
        }

        public ActionResult Save(User user)
        {
            if(user.Id==0)
            {
                db.Users.Add(user);
            }
            else
            {
                User user1 = new User();
                foreach (var item in db.Users)
                {
                    if(item.Id==user.Id)
                    {
                        user1 = user;
                    }
                }
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}