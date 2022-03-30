using Recipe.Core;
using Recipe.Model;
using Recipe.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RBProject.Controllers
{
    public class AdminController : Controller 
    {
        private readonly IAdminRepo _repo;
        public AdminController()
        {
            _repo = new AdminRepo();
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View(_repo.GetList());
        }

        // GET: Admin/Details/5
        public ActionResult Details(int id)
        {
            var model = _repo.GetById(id);
            return View(model);
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult Create(Admin data)
        {
            try
            {
                _repo.Add(data);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            var item = _repo.GetById(id);
            Admin model = new Admin
            {
                FirstName = item.FirstName,
                LastName = item.LastName,
                Email = item.Email,
                Password = item.Password,
                ConfirmPassword = item.ConfirmPassword,
                CreatedOn = item.CreatedOn
            };
            return View(model);
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult Edit(Admin data)
        {
            try
            {
                _repo.Update(data);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            var entity = _repo.GetById(id);
            return View(entity);
        }

        // POST: Admin/Delete/5
        [HttpPost]
        public ActionResult Delete(Admin data)
        {
            try
            {
                // TODO: Add delete logic here
                _repo.Delete(data);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        
        public ActionResult Login()
        {
           
            return View();


        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Login(Admin data)
        {



            //if (ModelState.IsValid)
            //{

            //    using (Context db = new Context())
            //    {
            //        var obj = db.Admin.Where(x => x.Email.Equals(data.Email) && x.Password.Equals(data.Password)).FirstOrDefault();
            //        if (obj != null)
            //        {
            //            Session["Id"] = obj.Id.ToString();
            //            Session["Email"] = obj.Email.ToString();
            //            return RedirectToAction("Index");
            //        }
            //    }
            //}

            //return View(data);

            var entity = _repo.ValidateUser(data.Email, data.Password);
            
                if (entity == true)
            {
                return RedirectToAction("index");
            }
            else
                return View();


        }
        public ActionResult Logout()
        {
            Session["Login"] = null;
            Session.Abandon();
            return RedirectToAction("Default", "index");

        }
    }
}
