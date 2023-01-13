using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SS3Restaurant.Models;

namespace SS3Restaurant.Controllers
{
    public class TablesController : Controller
    {
        private readonly AppDbContext _context;
        public TablesController(AppDbContext context)
        {
            _context = context;
        }
        // GET: Tables
        public async Task<ActionResult> Index()
        {
            return View(await _context.Tables.ToListAsync());
        }

        // GET: Tables/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Tables/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tables/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Tables tables)
        {
            if (ModelState.IsValid)
            {
                tables.TableId = Guid.NewGuid();
                _context.Tables.Add(tables);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Tables/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Tables/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Tables/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Tables/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}