﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Core_Health_and_Fitness.Data;
using Core_Health_and_Fitness.Models;
using System.Security.Claims;

namespace Core_Health_and_Fitness.Controllers
{
    public class ClientsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClientsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Clients
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Clients.Include(c => c.IdentityUser).Include(c => c.PersonalTrainer);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Clients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Clients
                .Include(c => c.IdentityUser)
                .Include(c => c.PersonalTrainer)
                .FirstOrDefaultAsync(m => m.ClientId == id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // GET: Clients/Create
        public IActionResult Create()
        {
            Client client = new Client();

            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["PersonalTrainerId"] = new SelectList(_context.PersonalTrainers, "PersonalTrainerId", "PersonalTrainerId");
            return View(client);
        }

        // POST: Clients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClientId,FirstName,LastName,StreetAddress,ZipCode,City,State,Age,Height,Weight,FitnessGoal,StartDate,EndDate,WeightGoal,MedicalProvider,PastInjuries,IdentityUserId,PersonalTrainerId")] Client client)
        {
            if (ModelState.IsValid)
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                client.IdentityUserId = userId;

                _context.Add(client);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", client.IdentityUserId);
            ViewData["PersonalTrainerId"] = new SelectList(_context.PersonalTrainers, "PersonalTrainerId", "PersonalTrainerId", client.PersonalTrainerId);
            return View(client);
        }

        // GET: Clients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Clients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", client.IdentityUserId);
            ViewData["PersonalTrainerId"] = new SelectList(_context.PersonalTrainers, "PersonalTrainerId", "PersonalTrainerId", client.PersonalTrainerId);
            return View(client);
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClientId,FirstName,LastName,StreetAddress,ZipCode,City,State,Age,Height,Weight,FitnessGoal,StartDate,EndDate,WeightGoal,MedicalProvider,PastInjuries,IdentityUserId,PersonalTrainerId")] Client client)
        {
            if (id != client.ClientId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(client);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientExists(client.ClientId))
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
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", client.IdentityUserId);
            ViewData["PersonalTrainerId"] = new SelectList(_context.PersonalTrainers, "PersonalTrainerId", "PersonalTrainerId", client.PersonalTrainerId);
            return View(client);
        }

        // GET: Clients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Clients
                .Include(c => c.IdentityUser)
                .Include(c => c.PersonalTrainer)
                .FirstOrDefaultAsync(m => m.ClientId == id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientExists(int id)
        {
            return _context.Clients.Any(e => e.ClientId == id);
        }

        public async Task<IActionResult> PersonalTrainersList()
        {
            var personalTrainersList = _context.PersonalTrainers.Include(p => p.IdentityUser);

            return View(await personalTrainersList.ToListAsync());
        }
    }
}
