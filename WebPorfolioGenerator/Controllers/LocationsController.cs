using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebPorfolioGenerator.DAL;
using WebPorfolioGenerator.Models;

namespace WebPorfolioGenerator.Controllers
{
    public class LocationsController : Controller
    {
        private readonly WebPortfolioContext _context;

        public LocationsController(WebPortfolioContext context)
        {
            _context = context;
        }

        // GET: Locations
        public async Task<IActionResult> Index()
        {
            return View(await _context.Locations.ToListAsync());
        }

        public async Task<IActionResult> Preview(int? id)
        {
            if (id == null)
                return NotFound();

            Portfolio portfolio = await _context.Portfolios.SingleOrDefaultAsync(p => p.PortfolioId.Equals(id));

            ViewBag.FirstColor = portfolio.FirstColor;
            ViewBag.SecondColor = portfolio.SecondColor;

            Font font = await _context.Fonts.SingleOrDefaultAsync(p => p.Id.Equals(portfolio.FontId));

            ViewBag.FontName = font.FontName;
            ViewBag.FontFamily = font.FontFamily;
            ViewBag.Style = font.Style;
            ViewBag.Link = font.Link;

            return View(await _context.Locations.SingleOrDefaultAsync(m => m.PortfolioId == id));
        }

        // GET: Locations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            Location location = await _context.Locations.SingleOrDefaultAsync(m => m.IdLocation == id);
            if (location == null)
                return NotFound();

            return View(location);
        }

        // GET: Locations/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdLocation,Street,Latitude,Longitude,PostalCode,Email,PhoneNumber")] Location location)
        {
            if (ModelState.IsValid)
            {
                _context.Add(location);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(location);
        }

        // GET: Locations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            Location location = await _context.Locations.SingleOrDefaultAsync(m => m.IdLocation == id);
            if (location == null)
                return NotFound();

            return View(location);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdLocation,Street,Latitude,Longitude,PostalCode,Email,PhoneNumber")] Location location)
        {
            if (id != location.IdLocation)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(location);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocationExists(location.IdLocation))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }

            return View(location);
        }

        // GET: Locations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            Location location = await _context.Locations.SingleOrDefaultAsync(m => m.IdLocation == id);
            if (location == null)
                return NotFound();

            return View(location);
        }

        // POST: Locations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Location location = await _context.Locations.SingleOrDefaultAsync(m => m.IdLocation == id);
            _context.Locations.Remove(location);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocationExists(int id)
        {
            return _context.Locations.Any(e => e.IdLocation == id);
        }
    }
}
