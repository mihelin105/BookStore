using BookStore.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace BookStore.Controllers
{
    
    public class StoreController : Controller
    {
        private readonly BookStoreContext context;

        public StoreController(BookStoreContext context)
        {
            this.context = context;
        }

        
        public async Task<IActionResult> Index(string searchString, string minPrice, string maxPrice)
        {
            var books = context.Books.Select(b => b);

            if(!string.IsNullOrEmpty(searchString) ) {
                books = books.Where(b => b.Title.Contains(searchString) || b.Author.Contains(searchString));
            }

            // handles the parsing for max value

            if (!string.IsNullOrEmpty(minPrice) && int.TryParse(minPrice, out int min))
            {
                books = books.Where(b => b.Price >= min);
            }

            if (!string.IsNullOrEmpty(maxPrice) && int.TryParse(maxPrice, out int max))
            {
                books = books.Where(b => b.Price <= max);
            }

			return View(await books.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await context.Books
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }


    }
}
