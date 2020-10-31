using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Core_Health_and_Fitness.Data;
using Core_Health_and_Fitness.Models;
using System.Security.Claims;
using Core_Health_and_Fitness.Services;
using Microsoft.AspNetCore.Authorization;

namespace Core_Health_and_Fitness.Controllers
{
    //[Authorize(Roles = "PersonalTrainer")]
    public class PersonalTrainersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly GeocodingService _geocodingService;

        public PersonalTrainersController(ApplicationDbContext context, GeocodingService geocodingService)
        {
            _context = context;
            _geocodingService = geocodingService;
        }

        // GET: PersonalTrainers
        public async Task<IActionResult> Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            //var personalTrainer = _context.PersonalTrainers.Where(c => c.IdentityUserId == userId).SingleOrDefault();

            //if (personalTrainer == null)
            //{
            //    return RedirectToAction("Create");
            //}

            //return View(personalTrainer);

            //var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var applicationDbContext = _context.PersonalTrainers.Include(p => p.IdentityUser);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PersonalTrainers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Clients
                .Include(p => p.IdentityUser)
                .Include(c => c.PersonalTrainer)
                .FirstOrDefaultAsync(m => m.ClientId == id);

            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // GET: PersonalTrainers/Create
        public IActionResult Create()
        {
            PersonalTrainer personalTrainer = new PersonalTrainer();

            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id");
            return View(personalTrainer);
        }

        // POST: PersonalTrainers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PersonalTrainerId,FirstName,LastName,AddressLine,State,ZipCode,MedicalProviders,Lat,Long,CaloricIntake,ProteinInGrams,CarbohydratesInGrams,FatInGram,Monday,Tuesday,Wednsday,Thursday,Friday,Saturday,Sunday,IdentityUserId")] PersonalTrainer personalTrainer)
        {
            if (ModelState.IsValid)
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                personalTrainer.IdentityUserId = userId;

                //var personalTrainerWithLatLong = await _geocodingService.GetGeocoding(personalTrainer);

                //_context.Add(personalTrainerWithLatLong);
                _context.Add(personalTrainer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", personalTrainer.IdentityUserId);
            return View(personalTrainer);
        }

        // GET: PersonalTrainers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalTrainer = await _context.PersonalTrainers.FindAsync(id);
            if (personalTrainer == null)
            {
                return NotFound();
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", personalTrainer.IdentityUserId);
            return View(personalTrainer);
        }

        // POST: PersonalTrainers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PersonalTrainerId,FirstName,LastName,AddressLine,State,ZipCode,MedicalProviders,Lat,Long,CaloricIntake,ProteinInGrams,CarbohydratesInGrams,FatInGram,Monday,Tuesday,Wednsday,Thursday,Friday,Saturday,Sunday,IdentityUserId")] PersonalTrainer personalTrainer)
        {
            if (id != personalTrainer.PersonalTrainerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personalTrainer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonalTrainerExists(personalTrainer.PersonalTrainerId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", personalTrainer.IdentityUserId);
            return View(personalTrainer);
        }

        // GET: PersonalTrainers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalTrainer = await _context.PersonalTrainers
                .Include(p => p.IdentityUser)
                .FirstOrDefaultAsync(m => m.PersonalTrainerId == id);
            if (personalTrainer == null)
            {
                return NotFound();
            }

            return View(personalTrainer);
        }

        // POST: PersonalTrainers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personalTrainer = await _context.PersonalTrainers.FindAsync(id);
            _context.PersonalTrainers.Remove(personalTrainer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonalTrainerExists(int id)
        {
            return _context.PersonalTrainers.Any(e => e.PersonalTrainerId == id);
        }

        public IActionResult ClientsList()
        {
            var clientsList = _context.Clients.ToList();

            return View(clientsList);
        }

    }
}
