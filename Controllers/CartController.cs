using Microsoft.AspNetCore.Mvc;
using BookStore.Models;
using BookStore.Data;

namespace BookStore.Controllers
{
    public class CartController : Controller
    {
        // _context is a private field that allows this controller to perform database operations like querying, updating, or saving data
        // can only be assigned once, in the constructor
        private readonly BookStoreContext _context;
        private readonly Cart _cart;
        public CartController(BookStoreContext context, Cart cart)
        {

            /*
             This ensures dependency injection is used to provide an instance
            of BookStoreContext, making the controller easier to test and manage.
             */
            _context = context;

            //_cart is assigned in the constructor using dependency injection
            _cart = cart;
        }
        public IActionResult Index()
        {

            // retrieve all cart items
            var items = _cart.GetAllCartItems();
            // assign the retrieved items back to the cart
            _cart.CartItems = items;
            return View(_cart);
        }


        // adds a book to a cart by its ID
        public IActionResult AddToCart(int id)
        {
            var selectedBook = GetBookId(id);

            if(selectedBook != null)
            {
                _cart.AddToCart(selectedBook, 1);

            }
            return RedirectToAction("Index");
        }

        // gets the book by its id from the database
        public Book GetBookId(int id)
        {
            //LINQ query that returns the first book it gets by id, if nothing mathes it returns null
            return _context.Books.FirstOrDefault(b => b.Id == id);
        }

    }
}
