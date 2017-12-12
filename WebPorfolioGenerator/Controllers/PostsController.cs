using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebPorfolioGenerator.DAL;
using WebPorfolioGenerator.Models;

namespace WebPorfolioGenerator.Controllers
{
    public class PostsController : Controller
    {
        private readonly WebPortfolioContext _context;

        public PostsController(WebPortfolioContext context)
        {
            _context = context;
        }

        // GET: Posts
        public async Task<IActionResult> Index(int? id)
        {
            return View(await _context.Posts.Where(p => p.PortfolioId.Equals(id)).ToListAsync());
        }

        public async Task<IActionResult> Preview(int? id)
        {
            if (id == null)
                return NotFound();

            var portfolio = await _context.Portfolios.SingleOrDefaultAsync(p => p.PortfolioId.Equals(id));
            var font = await _context.Fonts.SingleOrDefaultAsync(p => p.Id.Equals(portfolio.FontId));

            ViewBag.FirstColor = portfolio.FirstColor;
            ViewBag.SecondColor = portfolio.SecondColor;
            ViewBag.FontName = font.FontName;
            ViewBag.FontFamily = font.FontFamily;
            ViewBag.Style = font.Style;
            ViewBag.Link = font.Link;

            return View(_context.Posts.Where(p => p.PortfolioId.Equals(id)).ToList());
        }

        // GET: Posts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Posts.SingleOrDefaultAsync(m => m.PostId == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // GET: Posts/Create
        public IActionResult Create(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            return View(); 
        }

        // POST: Posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PostId,PortfolioId,Title,Subtitle,Body,CreationDate,ModificationDate")] Post post)
        {
            if (ModelState.IsValid)
            {
                _context.Add(post);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { id = post.PortfolioId});
            }
            return View(post);
        }

        // GET: Posts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Posts.SingleOrDefaultAsync(m => m.PostId == id);
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PostId,PortfolioId,Title,Subtitle,Body,CreationDate,ModificationDate")] Post post)
        {
            if (id != post.PostId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(post);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostExists(post.PostId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { id = post.PortfolioId });
            }
            return View(post);
        }

        // GET: Posts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Posts.SingleOrDefaultAsync(m => m.PostId == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var post = await _context.Posts.SingleOrDefaultAsync(m => m.PostId == id);
            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostExists(int id)
        {
            return _context.Posts.Any(e => e.PostId == id);
        }
    }
}
