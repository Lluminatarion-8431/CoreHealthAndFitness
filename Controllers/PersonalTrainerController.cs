using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Core_Health_and_Fitness.Data;
using Core_Health_and_Fitness.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

            var personalTrainerLoggedIn = _context.PersonalTrainers.Where(e => e.IdentityUserId == userId).SingleOrDefault();

            if (personalTrainerLoggedIn == null)
            {
                return RedirectToAction("Create");
            }

            else
            {
                return View(personalTrainerLoggedIn);
            }
        }

        // GET: PersonalTrainerController/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalTrainer = await _context.PersonalTrainers
                .Include(e => e.IdentityUser)
                .FirstOrDefaultAsync(m => m.PersonalTrainerId == id);
            if (personalTrainer == null)
            {
                return NotFound();
            }

            return View(personalTrainer);
        }

        // GET: PersonalTrainerController/Create
        public IActionResult Create()
        {
            PersonalTrainer personalTrainer = new PersonalTrainer();
            return View(personalTrainer);
        }

        // POST: PersonalTrainerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PersonalTrainerId,FirstName,LastName,AddressLine,State,ZipCode,Lat,Long,IdentityUserId")] PersonalTrainer personalTrainer)
        {
            if (ModelState.IsValid)
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                personalTrainer.IdentityUserId = userId;

                _context.Add(personalTrainer);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", personalTrainer.IdentityUserId);
            return View("Index", personalTrainer);
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
