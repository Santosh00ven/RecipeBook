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
    public class RecipesController : Controller
    {
        private readonly IRecipesRepo _repo;
        public RecipesController()
        {
            _repo = new RecipesRepo();
        }
      
        // GET: Recipes
        public ActionResult Index()
        {
            return View(_repo.GetList());
        }

        // GET: Recipes/Details/5
        public ActionResult Details(int id)
        {
            var model = _repo.GetById(id);
            return View(model);
        }

        // GET: Recipes/Create
        public ActionResult Create()
        {
            Recipes model = new Recipes
            {
                IngredientList = _repo.DropDownList(),
                
        };
            return View(model);
        }

        // POST: Recipes/Create
        [HttpPost]
        public ActionResult Create(Recipes data)
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

        // GET: Recipes/Edit/5
        public ActionResult Edit(int id)
        {
            var item = _repo.GetById(id);
            Recipes model = new Recipes
            {
                Name = item.Name,
                Description = item.Description,
                Serve = item.Serve,
                Duration = item.Duration,
              
            };
            return View(model);
        }

        // POST: Recipes/Edit/5
        [HttpPost]
        public ActionResult Edit(Recipes data)
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

        // GET: Recipes/Delete/5
        public ActionResult Delete(int id)
        {
            var entity = _repo.GetById(id);
            return View(entity);
        }

        // POST: Recipes/Delete/5
        [HttpPost]
        public ActionResult Delete(Recipes data)
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
