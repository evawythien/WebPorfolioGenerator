﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebPorfolioGenerator.DAL;
using WebPorfolioGenerator.Models;

namespace WebPorfolioGenerator.Controllers
{
    public class AboutsController : Controller
    {
        private readonly WebPortfolioContext _context;

        public AboutsController(WebPortfolioContext context)
        {
            _context = context;
        }

        // GET: Abouts
        public async Task<IActionResult> Index()
        {
            return View(await _context.Abouts.ToListAsync());
        }

        // GET: Abouts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var about = await _context.Abouts
                .SingleOrDefaultAsync(m => m.AboutId == id);
            if (about == null)
            {
                return NotFound();
            }

            return View(about);
        }

        // GET: Abouts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Abouts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AboutId,PortfolioId,Title,Body,Twitter,Instagram,Facebook")] About about)
        {
            if (ModelState.IsValid)
            {
                _context.Add(about);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(about);
        }

        // GET: Abouts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var about = await _context.Abouts.SingleOrDefaultAsync(m => m.AboutId == id);
            if (about == null)
            {
                return NotFound();
            }
            return View(about);
        }

        // POST: Abouts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AboutId,PortfolioId,Title,Body,Twitter,Instagram,Facebook")] About about)
        {
            if (id != about.AboutId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(about);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AboutExists(about.AboutId))
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
            return View(about);
        }

        // GET: Abouts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var about = await _context.Abouts
                .SingleOrDefaultAsync(m => m.AboutId == id);
            if (about == null)
            {
                return NotFound();
            }

            return View(about);
        }

        //// POST: Abouts/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var about = await _context.Abouts.SingleOrDefaultAsync(m => m.AboutId == id);
        //    _context.Abouts.Remove(about);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool AboutExists(int id)
        {
            return _context.Abouts.Any(e => e.AboutId == id);
        }
    }
}
