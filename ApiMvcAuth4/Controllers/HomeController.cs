using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ApiMvcAuth4.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ApiMvcAuth4.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace ApiMvcAuth4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ApplicationDbContext context ,ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        // public IActionResult Privacy()
        // {
        //     return View();
        // }
        
        [Authorize]
        public async Task<IActionResult> Employees()
        {
            var employees = await _context.Employees.ToListAsync();
            return View(employees);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}