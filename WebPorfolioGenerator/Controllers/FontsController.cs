using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebPorfolioGenerator.Data.DAL;
using WebPortfolioGenerator.Domain.Entity;

namespace WebPorfolioGenerator.Controllers
{
    public class FontsController : Controller
    {
        private readonly WebPortfolioContext _context;

        public FontsController(WebPortfolioContext context)
        {
            _context = context;
        }

        // GET: Fonts
        public async Task<IActionResult> Index()
        {
            return View(await _context.Fonts.ToListAsync());
        }

        // GET: Fonts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            Font font = await _context.Fonts.SingleOrDefaultAsync(m => m.Id == id);
            if (font == null)
                return NotFound();

            return View(font);
        }

        // GET: Fonts/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FontName,Link,FontFamily,Style")] Font font)
        {
            if (ModelState.IsValid)
            {
                _context.Add(font);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(font);
        }

        // GET: Fonts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            Font font = await _context.Fonts.SingleOrDefaultAsync(m => m.Id == id);
            if (font == null)
                return NotFound();

            return View(font);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FontName,Link,FontFamily,Style")] Font font)
        {
            if (id != font.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(font);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FontExists(font.Id))
                        return NotFound();
                    else
                        throw;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(font);
        }

        // GET: Fonts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            Font font = await _context.Fonts.SingleOrDefaultAsync(m => m.Id == id);
            if (font == null)
                return NotFound();


            return View(font);
        }

        // POST: Fonts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Font font = await _context.Fonts.SingleOrDefaultAsync(m => m.Id == id);
            _context.Fonts.Remove(font);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FontExists(int id)
        {
            return _context.Fonts.Any(e => e.Id == id);
        }

        public List<KeyValuePair<int, string>> GetFontList()
        {
            List<Font> font = _context.Fonts.ToList();

            List<KeyValuePair<int, string>> newList = new List<KeyValuePair<int, string>>();
            {
                font.ForEach(f =>
                {
                    newList.Add(new KeyValuePair<int, string>(f.Id, f.FontName));
                });
            }

            return newList;
        }

    }
}
