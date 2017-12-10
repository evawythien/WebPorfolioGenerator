using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebPorfolioGenerator.DAL;
using WebPorfolioGenerator.Models;

namespace WebPorfolioGenerator.Controllers
{
    public class PortfoliosController : Controller
    {
        private readonly WebPortfolioContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;

        public PortfoliosController(WebPortfolioContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        // GET: Portfolios
        public async Task<IActionResult> Index(int? id)
        {
            List<Portfolio> modelo = null;

            if (id == null)
                modelo = await _context.Portfolios.ToListAsync();
            else
                modelo = await _context.Portfolios.Where(n => n.UserId.Equals(id)).ToListAsync();

            return View(modelo);
        }

        public async Task<IActionResult> Preview(int? id)
        {
            return View(await _context.Portfolios.SingleOrDefaultAsync(m => m.PortfolioId == id));
        }

        // GET: Portfolios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var portfolio = await _context.Portfolios.SingleOrDefaultAsync(m => m.PortfolioId == id);
            if (portfolio == null)
            {
                return NotFound();
            }

            return View(portfolio);
        }

        // GET: Portfolios/Create
        public IActionResult Create(int? id)
        {
            ViewBag.Fonts = _context.Fonts.ToList();
            return View();
        }

        // POST: Portfolios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PortfolioId,PortfolioName,PortfolioSurname,FirstColor,SecondColor,FontId")] Portfolio portfolio, IFormFile image)
        {
            if (ModelState.IsValid)
            {
                if (image != null && image.Length > 0)
                {
                    String imageExtension = Path.GetExtension(image.FileName);
                    portfolio.ExtBackgroundImage = imageExtension;
                }

                _context.Add(portfolio);
                await _context.SaveChangesAsync();

                if (image != null && image.Length > 0)
                {
                    String path = Path.Combine(_hostingEnvironment.WebRootPath, "images", "backgrounds", portfolio.ImageName);

                    /* Read the File as byte[], just like a local File */
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await image.CopyToAsync(stream);
                    }
                }

                return RedirectToAction(nameof(Index));
            }
            return View(portfolio);
        }

        // GET: Portfolios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var portfolio = await _context.Portfolios.SingleOrDefaultAsync(m => m.PortfolioId == id);
            if (portfolio == null)
            {
                return NotFound();
            }
            return View(portfolio);
        }

        // POST: Portfolios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PortfolioId,PortfolioName,PortfolioSurname,FirstColor,SecondColor,FontId")] Portfolio portfolio, IFormFile image)
        {
            if (id != portfolio.PortfolioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (image != null && image.Length > 0)
                    {
                        String imageExtension = Path.GetExtension(image.FileName);
                        portfolio.ExtBackgroundImage = imageExtension;
                    }

                    _context.Update(portfolio);
                    await _context.SaveChangesAsync();

                    if (image != null && image.Length > 0)
                    {
                        String path = Path.Combine(_hostingEnvironment.WebRootPath, "images", "backgrounds", portfolio.ImageName);

                        /* Read the File as byte[], just like a local File */
                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await image.CopyToAsync(stream);
                        }
                    }

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PortfolioExists(portfolio.PortfolioId))
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
            return View(portfolio);
        }

        // GET: Portfolios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var portfolio = await _context.Portfolios.SingleOrDefaultAsync(m => m.PortfolioId == id);
            if (portfolio == null)
            {
                return NotFound();
            }

            return View(portfolio);
        }

        // POST: Portfolios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var portfolio = await _context.Portfolios.SingleOrDefaultAsync(m => m.PortfolioId == id);
            _context.Portfolios.Remove(portfolio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PortfolioExists(int id)
        {
            return _context.Portfolios.Any(e => e.PortfolioId == id);
        }
    }
}
