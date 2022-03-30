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
    public class IngredientController : Controller
    {
        // GET: Ingredient

        private readonly IIngredientRepo _repo;
        public IngredientController()
        {
            _repo = new IngredientRepo();
        }
        public ActionResult Index()
        {
            return View(_repo.GetList());
        }

        // GET: Ingredient/Details/5
        public ActionResult Details(int id)
        {
            var model=_repo.GetById(id);
            return View(model);
        }

        // GET: Ingredient/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ingredient/Create
        [HttpPost]
        public ActionResult Create(Ingredient data)
        {
            try
            {
                // TODO: Add insert logic here
                _repo.Add(data);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Ingredient/Edit/5
        public ActionResult Edit(int id)
        {
            var item = _repo.GetById(id);
            Ingredient model = new Ingredient
            {
                Name = item.Name,
                Measurement = item.Measurement,
                Description = item.Description,
                
            };
            return View(model);
        }

        // POST: Ingredient/Edit/5
        [HttpPost]
        public ActionResult Edit(Ingredient data)
        {
            try
            {
                // TODO: Add update logic here
                _repo.Update(data);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Ingredient/Delete/5
        public ActionResult Delete(int id)
        {
            var entity = _repo.GetById(id);
            return View(entity);
        }

        // POST: Ingredient/Delete/5
        [HttpPost]
        public ActionResult Delete(Ingredient data)
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
