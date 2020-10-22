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

            var personalTrainer = await _context.PersonalTrainers
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
            PersonalTrainer personalTrainer = new PersonalTrainer();
            return View(personalTrainer);
        }

        // POST: PersonalTrainers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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
        public async Task<IActionResult> Edit(int id, [Bind("PersonalTrainerId,FirstName,LastName,AddressLine,State,ZipCode,Lat,Long,IdentityUserId")] PersonalTrainer personalTrainer)
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

        private bool WorkoutScheduleExists(int id)
        {
            return _context.WorkoutSchedule.Any(e => e.ScheduleID == id);
        }
        [HttpGet]

        public IActionResult CreateWorkoutSchedule()
        {
            WorkoutSchedule workoutSchedule = new WorkoutSchedule();
            return View(workoutSchedule);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateWorkoutSchedule([Bind("ScheduleID,Monday,Tuesday,Wednsday,Thursday,Friday,Saturday,Sunday,IdentityUserId,")] WorkoutSchedule workoutSchedule)
        {
            if (ModelState.IsValid)
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                workoutSchedule.IdentityUserId = userId;
                var personalTrainer = _context.WorkoutSchedule.Where(c => c.IdentityUserId == userId).SingleOrDefault();

                _context.WorkoutSchedule.Add(workoutSchedule);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View("Index");
        }

        // GET: WorkoutSchedule/Edit/5
        public async Task<IActionResult> EditWorkoutSchedule(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workoutSchedule = await _context.WorkoutSchedule.FindAsync(id);
            if (workoutSchedule == null)
            {
                return NotFound();
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", workoutSchedule.IdentityUserId);
            return View(workoutSchedule);
        }

        // POST: WorkoutSchedule/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditWorkoutSchedule(int id, [Bind("ScheduleID,Monday,Tuesday,Wednsday,Thursday,Friday,Saturday,Sunday,IdentityUserId,")] WorkoutSchedule workoutSchedule)
        {
            if (id != workoutSchedule.ScheduleID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workoutSchedule);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkoutScheduleExists(workoutSchedule.ScheduleID))
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
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", workoutSchedule.IdentityUserId);
            return View(workoutSchedule);
        }
        public IActionResult ViewClientProfile()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var client = _context.Clients.Where(c => c.IdentityUserId == userId).SingleOrDefault();

            var clientProfiles = _context.ClientProfile.Where(c => c.ClientProfileId == client.ClientId);
            return View(clientProfiles);

            //var clientProfiles = _context.ClientProfile.Where(p => p.IdentityUser);
            //return View(await clientProfiles.ToListAsync());

            //var personalTrainersList = _context.PersonalTrainers.Include(p => p.IdentityUser);

            //return View(await personalTrainersList.ToListAsync());

            //var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            //var client = _context.Clients.Where(c => c.IdentityUserId == userId).SingleOrDefault();
            //var clientProfile = await _context.ClientProfile.Where(c => c.IdentityUserId == client.ClientId).ToList();


            //return View(clientProfile);
        }

        [HttpGet]
        public IActionResult CreateDietPlan()
        {
            DietPlan dietPlan = new DietPlan();
            return View(dietPlan);
        }

        // POST: DietPlan/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateDietPlan([Bind("DietPlanID,CaloricIntake,Protein,Carbohydrates,Fat,IdentityUserId,")] DietPlan dietPlan)
        {
            if (ModelState.IsValid)
            {
                //personalTrainer.IdentityUserId = userId;


                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                dietPlan.IdentityUserId = userId;

                var personalTrainer = _context.DietPlan.Where(c => c.IdentityUserId == userId).SingleOrDefault();

                _context.Add(dietPlan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", dietPlan.IdentityUserId);
            return View(dietPlan);
        }
    }
}

