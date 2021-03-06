﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebPorfolioGenerator.DAL;
using WebPorfolioGenerator.Models;

namespace WebPorfolioGenerator.Controllers
{
    public class HomeController : Controller
    {
        private readonly WebPortfolioContext _context;

        public HomeController(WebPortfolioContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            ViewData["Message"] = "Login";
            return View();
        }

        [HttpPost, ActionName("Login")]
        public async Task<IActionResult> Login(User user)
        {
            Boolean exits = _context.Users.Any(e => e.UserName.Equals(user.UserName) && e.Password.Equals(user.Password));
            if (exits)
            {
                int id = _context.Users.Where(x => x.UserName.Equals(user.UserName)).Select(x => x.UserId).FirstOrDefault();
                HttpContext.Session.SetInt32("UserId", id);
                return RedirectToAction(nameof(UsersController.Index), "Users");
            }
            else
                ViewData["Incorrecto"] = "Something incorrect";

            return View();
        }

        public IActionResult Index()
        {
            ViewData["Message"] = "Login";
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";
            return View();
        }

        public IActionResult UserList()
        {
            ViewData["Message"] = "UserList";
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult ChoosePortfolio()
        {
            ViewData["Message"] = "ChoosePortfolio";
            return View();
        }

    }
}
