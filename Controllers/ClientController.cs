﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Core_Health_and_Fitness.Data;
using Core_Health_and_Fitness.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Core_Health_and_Fitness.Controllers
{
    public class ClientController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClientController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ClientController
        public ActionResult Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var client = _context.Clients.Where(c => c.IdentityUserId == userId).SingleOrDefault();

            if (client == null)
            {
                return RedirectToAction("Create");

            }

            return RedirectToAction("Details", client);
        }

        // GET: ClientController/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = _context.Clients.Include(c => c.IdentityUser).FirstOrDefaultAsync(m => m.ClientId == id);

            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // GET: ClientController/Create
        public ActionResult Create()
        {
            Client client = new Client();
            return View(client);
        }

        // POST: ClientController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClientId,FirstName,LastName,StreetAddress,ZipCode,City,State,IdentityUserId")] Client client)
        {
            if (ModelState.IsValid)
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                client.IdentityUserId = userId;

                _context.Add(client);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(client);
        }

        // GET: ClientController/Edit/5
        public ActionResult Edit(int id)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            Client client = _context.Clients.Where(c => c.IdentityUserId == userId).Single();
            return View(client);
        }

        // POST: ClientController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClientId,FirstName,LastName,StreetAddress,ZipCode,City,State,IdentityUserId")] Client client)
        {
            if (id != client.ClientId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                    Client clientFromDb = _context.Clients.Where(c => c.IdentityUserId == userId).Single();
                    clientFromDb.FirstName = client.FirstName;
                    clientFromDb.LastName = client.LastName;
                    clientFromDb.StreetAddress = client.StreetAddress;
                    clientFromDb.ZipCode = client.ZipCode;
                    clientFromDb.City = client.City;
                    clientFromDb.State = client.State;
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
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", customer.IdentityUserId);
            return View(customer);
        }

        // GET: ClientController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ClientController/Delete/5
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
