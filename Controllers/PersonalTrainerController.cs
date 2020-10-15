using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Core_Health_and_Fitness.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Core_Health_and_Fitness.Controllers
{
    [Authorize(Roles = "PersonalTrainers")]
    public class PersonalTrainerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PersonalTrainerController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: PersonalTrainerController
        public ActionResult Index()
        {
            var applicationDbContext = _context.PersonalTrainers.Include(e => e.IdentityUser);

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var employeeLoggedIn = _context.PersonalTrainers.Where(e => e.IdentityUserId == userId).SingleOrDefault();

            return View();
        }

        // GET: PersonalTrainerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PersonalTrainerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonalTrainerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonalTrainerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PersonalTrainerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonalTrainerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PersonalTrainerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
