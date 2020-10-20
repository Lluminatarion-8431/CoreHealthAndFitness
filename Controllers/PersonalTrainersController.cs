using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Core_Health_and_Fitness.Data;
using Core_Health_and_Fitness.Models;

namespace Core_Health_and_Fitness.Controllers
{
    public class PersonalTrainersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PersonalTrainersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PersonalTrainers
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PersonalTrainers.Include(p => p.Client).Include(p => p.IdentityUser);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PersonalTrainers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalTrainer = await _context.PersonalTrainers
                .Include(p => p.Client)
                .Include(p => p.IdentityUser)
                .FirstOrDefaultAsync(m => m.PersonalTrainerId == id);
            if (personalTrainer == null)
            {
                return NotFound();
            }

            return View(personalTrainer);
        }

        // GET: PersonalTrainers/Create
        public IActionResult Create()
        {
            ViewData["ClientId"] = new SelectList(_context.Clients, "ClientId", "ClientId");
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: PersonalTrainers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PersonalTrainerId,FirstName,LastName,AddressLine,State,ZipCode,Lat,Long,IdentityUserId,ClientId")] PersonalTrainer personalTrainer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personalTrainer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientId"] = new SelectList(_context.Clients, "ClientId", "ClientId", personalTrainer.ClientId);
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
            ViewData["ClientId"] = new SelectList(_context.Clients, "ClientId", "ClientId", personalTrainer.ClientId);
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", personalTrainer.IdentityUserId);
            return View(personalTrainer);
        }

        // POST: PersonalTrainers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PersonalTrainerId,FirstName,LastName,AddressLine,State,ZipCode,Lat,Long,IdentityUserId,ClientId")] PersonalTrainer personalTrainer)
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
            ViewData["ClientId"] = new SelectList(_context.Clients, "ClientId", "ClientId", personalTrainer.ClientId);
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
                .Include(p => p.Client)
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
    }
}
