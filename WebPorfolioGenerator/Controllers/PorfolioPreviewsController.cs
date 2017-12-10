using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebPorfolioGenerator.DAL;

namespace WebPorfolioGenerator.Controllers
{
    public class PorfolioPreviewsController : Controller
    {
        private readonly WebPortfolioContext _context;

        public PorfolioPreviewsController(WebPortfolioContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> MainPreview(int? id)
        {
            return View(_context.Portfolios.Where(x => x.PortfolioId.Equals(id)));
        }

        public async Task<IActionResult> AboutPreview(int? id)
        {
            return View(_context.Abouts.Where(x => x.PortfolioId.Equals(id)));
        }

        public async Task<IActionResult> PostPreview(int? id)
        {
            return View(_context.Posts.Where(x => x.PortfolioId.Equals(id)));
        }
    }
}