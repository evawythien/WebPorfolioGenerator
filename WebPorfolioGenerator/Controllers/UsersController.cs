using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebPorfolioGenerator.DAL;
using WebPorfolioGenerator.Models;

namespace WebPorfolioGenerator.Controllers
{
    public class UsersController : Controller
    {
        private readonly WebPortfolioContext _context;

        public UsersController(WebPortfolioContext context)
        {
            _context = context;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            int userRol = _context.Users.Where(u => u.UserId.Equals(userId)).Select(u => u.RolId).FirstOrDefault();
            List<User> model = new List<User>();

            switch (userRol)
            {
                case 1:
                    model = await _context.Users.ToListAsync();
                    break;
                case 2:
                    model = await _context.Users.Where(u => u.RolId == 2 || u.RolId == 4).ToListAsync();
                    break;
                case 3:
                    model = await _context.Users.Where(u => u.RolId == 2 || u.RolId == 3 || u.RolId == 4).ToListAsync();
                    break;
                case 4:
                    model = await _context.Users.Where(u => u.UserId.Equals(userId)).ToListAsync();
                    break;
            }

            return View(model);
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            User user = await _context.Users.SingleOrDefaultAsync(m => m.UserId == id);
            if (user == null)
                return NotFound();

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            ViewBag.Rols = _context.Rols.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,UserName,Name,Surname,Password,RolId,Email,Birth,MovilePhone,Phone")] User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { id = user.UserId });
            }
            return View(user);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            User user = await _context.Users.SingleOrDefaultAsync(m => m.UserId == id);
            if (user == null)
                return NotFound();

            ViewBag.Rols = _context.Rols.ToList();

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,UserName,Name,Surname,Password,RolId,Email,Birth,MovilePhone,Phone")] User user)
        {
            if (id != user.UserId)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.UserId))
                        return NotFound();
                    else
                        throw;
                }

                return RedirectToAction(nameof(Index), new { id = id });
            }

            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            User user = await _context.Users.SingleOrDefaultAsync(m => m.UserId == id);
            if (user == null)
                return NotFound();

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            User user = await _context.Users.SingleOrDefaultAsync(m => m.UserId == id);
            _context.Users.Remove(user);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }
    }
}