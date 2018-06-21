using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
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
            List<Portfolio> modelo = new List<Portfolio>();
            int? userId = HttpContext.Session.GetInt32("UserId");
            int userRol = _context.Users.Where(u => u.UserId.Equals(userId)).Select(u => u.RolId).FirstOrDefault();

            if (userRol == 4)
                modelo = await _context.Portfolios.Where(n => n.UserId.Equals(userId)).ToListAsync();
            else if (id == null)
                modelo = await _context.Portfolios.ToListAsync();
            else
                modelo = await _context.Portfolios.Where(n => n.UserId.Equals(id)).ToListAsync();

            return View(modelo);
        }

        public async Task<IActionResult> Preview(int? id)
        {
            var portfolio = await _context.Portfolios.SingleOrDefaultAsync(p => p.PortfolioId.Equals(id));
            var font = await _context.Fonts.SingleOrDefaultAsync(p => p.Id.Equals(portfolio.FontId));

            ViewBag.FirstColor = portfolio.FirstColor;
            ViewBag.SecondColor = portfolio.SecondColor;
            ViewBag.FontName = font.FontName;
            ViewBag.FontFamily = font.FontFamily;
            ViewBag.Style = font.Style;
            ViewBag.Link = font.Link;

            return View(portfolio);
        }

        // GET: Portfolios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var portfolio = await _context.Portfolios.SingleOrDefaultAsync(m => m.PortfolioId == id);
            if (portfolio == null)
                return NotFound();

            return View(portfolio);
        }

        // GET: Portfolios/Create
        public IActionResult Create(int? id)
        {
            ViewBag.Fonts = _context.Fonts.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,PortfolioId,PortfolioName,PortfolioSurname,FirstColor,SecondColor,FontId")] Portfolio portfolio, IFormFile image)
        {
            if (ModelState.IsValid)
            {
                if (image != null && image.Length > 0)
                    portfolio.ExtBackgroundImage = Path.GetExtension(image.FileName);

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

                return RedirectToAction(nameof(Index), new { id = portfolio.UserId });
            }

            return View(portfolio);
        }

        // GET: Portfolios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var portfolio = await _context.Portfolios.SingleOrDefaultAsync(m => m.PortfolioId == id);
            if (portfolio == null)
                return NotFound();

            ViewBag.Fonts = _context.Fonts.ToList();

            return View(portfolio);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PortfolioId,PortfolioName,PortfolioSurname,FirstColor,SecondColor,FontId,ExtBackgroundImage,UserId")] Portfolio portfolio, IFormFile image)
        {
            if (id != portfolio.PortfolioId)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    if (image != null && image.Length > 0)
                        portfolio.ExtBackgroundImage = Path.GetExtension(image.FileName);

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
                        return NotFound();
                    else
                        throw;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(portfolio);
        }

        // GET: Portfolios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var portfolio = await _context.Portfolios.SingleOrDefaultAsync(m => m.PortfolioId == id);
            if (portfolio == null)
                return NotFound();

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
