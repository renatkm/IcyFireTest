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

        public async Task<IActionResult> Lexicon(int? filteredValue)
        {
            IQueryable<Word> words = _context.Words;

            if (filteredValue != null && filteredValue  >0)
            {
                words = words.Where(w => w.Score>0);
            }

            if (filteredValue != null && filteredValue < 0)
            {
                words = words.Where(w => w.Score < 0);
            }

            var viewModel = new FilteredWordModel
            {
                Words = words.ToList(),
                FilteredValue = filteredValue ?? 0
            };

            return View(viewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Word word)
        {
            _context.Words.Add(word);
            await _context.SaveChangesAsync();

            return RedirectToAction("Lexicon");
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                Word? word = await _context.Words.FirstOrDefaultAsync(w => w.Id == id);

                if (word != null)
                {
                    return View(word);
                }
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Word word)
        {
            _context.Words.Update(word);
            await _context.SaveChangesAsync();

            return RedirectToAction("Lexicon");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Word? word = await _context.Words.FirstOrDefaultAsync(w => w.Id == id);
                if (word != null)
                {
                    _context.Words.Remove(word);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Lexicon");
                }
            }

            return NotFound();
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