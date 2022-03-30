using Recipe.Model;
using Recipe.Repository;
using Recipe.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RBProject.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepo _repo;
        public CategoryController()
        {
            _repo = new CategoryRepo();
        }
        // GET: Category
        public ActionResult Index()
        {
            return View(_repo.GetList());
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            var model = _repo.GetById(id);
            return View(model);
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(Category data)
        {
            try
            {
                _repo.Add(data);
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            var item = _repo.GetById(id);
            Category model = new Category
            {
                Name = item.Name,
                Description = item.Description,
               
            };
            return View(model);
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(Category data)
        {
            try
            {
                _repo.Update(data);
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            var entity = _repo.GetById(id);
            return View(entity);
        }

        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(Category data)
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
    }
}
