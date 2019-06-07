using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Task_Manager.Models;

namespace Task_Manager.Controllers
{
    public class TasksController : Controller
    {
        static List<Models.Task> database = new List<Models.Task>() {
           new Models.Task( "07.06.2019 - 09:00", "C209", "Prezentare Proiect", "Laptop, mouse, cunostinte", "0", "1h") ,
           new Models.Task( "09.06.2019 - 14:00", "Restaurant Emerald", "Botez", "Pantofi de schimb, ruj", "-$200", "All day")
        };

        public TasksController()
        {
        }

        // GET: Tasks
        public async Task<IActionResult> Index()
        {
            return View( database);
        }
        

        // GET: Tasks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tasks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Models.Task task)
        {
            Console.WriteLine("--------"+task);
            if (ModelState.IsValid)
            {
                task.ID = Guid.NewGuid();
                database.Add(task);
                return RedirectToAction(nameof(Index));
            }
            return View(task);
        }

        // GET: Tasks/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var task =  database.FirstOrDefault(m => m.ID == id);
            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }

        // POST: Tasks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Models.Task task)
        {
            if (id != task.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    int i = database.FindIndex(m => m.ID == id);
                    if(i==-1)
                        return NotFound();
                    database[i] = task;
                    // database.Update(task);
                    // await database.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaskExists(task.ID))
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
            return View(task);
        }

        // GET: Tasks/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            
            if (id == null)
            {
                return NotFound();
            }

            var task = database.FirstOrDefault(m => m.ID == id);
            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }

        // POST: Tasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var task = database.FirstOrDefault(m => m.ID == id);
            database.Remove(task);
            return RedirectToAction(nameof(Index));
        }

        private bool TaskExists(Guid id)
        {
            return database.Any(e => e.ID == id);
        }
    }
}
