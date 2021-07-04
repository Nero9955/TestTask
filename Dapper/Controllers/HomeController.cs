using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DapperP.Models;

namespace DapperP.Controllers
{
    public class HomeController : Controller
    {
        UserRepository repo;
        public HomeController(UserRepository r)
        {
            repo = r;
        }
        // GET: UsersController
        public ActionResult Index()
        {
            return View(repo.GetUsers());
        }

        // GET: UsersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsersController/Create
        [HttpPost]
        public ActionResult Create(User user)
        {
                repo.Create(user);
                return RedirectToAction("Index");
        }

        // GET: UsersController/Edit/5
        public ActionResult Edit(int id)
        {
            User user = repo.Get(id);
            if (user != null)
            return View(user);
            return NotFound();
        }

        // POST: UsersController/Edit/5
        [HttpPost]

        public ActionResult Edit(User user)
        {
            repo.Update(user);
                return RedirectToAction("Index");

        }

        [HttpGet]
        [ActionName ("Delete")]
        // GET: UsersController/Delete/5
        public ActionResult ConfirmDelete(int id)
        {
            User user = repo.Get(id);
            if (user != null)
                return View(user);
            return NotFound();
        }

        // POST: UsersController/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            repo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
