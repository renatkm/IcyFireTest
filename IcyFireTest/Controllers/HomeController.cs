using IcyFireTest.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace IcyFireTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ApplicationContext _context;
        public HomeController(ApplicationContext context, ILogger<HomeController> logger)
        {
            _logger = logger;
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public  async Task<IActionResult> Lexicon()
        {
            return View(await _context.Words.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Word word)
        {
            _context.Words.Add(word);
            await _context.SaveChangesAsync();
            return RedirectToAction("Lexicon");
        }

        public async Task<IActionResult> Update(Word word)
        {
            _context.Words.Add(word);
            await _context.SaveChangesAsync();
            return RedirectToAction("Lexicon");
        }

        public IActionResult Calculation()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}