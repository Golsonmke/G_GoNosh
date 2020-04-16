using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Go_Nosh.Data;
using Go_Nosh.Models;

namespace Go_Nosh.Controllers
{
    public class FoodTrucksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FoodTrucksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FoodTrucks
        public async Task<IActionResult> Index()
        {
            return View(await _context.FoodTrucks.ToListAsync());
        }

        // GET: FoodTrucks/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodTruck = await _context.FoodTrucks
                .FirstOrDefaultAsync(m => m.FoodTruckPrimaryKey == id);
            if (foodTruck == null)
            {
                return NotFound();
            }

            return View(foodTruck);
        }

        // GET: FoodTrucks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FoodTrucks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FoodTruck foodTruck)
        {
            if (ModelState.IsValid)
            {
                _context.Add(foodTruck);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(foodTruck);
        }

        // GET: FoodTrucks/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodTruck = await _context.FoodTrucks.FindAsync(id);
            if (foodTruck == null)
            {
                return NotFound();
            }
            return View(foodTruck);
        }

        // POST: FoodTrucks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, FoodTruck foodTruck)
        {
            if (id != foodTruck.FoodTruckPrimaryKey)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(foodTruck);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FoodTruckExists(foodTruck.FoodTruckPrimaryKey))
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
            return View(foodTruck);
        }

        // GET: FoodTrucks/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodTruck = await _context.FoodTrucks
                .FirstOrDefaultAsync(m => m.FoodTruckPrimaryKey == id);
            if (foodTruck == null)
            {
                return NotFound();
            }

            return View(foodTruck);
        }

        // POST: FoodTrucks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var foodTruck = await _context.FoodTrucks.FindAsync(id);
            _context.FoodTrucks.Remove(foodTruck);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FoodTruckExists(string id)
        {
            return _context.FoodTrucks.Any(e => e.FoodTruckPrimaryKey == id);
        }
    }
}
